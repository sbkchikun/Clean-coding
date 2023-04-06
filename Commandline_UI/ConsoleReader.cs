﻿using System;

namespace CommandLineUI
{
    class ConsoleReader
    {
        public static int ReadInt(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public static double ReadDouble(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt + ": > ");
            return Console.ReadLine();
        }
    }
}
