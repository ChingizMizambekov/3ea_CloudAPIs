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
        private List<Person> listItems;

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
            listItems = new List<Person>();
            listItems.Add(new CloudAPIs.Person() { FirstName = "Bobby", LastName = "Smith", Age = 23, Gender = "Male" });
            listItems.Add(new CloudAPIs.Person() { FirstName = "Tommy", LastName = "McDonald", Age = 48, Gender = "Male" });
            listItems.Add(new CloudAPIs.Person() { FirstName = "Erica", LastName = "Rubenstein", Age = 28, Gender = "Female" });

            // Create adapter
            ListViewAdapter adapter = new ListViewAdapter(this, listItems);

            // Set adapter
            myListView.Adapter = adapter;          

        }
    }
}

