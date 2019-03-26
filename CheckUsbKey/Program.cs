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
        const string Drive = @"e:\";

        static Random rand = new Random();



        static string GetMd5Hash(MD5 md5Hash, byte[] input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(input);

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static void Main(string[] args)
        {

            int start = 4000;
            try
            {
                var buffer = new byte[10 * 1024 * 1024];
                rand = new Random(start);
                for (int i = 0; i < 1000; i++)
                {
                    rand.NextBytes(buffer);

                    using (MD5 md5Hash = MD5.Create())
                    {
                        var hash = GetMd5Hash(md5Hash, buffer);
                        var path = $@"{Drive}\test_{start + i:D8}";
                        Console.WriteLine(path);
                        File.WriteAllBytes(path + ".bin", buffer);
                        File.WriteAllText(path + ".txt", hash);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
