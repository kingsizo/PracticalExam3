using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class КatInteract
    {
        private static readonly KATContext ctx = DBContextManager.GetKATContext();
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the KAT Interaction Menu!");
                Console.WriteLine("Choose option:");
                Console.WriteLine("1) Create\n2) Read\n3) ReadAll\n4) Update\n5) Delete");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Read();
                        break;
                    case 3:
                        ReadAll();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        Console.WriteLine("No such option");
                        Start();
                        break;
                }
            }
        }
        public static void Create()
        {
            //Change 
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            KAT item = new KAT(city);
            ctx.Create(item);
        }
        public static void Read()
        {
            Console.WriteLine("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            KAT item = ctx.Read(id);
            Console.WriteLine(item.ToString());
            Console.ReadKey();
        }
        public static void ReadAll()
        {
            List<KAT> items = (List<KAT>)ctx.ReadAll();
            foreach (KAT item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
        public static void Update()
        {
            //Change
            Console.WriteLine("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            KAT item = new KAT(id, city);
            ctx.Update(item);
        }
        public static void Delete()
        {
            Console.WriteLine("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            ctx.Delete(id);
        }
    }
}
