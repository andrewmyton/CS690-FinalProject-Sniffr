namespace sniffr;
using System.Text.Json;
using Spectre.Console;

class Program
{
  
    static void Main(string[] args)
    {
        string[] mainMenu = {"Health", "Reminders"};
        string[] healthOptions = {"Medication", "Vet Records", "Vaccinations"};
        string[] medicationOptions = {"Add Medication", "View Medications"};
        string[] vetRecordOptions = {"Add a Vet Visit", "View Vet Records"};
        string[] vaccinationOptions = {"Add New Vaccination", "View Vaccination Schedule"};
        string[] reminderOptions = {"Reminder List","Add Reminder", "Delete Reminder"};
        string response = " ";

        Console.Clear();
        // instantiate a PetManager
         PetManager petManager = new PetManager();

         if (File.ReadAllText("list-of-pets.txt").Length == 0){
            petManager.AddPet();
        }
        
        // instantiate Reminders 
        Reminders reminders = new Reminders();
        reminders.remindersList = LoadReminders("reminders.txt");
        
    while(response != "q"){
        Console.Clear();
        // load a pet
        string users = File.ReadAllText("list-of-pets.txt");
        string[] userInfo = users.Split(":");
        Pet currentPet = new Pet();
        // currentPet.uid = userInfo[0];
        // currentPet.name = userInfo[1];
        currentPet.healthRecord = new HealthRecord();
         
        
        //start main menu
        Console.Clear();
        var mainMenuChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("How would like to manage your pet: ")
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
            // if you choose Vaccinations
            }else if (healthChoice == "Vaccinations"){
                // check to see if vaccination file has data to load
                if (File.ReadAllText("vaccinations.txt").Length != 0){
                    currentPet.healthRecord.vaccinationRecords = LoadVaccinationRecord(currentPet);
                }
                // prompt for vaccination options
                var vaccinationChoices = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(vaccinationOptions)
                );
                
                // add a vaccination record
                if (vaccinationChoices == "Add New Vaccination"){
                    currentPet.healthRecord.EnterVaccinationRecord();
                    SaveVaccinationRecord(currentPet);
                
                // view vaccination record
                }else if (vaccinationChoices == "View Vaccination Schedule"){
                    if (File.ReadAllText("vaccinations.txt").Length == 0){
                    // message if no vet visits added
                    Console.WriteLine("Add some vaccinations!");
                    }else{
                        foreach (var record in currentPet.healthRecord.vaccinationRecords){
                            Console.WriteLine($"{record.Key} was last given {record.Value[record.Value.Count-1]}.");
                        }
                    }
                }
            
            
            }

        }//end of health choice

        //Main Menu: if you choose Reminders
        else if (mainMenuChoice == "Reminders"){
            var reminderChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(reminderOptions)
        );

        if (reminderChoice == "Reminder List"){
            if (File.ReadAllText("reminders.txt").Length == 0){
                // message if no reminders added
                Console.WriteLine("Add some reminders!");
            }else{
                foreach(string reminder in reminders.remindersList){
                Console.WriteLine(reminder);
                }
            }
        }else if (reminderChoice == "Add Reminder"){
            reminders.AddReminder();
            Console.WriteLine("Reminder Added!");
            SaveReminders(reminders.remindersList);
        }else if (reminderChoice == "Delete Reminder"){
            if (File.ReadAllText("reminders.txt").Length == 0){
                // message if no reminders added
                Console.WriteLine("Add some reminders to delete!");
            }else{
                var itemToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Scroll to select a reminder to delete: ")
                .AddChoices(reminders.remindersList)
                );
                reminders.DeleteReminder(itemToDelete);
                Console.WriteLine("Deleted!");
                SaveReminders(reminders.remindersList);
                }   
            }

        } // end of reminder choice
    
        // user elects to continue program
        Console.Write("\nEnter any key to continue (type q to quit): ");
        response = Console.ReadLine();
        Console.Clear();
        };
    
        

    }
    
   // functions to load and save data
   public static void SaveMedicationData(Pet currentPet){
            Dictionary<string,int> medicationData = currentPet.healthRecord.medications;
            string jsonString = JsonSerializer.Serialize(medicationData);
            File.WriteAllText("medications.txt",jsonString);
            Console.WriteLine("\nData Saved\n");
        }
    
    public static Dictionary<string,int> LoadMedicationData(Pet currentPet){
        string medicationsText = File.ReadAllText("medications.txt");
        Dictionary<string,int> medicationData = JsonSerializer.Deserialize<Dictionary<string,int>>(medicationsText);
        // Console.WriteLine("\nData Loaded\n");   
        return medicationData;
    }

    public static void SaveVetData(Pet currentPet){
        List<DateTime> vetData = currentPet.healthRecord.vetVisits;
        string jsonString = JsonSerializer.Serialize(vetData);
        File.WriteAllText("vetvisits.txt",jsonString);
        Console.WriteLine("\nData Saved\n"); 
    }

    public static List<DateTime> LoadVetData(Pet currentPet){
        string vetVisitsText = File.ReadAllText("vetvisits.txt");
        List<DateTime> vetData = JsonSerializer.Deserialize<List<DateTime>>(vetVisitsText);
        // Console.WriteLine("\nData Loaded\n");
        return vetData;
    }

    public static void SaveVaccinationRecord(Pet currentPet){
        Dictionary<string,List<DateTime>> vaccinationData = currentPet.healthRecord.vaccinationRecords;
        string jsonString = JsonSerializer.Serialize(vaccinationData);
        File.WriteAllText("vaccinations.txt",jsonString);
        Console.WriteLine("\nData Saved\n"); 
    }

    public static Dictionary<string,List<DateTime>> LoadVaccinationRecord(Pet currentPet){
        string vaccinationText = File.ReadAllText("vaccinations.txt");
        Dictionary<string,List<DateTime>> vaccinationData = JsonSerializer.Deserialize<Dictionary<string,List<DateTime>>>(vaccinationText);
        // Console.WriteLine("\nData Loaded\n");
        return vaccinationData;
    }

    public static List<string> LoadReminders(string file){
        List<string> fileContentsList = new List<string>();
        string fileContents = File.ReadAllText(file);
        foreach(string line in fileContents.Split('\n')){
            fileContentsList.Add(line);
        }
        return fileContentsList;
    }

    public static void SaveReminders(List<string> reminders){
        foreach(string reminder in reminders){
        File.WriteAllText("reminders.txt",reminder);
    }
    }


}

  


