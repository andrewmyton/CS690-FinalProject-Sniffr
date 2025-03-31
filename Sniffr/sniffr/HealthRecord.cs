namespace sniffr;

public class HealthRecord
{
    public Dictionary<string,int> medications = new Dictionary<string,int>();
    public Dictionary<string, List<Datetime>> medicationAdministered = new Dictionary<string, List<Datetime>>();
    public List<DateTime> vetVisits = new List<DateTime>();
    public Dictionary<string,List<DateTime>> vaccinationRecords = new Dictionary<string, List<DateTime>>();
    public Dictionary<string,DateTime> medicationDue  = new Dictionary<string,DateTime>();



    public void AddMedication(){
        Console.Write("Enter medication to add: ");
        string medication = Console.ReadLine();
        medications.Add(medication);

        Console.Write("How often is this medication given (in days): ");
        int interval = int.Parse(Console.ReadLine());

        Console.Write("Enter last administration date (MM/DD/YYYY): ")
        DateTime dateAdministered = DateTime.Parse(Console.ReadLine());

        if(!medicationAdministered.ContainsKey(medication)){
            List<DateTime> dates = new List<DateTime>();
            dates.Add(dateAdministered);
            medicationAdministered.Add(medication,dates);
        }else{
            medicationAdministered[medication].Add(dateAdministered);
        }
    
    
    }
    
    public void EnterVetRecord(){
        Console.Write("Enter vet visit (MM/DD/YYYY): ");
        DateTime vetApptDate = DateTime.Parse(Console.ReadLine());
        vetVisits.Add(vetApptDate);
    }

    public void GiveMedication(string medication){
        
    }

}
