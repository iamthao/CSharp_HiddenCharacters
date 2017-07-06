using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectDatabase;
using ConnectDatabase.ValueObject;
using ConnectDatabase.Entities;

namespace Repository
{
    public class MilestoneStatusRepository
    {
        private  readonly TestDbContext _context;

        public MilestoneStatusRepository()
        {
             _context = new TestDbContext();
        }
        public MilestoneStatus GetById(int id)
        {
            try
            {
                var entity = _context.MilestoneStatuses.FirstOrDefault(o => o.Id == id);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed.");
            }
        }

    }
}
