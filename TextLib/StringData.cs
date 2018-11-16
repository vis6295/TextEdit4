using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLib
{
    static class StringData
    {
        static string[] data;
        static StringData() {
            data = File.ReadAllLines("data.txt");
        }

        public static string GetString(int num) {
            if (num < data.Length) return data[num];
            return null;
        }
    }
}
