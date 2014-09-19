using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections;

namespace Empty1
{
    public class SimpleView : UITableViewController
    {
        private bool autoLayout;

        public SimpleView(bool autoLayout)
        {
            this.Title = "Simple View";
            this.autoLayout = autoLayout;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SimpleModel model = SimpleModel.Instance();
            TableView.Source = new SimpleSource(model.Columns[0], model.Fields, autoLayout);
        }
    }

    public class SimpleSource : UITableViewSource
    {
        private List<Field> Fields;
        private Column Column;
        private bool autoLayout;

        public SimpleSource(Column column, List<Field> fields, bool autoLayout)
        {
            this.Column = column;
            this.Fields = fields;
            this.autoLayout = autoLayout;
        }

        public override int NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return Fields.Count;
        }

        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if (autoLayout)
                return GetAutoheight(tableView, indexPath);
            else
                return GetManualheight(tableView, indexPath);
        }

        private float GetAutoheight(UITableView tableView, NSIndexPath indexPath)
        {
            using (SimpleCell cell = new SimpleCell(Column, autoLayout))
            {
                cell.UpdateFonts();
                cell.SetData(Fields[indexPath.Row]);
                cell.SetNeedsUpdateConstraints();
                cell.UpdateConstraintsIfNeeded();
                cell.Bounds = new RectangleF(0, 0, tableView.Bounds.Width, tableView.Bounds.Height);
                cell.SetNeedsLayout();
                cell.LayoutIfNeeded();
                var height = cell.ContentView.SystemLayoutSizeFittingSize(UIView.UILayoutFittingCompressedSize).Height;
                height += 1;

                string info = GetInfo(cell);
                Console.Write(info);

                return height;
            }
        }

        private string GetInfo(SimpleCell cell)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine("Cell Bounds");
            sb.AppendLine(string.Format("    Bounds: {0}", RectInfo(cell.Bounds)));
            sb.AppendLine(string.Format("    Frame:  {0}", RectInfo(cell.Frame)));
            sb.AppendLine("Cell.ContentView");
            sb.AppendLine(string.Format("    Bounds: {0}", RectInfo(cell.ContentView.Bounds)));
            sb.AppendLine(string.Format("    Frame:  {0}", RectInfo(cell.ContentView.Frame)));
            sb.AppendLine("Cell.Label");
            sb.AppendLine(string.Format("    Bounds: {0}", RectInfo(cell.LabelLabel.Bounds)));
            sb.AppendLine(string.Format("    Frame:  {0}", RectInfo(cell.LabelLabel.Frame)));
            sb.AppendLine("Cell.Value");
            sb.AppendLine(string.Format("    Bounds: {0}", RectInfo(cell.ValueLabel.Bounds)));
            sb.AppendLine(string.Format("    Frame:  {0}", RectInfo(cell.ValueLabel.Frame)));
            sb.AppendLine(string.Format("    Text Length={0}", cell.ValueLabel.Text.Length));
            return sb.ToString();
        }

        private string RectInfo(RectangleF r)
        {
            return string.Format("X={0:00000}, Y={1:00000}, Width={2:00000}, Height={3:00000}, Top={4:00000}, Bottom={5:00000}", r.X, r.Y, r.Width, r.Height, r.Top, r.Bottom);
        }

        private float GetManualheight(UITableView tableView, NSIndexPath indexPath)
        {
            using (SimpleCell cell = new SimpleCell(Column, autoLayout))
            {
                cell.SetData(Fields[indexPath.Row]);
                cell.SetNeedsLayout();
                cell.LayoutIfNeeded();

                string info = GetInfo(cell);
                Console.Write(info);

                return cell.RowHeight;
            }
        }

        public override float EstimatedHeight(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableView.AutomaticDimension;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (SimpleCell)tableView.DequeueReusableCell(SimpleCell.Key);
            if (cell == null)
                cell = new SimpleCell(Column, autoLayout);
            cell.SetData(Fields[indexPath.Row]);
			cell.NeedsUpdateConstraints();
			cell.UpdateConstraintsIfNeeded();
            return cell;
        }

    }

    public class SimpleCell : UITableViewCell
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

        public static readonly NSString Key = new NSString("SimpleCell");
        private Column column;
        private bool autoLayout;
        private bool didUpdateConstraints;

        private ViewItem viewItem;
        public UILabel LabelLabel
        {
            get
            {
                return viewItem != null ? viewItem.Label : null;
            }
        }
        public UILabel ValueLabel
        {
            get
            {
                return viewItem != null ? viewItem.Value : null;
            }
        }

        public SimpleCell(Column column, bool autoLayout)
        {
            this.column = column;
            this.autoLayout = autoLayout;
            if (autoLayout)
                CreateAutoView();
            else
                CreateManualView();
        }

        public void SetData(Field field)
        {
            viewItem.Value.Text = field.Value;
        }

        public float RowHeight { get; private set; }

        public override void UpdateConstraints()
        {
            base.UpdateConstraints();

            if (autoLayout == false || didUpdateConstraints)
                return;

            UILabel labelLabel = viewItem.Label;
            UILabel valueLabel = viewItem.Value;

            labelLabel.SetContentCompressionResistancePriority(1000, UILayoutConstraintAxis.Vertical);
            labelLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            valueLabel.SetContentCompressionResistancePriority(1000, UILayoutConstraintAxis.Vertical);
            valueLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            UIView view = this.ContentView;

            // Create the required constraints to allow the ValueLabel to expand vertically as needed below the LabelLabel
            view.AddConstraint(NSLayoutConstraint.Create(labelLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, view, NSLayoutAttribute.Top, 1, Physics.VSpacing));
            view.AddConstraint(NSLayoutConstraint.Create(labelLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, view, NSLayoutAttribute.Left, 1, Physics.HSpacing));
            view.AddConstraint(NSLayoutConstraint.Create(labelLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, view, NSLayoutAttribute.Right, 1, (Physics.HSpacing * -1f)));

            view.AddConstraint(NSLayoutConstraint.Create(valueLabel, NSLayoutAttribute.Top, NSLayoutRelation.GreaterThanOrEqual, labelLabel, NSLayoutAttribute.Bottom, 1, Physics.VSpacing));
            view.AddConstraint(NSLayoutConstraint.Create(valueLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, view, NSLayoutAttribute.Left, 1, Physics.HSpacing));
            view.AddConstraint(NSLayoutConstraint.Create(valueLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, view, NSLayoutAttribute.Right, 1, (Physics.HSpacing * -1f)));
            view.AddConstraint(NSLayoutConstraint.Create(valueLabel, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, view, NSLayoutAttribute.Bottom, 1, (Physics.VSpacing * -1f)));

            didUpdateConstraints = true;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (autoLayout)
                LayoutSubviewsAuto();
            else
                LayoutSubviewsManual();
        }

        private void LayoutSubviewsAuto()
        {
            this.ContentView.SetNeedsLayout();
            this.ContentView.LayoutIfNeeded();

            viewItem.Label.PreferredMaxLayoutWidth = viewItem.Label.Frame.Width;
            viewItem.Value.PreferredMaxLayoutWidth = viewItem.Value.Frame.Width;
        }

        private void LayoutSubviewsManual()
        {
            float labelHeight = 20;

            float y = Physics.VSpacing;
            float width = this.ContentView.Bounds.Width - (Physics.HSpacing * 2f);
            viewItem.Label.Frame = new RectangleF(Physics.HSpacing, y, width, labelHeight);
            y += (labelHeight + Physics.VSpacing);
            viewItem.Value.Frame = new RectangleF(Physics.HSpacing, y, width, labelHeight);
            y += (labelHeight + Physics.VSpacing);
            RowHeight = y;
        }

        private void CreateManualView()
        {
            UILabel label = CreateLabelLabel(column);
            label.Bounds = new RectangleF(0, 0, 200, 20);

            UILabel value = CreateValueLabel(column);
            value.Bounds = new RectangleF(0, 0, 200, 20);

            this.viewItem = new ViewItem(column) { Label = label, Value = value };

            this.ContentView.BackgroundColor = UIColor.FromRGBA(0, 255, 0, 30);
            this.ContentView.AddSubviews(label, value);
            UpdateFonts();
        }

        private void CreateAutoView()
        {
            UILabel label = CreateLabelLabel(column);
            UILabel value = CreateValueLabel(column);
            
            this.viewItem = new ViewItem(column) { Label = label, Value = value };

            this.ContentView.BackgroundColor = UIColor.FromRGBA(0, 255, 0, 30);

            this.ContentView.AddSubviews(label, value);
            UpdateFonts();
        }

        public void UpdateFonts()
        {
            viewItem.Label.Font = UIFont.FromName("HelveticaNeue-Bold", 20f);
            viewItem.Value.Font = UIFont.FromName("HelveticaNeue", 16f);
        }

        private UILabel CreateLabelLabel(Column col)
        {
            return new UILabel()
            {
                LineBreakMode = UILineBreakMode.TailTruncation,
                Lines = 1,
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.Black,
                BackgroundColor = UIColor.FromRGBA(0, 0, 255, 30),
                Text = col.Caption
            };
        }

        private UILabel CreateValueLabel(Column col)
        {
            return new UILabel()
            {
                LineBreakMode = UILineBreakMode.TailTruncation,
                Lines = 0,
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.DarkGray,
                BackgroundColor = UIColor.FromRGBA(255, 0, 0, 30)
            };
        }


    }
}