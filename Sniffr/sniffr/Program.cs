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
                // check to see if medication file has data to load
                if (File.ReadAllText("medications.txt").Length != 0){
                    currentPet.healthRecord.medications = LoadMedicationData(currentPet);
                }
                // prompt for medication options
                var medicationChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(medicationOptions)
                );
                // add medication
                if (medicationChoice == "Add Medication"){
                    currentPet.healthRecord.AddMedication();
                    SaveMedicationData(currentPet);
                // view medications
                }else if (medicationChoice == "View Medications"){
                    if (File.ReadAllText("medications.txt").Length == 0){
                    // message if no medications added
                    Console.WriteLine("Add some meds!");
                    }else{
                        foreach (var medication in currentPet.healthRecord.medications){
                        Console.WriteLine(medication.Key);
                    }
                }                  
                }
            
            // if you choose Vet Records           
            }else if (healthChoice == "Vet Records"){
                // check to see if vetvisits file has data to load
                if (File.ReadAllText("vetvisits.txt").Length != 0){
                    currentPet.healthRecord.vetVisits = LoadVetData(currentPet);
                }
                // prompt for vet options
                var vetRecordChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(vetRecordOptions)
                );
                // add a vet visit
                if (vetRecordChoice == "Add a Vet Visit"){
                    currentPet.healthRecord.EnterVetRecord();
                    SaveVetData(currentPet);
                //view vet visits
                }else if (vetRecordChoice == "View Vet Records"){
                    if (File.ReadAllText("vetvisits.txt").Length == 0){
                    // message if no vet visits added
                    Console.WriteLine("Add some vet visits!");
                    }else{
                        foreach (DateTime record in currentPet.healthRecord.vetVisits){
                        Console.WriteLine(record.ToString());
                    }
                    }
                    
                }
            // if you choose Immunizations
            }else if (healthChoice == "Immunizations"){
                var immunizationChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(immunizationOptions)
                );
            }

        }//end of health choice

        //Main Menu: if you choose Reminders
        else if (mainMenuChoice == "Reminders"){
            var reminderChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(reminderOptions)
        );

        }
    
    
        
    
        

    }
    
   //save medication data
   public static void SaveMedicationData(Pet currentPet){
            Dictionary<string,int> medicationData = currentPet.healthRecord.medications;
            string jsonString = JsonSerializer.Serialize(medicationData);
            File.AppendAllText("medications.txt",jsonString);
            Console.WriteLine("Data Saved\n");
        }
    
    public static Dictionary<string,int> LoadMedicationData(Pet currentPet){
        string medicationsText = File.ReadAllText("medications.txt");
        Dictionary<string,int> medicationData = JsonSerializer.Deserialize<Dictionary<string,int>>(medicationsText);
        Console.WriteLine("Data Loaded\n");   
        return medicationData;
    }

    public static void SaveVetData(Pet currentPet){
        List<DateTime> vetData = currentPet.healthRecord.vetVisits;
        string jsonString = JsonSerializer.Serialize(vetData);
        File.AppendAllText("vetvisits.txt",jsonString);
        Console.WriteLine("Data Saved\n"); 
    }

    public static List<DateTime> LoadVetData(Pet currentPet){
        string vetVisitsText = File.ReadAllText("vetvisits.txt");
        List<DateTime> vetData = JsonSerializer.Deserialize<List<DateTime>>(vetVisitsText);
        Console.WriteLine("Data Loaded\n");
        return vetData;
    }
}

  


