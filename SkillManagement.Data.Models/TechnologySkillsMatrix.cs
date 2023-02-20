using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.Data.Models
{
    public partial class TechnologySkillsMatrix
    {

        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public int TechnologyId { get; set; }

        public int? ProficiencyLevelId { get; set; }


    }
}
