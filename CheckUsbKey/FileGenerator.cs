using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CheckUsbKey
{
    public class FileGenerator
    {
        private string _path;
        private int _start;
        private int _count;

        private Random _rand;

        private const int Size = 10 * 1024 * 1024;

        public FileGenerator(string path, int start = 0, int count = 100)
        {
            _path = path;
            _start = start;
            _count = count;
            _rand = new Random(_start);
        }

        public void Generate()
        {
            var buffer = new byte[Size];
            for (int i = 0; i < _count; i++)
            {
                _rand.NextBytes(buffer);

                var hash = Md5Util.GetMd5Hash(buffer);
                var path = $@"{_path}\test_{_start + i:D8}.{hash}.bin";
                Console.WriteLine($"{path}");
                File.WriteAllBytes(path, buffer);
            }
        }
    }
}
