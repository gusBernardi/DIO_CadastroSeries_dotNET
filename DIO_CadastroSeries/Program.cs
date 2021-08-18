using System;

namespace DIO_CadastroSeries
{
    class Program
    {
        static SeriesRepository Repository = new SeriesRepository();
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.NewLine + "     Welcome!");
            string option = Menu();

            while (option != "X")
            {
                switch (option)
                {
                    case "1": List(); break;
                    case "2": Insert(); break;
                    case "3": Remove(); break;
                    case "4": Update(); break;
                    default: Console.WriteLine(Environment.NewLine + "* Invalid input *"); break;
                }
                option = Menu();
            }
        }

        private static void List()
        {
            var list = Repository.List();

            if (list.Count == 0) Console.WriteLine(Environment.NewLine + "* Empty list *");
            else
                foreach (var series in list)
                    Console.WriteLine("ID: {0} | {1}", series.getId(), series.ToString());
        }

        private static void Insert()
        {
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Genre: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Series newSeries = new Series(Repository.NextId(), (Genre)genre, title, year);
            Repository.Insert(newSeries);
        }

        private static void Remove()
        {
            Console.WriteLine(Environment.NewLine + "Id to remove: ");
            int id = int.Parse(Console.ReadLine());

            if (IdValidation(id)) Repository.Remove(id);
            else Console.WriteLine(Environment.NewLine + "* Invalid Id *");
        }

        private static void Update()
        {
            Console.WriteLine(Environment.NewLine + "Id to update: ");
            int id = int.Parse(Console.ReadLine());

            if (IdValidation(id))
            {
                foreach (int i in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
                }
                Console.Write("Genre: ");
                int genre = int.Parse(Console.ReadLine());

                Console.Write("Title: ");
                string title = Console.ReadLine();

                Console.Write("Year: ");
                int year = int.Parse(Console.ReadLine());

                Series updateSeries = new Series(id, (Genre)genre, title, year);
                Repository.Update(id, updateSeries);
            }
            else Console.WriteLine(Environment.NewLine + "* Invalid Id *");
        }
        private static bool IdValidation(int id)
        {
            return ((Repository.List().Count > 0) && (id < Repository.List().Count)) ? true : false;
        }

        private static string Menu()
        {
            Console.WriteLine(Environment.NewLine + "____ DIOFLIX ____");
            Console.WriteLine("Select an option:" + Environment.NewLine);
            Console.WriteLine("1 - List all series");
            Console.WriteLine("2 - Add a new series");
            Console.WriteLine("3 - Remove");
            Console.WriteLine("4 - Update");
            Console.WriteLine("X - Exit");
            Console.Write(">: ");

            return Console.ReadLine();
        }
    }
}
