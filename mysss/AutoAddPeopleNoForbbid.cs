using mysss.tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using xcontrol.core.Helper;
using System.ComponentModel;

namespace mysss
{
    public class AutoAddPeopleNoForbbid : AndroidControlSDK.AndroidScript
    {
        //私有变量
        //存储插件用户的配置信息
        /// <summary>
        /// 一小时的毫秒数
        /// </summary>
        private static int oneHour;
        /// <summary>
        /// 等一个小时要达到的人数
        /// </summary>
        private static int waitOneHourNum;
        /// <summary>
        /// 等一天要达到的人数
        /// </summary>
        private static int waitOneDayNum;
        /// <summary>
        /// 验证信息
        /// </summary>
        private static string validateContext;

        //微信号列表所在的文件
        private static string fileName;   //要读取的文件名

        //快照名称列表(假设每个设备，都是按照统一的规律，来对快照进行设置的)
        public static List<string> lQArr;

        //临界资源 
        private static IList<string> wxItems;

        //加下一个好友的随机停顿范围
        private static int minWait;//最小值
        private static int maxWait;//最大值

        //已加好友的人数
        private static int addedNum = 0;

        //微信号总数
        private static int totalWxItem;

        //将每个线程，加好友的情况，以一个列表的形式，显示出来
        public static BindingList<CurrentPhoneInfo> AddedPhoneList = new BindingList<CurrentPhoneInfo>();

        //是否显示窗体
        private static bool isShowMainForm = false;//控制初始参数窗体
        private static bool isShowInfoForm = false;//控制好友添加信息窗体

        //好友添加信息窗体(因为每个线程都要传递一个值给它，所以它应当是静态的)
        private static InfoPanelForm frmInfo;

        //定义一个事件用于传递参数给私有窗体
        public static AddedTotalNumEventArgs allArgs = new AddedTotalNumEventArgs() {AddedNum = "0",AddedPercent = "0.00%",NoAddedNum="0" };
        public event EventHandler<AddedTotalNumEventArgs> ModifyAddedNum;    //后面将会定义一个方法 将数据传递给窗口

        private static Object myObject = new object();

        //返回 插件描述
        public override string Description()
        {
            return "自动微信加人，并且不被封号";
        }

        //返回 插件名称
        public override string Name()
        {
            return "模拟人工加微信";
        }

        //插件的功能主体
        public override void RunScript()
        {
            //当前线程用于运行控制台
            //加载配置文件中的配置信息,以及启动主控制面板
            lock (myObject)
            {
                if (!isShowMainForm)//初始参数窗体
                {
                    //下次不让它进来
                    isShowMainForm = true;
                    //窗体的作用，仅在于初始化
                    AppSetting frm_aps = new AppSetting();
                    frm_aps.loadAppSettingEvent += loadAppSettings;
                    frm_aps.ShowDialog();
                }

                //只能有一个信息窗口显示
                if (!isShowInfoForm)
                {
                    isShowInfoForm = true;
                    //在第一次使用时，构造
                    frmInfo = new InfoPanelForm();

                    //把当前窗体的引用 传递给 通知面板窗体
                    frmInfo.mcfEvent += transToOtherWindows;

                    //通知面板窗体，设置自己的引用
                    frmInfo.setMainClass();

                    //把通知面板的ShowDialog放在 另外启动的一个线程中
                    Task.Run(()=> {
                        frmInfo.ShowDialog();
                    });

                    //传递要加的好友的总数
                    allArgs.AddedTotalNum = totalWxItem.ToString();

                    //更新 通知面板窗体上面的数据
                    this.modifyAddedNum(allArgs);
                }
            }

            //执行核心部分
            Doing();
        }

