namespace sniffr;
using System.Text.Json;
using Spectre.Console;

class Program
{
  
    static void Main(string[] args)
    {
        string[] mainMenu = {"Health", "Reminders"};
        string[] healthChoices = {"Medication", "Vet Records", "Immunizations"};

        //  PetManager petManager = new PetManager();

        //  if (File.ReadAllText("list-of-pets.txt").Length == 0){
        //     petManager.AddPet();
        // }
        
        // // load a pet
        // string users = File.ReadAllText("list-of-pets.txt");
        // string[] userInfo = users.Split(":");
        // Pet currentPet = new Pet();
        // currentPet.uid = userInfo[0];
        // currentPet.name = userInfo[1];
        // currentPet.healthRecord = new HealthRecord();
        
        
        var menuChoices = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("How would like to manage your pet: ")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to select choice)[/]")
            .AddChoices(mainMenu));
        

    
    
    }

  

}
