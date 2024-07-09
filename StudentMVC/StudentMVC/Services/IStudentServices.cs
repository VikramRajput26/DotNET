using StudentMVC.Models;
namespace StudentMVC.Services
{
    public interface IStudentServices
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Insert(Student pro);
        void Update(Student pro);
        void Delete(int id);
    }
}
