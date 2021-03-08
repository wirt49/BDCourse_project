using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposytories.Abstract;
using Models;
namespace Reposytories.Concrete.EF
{
    public class StudentReposytory: IStudentReposytory
    {
        public IEnumerable<Student> GetAllStudents()
        {
            using (var dbContext = new SheduleEntities())
            {
                return dbContext.Student.ToList();
            }
        }

        public bool Add(Student student)
        {
            using (var dbContext = new SheduleEntities())
            {
                dbContext.Student.Add(student);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool Delete(Student student)
        {
            using (var dbContext = new SheduleEntities())
            {   
                var dbStudent = dbContext.Student.Where(x => x.Id == student.Id).FirstOrDefault();
                dbContext.Student.Remove(dbStudent);
                dbContext.SaveChanges();

                return true;
            }
        }

        public bool Update(Student student)
        {
            using (var dbContext = new SheduleEntities())
            {
                var old = dbContext.Student.FirstOrDefault(s => s.Id == student.Id);
                old.FirstName = student.FirstName;
                old.LastName = student.LastName;
                old.Birth = student.Birth;
                old.Group_number = student.Group_number;
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
