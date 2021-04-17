using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EHealthcare.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
        }

        public string Name { get; set; }

        public string Detail { get; set; }

        public double Price { get; set; }

        public string ImgSrc { get; set; }

        public long CategoryID { get; set; }

        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        public virtual IEnumerable<Category> Categories { get; set; }
    }
}
