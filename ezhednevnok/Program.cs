using System;
using System.Collections.Generic;

class Program
{
    static List<Note> notes = new List<Note>();

    static void Main(string[] args)
    {
        
        notes.Add(new Note("Заметка 1", "Описание 1", new DateTime(2022, 1, 6)));
        notes.Add(new Note("Заметка 2", "Описание 2", new DateTime(2022, 1, 8)));
        notes.Add(new Note("Заметка 3", "Описание 3", new DateTime(2022, 1, 13)));

        int currentNoteIndex = 0; 

        while (true)
        {
            Console.Clear();
            PrintMenu(currentNoteIndex); 

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;

            if (key == ConsoleKey.LeftArrow)
            {
                
                currentNoteIndex = (currentNoteIndex - 1 + notes.Count) % notes.Count;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                
                currentNoteIndex = (currentNoteIndex + 1) % notes.Count;
            }
            else if (key == ConsoleKey.Enter)
            {
                
                OpenNoteDetails(notes[currentNoteIndex]);
            }
        }
    }

    static void PrintMenu(int currentNoteIndex)
    {
        for (int i = 0; i < notes.Count; i++)
        {
            
            if (i == currentNoteIndex)
            {
                Console.WriteLine($"-> {notes[i].Title}");
            }
            else
            {
                Console.WriteLine($"   {notes[i].Title}");
            }
        }
    }

    static void OpenNoteDetails(Note note)
    {
        Console.Clear();
        Console.WriteLine($"Название: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        Console.WriteLine($"К выполнению: {note.DueDate.ToShortDateString()}");

        Console.ReadKey();
    }
}

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public Note(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        Date = DateTime.Now;
        DueDate = dueDate;
    }
}
