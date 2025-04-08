namespace sniffr;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
         if (File.ReadAllText("list-of-pets.txt").Length == 0){
            petManager.AddPet();
        }
        
        // load a pet
        PetManager petManager = new PetManager();
        string users = File.ReadAllText("list-of-pets.txt");
        string[] userInfo = users.Split(":");
        Pet currentPet = new Pet();
        currentPet.uid = userInfo[0];
        currentPet.name = userInfo[1];
        currentPet.healthRecord = new HealthRecord();
        
        

    }



}
