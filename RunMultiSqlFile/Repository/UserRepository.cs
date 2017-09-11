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
    public class UserRepository
    {
        private  readonly TestDbContext _context;

        public UserRepository()
        {
             _context = new TestDbContext();
        }
        public List<UserGridVo> GetListLibTask()
        {
            var data = _context.Users.Select(o => new UserGridVo()
            {
                Id = o.Id,
                UserName = o.UserName,
            }).ToList();

            return data;
        }
        public User GetById(int id)
        {
            try
            {
                var entity = _context.Users.FirstOrDefault(o => o.Id == id);
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
