namespace sniffr;

public class Reminders
{
    public List<string> remindersList = new List<string>();
    

    public void AddReminder(){
        Console.Write("Add Reminder: ");
        string item = Console.ReadLine();
        remindersList.Add(item);

    }

    public void RemoveReminder(string item){
        remindersList.Remove(item);
    }


}
