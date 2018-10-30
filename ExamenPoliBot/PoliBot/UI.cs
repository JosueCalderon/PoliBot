using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace PoliBot
{
    class UI
    {
        private static User user = new User();
        private static readonly UserManagement mngUser = new UserManagement();

        static void Main()
        {
            Welcome();
        }

        static void Welcome()
        {

            Console.WriteLine("************************************");
            Console.WriteLine("******  WELCOME TO POLI-BOT   ******");
            Console.WriteLine("************************************");
            Console.WriteLine();
            Console.WriteLine("Type your id: ");
            user.UserId = Console.ReadLine();
            user = mngUser.RetrieveById(user);

            if (user == null)
            {
                Console.WriteLine();
                Console.WriteLine("*********ID DOESN'T EXIST**********");
                Console.WriteLine();
                Console.WriteLine("***********************************");
                Console.WriteLine("**********   SING IN     **********");
                Console.WriteLine("***********************************");
                Console.WriteLine();
                Console.WriteLine("Type your ID and name");
                Console.WriteLine("Separated by comma");
                Console.WriteLine();
                var info = Console.ReadLine();
                var infoArray = info.Split(',');
                user = new User(infoArray);
                Console.WriteLine();
                mngUser.Create(user);
                Console.WriteLine();
                Console.WriteLine("user was created");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("Welcome to poli-bot " + user.Name);
                Console.WriteLine();
                GeneralMenu();

            }
            else
            {
                GeneralMenu();
                GeneralMenu();
                Console.WriteLine(" Welcome to poli-bot " + user.Name);
                GeneralMenu();
            }
         
        }

        static void GeneralMenu()
        {

            int opc;

            do
            {
                Console.WriteLine();
                Console.WriteLine("----SELECT LANGUAGE----");
                Console.WriteLine();
                Console.WriteLine("1. Select language.");
                Console.WriteLine("2. Exit.");
                Console.WriteLine();
                Console.WriteLine("Choose an option: ");
                Console.WriteLine();
                Console.WriteLine(); 
                opc = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                processOption(opc);
                Console.WriteLine();
            } while (opc != 2);

        }

        public static void processOption(int popc)
        {

            switch (popc)
            {

                //case 1:

                //    CustomerMenu();
                //    break;

                //case 2:

                //    AccountMenu();
                //    break;

                //case 3:

                //    AddressMenu();
                //    break;

                //case 4:

                //    LocationMenu();
                //    break;

                //case 5:

                //    CreditMenu();
                //    break;

            }

        }
    }
}
