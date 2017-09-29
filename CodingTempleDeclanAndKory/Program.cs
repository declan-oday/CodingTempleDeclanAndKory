using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace CodingTempleDeclanAndKory
{
    class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu == true)
            {
                displayMenu = CardCatalog.MainMenu();
            }

        }
        [Serializable]
        public class Book
        {public static void ListBooks()
            {
                //This is where we need to figure out how to list out all of the books.
            }

            public static void AddBook()
            {

                Console.WriteLine("Please enter the title of the book you would like to add: ");
                string Title = Console.ReadLine();
                Console.WriteLine("Please enter the author of the book you would like to add: ");
                string Author = Console.ReadLine();
                Console.WriteLine("Please enter the genre of the book that you would like to add: ");
                string Genre = Console.ReadLine();
                Console.WriteLine("Please enter the serial number of the book that you would like to add: ");
                string SerialNumber = Console.ReadLine();
                Console.WriteLine("Title: {0} Author: {1} Genre: {2} Serial Number: {3}", Title, Author, Genre, SerialNumber);
                Console.ReadLine();

                FileStream fs = new FileStream("BookData.dat", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, Title);
                    formatter.Serialize(fs, Author);
                    formatter.Serialize(fs, Genre);
                    formatter.Serialize(fs, SerialNumber);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }

            }

          /*  private static int PromptUserForSerialNumber(string Input)
            {
                int num;
                while (!int.TryParse(Input, out num))
                {
                    Console.WriteLine("Please enter the serial number of the book you would like to add: ");
                    Input = Console.ReadLine();
                }
                return num;
            }*/
            public static void SaveAndQuit()
            { //This is where we need to figure out how to save and fix things
            }

            protected string Author { get; set; }
            protected string Title { get; set; }
            protected string Genre { get; set; }
            public string SerialNumber { get; set; }
            public bool Availability { get; set; }


        }

        public class CardCatalog : Book
        {
            public static bool MainMenu()
            {
                Console.Write("Welcome to the Library! ");
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
                    Console.Write("Thank you and have a great day!");
                        Console.ReadLine();
                    return false;
                }
                else { return true; }
            }

        }
    }
}
