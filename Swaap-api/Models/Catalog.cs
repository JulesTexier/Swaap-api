using System;
namespace Swaap_api.Models
{
	public class Catalog	{
        public long Id { get; set; } 
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }


        public Catalog()
		{

        }
	}
}

