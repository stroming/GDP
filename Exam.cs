using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Channels;
using Npgsql;

namespace GDP
{
    class Exam
    {
        static void Main()
        {

            var cs = "Host=localhost;Username=postgres;Password=stroming1.6180;Database=postgres";
            using var connection = new NpgsqlConnection(cs);
            connection.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "DROP TABLE IF EXISTS gdpperyear";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE gdpperyear( id BIGSERIAL PRIMARY KEY, year INT UNIQUE, gdp_value INT )";
            cmd.ExecuteNonQuery();
            int year = YearInput;
            WriteValuesInPSQL(cmd, year);
            connection.Close();
        }

        private static void WriteValuesInPSQL(NpgsqlCommand cmd, int year)
        {
            for (var i = 0; i < int.MaxValue; i++)
            {
                var value = ValueInput;
                if (value != "q")
                {
                    cmd.CommandText = $"INSERT INTO gdpperyear(year, gdp_value) VALUES({year + i},{value})";
                    int a = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Lines affected : {a}");
                }
                else
                {
                    break;
                }
            }
        }

        //static IStorage WritingInputValuesInStorage()
        //{
        //    IStorage storage = CreateStorage();
        //    int year = YearInput;
        //    for (var i = 0; i < int.MaxValue; i++)
        //    {
        //        double value = double.Parse(ValueInput);
        //        if (Equals(ValueInput, "q"))
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            storage.WriteYearAndValue(year + i, value);
        //        }
        //    }
        //    return storage;
        //}

        private static IStorage CreateStorage()
        {
            IStorage storage;

            string DiskOrMemory = Console.ReadLine();
            if (DiskOrMemory.ToLower() == "memory")
            {
                storage = new DiskStorage();
            }
            else if (DiskOrMemory.ToLower() == "disk")
            {
                storage = new MemoryStorage();
            }
            else 
            {
                throw new Exception("Please pick one of the two methods of storing data!");
            }

            return storage;
        }

        static double InputAlphaCoef
        {
            get
            {
                // Infinite loop is making the user enter a value over an over again until there are no erros in his input
                // Once that is done "return" breaks the loop
                while (true)
                {
                    try
                    {
                        Console.WriteLine("What's is the alpha coeficient (Must be between 1 and 0 . ExampleFormat 0.21):");
                        if (double.TryParse(Console.ReadLine(), out double alpha) && alpha < 1 && alpha > 0)
                        {
                            Console.WriteLine("Coeficient accepted!");
                            return alpha;
                        }
                        else
                        {
                            throw new Exception("Invalid Coeficient");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }       
        static string ValueInput
        {
            get
            {
                string input = Console.ReadLine();
                bool a = double.TryParse(input, out _);
                if (input.ToLower() == "q")
                {
                    return input.ToLower();
                }
                else if (a == true)
                {
                    Console.WriteLine("That's a valid Value!");
                    return input;
                }
                else
                {
                    throw new Exception("That's not a valid value!");
                }
            }
        }
        static int YearInput
        {
            get
            {
                // Infinite loop is making the user enter a value over an over again until there are no erros in his input
                // Once that is done "return" breaks the loop
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please enter a starting point of data collection");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out int year))
                        {
                            Console.WriteLine("That's a valid Value!");
                            return year;
                        }
                        else
                        {
                            throw new Exception("That's not a valid value!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }                                   
            }
        }
    }
}
