using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JQueryDemo.Models;

namespace JQueryDemo.DAL
{
    public class StudentsDAL
    {
        Student_TestEntities2 context = new Student_TestEntities2();
        public List<StudentModel> GetStudentsDetails(int page, int rows, out int totalCount)
        {
            try
            {

                var studentsDataList = (from s in context.tblStudents
                                        orderby s.Name
                                        select new StudentModel
                                            {
                                                ID = s.ID,
                                                Name = s.Name,
                                                Gender = s.Gender,
                                                TotalMarks = s.TotalMarks
                                            }).Skip((page - 1) * rows).Take(rows).ToList();
                totalCount = (from s in context.tblStudents
                              select s).Count();

                return studentsDataList;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddStudentDetails(StudentModel model)
        {
            try
            {
                bool status = false;
                var studentDetails = context.tblStudents.Where(x => x.ID == model.ID).SingleOrDefault();
                if (studentDetails == null)
                {
                    tblStudent student = new tblStudent();
                    student.Name = model.Name;
                    student.Gender = model.Gender;
                    student.TotalMarks = model.TotalMarks;
                    student.BirthDate = model.BirthDate;
                    context.tblStudents.Add(student);
                    status = true;
                }
                else
                {
                    studentDetails.Name = model.Name;
                    studentDetails.Gender = model.Gender;
                    studentDetails.BirthDate = model.BirthDate;
                    studentDetails.TotalMarks = model.TotalMarks;
                    status = true;
                }
                context.SaveChanges();
                return status;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StudentModel> GetStudentNames(string searchText)
        {

            List<StudentModel> projectList = (from stud in context.tblStudents
                                              where (stud.Name.ToLower().Contains(searchText.ToLower()))
                                              orderby stud.Name ascending
                                              select new StudentModel
                                              {
                                                  Name = stud.Name,
                                                  ID = stud.ID
                                              }).ToList();
            return projectList;
        }
    }

}
