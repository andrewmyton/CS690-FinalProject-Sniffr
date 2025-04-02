namespace sniffr;

public class PetManager
{
    List<Pet> listOfPets = new List<Pet>();
    Pet currentPet;

    

    public void AddPet(){
        Console.Write("Enter a pet to manage: ");
        string petName = Console.ReadLine();
        File.AppendAllText("list-of-pets.txt", Guid.NewGuid() + ":" + petName + Environment.NewLine);
    
    }

    public string ReadPets(){
        string userList = File.ReadAllText("list-of-pets.txt");
        return userList;
    }

    public Pet SetCurrentPet(){
        
    }
}
