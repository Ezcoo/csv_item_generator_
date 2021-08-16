using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace CSVkuntoon
{
    class Program
    {
        static void Main()
        {

            string path = "C:\\Users\\Net_2\\Documents\\RevolutionRPG_Arma3\\daylight\\newTest.csv";
            var items = new List<Item>();

            while (true)
            {
                Console.WriteLine("What is the NAME of the item? ");
                string itemName = Console.ReadLine();

                Console.WriteLine("What is the DESCRIPTION of the item? ");
                string description = Console.ReadLine();

                Console.WriteLine("What is the possible SCRIPT FILE NAME of the item? Leave empty (press ENTER) if there isn\'t any.");
                string scriptFile = Console.ReadLine();

                Console.WriteLine("What is the WEIGHT of the item in kilograms? ");
                float weightFloat = 0;
                string weight = "";
                while (true)
                {
                    try
                    {
                        weightFloat = float.Parse(Console.ReadLine());
                        weight = weightFloat.ToString();
                        break;
                    } catch (Exception e)
                    {
                        Console.WriteLine("Well, you fucked up. Try again!");
                    };
                }

                Console.WriteLine("What is the PRICE of the item in the ingame currency? ");
                int priceInt = 0;
                string price = "";
                while (true)
                {
                    try
                    {
                        priceInt = int.Parse(Console.ReadLine());
                        price = priceInt.ToString();
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Well, you fucked up. Try again!");
                    };
                }

                Console.WriteLine("What INTERFACES does the item implement? Write \"END\" when done.");
                List<String> interfacesList = new List<string>();

                while (true)
                {
                    string interfaceName = Console.ReadLine();

                    if (interfaceName.Equals("END"))
                    {
                        break;
                    }


                    interfacesList.Add(interfaceName);
                }

                string interfaces = '\u0022' + "[" + '\u0022' + String.Join('\u0022' + ", " + '\u0022', interfacesList.ToArray()) + '\u0022' + "]" + '\u0022';



                Item item = new Item();
                item.STR_ITEM_NAME =   itemName  ;
                item.STR_ITEM_DESC =   description  ;
                item.STR_ITEM_SCRIPT =   scriptFile  ;
                item.STR_ITEM_WEIGHT =   weight  ;
                item.STR_ITEM_PRICE =   price  ;
                item.STR_ITEM_INTERFACES = interfaces;

                items.Add(item);

                Console.WriteLine("If you want to add new item, press ENTER. If you want to quit, type \"END\".");
                string answer = Console.ReadLine();
                if (answer.Contains("END"))
                {
                    break;
                } 
            }

            var indexes = new[] { 0, 1, 2, 3, 4 };

            if (File.Exists(path))
            {

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    ShouldQuote = args => indexes.Contains(args.Row.Index),
                    HasHeaderRecord = false,
                    Delimiter = ";"
                };

                using (var stream = File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(items);
                }

            } 
            else
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    ShouldQuote = args => indexes.Contains(args.Row.Index),
                    HasHeaderRecord = false,
                    Delimiter = ";"
                };

                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(items);
                }

            }
        }

    }

}
