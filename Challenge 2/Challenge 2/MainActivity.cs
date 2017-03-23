using Android.App;
using Android.Widget;
using Android.OS;
using System.Xml.Linq;
using System.Linq;
using Android.Content;
using Android.Views;
using System.Net.Http;

namespace Challenge_2
{
    [Activity(Label = "XamFeed", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private RssItem[] _items;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            using (var client = new HttpClient())
            {
                var xmlFeed = await client.GetStringAsync("http://blog.xamarin.com/feed/");
                var doc = XDocument.Parse(xmlFeed);
                XNamespace dc = "http://purl.org/dc/elements/1.1/";

                _items = (from item in doc.Descendants("item")
                          select new RssItem
                          {
                              Title = item.Element("title").Value,
                              PubDate = item.Element("pubDate").Value,
                              Creator = item.Element(dc + "creator").Value,
                              Link = item.Element("link").Value
                          }).ToArray();

                ListAdapter = new FeedAdapter(this, _items);
            }
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            var second = new Intent(this, typeof(WebActivity));
            second.PutExtra("link", _items[position].Link);
            StartActivity(second);
        }
    }
}

