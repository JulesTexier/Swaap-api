using System;
namespace Swaap_api.Models
{
	public class Category
	{
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Catalog>? Catalogs { get; set; }

        public Category()
		{
		}
	}
}

