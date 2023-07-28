using Repository.DesingPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.StudentRepo
{
    public interface IStudentRepository : IRepositoryBase<Data.Model.Student>
    {
    }
}
