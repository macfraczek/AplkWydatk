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

namespace AplkWydatk
{
    [Activity(Label = "ShowProductActivity")]
    public class ShowProductActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];

            CollectionProductIterator a = new CollectionProductIterator();
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, a.GetList());
        }
    }
}