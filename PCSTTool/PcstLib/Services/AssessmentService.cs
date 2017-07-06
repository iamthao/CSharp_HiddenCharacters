using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite;
using PcstLib.Sqlite.Entities;
using PcstLib.Sqlite.ValueObject;

namespace PcstLib.Services
{
    public partial class AssessmentService
    {

        public Assessment GetById(int id)
        {
            using (var context = new AssessmentContext())
            {
                return context.Assessments.FirstOrDefault(t => t.Id == id);
            }
        }
        public IList<AssessmentVo> GetAllAssessment(int pageSize, int pageNum,out int total)
        {
            using (var context = new AssessmentContext())
            {
                //context.Assessments.Add(new Assessment() { FileName = "Abc", FilePath = "111", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now, AssessmentSectionQuestions = new List<AssessmentSectionQuestion>(), AssessmentData = "AssessmentData", DisclosureFormData = "DisclosureFormData" });
                //context.SaveChanges();
                var query = context.Assessments
                    .Select(t => new AssessmentVo
                    {
                        Id = t.Id,
                        FilePath = t.FilePath,
                        FileName = t.FileName,
                        CreatedOn = t.CreatedOn,
                        ModifiedOn = t.ModifiedOn
                    }).OrderBy(t => t.Id);
                total = query.Count();
                var list = query.OrderByDescending(t=>t.Id).Skip(pageNum*pageSize).Take(pageSize).ToList();
                return list;
            }
        }

        public bool DeleteAssessment(int id)
        {
            using (var context = new AssessmentContext())
            {
                var assessment=context.Assessments.FirstOrDefault(t => t.Id == id);
                if (assessment!=null)
                {
                    context.Assessments.Remove(assessment);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public int NewRecord(string fileName)
        {
            using (var context = new AssessmentContext())
            {
                var entity = new Assessment
                {
                    FileName = fileName,
                    FilePath = "",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,                
                };
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();

                return entity.Id;
            }
        }

        public IList<AssessmentVo> GetAllAssessmentThao(int skip, int take, out int total)
        {
            using (var context = new AssessmentContext())
            {
                //context.Assessments.Add(new Assessment() { FileName = "Abc", FilePath = "111", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now, AssessmentSectionQuestions = new List<AssessmentSectionQuestion>(), AssessmentData = "AssessmentData", DisclosureFormData = "DisclosureFormData" });
                //context.SaveChanges();
                var query = context.Assessments
                    .Select(t => new AssessmentVo
                    {
                        Id = t.Id,
                        FilePath = t.FilePath,
                        FileName = t.FileName,
                        CreatedOn = t.CreatedOn,
                        ModifiedOn = t.ModifiedOn

                    }).OrderBy(t => t.Id);
                total = query.Count();
                var list = query.OrderByDescending(t => t.Id).Skip(skip).Take(take).ToList();
                return list;
            }
        }

        public bool CheckNameExist(string fileName)
        {
            using (var context = new AssessmentContext())
            {
                var assessment = context.Assessments.FirstOrDefault(t => t.FileName.ToLower().Equals(fileName.Trim().ToLower()));
                if (assessment!= null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
