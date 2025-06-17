using Microsoft.EntityFrameworkCore;
using Showcase.Data;
using Showcase.Models.ViewModels;

namespace Showcase.DAL
{
    public class ShowcaseRepo
    {
        private readonly ApplicationDbContext db;

        public ShowcaseRepo(ApplicationDbContext dbcntx)
        {
            db = dbcntx;
        }

        public List<ShowcaseVM> GetAllShowcase()
        {
            try
            {
                return db.ShowcaseModel.OrderBy(x => x.IsHidden)
                     .Select(vm => new ShowcaseVM
                     {
                         ID = vm.ID,
                         Name = vm.Name,
                         Description = vm.Description,
                         isHidden = vm.IsHidden
                     }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }

        public ShowcaseVM GetShowcaseByID(int id)
        {
            try
            {
                var showcase = db.ShowcaseModel.Where(x => x.ID == id)
                .Select(vm => new ShowcaseVM
                {
                    ID = vm.ID,
                    Name = vm.Name,
                    Description = vm.Description,
                    isHidden = vm.IsHidden
                }).FirstOrDefault();

                return showcase ?? new ShowcaseVM();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public bool HideShowcase(int id)
        {
            try
            {
                var showcase = db.ShowcaseModel.Where(x => x.ID == id).FirstOrDefault();
                if(showcase != null){
                    showcase.IsHidden = true;
                    db.SaveChanges();
                }
                else {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public void SaveShowcase(string name, string description, bool hidden)
        {
            Models.Showcase showcase = new Models.Showcase();
            showcase.Name = name;
            showcase.Description = description;
            showcase.IsHidden = hidden;
            db.ShowcaseModel.Add(showcase);
            db.SaveChanges();

        }


    }
}
