using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
	public class Notes:BaseEntity
	{
        public long StudentId { get; set; }
        public long LessonId { get; set; }
        public long? Midterm { get; set; }
        public long? Final { get; set; }
        public long? Butt { get; set; }

        #region Relation
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }

        #endregion
    }
}
