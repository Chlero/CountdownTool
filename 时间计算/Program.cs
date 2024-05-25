using System;
using System.Threading;
using System.IO;
using System.Text;

namespace 时间计算
{
    internal class Program
    {
        static int num = 0;
        static bool useList = false;
        static DateTime Now;
        const int MAXLEN = 114514;
        static string[] Str = new string[MAXLEN];
        static DateTime[] dt = new DateTime[MAXLEN];
        static StreamReader str = new StreamReader("C:\\ProgramData\\CountdownTool-config.txt");
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
            Console.Title = "时间计算";
            Console.CursorVisible = false;

            string line; int tot = 0;
            line = str.ReadLine();
            while (line != null)
            {
                string[] words = line.Split('#');
                Str[++tot] = words[0];
                dt[tot] = DateTime.ParseExact(words[1], "yyyy-MM-dd-HH-mm-ss", System.Globalization.CultureInfo.CurrentCulture);
                line = str.ReadLine();
            }
            while (true)
            {
                Now = DateTime.Now;
                for (int i = 1; i <= tot; i++)
                    Print(Str[i], dt[i]);
                if (useList)
                {
                    Console.WriteLine("\n\n目标清单:\n");
                    //暂时废弃
                }
                num = 0;
                Thread.Sleep(850);
                Console.Clear();
            }
        }
    }
}