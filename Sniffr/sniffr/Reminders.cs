namespace sniffr;

public class Reminders
{
    public static List<string> reminders = new List<string>();
    

    public static void AddReminder(){
        Console.Write("Add Reminder: ");
        string item = Console.ReadLine();
        reminders.Add(item);

    }

    public static void RemoveReminder(){
        Console.Write("Delete Reminder: ");
        string item = Console.ReadLine();
        reminders.Remove(item);
    }


}
