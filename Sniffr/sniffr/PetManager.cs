namespace sniffr;

public class PetManager
{
    public List<Pet> listOfPets = new List<Pet>();
    Pet currentPet;

    

    public void AddPet(){
        Console.Write("Enter a pet to manage: ");
        string petName = Console.ReadLine();
        string newUID = Guid.NewGuid().ToString();
        File.AppendAllText("list-of-pets.txt", newUID + ":" + petName + Environment.NewLine);
        Pet pet = new Pet();
        pet.name = petName;
        pet.uid = newUID;
        Console.Write("Enter "+petName+"'s birthday (MM/DD/YYYY): ");
        pet.dateOfBirth = DateTime.Parse(Console.ReadLine());

        
    }

    public string ReadPets(){
        string userList = File.ReadAllText("list-of-pets.txt");
        return userList;
    }

  
}
