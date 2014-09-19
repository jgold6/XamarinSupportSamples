using System;
using System.Linq;
using Xamarin.AdoData.Core.Model;

namespace Xamarin.AdoData.Core
{
    internal static class StockHelper
    {
        public static Stock GenerateStock()
        {
            return new Stock
            {
                Id = (new Random()).Next(),
                Symbol = GenerateSymbol()
            };
        }

        private static string GenerateSymbol()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var random = new Random();

            return new string(
                Enumerable.Repeat(chars, 4)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
        }
    }
}