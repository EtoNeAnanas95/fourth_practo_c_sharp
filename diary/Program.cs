using System.Runtime;

namespace diary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            note note = new note();
            DateTime date = new DateTime(2023, 10, 6);
            Console.CursorVisible = false;
            Console.WriteLine($"Дата {date}");




            note.date = date;
            note.Name[0] = "помыть попу";
            note.Description[0] = "ну помой просто, чёто ты описание смотришь";
            note.Name[1] = "ну зубы тоже можно опчистить";
            note.Description[1] = "та иди ты в задницу";



            
            Console.WriteLine($"  1. {note.Name[0]}");
            Console.WriteLine($"  2. {note.Name[1]}\n\n\n\n");

            int position = 1;
            ConsoleKeyInfo key;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            do
            {
                key = Console.ReadKey();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                Console.SetCursorPosition(0, 9); 
                Console.WriteLine(date);
                Console.SetCursorPosition(0, position);
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (position != 4)
                        {
                            position++; 
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (position != 1)
                        {
                            position--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        date = date.AddDays(-1);
                        break;
                    case ConsoleKey.RightArrow:
                        date = date.AddDays(1);
                        break;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
            }
            while (key.Key != ConsoleKey.Enter);



            switch (position)
            {
                case 1:
                    Console.Clear();

                    note.date = date;

                    Console.WriteLine("Введите название заметки ");
                    note.Name[3] = Console.ReadLine();

                    Console.WriteLine(note.date);
                    Console.WriteLine(note.Name);


                    break;
                case 2:
                    Console.Clear();


                    break;
                case 3:
                    Console.Clear();


                    break;
                case 4:
                    Console.Clear();


                    break;
            }
        }
    }
}