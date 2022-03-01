using DogGoMVC.Models;
using DogGoMVC.Models.ViewModels;
using DogGoMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Claims;

namespace DogGoMVC.Controllers
{
    public class WalkersController : Controller
    {
        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalkRepository _walkRepo;
        private readonly IOwnerRepository _ownerRepo;
        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalkersController(IWalkerRepository walkerRepository, IWalkRepository walkRepository, IOwnerRepository ownerRepository)
        {
            _walkerRepo = walkerRepository;
            _walkRepo = walkRepository;
            _ownerRepo = ownerRepository;
        }
        // GET: WalkersController
        public ActionResult Index()
        {
                //variable to get currentID user
                int currentOwnerId = GetCurrentUserId();

            //if no one signed in, the GetCurrentUserId is set to -0. See the GetCurrentUserId at the bottom
            if (currentOwnerId != -0)
            {
                //get owners by the current ownerId 
                Owner owner = _ownerRepo.GetOwnerById(currentOwnerId);


                List<Walker> walkers = _walkerRepo.GetAllWalkers();

                //filtering all walkers to only walkers with the same neighb id as the owner.neighb id

                List<Walker> NeightWalkers = walkers.Where(w => w.NeighborhoodId == owner.NeighborhoodId).ToList();



                return View(NeightWalkers);
            }
            else
            {

                List<Walker> walkers = _walkerRepo.GetAllWalkers();
                return View(walkers);

            }
            
        }

        // GET: WalkersController/Details/5
        public ActionResult Details(int id)
        {
            WalkerProfileViewModel vm = new WalkerProfileViewModel()
            {
                Walker = _walkerRepo.GetWalkerById(id),
                Walks = _walkRepo.GetWalksByWalkerId(id)
            };
            return View(vm);
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id?? "-0");
        }

    }
}
