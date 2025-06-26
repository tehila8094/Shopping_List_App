using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        //public string? Description { get; set; }

        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //public DateTime? UpdatedAt { get; set; }


        public virtual ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
