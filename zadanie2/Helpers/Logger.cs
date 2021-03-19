using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia2.Helpers
{
    class Logger
    {
        string logPath;
        string jsonPath;

        public Logger(string logPath, string jsonPath)
        {
            this.logPath = logPath;
            this.jsonPath = jsonPath;
            this.CreateDirectory();
            this.CreateFile(jsonPath);
            this.CreateFile(logPath);
        }

        public void Log(string text)
        {

            using (StreamWriter w = File.AppendText(this.logPath))
            {
                w.WriteLine(text);
                w.Close();
            }
          

        }

        public string path
        {
            get 
            {
                return this.logPath; 
            }
        }

        public string json
        {
            get 
            { 
                return this.jsonPath; 
            }
        }

        public void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists("output"))
                {
                    Directory.CreateDirectory("output");
                    Console.WriteLine("directory created");
                }

            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateFile(string path)
        {
            try
            {

                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                    Console.WriteLine("file created");
                }

                else
                {
                    File.Delete(path);
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                this.Log($"File {path} not found");
            }
        }

        public void WriteJson(string text)
        {
            
            using (var sw = new StreamWriter(this.jsonPath, false, Encoding.UTF8))
            {
                sw.WriteLine(text);
                sw.Close();
            }


        }

    }
}
