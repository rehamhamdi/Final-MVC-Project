using Student_Management_System.Context;
using Student_Management_System.Models;

namespace Student_Management_System.Repositories
{
    public class InstructorRepository
    {
        ProjectDBContext db = new ProjectDBContext();

        public void Create(Instructor i)
        {
            db.Add(i);
        }

        public List<Instructor> ReadAll()
        {
            return db.instructors.ToList();
        }

        public Instructor ReadById(int id)
        {
            return db.instructors.Find(id);
        }

        public void Update(Instructor i)
        {
            db.Update(i);
        }

        public void Delete(Instructor i)
        {
            db.Remove(i);
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
