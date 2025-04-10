namespace sniffr;
using System.Text.Json;
using Spectre.Console;

class Program
{
  
    static void Main(string[] args)
    {
        string[] mainMenu = {"Health", "Reminders"};
        string[] healthOptions = {"Medication", "Vet Records", "Immunizations"};
        string[] medicationOptions = {"Add Medication", "View Medications"};
        string[] vetRecordOptions = {"Add a Vet Visit", "View Vet Records"};
        string[] immunizationOptions = {"Add New Immunication ", "View Immunization Schedule"};
        string[] reminderOptions = {"Add Reminder", "Reminder List"};



        //  PetManager petManager = new PetManager();

        //  if (File.ReadAllText("list-of-pets.txt").Length == 0){
        //     petManager.AddPet();
        // }
        
        // load a pet
        string users = File.ReadAllText("list-of-pets.txt");
        string[] userInfo = users.Split(":");
        Pet currentPet = new Pet();
        currentPet.uid = userInfo[0];
        currentPet.name = userInfo[1];
        currentPet.healthRecord = new HealthRecord();
        
        //start main menu
        var mainMenuChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\nHow would like to manage your pet: ")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to select choice)[/]")
            .AddChoices(mainMenu));
        
        // Main Menu: if you choose Health
        if (mainMenuChoice == "Health"){
            var healthChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(healthOptions)
            );
            //if you choose Medication
            if (healthChoice == "Medication"){
                var medicationChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(medicationOptions)
                );
                if (medicationChoice == "Add Medication"){
                    currentPet.healthRecord.AddMedication();
                    SaveMedicationData(currentPet);
                }
            // if you choose Vet Records
            }else if (healthChoice == "Vet Records"){
                var vetRecordChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(vetRecordOptions)
                );
            // if you choose Immunizations
            }else if(healthChoice == "Immunizations"){
                var immunizationChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(immunizationOptions)
                );
            }

        }//end of health choise

        //Main Menu: if you choose Reminders
        else if (mainMenuChoice == "Reminders"){
            var reminderChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(reminderOptions)
        );

        }
    
    
        
        LoadMedicationData();
        

    }
    
   //save medication data
   public static void SaveMedicationData(Pet currentPet){
            Dictionary<string,int> medicationData = currentPet.healthRecord.medications;
            string jsonString = JsonSerializer.Serialize(medicationData);
            File.AppendAllText("medications.txt",jsonString);
            Console.WriteLine("Data Saved");
        }
    
    public static void LoadMedicationData(){
        string medicationsText = File.ReadAllText("medications.txt");
        Dictionary<string,int> medicationData = JsonSerializer.Deserialize<Dictionary<string,int>>(medicationsText);
        Console.WriteLine("Data Loaded");   
    }

}

  


