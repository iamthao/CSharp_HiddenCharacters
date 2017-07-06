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
    public class TaskActionRepository
    {
       private  readonly TestDbContext _context;

       public TaskActionRepository()
        {
             _context = new TestDbContext();
        }
       public TaskAction GetById(int id)
       {
           try
           {
               var entity = _context.TaskActions.FirstOrDefault(o => o.Id == id);
               return entity;
           }
           catch (Exception ex)
           {
               throw new Exception("Failed.");
           }
       }

        public TaskAction GetTaskIdAndActionId(int taskId, int actionId)
        {
            try
            {
                var entity = _context.TaskActions.FirstOrDefault(o => o.TaskId == taskId && o.ActionId == actionId);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed.");
            }
        }


        
    }
}
