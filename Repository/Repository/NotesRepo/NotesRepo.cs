using Repository.DesingPattern;
using Repository.Repository.StudentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.NotesRepo
{
	public class NotesRepo : RepositoryBase<Data.Model.Notes, AppDbContext>, INotesRepo
	{
	}
}
