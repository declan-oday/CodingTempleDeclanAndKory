using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace CodingTempleDeclanAndKory
{
    class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu == true)
            {
                displayMenu = MainMenu();
            }

            Book.AddBook();
            Console.ReadLine();
        }
        public class Book
        {
            public static void AddBook()
            {

                Console.WriteLine("Please enter the title of the book you would like to add: ");
                string title = Console.ReadLine();
                Console.WriteLine("Please enter the author of the book you would like to add: ");
                string Author = Console.ReadLine();
                Console.WriteLine("Please enter the genre of the book that you would like to add: ");
                string Genre = Console.ReadLine();
                int SerialNumber = PromptUserForSerialNumber("Please enter the serial number of the book you would like to add");

            }

            private static int PromptUserForSerialNumber(string Input)
            {
                int num;
                while (!int.TryParse(Input, out num))
                {
                    Console.WriteLine("Please enter the serial number of the book you would like to add: ");
                    Input = Console.ReadLine();
                }
                return num;
            }


            [Serializable.Book()]
            protected string Author { get; set; }
            protected string Title { get; set; }
            protected string Genre { get; set; }
            public int SerialNumber { get; set; }
            public bool Availability { get; set; }


        }
    }
    public class CardCatalog
    {
        public static bool MainMenu()
        {
            Console.Write("Welcome to the Library!");
            Console.WriteLine("How can I help you? ");
            Console.WriteLine("1) List books ");
            Console.WriteLine("2) Add a book to library");
            Console.WriteLine("3) Save and quit");
            string result = Console.ReadLine();

            if (result == "1")
            {
                ListBooks();
                return true;
            }
            if (result == "2")
            {
                AddBook();
                return true;
            }
            if (result == "3")
            {
                SaveAndQuit();
                return false;
            }
            else { return true; }
        }

        }
    }

