using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JSonSchemaCodeGenerator
{
    public class Program
    {
        private static readonly string baseDirectory = "../../../../../API/Models";
        public static void Main(string[] args)
        {
            Console.WriteLine("G - Generate");
            Console.WriteLine("D - Delete");
            var key = Console.ReadKey();
            if (key.KeyChar == 'G')
            {
                var tasks = new Task[]
                {
                CreateClassfromJsonSchema(@"https://www.billingo.hu/json/schema/invoice.json", "Invoice"),
                CreateClassfromJsonSchema(@"https://www.billingo.hu/json/schema/invoice_item.json", "InvoiceItem"),
                CreateClassfromJsonSchema(@"https://www.billingo.hu/json/schema/invoice_pay.json", "InvoicePay"),
                CreateClassfromJsonSchema(@"https://www.billingo.hu/json/schema/client.json", "Client"),
                };
                Task.WaitAll(tasks);
            }
            if (key.KeyChar == 'D')
            {
                foreach (var file in Directory.EnumerateFiles(baseDirectory).Where(f => f.Contains(".Generated.cs")).ToList())
                {
                    File.Delete(file);
                }
            }
        }

        public static async Task CreateClassfromJsonSchema(string url, string name)
        {
            JsonSchema4 jsonSchema = await JsonSchema4.FromUrlAsync(url);
            CSharpGenerator generator = new CSharpGenerator(jsonSchema);
            generator.Settings.ArrayBaseType = "System.Collections.Generic.List";
            generator.Settings.ArrayType = "System.Collections.Generic.List";
            generator.Settings.EnumNameGenerator = new EnumNameGenerator();
            generator.Settings.GenerateDataAnnotations = false;
            generator.Settings.GenerateJsonMethods = false;
            generator.Settings.Namespace = "LETin.Billingo.Api";
            generator.Settings.ClassStyle = CSharpClassStyle.Poco;
            var text = generator.GenerateFile(name);
            while (text.Contains("  ")) text = text.Replace("  ", " ");
            text = text.Replace("\n \n", "\n");
            while (text.Contains("\n\n")) text = text.Replace("\n\n", "\n");
            text = text.Replace("#pragma warning disable // Disable all warnings", "");
            await File.WriteAllTextAsync($"{baseDirectory}/{name}.Generated.cs", text);
        }
    }
}