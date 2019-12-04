using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver_Inventory
{
    public static class TreasureChest
    {
        private static ChestContext db = new ChestContext();

        public static Item CreateItem
            (string chestName,
            string itemName,
            string itemYear,
            string itemGrade,
            string itemStrike,
            string itemCondition,
            string itemDescription,
            string itemPurchaseDate,
            decimal itemPurchaseAmount,
            decimal itemNurismaticAmount,
            decimal itemMeltAmount,
            string itemMintMark,
            string itemGradingService,
            Type itemType = Type.Coin)

        {
            if (string.IsNullOrEmpty(chestName))
            {
                throw new ArgumentNullException("chestName", "Treasure chest name is required!");
            }
            if (string.IsNullOrEmpty(itemName))
            {
                throw new ArgumentNullException("itemName", "Treasure name is required!");
            }
            var item = new Item
            {
                ChestName = chestName,
                ItemName = itemName,
                ItemYear = itemYear,
                ItemType = itemType,
                Grade = itemGrade,
                Strike = itemStrike,
                Condition = itemCondition,
                Description = itemDescription,
                PurchaseDate = itemPurchaseDate,
                PurchaseAmount = itemPurchaseAmount,
                NurismaticAmount = itemNurismaticAmount,
                MeltAmount = itemMeltAmount,
                MintMark = itemMintMark,
                GradingService = itemGradingService,
            };

            db.Items.Add(item);
            db.SaveChanges();
            return item;
        }

        public static IEnumerable<Item>GetAllItems(string chestName)
        {
            return db.Items.Where(i => i.ChestName == chestName);
        }

        public static Item GetItemByItemNumber(int itemNumber)
        {
            return db.Items.SingleOrDefault(a => a.ItemNumber == itemNumber);
        }
        public static void Update(Item updatedItem)
        {
            var oldItem = GetItemByItemNumber(updatedItem.ItemNumber);
            oldItem.ChestName = updatedItem.ChestName;
            oldItem.ItemNumber = updatedItem.ItemNumber;
            oldItem.ItemType = updatedItem.ItemType;

            db.SaveChanges();
        }

        public static void Deposit(string chestName, int itemNumber)
        {
            var item = db.Items.SingleOrDefault(i => i.ChestName == chestName);
            if (item == null)
            {
                //throw exception
                return;
            }

            //item.Deposit(itemNumber);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TypeOfTransaction.Deposit,
                Description = "Treasure Chest Deposit",
                ItemNumber = itemNumber,
                ChestName = chestName
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void Withdraw(string chestName, int itemNumber)
        {
            var item = db.Items.SingleOrDefault(i => i.ChestName == chestName);
            if (item == null)
            {
                //throw exception
                return;
            }

            item.Withdrawal(itemNumber);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TypeOfTransaction.Withdrawal,
                Description = "Treasure Chest withdrawal",
                ItemNumber = itemNumber,
                ChestName = chestName
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}
