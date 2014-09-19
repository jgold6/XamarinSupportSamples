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
		public static List<BNRAssetType> allAssetTypes = new List<BNRAssetType>();


		public static BNRItem CreateItem()
		{
			BNRItem p = BNRItem.RandomBNRItem();
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
//			string path = itemArchivePath(); // Archiving method of saving
//			var unarchiver = (NSMutableArray)NSKeyedUnarchiver.UnarchiveFile(path); // Archiving method of saving
//			if (unarchiver != null) { // Archiving method of saving
//				for (int i = 0; i < unarchiver.Count; i++) { // Archiving method of saving
//					allItems.Add(unarchiver.GetItem<BNRItem>(i)); // Archiving method of saving
//				} // Archiving method of saving
//			} // Archiving method of saving

			string dbPath = GetDBPath();
			SQLiteConnection db;
			if (!File.Exists(dbPath)) {
				db = new SQLiteConnection(dbPath);
				db.CreateTable<BNRAssetType>();
				db.CreateTable<BNRItem>();
				db.BeginTransaction();
				var at = new BNRAssetType();
				at.assetType = "Furniture";
				db.Insert(at);
				at.assetType = "Computer";
				db.Insert(at);
				at.assetType = "Electronics";
				db.Insert(at);
				at.assetType = "Musical Instrument";
				db.Insert(at);
				at.assetType = "Tool";
				db.Insert(at);
				at.assetType = "Clothes";
				db.Insert(at);
				db.Commit();
				db.Close();
				db = null;
			} 
			db = new SQLiteConnection(dbPath);
			allAssetTypes = db.Query<BNRAssetType>("SELECT * FROM BNRAssetTypes ORDER BY assetType");
			allItems = db.Query<BNRItem>("SELECT * FROM BNRItems ORDER BY orderingValue");
		}

		public static void RemoveItem(BNRItem p)
		{
			string key = p.imageKey;
			if (key != null) {
				BNRImageStore.deleteImageForKey(key);
				BNRImageStore.deleteImageForKey(key + ".thumbnail");
			}
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

//		public static string itemArchivePath() // For archiving method of saving
//		{ // For archiving method of saving
//			string[] documentDirectories = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true); // For archiving method of saving
// // For archiving method of saving
//			// Get one and only document directory from that list // For archiving method of saving
//			string documentDirectory = documentDirectories[0]; // For archiving method of saving
//			return Path.Combine(documentDirectory, "items.archive"); // For archiving method of saving
//		}

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

//		public static bool saveChanges()
//		{
//			// Save to db
//			string dbPath = GetDBPath();
//			var db = new SQLiteConnection(dbPath);
//			db.DeleteAll<BNRItem>();
//			db.BeginTransaction();
//			db.InsertAll(allItems);
//			db.Commit();
//			db.Close();
//			return true;

			// Archive method of saving
//			// returns success or failure // For archiving method of saving
//			string path = itemArchivePath(); // For archiving method of saving
//			NSMutableArray newArray = new NSMutableArray(); // For archiving method of saving
//			foreach (BNRItem item in allItems) { // For archiving method of saving
//				newArray.Add(item); // For archiving method of saving
//			} // For archiving method of saving
//			return NSKeyedArchiver.ArchiveRootObjectToFile(newArray, path); // For archiving method of saving
//		}

		public static void addAssetType(string assetType)
		{
			string dbPath = GetDBPath();
			SQLiteConnection db;
			if (File.Exists(dbPath)) {
				db = new SQLiteConnection(dbPath);
				db.BeginTransaction();
				var at = new BNRAssetType();
				at.assetType = assetType;
				allAssetTypes.Add(at);
				db.Insert(at);
				db.Commit();
				db.Close();
			}
		}
	}
}

