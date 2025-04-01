namespace sniffr;

public class Reminders
{
    public List<string> reminders = new List<string>();

    public static void AddReminder(){
        Console.Write("Add Reminder: ")
        string item = Console.ReadLine();
        reminders.Add(item);

    }

    public static void RemoveReminder(string item){
        reminders.Remove(item);
    }


}
