using System;
namespace SwaapApi.Models
{
	public class Category
	{
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<CatalogProduct> CatalogProducts { get; set; }

        public Category()
		{
		}
	}
}

