using System;
using System.Collections.Generic;
using System.Text;

namespace BookMannage
{
    public class FileHelper
    {
        public String SavaProcess(string data)
        {
            String FilePath = "I:\\c#项目\\BookMannage\\BookMannage\\BookFile.txt";
            //文件覆盖方式添加内容
            System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath, false);
            //保存数据到文件
            file.Write(data);

            file.Close();
            file.Dispose();

            return FilePath;
        }

        public string FileToString(String filePath)
        {
            string strData = "";
            try
            {
                string line;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        strData = line;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return strData;
        }
    }
}