        private void Doing()
        {
            //判断，是否存在微信号
            if (wxItems == null || wxItems.Count < 1)
            {
                //System.Windows.Forms.MessageBox.Show("txt文件数据异常，确保其正常之后，再运行本插件……");
                return;  //结束插件运行
            }
            //当前手机的信息
            string thisPhoneName = AndroidHelper.AndroidControls[Key].AndroidAModel.group + " " + AndroidHelper.AndroidControls[Key].AndroidAModel.description;

            //当前微信号 已添加好友人数(微信号数量) （这样每个微信号，各自持有一个 自己的 变量）
            ThreadLocal<int> addedNumLocal = new ThreadLocal<int>();
            addedNumLocal.Value = 0;

            //当前微信号，已加好友的轮数
            ThreadLocal<int> addedCircleNum = new ThreadLocal<int>();
            addedCircleNum.Value = 0;

            //本地变量  本机微信加好友的状态
            ThreadLocal<CurrentPhoneInfo> currentPhoneInfo = new ThreadLocal<CurrentPhoneInfo>();
            //ThreadLocal中的引用对象，应当初始化一下的。
            currentPhoneInfo.Value = new CurrentPhoneInfo();
            //初始化 当前微信号的状态信息
            currentPhoneInfo.Value.CurrentThreadID = Thread.CurrentThread.ManagedThreadId;
            currentPhoneInfo.Value.PhoneName = thisPhoneName;
            currentPhoneInfo.Value.AddedNum = addedNumLocal.Value;
            currentPhoneInfo.Value.CircleNum = 1;
            currentPhoneInfo.Value.State = "正在执行……";

            //将当前微信号的状态 放入Map中
            AddedPhoneList.Add(currentPhoneInfo.Value);
            //本地变量 插槽中，快照名称  --从类的静态属性中获取 一方面 不更改类的静态属性，一方面 复制了一份自己的副本（方便遍历使用）
            ThreadLocal<List<string>> lQArrl = new ThreadLocal<List<string>>();
            lQArrl.Value = lQArr; //字符串数组，可以构建字符串列表

            string item = ""; // 单个微信号信息
            while (true) //永真循环，意味着插件一直在运行。
            {
                addedNumLocal.Value++;     //累加
                //立刻更新 状态信息
                currentPhoneInfo.Value.AddedNum = addedNumLocal.Value;

                //ShowStatus("加" + waitOneHourNum + "个，停1小时，加" + waitOneDayNum + "个，停一天");
                //Thread.Sleep(2000);

                lock (wxItems)  //锁定 wxItems临界资源 防止 多个微信号 添加同一个 人 为好友。
                {
                    try
                    {
                        item = wxItems[0];
                        wxItems.Remove(item); //立刻 移除已经添加过的元素 (不用担心，这里移除了，就会永远消失，因为，如果添加失败，还是会写回的)
                        //更新 通知窗口面板 上面的显示  ---1 让 面板上的信息更加及时
                        this.modifyAddedNum(allArgs);
                    }
                    catch (Exception)
                    {
                        ShowStatus("加载的 手机号已经使用完！,点击确定，终止当前线程……");
                        //更新 通知窗口面板 上面的显示  ---2 让 面板上的信息更加及时
                        this.modifyAddedNum(allArgs);
                        currentPhoneInfo.Value.State = "……运行结束";
                        return;
                    }
                }

                bool flag = true;
                //System.Windows.Forms.MessageBox.Show("加好友开始…… and flag = "+flag);
                addWXFriend(item,ref flag,currentPhoneInfo);// 利用 根据item的值，添加微信好友
                //System.Windows.Forms.MessageBox.Show("加好友结束…… and flag = " + flag);
                //每次加好友之后，随机停顿一定的时间
                int stopTime = getRandomWaitTime();
                ShowStatus("加下一个好友，停顿" + stopTime / 1000 + "秒");
                Thread.Sleep(stopTime);
                if (flag)
                {
                    addedNum++;
                    //更新主面板上面显示的信息
                    allArgs.AddedNum = addedNum.ToString();        //已添加的微信好友数
                    allArgs.NoAddedNum = (totalWxItem - addedNum).ToString();   //未添加的好友数
                    allArgs.AddedPercent = ((double)addedNum / (double)totalWxItem).ToString("p");

                    //更新 通知窗口面板 上面的显示
                    this.modifyAddedNum(allArgs); 
                    //System.Windows.Forms.MessageBox.Show("添加完一个好友之后，立刻把剩余的数据写回。。。");
                    //根据配置信息，控制加好友的人数以及停顿
                    if ((((addedNumLocal.Value - 1) % waitOneHourNum) + 1) >= waitOneHourNum)//如果达到 要等待一个小时的人数
                    {
                        ShowStatus("已达到停一个小时的条件");
                        Thread.Sleep(2000);

                        ShowStatus("进入 停止一小时，再进行添加好友的状态！ 已加好友" + addedNumLocal.Value + "个");
                        Thread.Sleep(oneHour);

                        //如果已经达到了限定的轮数  就终止当前线程的运行
                        if (++addedCircleNum.Value >= waitOneDayNum)
                        {
                            currentPhoneInfo.Value.State = "……运行结束";

                            if (lQArrl.Value != null && lQArrl.Value.Count> 0)  //加“&& lQArrl.Value.Count> 0”，是为了在下一次执行到这里的时候，程序能够执行到else中
                            {
                                while (lQArrl.Value.Count > 0)
                                {
                                    System.Windows.Forms.MessageBox.Show(lQArrl.Value[0]);
                                    //加载快照（快照加载的函数，没有返回任何状态信息）
                                    AndroidHelper.WeixinRestore(lQArrl.Value[0], new List<string>() { Key });

                                    lQArrl.Value.Remove(lQArrl.Value[0]);//移除 第一个元素

                                    ShowStatus("等待十秒时间，待新的快照加载");
                                    Thread.Sleep(14000);//等待十秒时间，待新的快照加载

                                    //加载若成功 则 重置 当前已执行轮数 并 让程序继续执行（这一步，该如何判断呢？）
                                    if (IsLoadRight())
                                    {
                                        //重置轮数
                                        addedCircleNum.Value = 0;
                                        //初始化 当前微信号的状态信息
                                        currentPhoneInfo.Value.AddedNum = 0;
                                        currentPhoneInfo.Value.CircleNum = 1;
                                        currentPhoneInfo.Value.State = "正在执行……";
                                        break;
                                    }
                                }
                            }
                            else //在进到 终止判断的前提下
                              return;
                        }
                        else
                        {
                            currentPhoneInfo.Value.CircleNum = addedCircleNum.Value+1;
                        }
                    }//if
                }//if

            }//while

        }//Doing

