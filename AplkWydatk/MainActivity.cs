using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;

namespace AplkWydatk
{
    [Activity(Label = "Nazwa Aplikacji - Main Activity", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it


            Button addProductButton = FindViewById<Button>(Resource.Id.AddProductButton);
            Button showProdutButton = FindViewById<Button>(Resource.Id.ShowProductButton);
            Button mangamentButton = FindViewById<Button>(Resource.Id.ManagmentButton);
            Button algorytmUseButton = FindViewById<Button>(Resource.Id.AlgorytmUseButton);

            addProductButton.Click += delegate { StartActivity(typeof(AddProductActivity)); };
            showProdutButton.Click += delegate {
                new ShowProductActivity();
                var intent = new Intent(this, typeof(ShowProductActivity));
                CollectionProductIterator a = new CollectionProductIterator();

                    intent.PutStringArrayListExtra("phone_numbers", a.GetList());
                StartActivity(intent);
            };
            mangamentButton.Click += delegate { StartActivity(typeof(ManagmentActivity)); };
            algorytmUseButton.Click += delegate { StartActivity(typeof(AlgorytmUseActivity)); };



            Button testButton = FindViewById<Button>(Resource.Id.TEST);
            testButton.Click += delegate
            {
                CollectionPerson.Add("Adrian", "Adrian@op.pl");
                CollectionPerson.Add("Kamil");
                CollectionPerson.Add("Basia", "Basia@op.pl");
                CollectionPersonIterator a = new CollectionPersonIterator();
                List<double> lista = new List<double>();
                lista.Add(0.0);
                lista.Add(1.0);
                lista.Add(0.0);
                CollectionProduct.Add("Grabie", 150.0f, lista, "Narzedzia");

                lista[0] = 0.0f;
                lista[1] = 1.0f;
                lista[2] = 0.0f;
                CollectionProduct.Add("Cynamon", 150.0f, lista, "Jedzenie");

                lista[0] = 1.0f;
                lista[1] = 0.0f;
                lista[2] = 0.0f;
                CollectionProduct.Add("Widelec", 150.0f, lista, "Narzedzia");
                CollectionProductIterator b = new CollectionProductIterator();

                //Algorytm alg = new Algorytm();
               // alg.Count(CollectionPerson.ReturnList, CollectionProduct.ReturnList);

                //SmtpClientAccess.Program.SendEmail("macfraczek@gmail.com", a.Get());

            };


        }
    }
}

