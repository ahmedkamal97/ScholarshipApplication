using Auc.Common.ViewModels.Students;
using Auc.Data.DAL;
using Auc.Data.Interfaces;
using Auc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Service.Services
{
    public class StudentService
    {
        private IStudentsRepo _repo;
        public StudentService()
        {
            _repo = new StudentsRepo();
        }


        public IEnumerable<StudentVM> GetStudents()
        {
            return _repo.GetStudents()
                 .Where(c => c.Removed == false)
                 .Select(x => new StudentVM
                 {
                     Id = x.Id,
                     UserId = x.UserId,
                     FirstName = x.FirstName,
                     SecondName = x.SecondName,
                     BirthDate = x.BirthDate,
                     BirthDataStr = x.BirthDate.Value.ToString("dd MMM yyyy"),
                     NationalId = x.NationalId,
                     UniversityId = x.University,
                     UniversityName = x.tblUniversity?.Name,
                     Major = x.Major,
                     GPA = x.GPA,
                     ResumePath = x.Resume,
                     StatusId = x.StatusId,
                     Status=x.tblAppStatu?.ApplicationStatus,
                     EmailAddress=x.tblUser?.EmailAddress
                 });
        }

        public StudentVM GetStudent(int UserId)
        {
            var Entity = _repo.GetStudents()
                 .FirstOrDefault(c => c.Removed == false && c.UserId == UserId);

            return new StudentVM
            {
                Id = Entity.Id,
                UserId = Entity.UserId,
                FirstName = Entity.FirstName,
                SecondName = Entity.SecondName,
                BirthDate = Entity.BirthDate,
                BirthDataStr = Entity.BirthDate.Value.ToString("dd MMM yyyy"),
                NationalId = Entity.NationalId,
                UniversityId = Entity.University,
                UniversityName=Entity.tblUniversity?.Name,
                Major = Entity.Major,
                GPA = Entity.GPA,
                ResumePath = Entity.Resume,
                StatusId = Entity.StatusId,
                Status = Entity.tblAppStatu?.ApplicationStatus,
                EmailAddress=Entity.tblUser?.EmailAddress


            };
        }

                

        public IEnumerable<StudentVM> GetStudents(string Name, int? UniversityId, int? AppStatus)
        {
            var Students = GetStudents();


            if (Name != null)
                Students = Students.Where(c => c.FirstName.ToLower().Contains(Name.ToLower()) ||
                c.SecondName.ToLower().Contains(Name.ToLower()));

            if (UniversityId != null)
                Students = Students.Where(c => c.UniversityId == UniversityId);

            if (AppStatus != null)
                Students = Students.Where(c => c.StatusId == AppStatus);

            return Students;

        }


        public void Add(AddStudentVM Entity)
        {
            var Student = new tblStudent
            {
                UserId=Entity.UserId,
                FirstName=Entity.FirstName,
                SecondName=Entity.SecondName,
                BirthDate=Entity.BirthDate,
                NationalId=Entity.NationalId,
                University=Entity.University,
                Major=Entity.Major,
                GPA=Entity.GPA,
                Resume=Entity.ResumePath,
                StatusId=StaticAppStatus.Pending,
                Removed=false
            };
            _repo.Add(Student);
            _repo.Save();
        }


        public void Update(StudentVM Entity)
        {
            var Student = new tblStudent
            {
                Id=Entity.Id,
                UserId = Entity.UserId,
                FirstName = Entity.FirstName,
                SecondName = Entity.SecondName,
                BirthDate = Entity.BirthDate,
                NationalId = Entity.NationalId,
                University = Entity.UniversityId,
                Major = Entity.Major,
                GPA = Entity.GPA,
                Resume = Entity.ResumePath,
                StatusId = StaticAppStatus.Pending,
                Removed = false
            };
            _repo.Update(Student);
            _repo.Save();


        }
        
        public bool CheckExsistApp(int UserId)
        {
            var Application = GetStudents().FirstOrDefault(c => c.UserId == UserId);
            if (Application != null)
                return true;
            else
                return false;
        }


        public void Update(int? StatusId,int StudentId)
        {
            _repo.UpdateStatus(StatusId, StudentId);
            _repo.Save();
        }


        public DataTable ExportApplications(string Name, int? UniversityId, int? AppStatus)
        {
            IEnumerable<StudentVM> Applications = GetStudents(Name, UniversityId, AppStatus);
            DataTable DT = new DataTable();
            DT.Columns.Add("First Name", typeof(string));
            DT.Columns.Add("Second Name", typeof(string));
            DT.Columns.Add("Birth Date", typeof(string));
            DT.Columns.Add("National Id", typeof(string));
            DT.Columns.Add("University", typeof(string));
            DT.Columns.Add("Major", typeof(string));
            DT.Columns.Add("GPA", typeof(string));
            DT.Columns.Add("Status", typeof(string));

            foreach(var item in Applications)
            {
                DT.Rows.Add(item.FirstName, item.SecondName, item.BirthDataStr, item.NationalId, item.UniversityName, item.Major, item.GPA, item.Status);
            }

            return DT;
        }
         

  
    }
}
