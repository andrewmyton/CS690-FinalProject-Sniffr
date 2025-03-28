namespace sniffr;

public class HealthRecord
{
    public Dictionary<string,int> medications = new Dictionary<string,int>();
    public Dictionary<string, List<Datetime>> medicationAdministered = new Dictionary<string, List<Datetime>>();
    public List<DateTime> vetVisits = new List<DateTime>();
    public Dictionary<string,List<DateTime>> vaccinationRecords = new Dictionary<string, List<DateTime>>();
    



    public void AddMedication(){
        Console.Write("Enter medication name: ");
        string medication = Console.ReadLine();

        Console.Write("How often is this medication given (in days): ");
        int interval = int.Parse(Console.ReadLine());

        Console.Write("Enter last administration date (MM/DD/YYYY): ")
        
    }
    
}
