using System;
namespace SwaapApi.Models
{
	public class Catalog	{
        public long Id { get; set; } 
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }



        public Catalog()
		{

        }
	}
}

