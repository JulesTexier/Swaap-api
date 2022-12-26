using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Swaap_api.Models
{
	public class CatalogItem
    {

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Secret { get; set; }

        //public int? CategoryId { get; set; }
        //[JsonIgnore]
        //public Category? Category { get; set; }

	}
}

