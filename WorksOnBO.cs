using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class WorksOnBO
    {
        public string Emp_ID { get; set; }
        public string Proj_ID { get; set; }
        public int WorkHours { get; set; }
        public int WorkHours_per_Week { get; set; }
        public string Work_Rate_per_hour { get; set; }
        public DateTime Work_Assign_Date { get; set; }
        public DateTime Work_Rel_Date { get; set; }

    }
}
