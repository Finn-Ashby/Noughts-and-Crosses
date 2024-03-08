using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = "C:/Users/finni/source/repos/Naughts and Crosses/Naughts and Crosses/bin/Debug/Settings/Settings.csv";

            //Download and read all Texts within the uploaded Text file.  
            string csvContentStr = File.ReadAllText(csvPath);
            List<List<string>> Settings = new List<List<string>>();
            List<string> singleList = new List<string>();
            string newString = null;
            string[] splitted = csvContentStr.Split('\n');

            
            bool flag = true;
            foreach (char character in csvContentStr)
            {
                
                if (character == ',')
                {
                    singleList.Add(newString);
                    newString = null;
                }
                else if (character == '\n')
                {
                    singleList.Add(newString);
                    Settings.Add(singleList);
                    singleList = new List<string>();
                    newString = null;
                }
                else newString += character;
            }
            Settings.Add(singleList);
            for(int i = 0; i < Settings.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    
                    
                }
            }
            Console.WriteLine(Settings[0][3]);
            
            
        }
    }
}
