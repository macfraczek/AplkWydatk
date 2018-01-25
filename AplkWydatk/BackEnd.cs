using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AplkWydatk
{

    class Person
    {
        // count usunac -> nie potrzebne
        public static int Count { get; private set; } = 0;
        public int Id { get; private set; }
        public string Nick { get; set; }
        public string Email { get; set; }

        public Person(string nick, string email = "")
        {
            Id = Count++;
            Nick = nick;
            if (Email == "-")
            { }
            else
                Email = email;
        }
    }
    class Product
    {
        public string Name { get; set; }
        public float Prize { get; set; }
        public double[] ListBuyer { get; set; }
        public string Category { get; set; }

        public Product(string name, float prize, List<double> listBuyer, string category = "-")
        {
            Name = name;
            Prize = prize;
            ListBuyer = new double[Person.Count];
            listBuyer.CopyTo(ListBuyer);
            Category = category;
        }
    }
    class CollectionPerson
    {
        private static List<Person> _CollPerson = new List<Person>();
        private CollectionPerson() { }

        public static List<Person> ReturnList
        {
            get
            {
                return _CollPerson;
            }
        }
        public static bool Add(string nick, string email = "")
        {
            _CollPerson.Add(new Person(nick, email));
            return true;
        }

    }
    class CollectionProduct
    {
        private static List<Product> _CollProduct = new List<Product>();
        private CollectionProduct() { }

        public static List<Product> ReturnList
        {
            get
            {
                return _CollProduct;
            }
        }
        public static bool Add(string name, float prize, List<double> listBuyer, string category = "-")
        {
            _CollProduct.Add(new Product(name, prize, listBuyer, category));
            return true;
        }

    }

    class CollectionPersonIterator
    {
        private List<Person> iterator = CollectionPerson.ReturnList;

        private bool IsNext(int count)
        {
            if (count < iterator.Count)
            {
                //Console.Write(count.ToString()+" ");
                return true;
            }
            else
                return false;
        }
        public void Iterate2()
        {
            int count = 0;
            //Console.WriteLine(iterator.Count.ToString());
            while (IsNext(count))
            {
                Console.WriteLine("ID: {0} \tNick: {1} \tEmail: {2}", iterator[count].Id.ToString(), iterator[count].Nick.ToString(), iterator[count].Email.ToString());
                count++;
            }
        }
        public string Get()
        {
            string result = "";
            int count = 0;
            //Console.WriteLine(iterator.Count.ToString());
            while (IsNext(count))
            {
                result += "ID: " + iterator[count].Id + " \tNick: "
                    + iterator[count].Nick + " \n   Email: " + iterator[count].Email + "\n";
                count++;
            }
            return result;
        }
        public List<string> GetList()
        {
            List<string> result = new List<string>();
            int count = 0;
            //Console.WriteLine(iterator.Count.ToString());
            while (IsNext(count))
            {
                result.Add( "ID: " + iterator[count].Id + " \tNick: "
                    + iterator[count].Nick + " \n   Email: " + iterator[count].Email + "\n");
                count++;
            }
            return result;
        }


    }
    class CollectionProductIterator
    {
        private List<Product> iterator = CollectionProduct.ReturnList;

        private bool IsNext(int count)
        {
            if (count < iterator.Count)
            {
                //Console.Write(count.ToString()+" ");
                return true;
            }
            else
                return false;
        }
        public void Iterate2()
        {
            int count = 0;
            //Console.WriteLine(iterator.Count.ToString());
            while (IsNext(count))
            {
                Console.WriteLine("Name: {0} \tPrize: {1} \tCategory: {2}\t List: {3} , {4} , {5}",
                    iterator[count].Name.ToString(), iterator[count].Prize.ToString(), iterator[count].Category.ToString(),
                iterator[count].ListBuyer[0].ToString(), iterator[count].ListBuyer[1].ToString(), iterator[count].ListBuyer[2].ToString());
                count++;
            }
        }
        public string Get()
        {
            int count = 0;
            string result = "";
            while (IsNext(count))
            {
                result += ("Name: " + iterator[count].Name.ToString() + " \tPrize: " + iterator[count].Prize.ToString()
                    + " \tCategory: " + iterator[count].Category.ToString() + "\t List: " + iterator[count].ListBuyer[0].ToString()
                    + " , " + iterator[count].ListBuyer[1].ToString() + " , " + iterator[count].ListBuyer[2].ToString()) + "\n";
                count++;
            }
            return result;
        }
        public List<string> GetList()
        {
            int count = 0;
            List<string> result = new List<string>();
            while (IsNext(count))
            {
                result.Add("Name: " + iterator[count].Name.ToString());
                  //  + " \tPrize: " + iterator[count].Prize.ToString()
                   // + " \tCategory: " + iterator[count].Category.ToString() + "\tList: ");
                /*
                for(int i = 0; i < CollectionPerson.ReturnList.Count; i++)
                {
                    result.Add(iterator[count].ListBuyer[i].ToString());
                    result.Add("  ");
                }


                result.Add("\n");*/
                count++;
            }
            return result;
        }

    }

    class Algorytm
    {


        public string Count(List<Person> personList, List<Product> productList)
        {
            double total = 0;
            double perOnePerson = 0;
            List<double> listOfDebt = new List<double>();
            string result = "";
            bool anyChange = true;

            foreach (Product i in productList)
            {
                total += i.Prize;
            }
            perOnePerson = total / personList.Count;

            for (int i = 0; i < personList.Count; i++)
            {
                listOfDebt.Add(0);
            }

            for (int i = 0; i < productList.Count; i++)
            {
                for (int j = 0; j < personList.Count; j++)
                {
                    listOfDebt[j] += productList[i].Prize * productList[i].ListBuyer[j];
                }

            }
            for (int i = 0; i < personList.Count; i++)
            {
                listOfDebt[i] -= perOnePerson;
            }

            for (int i = 0; i < personList.Count; i++)
            {
                if (listOfDebt[i] > 0)
                {

                    for (int j = 0; j < personList.Count; j++)
                    {
                        if (listOfDebt[j] < 0)
                        {
                            double temp;
                            if (listOfDebt[i] <= (-listOfDebt[j]) + 0.001)
                            {
                                anyChange = false;
                                temp = listOfDebt[i];
                                listOfDebt[j] += listOfDebt[i];
                                listOfDebt[i] = 0;
                                result += personList[i].Nick + " musi przekazac " + personList[j].Nick + " " + String.Format("{0:00.00}", temp) + " zl.\n";
                            }
                            else
                            {
                                anyChange = false;
                                temp = -listOfDebt[j];
                                listOfDebt[i] += listOfDebt[j];
                                listOfDebt[j] = 0;
                                result += personList[i].Nick + " musi przekazac " + personList[j].Nick + " " + String.Format("{0:00.00}", temp) + " zl.\n";
                            }
                        }

                    }
                }

            }
            if (anyChange)
                result = "Wszystko jest OK :)";

            return result;
        }
    }


    class Program
    {
        /*static void Main(string[] args)
        {
            InitializeSomePeople();
            CollectionPersonIterator a = new CollectionPersonIterator();
            InitializeSomeProducts();
            CollectionProductIterator b = new CollectionProductIterator();

            Algorytm alg = new Algorytm();
            alg.Count(CollectionPerson.ReturnList, CollectionProduct.ReturnList);

            Console.WriteLine(a.Get());
            Console.WriteLine(b.Get());

            Console.WriteLine("=======================================================");c
            

            Console.ReadKey();
            return;
        }*/

        private static void InitializeSomeProducts()
        {
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
        }
        private static void InitializeSomePeople()
        {
            CollectionPerson.Add("Adrian", "Adrian@op.pl");
            CollectionPerson.Add("Kamil");
            CollectionPerson.Add("Basia", "Basia@op.pl");
        }

    }
}