        /// <summary>
        /// 判断 是否加载到可加好友的状态
        /// </summary>
        /// <returns></returns>
        private bool IsLoadRight()
        {
            List<string> isInRight = GetUiTexts("登录.*");
            if (isInRight.Count>0)
                return false;
            return true;
        }

        private void writeBackToTxt()
        {
            ShowStatus("正在写回剩余的手机号。。。。。。。。");
            lock (wxItems)      //需要在写回文件的时候加锁
            {
                StreamWriter sw = new StreamWriter(File.Create(fileName));      //重新创建，直接覆盖原有的文件
                foreach (string ii in wxItems)
                {
                    sw.WriteLine(ii);
                }
                sw.Flush();
                //关闭流
                sw.Close();
            }

            ShowStatus("已写回完成。。。。。。。。");
            Thread.Sleep(2000);
        }

        //返回一个 随机的 秒数
        private int getRandomWaitTime()
        {
            return new Random().Next(minWait,maxWait) * 1000;
        }

        /// <summary>
        /// 加载配置文件中的配置信息
        /// </summary>
        /// <param name="oneHour">等待一小时的毫秒数</param>
        /// <param name="oneDay">等待一天的毫秒数</param>
        /// <param name="waitOneDayNum">停顿一小时，不加人的人数</param>
        /// <param name="waitOneHourNum">停顿一天，不加人的人数</param>
        /// <param name="validateContext">加好友时，验证信息的内容</param>
        /// <param name="fileNamei">文件名</param>
        /// <param name="hasLoadRight">是否加载到了手机号</param>
        /// <param name="minWaiti">等待随机值的下限</param>
        /// <param name="maxWaiti">等待随机值的上限</param>
        private void loadAppSettings(int oneHouri,int waitOneDayNumi,int waitOneHourNumi, string validateContexti,string fileNamei,out bool hasLoadRight,int minWaiti,int maxWaiti,List<string> lQArri)
        {
            oneHour = oneHouri;
            waitOneDayNum = waitOneDayNumi;
            waitOneHourNum = waitOneHourNumi;
            validateContext = validateContexti;

            minWait = minWaiti;
            maxWait = maxWaiti;
            lQArr = lQArri;

            //判断是否正确加载了txt文件中的信息
            fileName = fileNamei;
            wxItems = FileInputAndGetList.getWeiXinIDItem(fileName);  //微信号单项
            //判断，是否存在微信号
            if (wxItems == null || wxItems.Count < 1)
            {
                ShowStatus("所选文件中的内容为空！");
                Thread.Sleep(5000);
                hasLoadRight = false;
            }
            else
            {
                //如果确实加载到了微信号，就返回true
                hasLoadRight = true;

                //所有的手机号数量
                totalWxItem = wxItems.Count;
            }
        }

