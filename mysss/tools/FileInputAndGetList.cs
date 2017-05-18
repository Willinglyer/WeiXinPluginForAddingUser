using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysss.tools
{
    public class FileInputAndGetList
    {
        //读取txt文档中 每行的数据，每行作为一个String类型的元素，存储在List中。
       internal static IList<string> getWeiXinIDItem(string filePath)
        {
            //List结果集
            IList<string> resultList = new List<string>();
            //文件读取流
            StreamReader sr;
            try
            {
                sr = File.OpenText(filePath);
            }
            catch
            {
                Console.WriteLine("文件打开失败！");
                return null;// 返回空值
            }

            while (sr.Peek()!=-1)  //如果还没有到达文件结尾
            {
                //避免读入空白行值
                string item = sr.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    resultList.Add(item); //将读取到的行，放入List中 
                }
            }
            return resultList;
        }
    }
}