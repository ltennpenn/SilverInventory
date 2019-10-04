using System;
using System.Collections.Generic;
using System.Text;

namespace Silver_Inventory
{
    class Item
    {
        #region Properties
        public string Type { get; set; }
        public string Year { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchasePrice { get; set; }
        public string NurismaticValue { get; set; }
        public int MeltValue { get; set; }
        #endregion
    }
}
