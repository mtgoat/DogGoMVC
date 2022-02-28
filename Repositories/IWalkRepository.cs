using DogGoMVC.Models;
using System.Collections.Generic;

namespace DogGoMVC.Repositories
{
    public interface IWalkRepository
    {
        List<Walk> GetAllWalks();
        List<Walk> GetWalksByWalkerId(int Id);
        
    }
}
