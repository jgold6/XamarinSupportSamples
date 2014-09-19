//using MonoTouch.UIKit;
//
//namespace SearchSample
//{
//    public sealed class TableViewController : UITableViewController
//    {
//        public override void ViewDidLoad()
//        {
//            // Loading data from the server in ViewDidLoad results in loading when transistioning from
//            // parent to child views, but not from child to parent (as happens with ViewWillAppear).
//            base.ViewDidLoad();
//
//            TableView.Source = new GuidIndexedTableViewSource();
//        }
//    }
//}