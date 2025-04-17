namespace sniffr;
using Spectre.Console;

public class HealthRecord
{
    public Dictionary<string,int> medications = new Dictionary<string,int>();
    public Dictionary<string, DateTime> medicationAdministered = new Dictionary<string, DateTime>();
    public List<DateTime> vetVisits = new List<DateTime>();
    public Dictionary<string,List<DateTime>> vaccinationRecords = new Dictionary<string, List<DateTime>>();



    public void AddMedication(){
        Console.Write("Enter medication to add: ");
        string medication = Console.ReadLine();
        
        Console.Write("How often is this medication given (in days): ");
        int interval = int.Parse(Console.ReadLine());

        medications.Add(medication,interval);

        Console.Write("Enter last administration date (MM/DD/YYYY): ");
        DateTime dateAdministered = DateTime.Parse(Console.ReadLine());
        medicationAdministered[medication] = dateAdministered;
    }
    
    public void EnterVetRecord(){
        Console.Write("Enter vet visit (MM/DD/YYYY): ");
        DateTime vetApptDate = DateTime.Parse(Console.ReadLine());
        vetVisits.Add(vetApptDate);
    }

    public void EnterVaccinationRecord(){
        Console.Write("Enter vaccionation: ");
        string vaccination = Console.ReadLine();

        Console.Write("Enter date given (MM/DD/YYYY): ");
        DateTime vaccinationDate = DateTime.Parse(Console.ReadLine());

        if(!vaccinationRecords.ContainsKey(vaccination)){
            List<DateTime> dates = new List<DateTime>();
            dates.Add(vaccinationDate);
            vaccinationRecords.Add(vaccination,dates);
        }else{
            vaccinationRecords[vaccination].Add(vaccinationDate);
        }
    }

    public void GiveMedication(Dictionary<string,int> medications){
        List<string> medicationList= new List<string>();
        foreach (string medication in medications.Keys){
            medicationList.Add(medication);
        }

        var medicationChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select medication to give: ")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to select choice)[/]")
            .AddChoices(medicationList));
            medicationAdministered[medicationChoice]= DateTime.Today;
    }

    public void ViewMedicationDue(Dictionary<string,int> medications,Dictionary<string, DateTime> medicationAdministered){
        foreach(var medication in medications){ 
            System.TimeSpan duration = new System.TimeSpan(medication.Value,0,0,0);
            Console.WriteLine($"{medication.Key} is due {medicationAdministered[medication.Key].Add(duration).ToString("MM/dd/yyyy")}");
        }       
        // {medicationAdministered[medication.Key].Value[medicationAdministered[medication.Key].Value.Count-1].Add(medication.Value).ToString("MM/dd/yyyy")}

        }
    

}
