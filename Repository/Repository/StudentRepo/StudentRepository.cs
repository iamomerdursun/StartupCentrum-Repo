
using Repository.DesingPattern;
using Repository.Repository.StudentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Student
{
    public class StudentRepository : RepositoryBase<Data.Model.Student, AppDbContext>, IStudentRepository
    {

    }
}
