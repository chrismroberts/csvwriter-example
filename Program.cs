using System;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace CsvWriterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvPath = Path.Combine(Environment.CurrentDirectory, $"rockets-{DateTime.Now.ToFileTime()}.csv");
            using (var streamWriter = new StreamWriter(csvPath))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    var rockets = RocketInfo.GetRockets();
                    csvWriter.Context.RegisterClassMap<RocketInfoClassMap>();
                    csvWriter.WriteRecords(rockets);
                }
            }
        }
    }
}
