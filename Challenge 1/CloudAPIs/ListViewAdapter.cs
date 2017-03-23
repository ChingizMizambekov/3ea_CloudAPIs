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

namespace CloudAPIs
{
    class ListViewAdapter : BaseAdapter<Person>
    {
        // Create List to containt list items and context
        private List<Person> _Items;
        private Context _Context;
        

        // Constructor
        public ListViewAdapter(Context context, List<Person> items)
        {
            _Items = items;
            _Context = context;
        }

        // Get number of items in the list
        public override int Count
        {
            get { return _Items.Count; }
        }

        // Get item ID number
        public override long GetItemId(int position)
        {
            return position;
        }

        // Get item position index
        public override Person this[int position]
        {
            get { return _Items[position];  }
        }

        // Create and display the view
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(_Context).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView txtFirsname = row.FindViewById<TextView>(Resource.Id.txtFirstname);
            txtFirsname.Text = _Items[position].FirstName;

            TextView txtLastname = row.FindViewById<TextView>(Resource.Id.txtLastname);
            txtLastname.Text = _Items[position].LastName;

            TextView txtAge = row.FindViewById<TextView>(Resource.Id.txtAge);
            txtAge.Text = Convert.ToString(_Items[position].Age);

            TextView txtGender = row.FindViewById<TextView>(Resource.Id.txtGender);
            txtGender.Text = _Items[position].Gender;

            return row;
        }
    }
}