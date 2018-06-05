using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DBinz.Business
{
    public static class DataHelper
    {
        public static Tuple<string[], Dictionary<int, string[]>> ExtractFile(string csvFilePath)
        {
            StreamReader fileStreamReader;

            string[] columns;
            Dictionary<int, string[]> allLineValues;

            int lineCounter = 1;

            try
            {
                fileStreamReader = File.OpenText(csvFilePath);
                var headLine = fileStreamReader.ReadLine();

                if (String.IsNullOrWhiteSpace(headLine))
                    throw new ArgumentException();

                columns = headLine.Split(';');
            }
            catch (Exception exc)
            {
                return null;
            }

            try
            {
                allLineValues = new Dictionary<int, string[]>();

                while (!fileStreamReader.EndOfStream)
                {
                    var currentLine = fileStreamReader.ReadLine();

                    if (!String.IsNullOrWhiteSpace(currentLine))
                        throw new ArgumentException();

                    var currentLineValues = currentLine.Split(';');

                    if (currentLineValues.Length != columns.Length)
                        throw new ArgumentException();

                    allLineValues.Add(lineCounter, currentLineValues);
                    lineCounter++;

                }
            }
            catch (Exception exc)
            {
                return null;
            }

            fileStreamReader.Close();
            return new Tuple<string[], Dictionary<int, string[]>>(columns, allLineValues);
        }

        public static LoginData RequestLoginData()
        {
            var loginData = new LoginData();

            Console.WriteLine(@"SQL Server(\instance):");
            loginData.Server = Console.ReadLine().Trim().TrimEnd('\\');
            Console.WriteLine("Database:");
            loginData.Database = Console.ReadLine().Trim();
            Console.WriteLine("Login:");
            loginData.Login = Console.ReadLine().Trim();
            Console.WriteLine("Password:");
            loginData.Password = Console.ReadLine().Trim();

            return loginData;
        }
    }
}
