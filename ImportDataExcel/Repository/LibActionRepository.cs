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
    public class LibActionRepository 
    {
         private  readonly TestDbContext _context;

         public LibActionRepository()
        {
             _context = new TestDbContext();
        }
        public LibAction GetById(int id)
        {
            try
            {
                var entity = _context.LibActions.FirstOrDefault(o => o.Id == id);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LibAction> GetAll()
        {
            try
            {
                var entity = _context.LibActions.ToList();
                //var entity = _context.LibActions.Select( s => new LibAction
                //{
                //    Id =  s.Id,
                //    RouteName = s.RouteName,
                //    ActionProperty = s.ActionProperty
                //}).ToList();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
