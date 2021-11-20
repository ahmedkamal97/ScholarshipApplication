using Auc.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auc.Data.DAL;
using System.Data.Entity.Migrations;

namespace Auc.Data.Repositories
{
    public class StudentsRepo:IStudentsRepo
    {
        private AUCDBEntities _db;
        public StudentsRepo()
        {
            _db = new AUCDBEntities();
        }

        public void Add(tblStudent Entity)
        {
            _db.tblStudents.AddOrUpdate(x=> new { x.UserId,x.NationalId},Entity);
        }

     

        public IEnumerable<tblStudent> GetStudents()
        {
            return _db.tblStudents;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(tblStudent Entity)
        {
            var Student = _db.tblStudents.FirstOrDefault(c => c.Id == Entity.Id);
            Student.FirstName = Entity.FirstName;
            Student.SecondName = Entity.SecondName;
            Student.BirthDate = Entity.BirthDate;
            Student.NationalId = Entity.NationalId;
            Student.University = Entity.University;
            Student.Major = Entity.Major;
            Student.GPA = Entity.GPA;
            Student.StatusId = Entity.StatusId;

        }

        public void UpdateStatus(int? StatusId,int StudentId)
        {
            var Student = _db.tblStudents.FirstOrDefault(c => c.Id == StudentId);
            Student.StatusId = StatusId;
        }
    }
}
