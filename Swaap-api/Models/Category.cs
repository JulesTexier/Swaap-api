using System;
namespace SwaapApi.Models
{
	public class Category
	{
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Catalog> CatalogProducts { get; set; }

        public Category()
		{
		}
	}
}

