using Auc.Common.ViewModels.Students;
using Auc.Service.Services;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUCProject.Controllers
{
    public class StudentsController : Controller
    {

        private StudentService _studentService;
        private UniversityService _universityService;
        private AppStatusService _statusService; 
        public StudentsController()
        {
            _studentService = new StudentService();
            _universityService = new UniversityService();
            _statusService = new AppStatusService();
        }



        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Universities = _universityService.GetUniversity();
            ViewBag.Status = _statusService.GetAppStatuses();
            var Filter = new StudentFilter
            {
                Name=null,
                StatusId=null,
                University=null
            };

            var ViewModel = new StudentsContainerVM
            {
                Student=_studentService.GetStudents(Filter.Name,Filter.University,Filter.StatusId),
                Filter=Filter
            };
            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Index(StudentsContainerVM Entity)
        {
            ViewBag.Universities = _universityService.GetUniversity();
            ViewBag.Status = _statusService.GetAppStatuses();

            Entity.Filter = new StudentFilter
            {
                Name = Entity.Filter.Name,
                StatusId = Entity.Filter.StatusId,
                University = Entity.Filter.University
            };

            var ViewModel = new StudentsContainerVM
            {
                Student = _studentService.GetStudents(Entity.Filter.Name,Entity.Filter.University,Entity.Filter.StatusId),
                Filter = Entity.Filter
            };
            return View(ViewModel);
        }


        [HttpGet]
        public ActionResult NewApp(int UserId)
        {
            ViewBag.UserId = UserId;
            ViewBag.Universities = _universityService.GetUniversity();
            return View();
        }

        [HttpPost]
        public ActionResult NewApp(AddStudentVM Entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Universities = _universityService.GetUniversity();
                return View(Entity);
            }

            if (Entity.Resume.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(Entity.Resume.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                Entity.Resume.SaveAs(_path);
                Entity.ResumePath = _path;
            }


            _studentService.Add(Entity);
            return View();
        }


        [HttpGet]
        public ActionResult EditStudentApp(int UserId)
        {
            ViewBag.Universities = _universityService.GetUniversity();
            var Student = _studentService.GetStudent(UserId);
            return View(Student);
        }


        [HttpPost]
        public ActionResult EditStudentApp(StudentVM Entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Universities = _universityService.GetUniversity();
                return View(Entity);
            }


            if (Entity.Resume.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(Entity.Resume.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                Entity.Resume.SaveAs(_path);
                Entity.ResumePath = _path;
            }


            _studentService.Update(Entity);
            return View();
        }
        

        [HttpGet]
        public ActionResult EditStatus(int Id)
        {
            ViewBag.Status = _statusService.GetAppStatuses();
            var Application = _studentService.GetStudents().FirstOrDefault(c=>c.Id==Id);
            var Entity = new UpdateStatusVm
            {
                Id=Application.Id,
                Name=Application.FirstName + Application.SecondName,
                StatusId=Application.StatusId
 
            };
            return View(Entity);
        }

        [HttpPost]
        public ActionResult EditStatus(UpdateStatusVm Entity)
        {
            ViewBag.Status = _statusService.GetAppStatuses();
            if(!ModelState.IsValid)
            {
                ViewBag.Status = _statusService.GetAppStatuses();
                return View(Entity);
            }
            _studentService.Update(Entity.StatusId, Entity.Id);
            return RedirectToAction("Index");
        }



        public FileResult ExportApplications(string Name, int? UniversityId, int? AppStatus)
        {
            DataTable DT = new DataTable();
            string ExcelName = "Applications";
            DT = _studentService.ExportApplications(Name, UniversityId, AppStatus);
            return ExportSetting(DT, ExcelName);
        }



        public FileResult ExportSetting(DataTable DT, string Name)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                var wsDetailedData = wb.Worksheets.Add(DT, "Applications");

                wsDetailedData.Columns().AdjustToContents();
                wsDetailedData.Rows().AdjustToContents();

                wsDetailedData.Range(1, 1, DT.Rows.Count + 1, 23).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wsDetailedData.Range(1, 1, DT.Rows.Count + 1, 23).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Name + " " + DateTime.Now.ToLongDateString() + ".xlsx");
                }
            }
        }



    }
}