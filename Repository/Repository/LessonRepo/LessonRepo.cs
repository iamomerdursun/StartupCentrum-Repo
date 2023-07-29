using Repository.DesingPattern;
using Repository.Repository.StudentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.LessonRepo
{
	public class LessonRepo : RepositoryBase<Data.Model.Lesson, AppDbContext>, ILessonRepo
	{
	}
}
