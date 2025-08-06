using Microsoft.Build.Evaluation;
using Student_Management_System.Context;
using Student_Management_System.Models;

namespace Student_Management_System.Repositories
{
    public class DepartmentRepository
    {
        ProjectDBContext db =new ProjectDBContext();

        public void Create(Department d)
        {
            db.Add(d);
        }

        public List<Department> ReadAll()
        {
            return db.departments.ToList();
        }

        public Department ReadById(int id)
        {
            return db.departments.Find(id);
        }

        public void Update(Department d)
        {
            db.Update(d);
        }

        public void Delete(Department d)
        {
            db.Remove(d);
        }

        public void save()
        {
            db.SaveChanges();
        }


    }
}
