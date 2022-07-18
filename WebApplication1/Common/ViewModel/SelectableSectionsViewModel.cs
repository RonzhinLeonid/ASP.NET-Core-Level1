using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SelectableSectionsViewModel
    {
        public IEnumerable<SectionViewModel> Sections { get; set; } = null!;

        public int? SectionId { get; set; }

        public int? ParentSectionId { get; set; }
    }
}
