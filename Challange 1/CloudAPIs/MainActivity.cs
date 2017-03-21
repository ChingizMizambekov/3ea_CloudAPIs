using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace CloudAPIs
{
    [Activity(Label = "CloudAPIs", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // Create strings list
        private List<string> listItems;

        // Reference to the XAML listview
        private ListView myListView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Ref to the XAML ListView
            myListView = FindViewById<ListView>(Resource.Id.MyListView);

            // Populate the list
            listItems = new List<string>();
            listItems.Add("Bobby");
            listItems.Add("Tommy");
            listItems.Add("Jimmy");

            // Create adapter
            ListViewAdapter adapter = new ListViewAdapter(this, listItems);

            myListView.Adapter = adapter;
           

        }
    }
}

