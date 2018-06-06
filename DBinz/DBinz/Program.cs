using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBinz.Business;

namespace DBinz
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region hello
            //Console.Write(@"
            //________ __________.__               
            //\______ \\______   \__| ____ ________
            // |    |  \|    |  _/  |/    \\___   /
            // |    `   \    |   \  |   |  \/    / 
            ///_______  /______  /__|___|  /_____ \
            //        \/       \/        \/      \/
            //for MS SQL Server 2016");
            //Console.Write("\n\n\nEnter your SQL Server credentials\n\n");
            //var loginData = DataHelper.RequestLoginData();
            #endregion

            var loginData = new LoginData
            {
                Server = @"nb-mebenig\SQLEXPRESS",
                Database = "CustomerManagementDB",
                Login = "testlogin",
                Password = ""
            };

            using (var bObject = new DBinzBusinessObject(loginData))
            {
                while (!bObject.CheckConnection())
                {
                    Console.Write("\n\nBad Credentials, try again.\n\n");
                    loginData = DataHelper.RequestLoginData();
                }

                var tableDetails = bObject.FetchTableDetails().ToList();

                #region TableChoice

                //const byte tablePageSize = 25;

                //if (tableDetails.Count == 0)
                //{
                //    Console.WriteLine("There are no tables in this database.");
                //    return;
                //}
                //if (tableDetails.Count > tablePageSize)
                //    Console.WriteLine("Printing the first 25 tables...");
                //else
                //    Console.WriteLine("Printing all tables...");

                //short tableCounter = 1;
                //short tableCounterMultiplicator = 1;

                //foreach (var tableDetailsItem in tableDetails)
                //{
                //    if (tableCounter > tablePageSize * tableCounterMultiplicator)
                //    {
                //        Console.WriteLine("Did you find the wanted table? Y/N");
                //        var answer = Console.ReadKey().ToString().ToLower();

                //        if (answer == "y")
                //        {
                //            break;
                //        }
                //        if (answer == "n")
                //        {
                //            tableCounterMultiplicator++;
                //            Console.WriteLine("Printing the next 25 tables...");
                //        }
                //        else
                //        {
                //            Console.WriteLine("Invalid answer.");
                //            return;
                //        }
                //    }
                //    Console.WriteLine($"{ tableCounter.ToString().PadLeft(3, '0') }: [{ tableDetailsItem.Item1 }].[{ tableDetailsItem.Item2 }]");
                //    tableCounter++;
                //}
                //Console.Write("\nEnter the number of the table you want to use: ");

                //int chosenTableNumber = -1;
                //if (!Int32.TryParse(Console.ReadLine(), out chosenTableNumber) || chosenTableNumber > tableCounter || chosenTableNumber < 1)
                //{
                //    return;
                //}
                //var chosenTable = tableDetails[chosenTableNumber -= 1];

                //Console.WriteLine($"You chose the table [{ chosenTable.Item1 }].[{ chosenTable.Item2 }].");

                #endregion

                int tableChoice = 3;
                var chosenTable = tableDetails[tableChoice -= 1];


                Console.ReadKey();
            }
        }
    }
}