﻿namespace sniffr;

class Program
{
    static void Main(string[] args)
    {
        Pet pet = new Pet();
        pet.name = "Norbert";
        Console.WriteLine(pet.name);

        PetManager.AddPet();
    }
}
