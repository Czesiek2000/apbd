using cwiczenia4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia4.Services.Animals
{
    public interface IAnimalDbService
    {
        public List<Animal> GetAnimals(string orderBy);

        public int AddAnimal (Animal animal);

        public int UpdateAnimal (Animal animal, int idAnimal);

        public int DeleteAnimal ( int idAnimal );

    }
}
