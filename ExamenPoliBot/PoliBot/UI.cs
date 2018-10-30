using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Entities_POJO;

namespace PoliBot
{
    class UI
    {
        private static User user = new User();
        private static Language language = new Language();
        private static readonly LanguageManagement mngLanguage = new LanguageManagement();
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
                Console.WriteLine();
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

                case 1:

                    SelectLanguage();
                    break;

                case 2:

                    Console.WriteLine("Bye");
                    break;

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

        public static void SelectLanguage()
        {

            Console.WriteLine("************************************");
            Console.WriteLine("********  WRITE LANGUAGE   *********");
            Console.WriteLine("************************************");
            Console.WriteLine();
            Console.WriteLine("Type language: ");
            language.Languages = Console.ReadLine();
            language = mngLanguage.RetrieveById(language);

            if (language == null)
            {
                Console.WriteLine();
                Console.WriteLine("*********LANGUAGE DOESN'T EXIST**********");
                Console.WriteLine();
                Console.WriteLine("*************************************************************");
                Console.WriteLine("**********   DO YOU WANT TO CREATE THIS LANGUAGE?  **********");
                Console.WriteLine("*************************************************************");
                Console.WriteLine();
                Console.WriteLine("Type language again");
                Console.WriteLine();
                var info = Console.ReadLine();
                var infoArray = info.Split(',');
                language = new Language(infoArray);
                Console.WriteLine();
                mngLanguage.Create(language);
                Console.WriteLine();
                Console.WriteLine("Language was created");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("This language was created: " + language.Languages);
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Language selected: " + language.Languages);
                Console.WriteLine();
                Translate();
            }

        }

        public static void Translate()
        {

            Console.WriteLine("************************************");
            Console.WriteLine("********  WRITE WORD TO TRANSLATE  *********");
            Console.WriteLine("************************************");
            Console.WriteLine();
            Console.WriteLine("Type word: ");

        }
    }
}
