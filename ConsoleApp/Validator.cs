using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    enum ValidatorResponse
    {
        Success,
        InvalidAction,
        CheckArguments,
        InvalidProductName,
        InvalidProductPrice,
        InvalidProductQuantity
    }
    static class Validator
    {
        private static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        private static HashSet<string> set = new HashSet<string>() {"add", "view", "edit", "delete", "search", "exit"};
        public static ValidatorResponse ValidateCommand(string command)
        {

            
            string[] args = command.Trim().Split(" ");

            if (!set.Contains(args[0]))
                return ValidatorResponse.InvalidAction;

            switch(args[0])
            {
                case "add": return args.Length == 4? ValidateProduct(SubArray(args, 1, 3)) : ValidatorResponse.CheckArguments;
                case "view": return ValidatorResponse.Success;
                case "edit": return args.Length == 5 ? ValidateProduct(SubArray(args, 2, 3)) : ValidatorResponse.CheckArguments;
                case "delete": return args.Length == 2 ? ValidatorResponse.Success : ValidatorResponse.CheckArguments;
                case "search": return args.Length == 2 ? ValidatorResponse.Success : ValidatorResponse.CheckArguments;
                case "exit": return ValidatorResponse.Success;
            }

            return ValidatorResponse.InvalidAction;
        }
        private static ValidatorResponse ValidateProduct(string[] args)
        {
            (string name, string price, string quantity) = (args[0], args[1], args[2]);

            if(String.IsNullOrEmpty(name))
                return ValidatorResponse.InvalidProductName;
            if (!double.TryParse(price, out double resPrice))
                return ValidatorResponse.InvalidProductPrice;
            if (!int.TryParse(quantity, out int resQuantity))
                return ValidatorResponse.InvalidProductQuantity;

            return ValidatorResponse.Success;
        }
        
    }
}
