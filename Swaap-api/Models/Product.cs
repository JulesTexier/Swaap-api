using System;
namespace Swaap_api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int? CatalogId { get; set; }
        public int? UserId { get; set; }
        public string? Description { get; set; }

        public Product()
        {
        }
    }
}

