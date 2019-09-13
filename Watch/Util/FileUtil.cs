using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Watch.Util
{
    public class FileUtil
    {
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
