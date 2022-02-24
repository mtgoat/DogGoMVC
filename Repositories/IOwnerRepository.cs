using DogGoMVC.Models;
using System.Collections.Generic;

namespace DogGoMVC.Repositories
{
    public interface IOwnerRepository
    {

        List<Owner> GetAllOwners();
        List<Dog> GetDogsByOwner(int ownerId);
        
        
        Owner GetOwnerById(int id);
        
        Owner GetOwnerByEmail(string email);

        void AddOwner(Owner owner);

        void UpdateOwner(Owner owner);

        void DeleteOwner(int ownerId);
    }
}
