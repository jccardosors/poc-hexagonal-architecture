using Domain.Adapters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataBase.InMemory.Repositories
{
    public class ClubRepository : IClubRepository
    {
        public async Task<IEnumerable<Club>> GetAll()
        {
            //throw new NotImplementedException();
            var clubList = new List<Club>();
            clubList.Add(new Club()
            {
                Id = 1,
                Name = "Test"
            });

            return await Task.FromResult(clubList.AsEnumerable<Club>());
        }

        public async Task<int> Insert(Club club)
        {
            return await Task.FromResult(club.Id);
        }
    }
}
