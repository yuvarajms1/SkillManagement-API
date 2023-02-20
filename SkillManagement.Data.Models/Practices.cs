using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.Data.Models
{
    public partial class Practices
    {
        public int Id { get; set; }
        public string PracticeName { get; set; }
        public string Description { get; set; } = null!;
    }
}
