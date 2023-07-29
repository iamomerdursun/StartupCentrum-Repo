using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
	public class Lesson :BaseEntity
	{
        public string Name { get; set; }
        public int Credit { get; set; }
		#region Relation

		public List<Notes> Notes { get; set; }

		#endregion
	}
}
