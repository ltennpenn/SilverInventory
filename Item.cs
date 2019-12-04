using System;
using System.Collections.Generic;
using System.Text;

namespace Silver_Inventory
{
    public enum Type
    {
        Coin,
        Round,
        Medal,
    }
    public class Item
    {

        #region Properties
        public string ChestName { get; set; }
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public Type ItemType { get; set; }
        public string ItemYear { get; set; }
        public string Grade { get; set; }
        public string Strike { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string PurchaseDate { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal NurismaticAmount { get; set; }
        public decimal MeltAmount { get; set; }
        public string MintMark { get; set; }
        public string GradingService { get; set; }
        public DateTime CreatedDate { get; }
        #endregion

        #region Methods
        public void PurchasePrice(decimal amount)
        {
            PurchaseAmount = amount;
        }

        public void NurismaticValue(decimal amount)
        {
            NurismaticAmount = amount;
        }
        public void MeltValue(decimal amount)
        {
            MeltAmount = amount;
        }
        //public void Deposit(int itemNumber)
        //{
        //    lastItemNumber += itemNumber;
        //}

        /// <summary>
        /// Withdraw an item from your treasure chest
        /// </summary>
        /// <param name="itemNumber">Item to withdraw</param>
        /// <returns>Item Number</returns>
        public int Withdrawal(int itemNumber)
        {
            ItemNumber = itemNumber;
            return ItemNumber;
        }

        #endregion

        #region Constructor
        public Item()
        {
            CreatedDate = DateTime.Today;
        }
        #endregion
    }
}
