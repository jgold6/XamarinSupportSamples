using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WaveMaker
{

    public static class DataReadFobClass
    {
        static string[] item = { " FOB Value", " FOB Value", " FOB Value", "END_DATA" };

        static string[] datas = {  "...", "...", "...", "..." };

        static bool data_updated = false;

        public static int getArrayCount()
        {
            return 3;
        }

        public static bool getDataNew()
        {
            if (data_updated == true)
            {
                data_updated = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void setDataNew(bool data_status)
        {
            data_updated = data_status;
        }

        public static string getDataString(int i)
        {
            return datas[i];
        }

        public static string getItemString(int i)
        {
            return item[i];
        }

        public static void setItemString(string new_data, int i)
        {
            item[i] = new_data;
        }

        public static void setDataString(string new_data, int i)
        {
            datas[i] = new_data;
        }
    }

 

}