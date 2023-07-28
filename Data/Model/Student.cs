using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Student: BaseEntity
    {
        public string Name{ get; set; }     
        public string Surname{ get; set; }     
        public string Phone{ get; set; }     
    }
}
