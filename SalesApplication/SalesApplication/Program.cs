using System;

namespace SalesApplication
{
    class Program
    {
        public enum CrudOptions

        {
            CREATE,
            READ,
            UPDATE,
            DELETE,
            QUIT
        }
        static void Main(string[] args)
        {
            string s = " Sales ";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);

            Console.WriteLine(" ===== Menu ===== ");
            Console.WriteLine("1. Make an Entry");
            Console.WriteLine("2. Sales Reports");
            Console.WriteLine(" === ======= === ");

       
            string input = Console.ReadLine();

            if(input == "1") {
                // open CRUD menu

                Console.WriteLine(" 1. Create ");
                Console.WriteLine(" 2. Update ");
                Console.WriteLine(" 3. Delete ");

                string input2 = Console.ReadLine();

                switch (input2)
                {
                    case "1":
                        // create 
                        break;

                    case "2":
                        // Update 
                        break;

                    case "3":
                        // delete
                        break;

                }
            }
            else if(input == "2")
            {
                // view reports
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        public static void Create()
        {
            // get input from user and store them
        }

    }
    

}
