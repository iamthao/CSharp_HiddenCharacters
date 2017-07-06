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
    public class LibTaskRepository
    {
        private  readonly TestDbContext _context;

        public LibTaskRepository()
        {
             _context = new TestDbContext();
        }
        public LibTask GetById(int id)
        {
            try
            {
                var entity = _context.LibTasks.FirstOrDefault(o => o.Id == id);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
