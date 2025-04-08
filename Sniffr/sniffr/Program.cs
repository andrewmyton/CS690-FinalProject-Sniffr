namespace sniffr;

class Program
{
    static void Main(string[] args)
    {
        PetManager petManager = new PetManager();

        if (File.ReadAllText("list-of-pets.txt").Length == 0){
            petManager.AddPet();
        }else{
            while (true){
            Console.Write("Enter command (q to quit program): ");
            string response = Console.ReadLine();
            if (response == "q"){
                break;
            }else if(response == "p"){
                Console.WriteLine(petManager.ReadPets());
            }

            }
        }
    }
}
