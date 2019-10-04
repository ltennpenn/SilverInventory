using System;

namespace Silver_Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = new Item();
            item1.Type = "American Silver Eagle";
            item1.Year = "2019";
            item1.Condition = "MS70";
            item1.Description = "FDI";
            item1.PurchaseDate = "201901151200";
            item1.PurchasePrice = "45";
            item1.NurismaticValue = "47";
            item1.MeltValue = "17.68";
        }
    }
}
