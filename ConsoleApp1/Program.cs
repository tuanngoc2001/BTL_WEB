using System;
using Web.Common.Utils;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Util.GetConfig("ConnectionStrings:MyDb"));
        }
    }
}
