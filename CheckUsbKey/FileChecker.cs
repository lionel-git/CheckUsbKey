using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckUsbKey
{
    public class FileChecker
    {
        private string _path;

        public FileChecker(string path)
        {
            _path = path;
        }

        public void Check()
        {
            Console.WriteLine($"Checking {_path} ..");
            var files = Directory.GetFiles(_path, "*.bin", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var buffer = File.ReadAllBytes(file);
                var hash = Md5Util.GetMd5Hash(buffer);

                var shortFile=Path.GetFileName(file);
                var tokens = shortFile.Split('.');

                if (tokens[1]!=hash)
                 Console.WriteLine($"Error: {shortFile} {hash}");
                else
                    Console.Write(".");

            }
            Console.WriteLine();
        }
    }
}
