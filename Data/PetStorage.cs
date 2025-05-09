using PetVirtual.Models;
using System.IO;

namespace PetVirtual.Data
{
    public static class PetStorage
    {
        private const string path = "petdata.txt";

        public static void Salvar(Pet pet)
        {
            File.WriteAllText(path, $"{pet.Nome};{pet.Energia};{pet.Fome};{pet.Felicidade};{pet.Idade};{pet.Vivo};{pet.Nivel};{pet.Experiencia};{pet.EstadoSaude};{string.Join(",", pet.Conquistas)}");
        }

        public static Pet Carregar()
        {
            if (!File.Exists(path)) return null;

            string[] data = File.ReadAllText(path).Split(';');
            Pet pet = new Pet(data[0]);
            typeof(Pet).GetProperty("Energia").SetValue(pet, int.Parse(data[1]));
            typeof(Pet).GetProperty("Fome").SetValue(pet, int.Parse(data[2]));
            typeof(Pet).GetProperty("Felicidade").SetValue(pet, int.Parse(data[3]));
            typeof(Pet).GetProperty("Idade").SetValue(pet, int.Parse(data[4]));
            typeof(Pet).GetProperty("Vivo").SetValue(pet, bool.Parse(data[5]));
            typeof(Pet).GetProperty("Nivel").SetValue(pet, int.Parse(data[6]));
            typeof(Pet).GetProperty("Experiencia").SetValue(pet, int.Parse(data[7]));
            typeof(Pet).GetProperty("EstadoSaude").SetValue(pet, Enum.Parse<EstadoDeSaude>(data[8]));
            typeof(Pet).GetProperty("Conquistas").SetValue(pet, new List<string>(data[9].Split(',')));
            return pet;
        }
    }
}