        /// <summary>
        /// 添加微信好友
        /// </summary>
        /// <param name="item">微信好友的ID</param>
        private void addWXFriend(string item,ref bool flag, ThreadLocal<CurrentPhoneInfo> currentPhoneInfo)
        {
            //打开搜索好友界面
            ShowStatus("打开搜索好友界面");
            Thread.Sleep(4000);//停顿四秒

            var dic = new Dictionary<string, string> { { "act", "searchui" } };
            string result = SendIntent(dic);

            while (result == "false")
            {
                if (result == "false")
                {
                    if (System.Windows.Forms.MessageBox.Show("请确保微信处于正常的运行状态!(如果继续，请点击OK，不继续，则点击Cancle)" + "\n来自手机： " + AndroidHelper.AndroidControls[Key].AndroidAModel.description + "  " + AndroidHelper.AndroidControls[Key].AndroidAModel.group, "打开搜索好友界面失败!\n", System.Windows.Forms.MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        ShowStatus("继续尝试打开 搜索好友界面……");
                        Thread.Sleep(1000); //停顿一秒
                        result = SendIntent(dic);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("插件将结束运行……"+ "\n来自手机： " + AndroidHelper.AndroidControls[Key].AndroidAModel.description + "  " + AndroidHelper.AndroidControls[Key].AndroidAModel.group);
                        //不加好友，就退出
                        flag = false;
                        //搜索好友也出问题了，就把当前手机号，立即写回
                        wxItems.Add(item);
                        writeBackToTxt();
                        return;
                    }
                }
            }

            Thread.Sleep(4000); //停顿四秒

            //在查找输入框中 填入 手机号 或是 微信号
            ShowStatus(FindAndInutText("android.widget.EditText", item, 0)+ "  等待四秒，待搜索结果展示出来");    //0,是选中第一个搜索到的结果
            //System.Windows.Forms.MessageBox.Show("输入的手机号是"+item);

            Thread.Sleep(6000);//等待六秒，待搜索结果展示出来

            ShowStatus("点击匹配的第一个结果  "+ FindAndCLickObjByRegex("(查找手机/QQ号.*|查找微信号.*)"));
            //给两秒时间，用于弹出 那个操作频繁框。 即使是，没有弹出，也点一下 确定，不会有 影响的。 因为这时 界面上 应该不会有 其他确定的 按钮
            Thread.Sleep(2000);
            //这里有一种， 操作频繁的情况， 会弹出一个框
            List<string> isInRight = GetUiTexts("操作过于频繁.*");

            if (isInRight.Count>0)     //如果确实，提示操作频繁。 那么   这个时候，  当前手机号的资源不能被浪费，也要及时终止 就像 添加到通讯录 点击失败那样
            {
                System.Windows.Forms.MessageBox.Show("现在操作过于频繁…………（手机号将会写回，不会浪费……）"+ "\n来自手机： " + AndroidHelper.AndroidControls[Key].AndroidAModel.description + "  " + AndroidHelper.AndroidControls[Key].AndroidAModel.group);

                //点击操作频繁的上面的那个确定按钮
                FindAndCLickObj("确定");

                flag = false;

                wxItems.Add(item); 
                writeBackToTxt();
                return;
            }
            Thread.Sleep(6000);

            //点击 添加到 通讯录按钮
            string tianjiaRet = FindAndCLickObjByRegex("添加到通讯录");
            ShowStatus("点击............添加到通讯录.......11221122 "+ tianjiaRet);
            Thread.Sleep(4000);

            //如果按钮点击成功
            if (tianjiaRet.Contains("true"))
            {
                ShowStatus("找到文本框，进行输入。。"+FindAndInutText("android.widget.EditText", validateContext, 0));
                Thread.Sleep(4000);
                
                string ret = FindAndCLickObjByRegex("(加为朋友|发送)");
                ShowStatus(ret);
                Thread.Sleep(4000);

                //如果发送按钮点击失败，就置flag为false，以及发出提示，是不是网络问题。
                if (ret == "false")
                {
                    flag = false;
                    //发送按钮 点击失败，也立即写回当前的手机号
                    wxItems.Add(item);
                    writeBackToTxt();
                    System.Windows.Forms.MessageBox.Show("发送按钮点击失败，查看一下，是不是网络问题……"+ "\n来自手机： " + AndroidHelper.AndroidControls[Key].AndroidAModel.description + "  " + AndroidHelper.AndroidControls[Key].AndroidAModel.group);
                }
                Thread.Sleep(3000);//停顿3秒
            }
            else
            {
                //点击弹出框的确认按钮  顺便判断，是网络的原因，还是用户不存在（如果 是网络的原因， 在点击查找好友之后，会停顿较长的一段时间。后面的点击 添加到通讯录，会和用户不存在的情况相同，区别在于，是否弹出用户不存在的提示框 提示框上面是有一个确定按钮的）
                string pressResult = FindAndCLickObj("确定");
                if (!pressResult.Contains("true"))//如果 确定按钮没有点击成功，证明是 网络的问题  flag 要为 false  不能删除这个手机号
                {
                    flag = false;
                    //没有添加成功，就立即写回
                    wxItems.Add(item);
                    writeBackToTxt();
                    if (System.Windows.Forms.MessageBox.Show("请检查本机的网络设置……，\n是否选择停止本机上脚本的运行(Yes/No)："+ "\n来自手机： " + AndroidHelper.AndroidControls[Key].AndroidAModel.description + "  " + AndroidHelper.AndroidControls[Key].AndroidAModel.group, "错误", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        currentPhoneInfo.Value.State = "……运行结束";
                        Thread.CurrentThread.Abort();  //终止当前机器的脚本运行
                    }
                }
                else
                {
                    ShowStatus("该用户不存在！");
                }
                
                Thread.Sleep(2000);
            }

            //不重复写入
            if (flag)
            {
                //将剩余的项，写回txt文件
                writeBackToTxt();
            }
        }

        //将当前类的引用传递给 通知窗口
        private void transToOtherWindows(ref AutoAddPeopleNoForbbid foo,ref BindingList<CurrentPhoneInfo> addedPhoneList) {
            foo = this;
            addedPhoneList = AddedPhoneList;
        }

        //传递一个 本地的数据给窗体
        public void modifyAddedNum(AddedTotalNumEventArgs data) {
            ModifyAddedNum?.Invoke(this,data);
        }
    };
}
