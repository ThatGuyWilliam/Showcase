using Microsoft.EntityFrameworkCore;
using Showcase.DAL;
using Showcase.Data;
using Showcase.Models.ViewModels;

namespace Showcase.BLL
{
    public class ShowcaseManager
    {
        
        private ShowcaseRepo repo;

        public ShowcaseManager(ApplicationDbContext DBcontext)
        {
            repo = new ShowcaseRepo(DBcontext);
        }
        
        public List<ShowcaseVM> GetAllShowcase()
        {
            return repo.GetAllShowcase();
        }

        public ShowcaseVM GetShowcaseByID(int id)
        {
            return repo.GetShowcaseByID(id);
        }

        public bool HideShowcase(int id)
        {
            return repo.HideShowcase(id);
        }

        public void SaveShowcase(string name, string description, bool hidden)
        {
            repo.SaveShowcase(name, description, hidden);
        }
    }
}
