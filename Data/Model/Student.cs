using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Student: BaseEntity
    {
        public string? Name { get; set; } = string.Empty;   
        public string? Surname{ get; set; } = string.Empty;
		public string? Phone{ get; set; } = string.Empty;
		public string? TC{ get; set; } = string.Empty;
		public string? Adress{ get; set; } = string.Empty;
		public int Rate { get; set; }
		#region Relation

		public List<Notes> Notes { get; set; }

		#endregion
	}
}
