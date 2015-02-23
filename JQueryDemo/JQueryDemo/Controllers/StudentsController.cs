using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryDemo.DAL;
using JQueryDemo.Models;

namespace JQueryDemo.Controllers
{
    public class StudentsController : Controller
    {
        StudentsDAL dal = new StudentsDAL();
        // GET: Students
        public ActionResult AddStudents()
        {
            StudentModel model = new StudentModel();

            return View(model);
        }

        [HttpGet]
        public ActionResult GetStudentsData()
        {
            StudentModel model = new StudentModel();

            return View();
        }

        [HttpPost]
        public ActionResult StudentsLoadGrid(int page, int rows)
        {
            try
            {
                List<StudentModel> model = new List<StudentModel>();

                int totalCount;
                model = dal.GetStudentsDetails(page, rows, out totalCount);
                if ((model == null || model.Count <= 0) && page - 1 > 0)
                {
                    page = page - 1;
                    model = dal.GetStudentsDetails(page, rows, out totalCount);
                }

                var totalRecords = totalCount;
                var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);
                var jsonData = new
                {
                    total = totalPages,
                    page = page,
                    records = totalRecords,
                    rows = model,
                };
                return Json(jsonData);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error", new { errorCode = "There are some errors." });
            }
        }

        [HttpPost]
        public ActionResult SaveStudentDetails(StudentModel model)
        {
            try
            {
                bool response = false;
                    response = dal.AddStudentDetails(model);
                return Json(new { status = response }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { status = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult StudentNameAutoComplete(string term)
        {
            List<StudentModel> searchResult = new List<StudentModel>();
            searchResult = dal.GetStudentNames(term);
            return Json(searchResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShowStudentData()
        {
            try
            {
                return PartialView("GetStudentsData");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult StudentDataStringify(StudentModel model)
        {
            return new EmptyResult();
        }
    }
}