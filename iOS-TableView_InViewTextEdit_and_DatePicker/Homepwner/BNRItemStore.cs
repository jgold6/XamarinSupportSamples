using System;
using System.Drawing;
using MonoTouch.Foundation;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace Homepwner
{
	public static class BNRItemStore : object
	{
		public static List<BNRItem> allItems = new List<BNRItem>();


		public static BNRItem CreateItem()
		{
			BNRItem p = new BNRItem();
			if (allItems.Count == 0) {
				p.orderingValue = 1;
			} else {
				p.orderingValue = allItems[allItems.Count-1].orderingValue + 1.0;
			}
			allItems.Add(p);

			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.Insert(p);
			return p;
		}

		public static void loadItemsFromDatabase()
		{
			string dbPath = GetDBPath();
			SQLiteConnection db;
			if (!File.Exists(dbPath)) {
				db = new SQLiteConnection(dbPath);
				db.CreateTable<BNRItem>();
				db.Close();
				db = null;
			} 
			db = new SQLiteConnection(dbPath);
			allItems = db.Query<BNRItem>("SELECT * FROM BNRItems ORDER BY orderingValue");
		}

		public static void RemoveItem(BNRItem p)
		{
			allItems.Remove(p);
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.Delete(p);
			db.Close();
		}

		public static void moveItem(int fromIndex, int toIndex)
		{
			if (fromIndex == toIndex)
				return;
			BNRItem p = allItems[fromIndex];
			allItems.Remove(p);
			allItems.Insert(toIndex, p);

			// Computing a new ordering value for the object that was moved
			double lowerBound = 0.0;

			// Is there an objetc before it in the array?
			if (toIndex > 0) {
				lowerBound = allItems[toIndex - 1].orderingValue;
			} else {
				lowerBound = allItems[1].orderingValue - 2.0;
			}

			double upperBound = 0.0;

			// Is there an object after it in the array?
			if (toIndex < allItems.Count - 1) {
				upperBound = allItems[toIndex + 1].orderingValue;
			} else {
				upperBound = allItems[toIndex - 1].orderingValue + 2.0;
			}

			double newOrderValue = (lowerBound + upperBound) / 2.0;

			Console.WriteLine("Moving to order {0}", newOrderValue);
			p.orderingValue = newOrderValue;

			updateDBItem(p);

		}
		public static void updateDBItem(BNRItem item)
		{
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.Update(item);
			db.Close();
		}

		public static string GetDBPath()
		{
			string[] documentDirectories = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true);

			// Get one and only document directory from that list
			string documentDirectory = documentDirectories[0];
			return Path.Combine(documentDirectory, "items.db");
		}
	}
}

