using Showcase.DAL;
using Showcase.Data;
using Showcase.Models.ViewModels;

namespace Showcase.BLL
{
    public class TeamsManager
    {
        private TeamsRepo repo;

        public TeamsManager(ApplicationDbContext DBcontext)
        {
            repo = new TeamsRepo(DBcontext);
        }

        public List<TeamsVM> GetAllTeams()
        {
            return repo.GetAllTeams();
        }

        public TeamsVM GetTeamByID(int ID)
        {
            return repo.GetTeamByID(ID);
        }

        public bool HideTeam(int ID)
        {
            return repo.HideTeam(ID);
        }

        public void SaveTeam(string Name, string Description, bool active)
        {
            repo.SaveTeam(Name, Description, active);
        }

    }
}
