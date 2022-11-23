using System;
namespace SwaapApi.Models
{
	public class CatalogProduct
	{
        public long Id { get; set; }
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }



        public CatalogProduct()
		{

        }
	}
}

