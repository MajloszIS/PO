using System;
using System.Reflection;

public enum Priority
{
    Low,
    Medium,
    High
}

public enum Frequency
{
    Daily,
    Weekly,
    Monthly
}

public class Task
{
    protected string Title;
    protected string Description;
    protected bool IsCompleted;

    public Task(string title, string description, bool isCompleted)
    {
        this.Title = title;
        this.Description = description;
        this.IsCompleted = isCompleted;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public virtual void DisplayTaskInfo()
    {
        Console.WriteLine("\n------------------------");
        Console.WriteLine($"Tytuł: {Title}");
        Console.WriteLine($"Opis: {Description}");
        Console.WriteLine($"Ukończone: {IsCompleted}");
        Console.WriteLine("------------------------\n");
    }

}



//TIMED TASK
public class TimedTask : Task
{
    protected DateTime DueDate;

    public TimedTask(string title, string description, bool isCompleted, DateTime dueDate) :
                    base(title, description, isCompleted)
    {
        this.DueDate = dueDate;
    }

    public bool IsOverDue()
    {
        DateTime currentDate = DateTime.Today;

        if (DueDate > currentDate)
        {
            Console.WriteLine("Zadanie jest po czasie");
            return true;
        }
        else
        {
            Console.WriteLine("Zadanie nie jest po czasie");
            return false;
        }

    }

    public void ExtendDeadline(DateTime newDate)
    {
        DueDate = newDate;
    }
}

public class RecurringTask : TimedTask
{
    protected Frequency RepeatInterval;

    public RecurringTask(string title, string description, bool isCompleted, DateTime dueDate, Frequency repeatInterval) :
                    base(title, description, isCompleted, dueDate)
    {
        this.RepeatInterval = repeatInterval;
    }

    public void Reschedule()
    {
        RepeatInterval++;
    }
}



//PRIORITY TASK
public class PriorityTask : Task
{
    protected Priority TaskPriority;

    public PriorityTask(string title, string description, bool isCompleted, Priority taskPriority) :
                    base(title, description, isCompleted)
    {
        this.TaskPriority = taskPriority;
    }

    public void ChangePriority(Priority newPriority)
    {
        TaskPriority = newPriority;
    }
}



//TASK WITH NOTES
public class TaskWithNotes : Task
{
    protected string[] Notes;

    public TaskWithNotes(string title, string description, bool isCompleted, string[] notes) :
                    base(title, description, isCompleted)
    {
        this.Notes = notes;
    }

    public void AddNote(string note)
    {
        string[] newNotes = new string[Notes.Length + 1];
        for (int i = 0; i < Notes.Length; i++)
        {
            newNotes[i] = Notes[i];
        }
        newNotes[Notes.Length] = note;
        Notes = newNotes;
    }

    public void DisplayNotes()
    {
        for (int i = 0; i < Notes.Length; i++)
        {
            Console.WriteLine($"{i+1}: {Notes[i]}");
        }
    }
}



//Main
public class Program02
{
    public static void Main()
    {
        Task basicTask = new Task("Zakupy", "Kupić mleko i chleb", false);
        TimedTask deadlineTask = new TimedTask("Oddać raport", "Raport z postępów", false, DateTime.Now.AddDays(2));
        PriorityTask highPriorityTask = new PriorityTask("Ważne spotkanie", "Omówienie budżetu", true, Priority.High);
        RecurringTask recurringTask = new RecurringTask("Ćwiczenia", "Codzienna siłownia", false, DateTime.Now, Frequency.Daily);
        Task workTask = new Task("Przygotowanie prezentacji", "Slajdy na konferencję", false);

        // Testowanie metod
        recurringTask.Reschedule();
        deadlineTask.MarkAsCompleted();
        highPriorityTask.DisplayTaskInfo();
        workTask.DisplayTaskInfo();

        //

        TaskWithNotes myNotes = new TaskWithNotes("Zrealizować projekt końcowy",
                                                    "Stworzyć aplikację konsolową w C#, która zarządza zadaniami i pozwala na dodawanie notatek.",
                                                    false,
                                                    new string[] {"asd", "asd", "asd"});
        myNotes.DisplayNotes();
        Console.WriteLine("-------------------------");
        myNotes.AddNote("Spushowanie zmian do repo");
        myNotes.DisplayNotes();


    }
}