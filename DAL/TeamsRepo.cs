using Showcase.Data;
using Showcase.Models;
using Showcase.Models.ViewModels;

namespace Showcase.DAL
{
    public class TeamsRepo
    {
        private readonly ApplicationDbContext db;

        public TeamsRepo(ApplicationDbContext dbcntx)
        {
            db = dbcntx;
        }

        public List<TeamsVM> GetAllTeams()
        {
            try
            {
                return db.TeamsModel.OrderBy(x => x.IsActive)
                     .Select(vm => new TeamsVM
                     {
                         Id = vm.Id,
                         Name = vm.Name,
                         Description = vm.Description,
                         IsActive = vm.IsActive,
                     }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TeamsVM GetTeamByID(int ID)
        {
            try
            {
                var team = db.TeamsModel.Where(x => x.Id == ID)
                .Select(vm => new TeamsVM
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Description = vm.Description,
                    IsActive = vm.IsActive,
                }).FirstOrDefault();

                return team ?? new TeamsVM();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool HideTeam(int ID)
        {
            try
            {
                var showcase = db.TeamsModel.Where(x => x.Id == ID).FirstOrDefault();
                if (showcase == null)
                {
                    return false;
                    
                }
                showcase.IsActive = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SaveTeam(string Name, string Description, bool active)
        {
            try
            {
                Models.Team team = new Models.Team();
                team.Name = Name;
                team.Description = Description;
                team.IsActive = active;
                db.TeamsModel.Add(team);
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
