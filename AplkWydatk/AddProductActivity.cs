using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

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

            CheckBox cB0 = FindViewById<CheckBox>(Resource.Id.checkBox0);
            CheckBox cB1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            CheckBox cB2 = FindViewById<CheckBox>(Resource.Id.checkBox2);
            CheckBox cB3 = FindViewById<CheckBox>(Resource.Id.checkBox3);
            CheckBox cB4 = FindViewById<CheckBox>(Resource.Id.checkBox4);
            EditText productText = FindViewById<EditText>(Resource.Id.ProductText);
            EditText prizeText = FindViewById<EditText>(Resource.Id.PrizeText);
            EditText categoryText = FindViewById<EditText>(Resource.Id.CategoryText);
            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            Button addButton = FindViewById<Button>(Resource.Id.AddButton);

            int count = CollectionPerson.ReturnList.Count;
            if (0 == count)
            {
                addButton.Enabled = false;
            }

            switch (count)
            {
                case 5:
                    cB4.Enabled = true;
                    cB4.Visibility = ViewStates.Visible;
                    cB4.Text = CollectionPerson.ReturnList[4].Nick;
                    goto case 4;
                case 4:
                    cB3.Enabled = true;
                    cB3.Visibility = ViewStates.Visible;
                    cB3.Text = CollectionPerson.ReturnList[3].Nick;
                    goto case 3;
                case 3:
                    cB2.Enabled = true;
                    cB2.Visibility = ViewStates.Visible;
                    cB2.Text = CollectionPerson.ReturnList[2].Nick;
                    goto case 2;
                case 2:
                    cB1.Enabled = true;
                    cB1.Visibility = ViewStates.Visible;
                    cB1.Text = CollectionPerson.ReturnList[1].Nick;
                    goto case 1;
                case 1:
                    cB0.Enabled = true;
                    cB0.Visibility = ViewStates.Visible;
                    cB0.Text = CollectionPerson.ReturnList[0].Nick;
                    break;
            }

            List<CheckBox> checkBoxList = new List<CheckBox>() { cB0, cB1, cB2, cB3, cB4 };




            cancelButton.Click += delegate { Finish(); };
            addButton.Click += delegate 
            {

                if (string.IsNullOrWhiteSpace(productText.Text))
                    Toast.MakeText(this, "Nazwa jest wymagana !", ToastLength.Long).Show();
                else if(double.Parse(prizeText.Text) < 0.01)
                    Toast.MakeText(this, "Cena musi być dodatnia !", ToastLength.Long).Show();
                else
                {
                    List<double> list = new List<double>();
                    double counter = 0;
                    foreach (int i in checkBoxList)
                        if (checkBoxList[i].Checked)
                            counter += 1;

                    if (0 == counter)
                        counter = 1 / count;
                    else
                        counter = 1 / counter;
                    
                    foreach (int i in checkBoxList)
                        if (checkBoxList[i].Checked)
                            list.Add(counter);
                        else
                            list.Add(0.0);



                    CollectionProduct.Add(productText.Text, float.Parse(prizeText.Text), list, categoryText.Text);
                    Toast.MakeText(this, "Successful", ToastLength.Long).Show();
                    Finish();
                }


            };



        }
    }
}