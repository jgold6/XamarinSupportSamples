using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace MonoDroid.DialogSample
{
    public class CoolDialogsFragment : Fragment, DatePickerDialog.IOnDateSetListener, NumberPicker.IOnValueChangeListener
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.DialogFragment_Contents, container, false);

            var datePickerButton = view.FindViewById<Button>(Resource.Id.DatePickerDialogButton);
			datePickerButton.Click += delegate {
				var dialog = new DatePickerDialogFragment(Activity, DateTime.Now, this);
				dialog.Show(FragmentManager, "date");
			};

            var numberPickerButton = view.FindViewById<Button>(Resource.Id.NumberPickerDialogButton);
			numberPickerButton.Click += delegate {
				var dialog = new NumberPickerDialogFragment(Activity, 10, 9999, 42, this);
                dialog.Show(FragmentManager, "number"); 
            };

            return view;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            Toast.MakeText(Activity, string.Format("Picked date: {0}/{1}/{2}", year, monthOfYear + 1, dayOfMonth), ToastLength.Short).Show();
        }

        public void OnValueChange(NumberPicker picker, int oldVal, int newVal)
        {
            Toast.MakeText(Activity, string.Format("Value changed from: {0} to {1}", oldVal, newVal), ToastLength.Short).Show();
        }

        private class DatePickerDialogFragment : DialogFragment
        {
            private readonly Context _context;
            private DateTime _date;
            private readonly DatePickerDialog.IOnDateSetListener _listener;

            public DatePickerDialogFragment(Context context, DateTime date, DatePickerDialog.IOnDateSetListener listener)
            {
                _context = context;
                _date = date;
                _listener = listener;
            }

            public override Dialog OnCreateDialog(Bundle savedState)
            {
                var dialog = new DatePickerDialog(_context, _listener, _date.Year, _date.Month - 1, _date.Day);
                return dialog;
            }
        }

        private class NumberPickerDialogFragment : DialogFragment
        {
            private readonly Context _context;
            private readonly int _min, _max, _current;
            private readonly NumberPicker.IOnValueChangeListener _listener;

            public NumberPickerDialogFragment(Context context, int min, int max, int current, NumberPicker.IOnValueChangeListener listener)
            {
                _context = context;
                _min = min;
                _max = max;
                _current = current;
                _listener = listener;
            }

            public override Dialog OnCreateDialog(Bundle savedState)
            {
                var inflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
                var view = inflater.Inflate(Resource.Layout.NumberPickerDialog, null);
                var numberPicker = view.FindViewById<NumberPicker>(Resource.Id.numberPicker);
                numberPicker.MaxValue = _max;
                numberPicker.MinValue = _min;
                numberPicker.Value = _current;
                numberPicker.SetOnValueChangedListener(_listener);

				for (int i = 0; i < numberPicker.ChildCount; i++)
				{
					var v = numberPicker.GetChildAt(i);
					if (v.GetType() == typeof(EditText)) {
						var editText = v as EditText;
						editText.SetBackgroundColor(Android.Graphics.Color.BlueViolet);
						editText.SetMinimumWidth(250);
						editText.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
							Console.WriteLine("Text Changed");
							Toast.MakeText(Activity, string.Format("New Value: {0}", editText.Text), ToastLength.Short).Show();
						};
						editText.EditorAction += (object sender, TextView.EditorActionEventArgs e) => {
							Console.WriteLine("Done pressed");
							Toast.MakeText(Activity, string.Format("New Value: {0}", editText.Text), ToastLength.Short).Show();
						};
						break;
					}
				}



                var dialog = new AlertDialog.Builder(_context);
                dialog.SetTitle(Resource.String.number_dialog_title);
                dialog.SetView(view);
                dialog.SetNegativeButton(Resource.String.dialog_cancel, (s, a) => { });
                dialog.SetPositiveButton(Resource.String.dialog_ok, (s, a) => { });
                return dialog.Create();
            }
        }
    }
}