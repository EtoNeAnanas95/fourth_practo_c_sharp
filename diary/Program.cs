using Microsoft.VisualBasic;
using System.Runtime;
using System;
using System.Text;
using System.Net.Http.Headers;

namespace diary
{
    internal class Program
    {
        static void manual(int i)
        {
            Console.SetCursorPosition(0, i + 2);
            Console.WriteLine("Для написания новой записки нажмите \"G\"");
        }

        static int GetNotesCount(Date? date)
        {
            if (date != null)
                return date.notes.Count;
            else
                return 1;
        }

        static int DrawDate(Date date, DateTime selectedDataTime, string format)
        {
            Console.Clear();
            int index;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                   ");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Дата " + selectedDataTime.ToString(format));
            Console.SetCursorPosition(0, 1);

            if (date == null)
            {
                Console.WriteLine("  Здесь нет записок");
                index = 0;
            }
            else
            {
                index = date.Print();
            }
            manual(GetNotesCount(date));
            return index;
        }
        static void DrowNameAndDecription(int position, Date note_for_print, DateTime selected_date, string format)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Дата: {selected_date.ToString(format)}");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"Название: {note_for_print.notes[position-1].name}");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"Описание: {note_for_print.notes[position-1].description}");
        }

        static void CreateNote()
        {

        }


        static int i = 0;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            i++;
            string format = "dd.MM.yyyy";
            DateTime SelectedDateTime = new DateTime(2023, 9, 15);
            DatesManager DatesManager = new DatesManager();



            Date date_Whith_Note = new Date();
            date_Whith_Note.datetime = new List<DateTime>();
            date_Whith_Note.notes = new List<Note>();
            date_Whith_Note.datetime.Add(new DateTime(2023, 9, 15));
            date_Whith_Note.notes.Add(new Note("Покрутить землю, чтобы она не остановилась"));
            date_Whith_Note.notes.Add(new Note("Не рожал -- не мужик", "Обязательно (партийное задание от партии комунистов)"));
            date_Whith_Note.notes.Add(new Note("Подоить быка"));

            DatesManager.dates = date_Whith_Note;

            /*Console.SetCursorPosition(0, 10);
            Console.WriteLine(DatesManager.dates.datetime[0].ToString(format));*/
            Date note_for_print = DatesManager.FindByDateTime(SelectedDateTime);

            int index = DrawDate(note_for_print, SelectedDateTime, format);

            int position = 1;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            ConsoleKey key = ConsoleKey.Q;
            while (key != ConsoleKey.Enter)
            {
                key = Console.ReadKey().Key;
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                Console.SetCursorPosition(5, 0);
                Console.Write("                   ");
                Console.SetCursorPosition(5, 0);
                Console.Write(SelectedDateTime.ToString(format));
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (position < index) 
                            position++;
                        break;
                    case ConsoleKey.UpArrow:  
                        if (position > 1)
                            position--;
                        break;
                    case ConsoleKey.LeftArrow:
                        SelectedDateTime = SelectedDateTime.AddDays(-1);
                        note_for_print = DatesManager.FindByDateTime(SelectedDateTime);
                        DrawDate(note_for_print, SelectedDateTime, format);
                        if (note_for_print == null)
                        {
                            index = 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        SelectedDateTime = SelectedDateTime.AddDays(1);
                        note_for_print = DatesManager.FindByDateTime(SelectedDateTime);
                        DrawDate(note_for_print, SelectedDateTime, format);
                        if (note_for_print == null)
                        {
                            index = 1;
                        }
                        break;
                    case ConsoleKey.G: 

                        break;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
            }
            DrowNameAndDecription(position, note_for_print, SelectedDateTime, format);
        }
    }
}