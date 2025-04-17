namespace Sniffr.Tests;
using sniffr;


public class RemindersTests
{
Reminders reminders;
string item;

public RemindersTests(){
    item = "buy food";
    reminders = new Reminders();

}

[Fact]
public void Test_DeleteReminder()
{
    reminders.remindersList.Add(item);
    reminders.DeleteReminder(item);
    Assert.DoesNotContain(item,reminders.remindersList);
}



}