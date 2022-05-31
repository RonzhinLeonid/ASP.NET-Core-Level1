using DataLayer.Base;
using DataLayer.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Blog : NamedEntity
    {
        public string User { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
