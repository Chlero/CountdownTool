using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 时间计算 //Verson 3.2
{
    internal class Program
    {
        static int num = 0;
        static bool useList = false;
        static DateTime Now;
        static string ProcessingSecond(long se)
        {
            int sum = 1;
            string useSecond = se.ToString();
            for (int i = useSecond.Length - 1; i > 0; i--)
            {
                if (sum == 4)
                {
                    useSecond = useSecond.Insert(i, " ");
                    sum = 0;
                }
                sum++;
            }
            return useSecond;
        }
        static void Print(string name, DateTime time)
        {
            long lastSecond = (long)new TimeSpan(time.Ticks - Now.Ticks).TotalSeconds;
            long useDay = (long)new TimeSpan(time.Ticks - Now.Ticks).TotalDays;
            if (useDay < 0) return;

            string useSecond = ProcessingSecond(lastSecond);
            if (useDay <= 31)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("从现在开始到" + name + "只剩" + useDay + "天，也就是" + useSecond + "秒");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else Console.WriteLine("从现在开始到" + name + "还剩" + useDay + "天，也就是" + useSecond + "秒");
        }
        static void PrintList(string name)
        {
            num++;
            Console.WriteLine(num + "." + name);
        }
        static void Main()
        {
            Console.Title = "时间程序";
            Console.CursorVisible = false;
            DateTime dt1 = new DateTime(2023, 9, 16, 9, 30, 00);
            DateTime dt2 = new DateTime(2026, 6, 17, 0, 00, 00);
            DateTime dt3 = new DateTime(2029, 6, 7, 0, 00, 00);
            while (true)
            {
                Now = DateTime.Now;
                Print("SCP-J考试", dt1);
                Print("中考", dt2);
                Print("高考", dt3);
                if (useList)
                {
                    Console.WriteLine("\n\n目标清单：");
                    PrintList("try open ai Chat GPT");
                    PrintList("Azure open ai in 小幻助手");
                    PrintList("SO-VITS 重新训练模型");
                }
                num = 0;
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}