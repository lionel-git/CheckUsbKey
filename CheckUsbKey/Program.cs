using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace CheckUsbKey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Syntaxe: <path> <count>");
            string path = @"f:\";
            int count = 1000;
            if (args.Length > 0)
                path = args[0];
            if (args.Length > 1)
                count = int.Parse(args[1]);
            Console.WriteLine($"path={path} count={count}");
            try
            {
                var fileGenerator = new FileGenerator(path, 0, count);
                fileGenerator.Generate();

                var fileChecker = new FileChecker(path);
                fileChecker.Check();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
