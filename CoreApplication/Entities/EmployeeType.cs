using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApplication.Entities
{
    public class EmployeeType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } 

        //Navigation property
        public List<EmployeeRequirementType> EmployeeRequirementTypes { get; set; }
    }
}
