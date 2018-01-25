using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AplkWydatk
{
    [Activity(Label = "ManagmentActivity")]
    public class ManagmentActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MangamentLayout);
            // Create your application here

            TextView listOfUsers = FindViewById<TextView>(Resource.Id.ListOfUsers);
            Button addPersonButton = FindViewById<Button>(Resource.Id.AddPersonButton);
            Button editEventButton = FindViewById<Button>(Resource.Id.EditEventNameButton);
            Button backEventButton = FindViewById<Button>(Resource.Id.BackButton);


            CollectionPersonIterator a = new CollectionPersonIterator();
            if (!string.IsNullOrWhiteSpace(a.Get()))
            {
                listOfUsers.Text = a.Get();
            }

            addPersonButton.Click += delegate
            {
                StartActivity(typeof(PeopleEditActivity));
            };
            editEventButton.Click += delegate
            {
                Toast.MakeText(this, "FUNKCJONALNOSC NIEDOSTEPNA", ToastLength.Long).Show();
            };
            backEventButton.Click += delegate
            {
                Finish();
            };

            listOfUsers.Click += delegate
            {
                this.Recreate();
            };



        }
        

    }
}