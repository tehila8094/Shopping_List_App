using Services.DTOs;

namespace API.Models
{
    public class ProductModel
    {
        public string Name { get; set; } = string.Empty;

        //public string? Description { get; set; }

        //public decimal? Price { get; set; }

        public int Quantity { get; set; } = 1;

        //public string? Unit { get; set; }

        //public bool IsCompleted { get; set; } = false;

        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //public DateTime? UpdatedAt { get; set; }


        public int CategoryId { get; set; }

        //public virtual CategoryModel Category { get; set; } = null!;
    }
}
