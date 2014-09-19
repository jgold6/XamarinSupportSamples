using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Empty1
{
    public class ItemsView : UITableViewController
    {
        public ItemsView()
        {
            this.Title = "Resizable Rows";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ComplexModel model = ComplexModel.Instance();
            this.TableView.Source = new DataSource(model.Columns, model.Records);
        }
    }

    public class DataSource : UITableViewSource
    {
        private Column[] columns;
        private List<Record> records;
        private DataCell offScreenCell;

        public DataSource(IList<Column> columns, IList<Record> records)
        {
            this.columns = columns.ToArray();
            this.records = new List<Record>(records);
        }

        public override int NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return records.Count;
        }

        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if (offScreenCell == null)
                offScreenCell = new DataCell(columns);
            offScreenCell.SetData(records[indexPath.Row]);
            offScreenCell.SetNeedsUpdateConstraints();
            offScreenCell.UpdateConstraintsIfNeeded();

            offScreenCell.Bounds = new RectangleF(0, 0, tableView.Bounds.Width, tableView.Bounds.Height);

            offScreenCell.SetNeedsLayout();
            offScreenCell.LayoutIfNeeded();

            var height = offScreenCell.ContentView.SystemLayoutSizeFittingSize(UIView.UILayoutFittingCompressedSize).Height;
            height += 1;

            return height;
        }

        public override float EstimatedHeight(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableView.AutomaticDimension;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (DataCell)tableView.DequeueReusableCell(DataCell.Key);
            if (cell == null)
                cell = new DataCell(columns);
            cell.SetData(records[indexPath.Row]);

            cell.SetNeedsUpdateConstraints();
            cell.UpdateConstraintsIfNeeded();

            string info = cell.GetInfo();
            Console.WriteLine(info);

            return cell;
        }

    }

    public class DataCell : UITableViewCell
    {
        private class ViewItem
        {
            public ViewItem(Column column)
            {
                this.Column = column;
            }
            public UILabel Label { get; set; }
            public UILabel Value { get; set; }
            public Column Column { get; private set; }
        }

        public static readonly NSString Key = new NSString("ListPageCell");
        private Column[] Columns;
        private Dictionary<string, ViewItem> viewItems;
        private bool didUpdateConstraints;

        public DataCell(Column[] columns)
        {
            this.Columns = columns;
            CreateView();
        }

        public void SetData(Record record)
        {
            foreach (Field field in record.Fields)
            {
                viewItems[field.Column.Name].Value.Text = field.Value;
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in viewItems.Keys)
            {
                sb.AppendLine("");
                sb.AppendLine(key);
                ViewItem item = viewItems[key];
                sb.AppendLine(string.Format("     Label: X={0}, Y={1}, Height={2}, Width={3}", item.Label.Bounds.X, item.Label.Bounds.Y, item.Label.Bounds.Height, item.Label.Bounds.Width));
                sb.AppendLine(string.Format("     Value: X={0}, Y={1}, Height={2}, Width={3}", item.Value.Bounds.X, item.Value.Bounds.Y, item.Value.Bounds.Height, item.Value.Bounds.Width));
                sb.AppendLine("------------------------------------------");
            }
            return sb.ToString();
        }

        public override void UpdateConstraints()
        {
            base.UpdateConstraints();
            if (didUpdateConstraints)
                return;
            this.ContentView.RemoveConstraints(this.ContentView.Constraints);
            UIView v = ContentView;
            foreach (Column col in ComplexModel.Instance().Columns)
            {
                UILabel label = viewItems[col.Name].Label;
                label.TranslatesAutoresizingMaskIntoConstraints = false;
                label.SetContentCompressionResistancePriority(1000f, UILayoutConstraintAxis.Vertical);
                UILabel value = viewItems[col.Name].Value;
                value.TranslatesAutoresizingMaskIntoConstraints = false;
                value.SetContentCompressionResistancePriority(1000f, UILayoutConstraintAxis.Vertical);

                label.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 20));
                v.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Left, NSLayoutRelation.Equal, v, NSLayoutAttribute.Left, 1, Physics.HSpacing));
                v.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Top, NSLayoutRelation.Equal, v, NSLayoutAttribute.Top, 1, Physics.VSpacing));
                v.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Right, NSLayoutRelation.Equal, v, NSLayoutAttribute.Right, 1, (Physics.HSpacing * -1f)));

                value.AddConstraint(NSLayoutConstraint.Create(value, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 20));
                v.AddConstraint(NSLayoutConstraint.Create(value, NSLayoutAttribute.Left, NSLayoutRelation.Equal, v, NSLayoutAttribute.Left, 1, Physics.HSpacing));
                v.AddConstraint(NSLayoutConstraint.Create(value, NSLayoutAttribute.Top, NSLayoutRelation.Equal, label, NSLayoutAttribute.Bottom, 1, Physics.VSpacing));
                v.AddConstraint(NSLayoutConstraint.Create(value, NSLayoutAttribute.Right, NSLayoutRelation.Equal, v, NSLayoutAttribute.Right, 1, (Physics.HSpacing * -1f)));
            }
            this.ContentView.TranslatesAutoresizingMaskIntoConstraints = false;
            didUpdateConstraints = true;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.ContentView.SetNeedsLayout();
            this.ContentView.LayoutIfNeeded();

            foreach (string key in viewItems.Keys)
            {
                ViewItem item = viewItems[key];
                if (item.Column.MultiLine)
                    viewItems[key].Value.PreferredMaxLayoutWidth = viewItems[key].Value.Frame.Width;
            }

        }

        private void CreateView()
        {
            viewItems = new Dictionary<string, ViewItem>();
            foreach (Column col in Columns)
            {
                UILabel label = CreateLabelLabel(col);
                UILabel value = CreateValueLabel(col);
                this.ContentView.AddSubviews(new UIView[] { label, value });
                viewItems.Add(col.Name, new ViewItem(col) { Label = label, Value = value });
            }
            // This will be Style.BackColor
            this.ContentView.BackgroundColor = UIColor.FromRGBA(0, 255, 0, 30);
        }

        private UILabel CreateLabelLabel(Column col)
        {
            return new UILabel()
            {
                LineBreakMode = UILineBreakMode.TailTruncation,
                Lines = 1,
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.Black,
                //Font = UIFont.PreferredHeadline,
                BackgroundColor = UIColor.FromRGBA(0, 0, 255, 30),
                Text = col.Caption
            };
        }

        private UILabel CreateValueLabel(Column col)
        {
            return new UILabel()
            {
                LineBreakMode = UILineBreakMode.TailTruncation,
                Lines = col.MultiLine ? 0 : 1,
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.DarkGray,
                //Font = UIFont.PreferredCaption2,
                BackgroundColor = UIColor.FromRGBA(255, 0, 0, 30)
            };
        }
    }
}