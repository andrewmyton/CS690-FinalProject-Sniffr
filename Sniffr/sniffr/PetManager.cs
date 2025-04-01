namespace sniffr;

public class PetManager
{
    List<Pet> listOfPets = new List<Pet>();
    Pet currentPet;

    

    public static void AddPet(){
        Console.Write("Enter a pet to manage: ");
        string petName = Console.ReadLine();
        File.AppendAllText("list-of-pets.txt", petName + Environment.NewLine);
    
    }
}
