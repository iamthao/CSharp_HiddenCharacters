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
    public class DatabaseVersionRepository
    {
        private  readonly TestDbContext _context;

        public DatabaseVersionRepository()
        {
             _context = new TestDbContext();
        }
       
        public DatabaseVersion GetById(int id)
        {
            try
            {
                var entity = _context.DatabaseVersions.FirstOrDefault(o => o.Id == id);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed.");
            }
        }

        public DatabaseVersion FirstOrDefault()
        {
            try
            {
                var entity = _context.DatabaseVersions.FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed.");
            }
        }
    }
}
