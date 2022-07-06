using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Interfaces.Services
{
    public interface ICartStore
    {
        public Cart Cart { get; set; }
    }
}
