using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationQuery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12347"))
            {
                Console.WriteLine("http://localhost:12347");
                Console.WriteLine("Commercial Application Query Server is running .");
                Console.WriteLine("Press any key to continue .");
                Console.ReadLine();
            }
        }
    }
}
