using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        //public string? Description { get; set; } = string.Empty;

        //public decimal? Price { get; set; }

        public int Quantity { get; set; } = 1;

        //public string? Unit { get; set; } = string.Empty;

        //public bool IsCompleted { get; set; } = false;

        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;


        public int CategoryId { get; set; }

        public virtual CategoryDTO Category { get; set; } = null!;
    }
}
