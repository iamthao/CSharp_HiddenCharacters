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
    public class SectionQuestionRepository 
    {
         private  readonly TestDbContext _context;

        // public SectionQuestionRepository()
        //{
        //     _context = new TestDbContext();
        //}
        //public SectionQuestion GetById(int id)
        //{
        //    try
        //    {
        //        var entity = _context.SectionQuestions.FirstOrDefault(o => o.Id == id);
        //        return entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public List<SectionQuestion> GetAll()
        //{
        //    try
        //    {
        //        var entity = _context.SectionQuestions.ToList();               
        //        return entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        
    }
}
