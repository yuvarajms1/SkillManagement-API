using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.Data.Models
{
    public partial class TechnologyStack
    {
        public int Id { get; set; }
        public string TechnologyName { get; set; }
        public int CategoryId { get; set; }
        public int Selected { get; set; }
        public int? SelectedProficiencyLevel { get; set; }
    }
}
