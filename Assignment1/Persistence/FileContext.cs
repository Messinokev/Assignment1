using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Assignment1.Models;

namespace Assignment1.Persistence
{
    public class FileContext
    {
        public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void removeFamily(Family family)
        {
            Families.Remove(family);
            SaveChanges();
        }

        public void AddAdult(Adult adult)
        {
            int max = Adults.Count;
            adult.Id = max;
            Adults.Add(adult);
            SaveChanges();
        }

        public void AddPet(Pet pet, Family family)
        {
            int max = family.Pets.Count;
            pet.Id = max;
            family.Pets.Add(pet);
            SaveChanges();
        }

        public void updateAdult(Adult adult)
        {
            int max = Adults.Count;
            adult.Id = max;
            Adults.Add(adult);
            SaveChanges();
        }

        public Adult getAdultById(int adultId)
        {
            Adult returnAdult = new Adult();
            foreach (var adult in Adults)
            {
                if (adult.Id == adultId)
                {
                    returnAdult = adult;
                }
            }
            return returnAdult;
        }

        public void SaveChanges()
        {
            // storing families
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }
    }
}