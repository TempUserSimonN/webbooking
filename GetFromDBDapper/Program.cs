using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFromDBDapper
{
    class Program
    {
        //this is for test
        static void Main(string[] args)
        {
            //RunTest();
            Console.Title = "GetWordFromDB Server";
            //new Server();
            RunTest();
            Console.WriteLine("press Enter To Close Server");
            Console.ReadLine();
        }

        private static void RunTest()
        {
            Console.WriteLine("Doing Test");
            Console.WriteLine("Type A Word To get its Id");
            Console.WriteLine("User Id = " + DBCaller.GetUser(0).id);
            Console.WriteLine("Test is over");
            Console.ReadLine();
        }
    }
}
