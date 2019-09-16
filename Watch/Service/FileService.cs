using MoreLinq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using Watch.DTO;
using Watch.Util;

namespace Watch.Service
{
    public class FileService
    {
        private static readonly string folderIn = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "\\data\\in";
        private static readonly string folderOut = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "\\data\\out";
      
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void WatchFile()
        {
            FileUtil.CreateDirectory(folderIn);

            Console.WriteLine("Watcher Started");

            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = folderIn;

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                // Only watch text files.
                watcher.Filter = "*.txt";

                // Add event handlers.                
                watcher.Created += OnChanged;
                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e) =>
            LoadData(e.FullPath);                        
        private static void LoadData(string filePath)
        {
            Console.WriteLine("Begin File read");
            string file = File.ReadAllText(filePath, Encoding.UTF7);
            var fileRow = file.Split(new string[] { "\n" }, StringSplitOptions.None);
            
            Salesman salesman = new Salesman();
            Sale sale = new Sale();
            Customer customer = new Customer();
            var lstSalesman = salesman.LoadSalesman(fileRow.Where(t => t.Contains("001")));
            var lstCustomer = customer.LoadCustomer(fileRow.Where(t => t.Contains("002")));
            var lstSale = sale.LoadSale(fileRow.Where(t => t.Contains("003")));

            Console.WriteLine("End File read");
            GeraArquivo(lstSalesman, lstCustomer, lstSale);
            
        }
        private static void OnRenamed(object source, RenamedEventArgs e) =>            
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");

        /// <summary>
        /// Generate the output fle
        /// </summary>
        /// <param name="salesman"></param>
        /// <param name="customer"></param>
        /// <param name="sale"></param>
        private static void GeraArquivo(List<Salesman> salesman, List<Customer> customer, List<Sale> sale)
        {
            StreamWriter file;

            FileUtil.CreateDirectory(folderOut);

            string arquivo = folderOut + "\\OutputFile.txt";

            file = File.CreateText(arquivo);

            if (salesman.Any())
                file.WriteLine("Amount of salesman in the input file: " + salesman.Count());

            if (customer.Any())
                file.WriteLine("Amount of costumers in the input file: " + customer.Count());

            if (sale.Any())
            {
                Sale maxSalePrice = sale.MaxBy(x => x.SalePrice).SingleOrDefault();

                file.WriteLine("Id of the most expensive sale: " + maxSalePrice.SaleId);

                file.WriteLine("Worst salesman: " + sale.OrderBy(x => x.SalePrice).FirstOrDefault().Salesman);
            }

            Console.WriteLine("Output file created");
            file.Close();
        }
    }
}
