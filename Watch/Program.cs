using System;
using Watch.Service;

namespace Watch
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileService fileService = new FileService();
            FileService.WatchFile();
        }
    }
}
