using System;
using System.IO;

namespace GainChangerSpecFlow
{
    public static class WriteJsonFile
    {
        static string RootDirectoryPath
        {
            get
            {
                if (Directory.GetCurrentDirectory().ToString().Contains(@"\bin\Debug"))
                {
                    return Directory.GetCurrentDirectory().ToString().Replace(@"\bin\Debug", "");
                }
                else
                {
                    return Directory.GetCurrentDirectory().ToString();
                }
            }
        }
        public static void WriteToFile(string message)
        {
            string path = RootDirectoryPath + @"\json-files\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            string filepath = path + @"\JsonFile_" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".json";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}
