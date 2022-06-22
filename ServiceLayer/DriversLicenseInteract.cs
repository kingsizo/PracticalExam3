using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public static class DriversLicenseInteract
    {
        private static readonly DriversLicenseContext ctx = DBContextManager.GetDriversLicenseContext();
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Drivers License Interaction Menu!");
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
            Console.WriteLine("Full Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("EGN: ");
            string egn = Console.ReadLine();
            DriversLicense item = new DriversLicense(name, egn);
            ctx.Create(item);
        }
        public static void Read() 
        {
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();
            DriversLicense item = ctx.Read(id);
            Console.WriteLine(item.ToString());
            Console.ReadKey();
        }
        public static void ReadAll() 
        {
            List<DriversLicense> items = (List<DriversLicense>)ctx.ReadAll();
            foreach(DriversLicense item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
        public static void Update() 
        {
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();
            Console.WriteLine("Full Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("EGN: ");
            string egn = Console.ReadLine();
            DriversLicense item = new DriversLicense(id, name, egn);
            ctx.Update(item);
        }
        public static void Delete() 
        {
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();
            ctx.Delete(id);
        }

    }
}
