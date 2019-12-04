using System;
using System.Collections.Generic;
using System.Text;

namespace Silver_Inventory
{
    public enum TypeOfTransaction
    {
        Deposit,
        Withdrawal
    }
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int ItemNumber { get; set; }
        public TypeOfTransaction TransactionType { get; set; }
        public string ChestName { get; set; }
        public virtual Item Item { get; set; }
        public decimal Balance { get; set; }
    }
}
