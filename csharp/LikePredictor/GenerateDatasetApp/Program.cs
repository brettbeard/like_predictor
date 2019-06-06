using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDatasetApp
{
    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //ConvertJsonToCsv(@"..\..\..\..\..\profiles"); 

            var lines = File.ReadAllLines("influencers.csv");
            foreach (String line in lines)
            {
                var tokens = line.Split(',');
                String url = tokens[2].TrimStart('\"').TrimEnd('\"');
                Console.WriteLine("{0}", url);
            }
        }

        private static void ConvertJsonToCsv(String jsonPath)
        {            
            var files = System.IO.Directory.GetFiles(jsonPath, "*.json");

            var outputText = new StringBuilder();
            foreach (String fileName in files)
            {
                JObject jsonObject = JObject.Parse(File.ReadAllText(fileName));

                var userName = jsonObject["username"];
                var alias = jsonObject["alias"];
                var url = jsonObject["urlProfile"];

                outputText.AppendFormat("\"{0}\",\"{1}\",\"{2}\"\r\n", alias, userName, url);
            }

            File.WriteAllText("influencers.csv", outputText.ToString());
        }
    }
}
