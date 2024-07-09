using StudentMVC.Models;
using StudentMVC.Repository;
using System.Collections.Generic;
using System.Linq;

namespace StudentMVC.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly StControllerContext _context;

        public StudentServices(StControllerContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var product = _context.Students.Find(id);
            if (product != null)
            {
                _context.Students.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Insert(Student product)
        {
            _context.Students.Add(product);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            var existingStudent = _context.Students.Find(student.id);
            if (existingStudent != null)
            {
                existingStudent.id = student.id;
                existingStudent.name = student.name;
                existingStudent.email = student.email;
                existingStudent.address = student.address;
                existingStudent.date = student.date;
                existingStudent.fees = student.fees;
                existingStudent.status = student.status;
          
                _context.SaveChanges();
            }
        }
    }
}
