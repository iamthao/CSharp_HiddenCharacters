using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectDatabase;
using ConnectDatabase.ValueObject;
using ConnectDatabase.Entities;

namespace Repository
{
    public class MilestoneRepository
    {
        private  readonly TestDbContext _context;

        public MilestoneRepository()
        {
             _context = new TestDbContext();
        }
        public List<MilestoneGridvo> GetListLibTask()
        {
            var data = _context.Milestones.Select(o => new MilestoneGridvo
            {
                Id = o.Id,
                Name = o.Name,
            }).ToList();

            return data;
        }
        public Milestone GetById(int id)
        {
            try
            {
                var entity = _context.Milestones.FirstOrDefault(o => o.Id == id);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed.");
            }
        }

        public Milestone CreateOrUpdate(Milestone entity)
        {
            try
            {
                _context.Entry(entity).State = entity.Id ==0 ? EntityState.Added:  EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed.");
            }
        }

    }
}
