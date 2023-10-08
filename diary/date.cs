using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diary
{
    internal class Date
    {
        public List<DateTime> datetime = new List<DateTime>();
        public List<Note> notes = new List<Note>();
        public int Print() 
        {
            int index = 0;

            int position = 1;
            foreach (Note note in this.notes) 
            {
                Console.SetCursorPosition(2, position);
                int length = note.name.Length;
                for (int j = 0; j < length; j++)
                {
                    Console.Write(" ");
                    j++;
                    j++;
                }
                Console.SetCursorPosition(2, position);
                Console.WriteLine($"({index + 1}) {note.name}");
                index++;
                position++;
            }
            return index;
        }

        public void AddNote(Note note) {
            this.notes.Add(note);
        }
    }
}
