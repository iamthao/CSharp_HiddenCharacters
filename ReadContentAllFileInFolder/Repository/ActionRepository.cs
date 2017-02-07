using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectDatabase;
using ConnectDatabase.Entities;

namespace Repository
{
    public class ActionRepository
    {
        private readonly DatabaseContent _context;

        public ActionRepository()
        {
            _context = new DatabaseContent();
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
    }
}
