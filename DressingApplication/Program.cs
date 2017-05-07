using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressingApplication
{
    //<summary>This is main class from where application starts.</summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ans;
                do
                {
                    Console.WriteLine("Input temperature type ('Hot' or 'Cold', no case sensitive.) in first line and \nlist of commands separated by comma in next line.");
                    Console.WriteLine();
                    string tempType = Console.ReadLine().Trim().ToUpper();
                    string[] arr_temp = Console.ReadLine().Split(',');
                    int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------Output---------------------------------------");
                    Console.WriteLine();                    
                    IHelper helper = new Helper();
                    Dictionary<int, string> processedCommands = helper.ProcessCommands(tempType, arr);
                    string result = "";
                    foreach (var item in processedCommands)
                    {
                        result += item.Value + ",";
                    }
                    Console.WriteLine("Output:"+result.Remove(result.Length - 1));
                    Console.WriteLine();
                    Console.WriteLine("Do you want to continue(Y/N)...");
                    ans = Console.ReadLine().Trim().ToUpper();
                } while (ans == "Y");
            }
            catch
            {
                Console.WriteLine("Some Error has been occured!");
                Console.ReadLine();
            }
            
        }
    }
}
