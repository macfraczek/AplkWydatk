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
    [Activity(Label = "PeopleEditActivity")]
    public class PeopleEditActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PeopleEditLayout);

            EditText nameText = FindViewById<EditText>(Resource.Id.NameText);
            EditText emailText = FindViewById<EditText>(Resource.Id.EmailText);
            Button saveButton = FindViewById<Button>(Resource.Id.SaveButton);
            Button rejectButton = FindViewById<Button>(Resource.Id.RejectButton);

            saveButton.Click += delegate
            {
                if (!string.IsNullOrWhiteSpace(nameText.Text)) {
                    CollectionPerson.Add(nameText.Text, emailText.Text);
                    Toast.MakeText(this, "Successful", ToastLength.Long).Show();
                    Finish();
                }else
                    Toast.MakeText(this, "Nick jest wymagany !", ToastLength.Long).Show();

            };

            rejectButton.Click += delegate
            {
                Toast.MakeText(this, "Cancelled", ToastLength.Long).Show();
                Finish();
            };

        }
    }
}