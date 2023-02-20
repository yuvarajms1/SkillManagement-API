using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.Data.Models
{
    public partial class Categories
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; } = null!;

        public int PracticesId { get; set; }

    }
}
