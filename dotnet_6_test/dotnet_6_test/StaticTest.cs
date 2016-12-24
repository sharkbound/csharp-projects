using System;

namespace dotnet_6_test.StaticTest
{
    public class StaticTest
    {
        public static void LogString(string msg)
        {
            Console.WriteLine($"Message from Log: {msg}");
        }

        public static void LogObj(object obj)
        {
            Console.WriteLine($"Message from Log: {obj}");
        }
    }
}
