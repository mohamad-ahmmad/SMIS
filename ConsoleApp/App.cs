using System;
using BL;
using ConsoleApp;

namespace App
{
    class App
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1-add <name> <price> <quantity>\n" +
                            "2-view\n" +
                            "3-edit <name> <new_name> <new_price> <new_quantity>\n" +
                            "4-delete <name>\n" +
                            "5-search <name>\n");
            while (true)
            {

                string? command = Console.ReadLine();
                if (command == null) continue;

                command = command.ToLower();

                ValidatorResponse validatorResponse = ConsoleApp.Validator.ValidateCommand(command);
                if (validatorResponse != ConsoleApp.ValidatorResponse.Success)
                {
                    Console.WriteLine(validatorResponse);
                    continue;
                }


                Executor.Execute(command);
            }

            }
    }
}
