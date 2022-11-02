using CsvHelper; // install CSV helper
using Newtonsoft.Json; // install Newtonsoft.JSON NuGet Package
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace JSONToCSV
{
    internal class Program
    {
        public static void Main()
        {

            var json = @"[{""Sample"":""StringValue"", ""Id"": 1},{""Sample"":""StringValue2"", ""Id"": 2},{""Sample"":""StringValue"", ""Id"": 1}]";

            JsonToCsv(json);
        }

        public static string JsonToCsv(string jsonContent)
        {
            var expandos = JsonConvert.DeserializeObject<ExpandoObject[]>(jsonContent);

            using (TextWriter writer = new StreamWriter(@"sample.csv"))
            {
                using (var csv = new CsvWriter(writer,System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.WriteRecords((expandos as IEnumerable<dynamic>));
                }

                return writer.ToString();
            }
        }
    }
}