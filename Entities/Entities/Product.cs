using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public  int Rating { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
