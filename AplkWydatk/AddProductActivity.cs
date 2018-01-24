using Android.App;
using Android.OS;
using Android.Widget;

namespace AplkWydatk
{
    [Activity(Label = "AddProductActivity")]
    public class AddProductActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddProductLayout);
            // Create your application here


            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            Button addButton = FindViewById<Button>(Resource.Id.AddButton);





            cancelButton.Click += delegate { Finish(); };
            addButton.Click += delegate 
            {

                Toast.MakeText(this, "Successful", ToastLength.Long).Show();
                Finish();
            };



        }
    }
}