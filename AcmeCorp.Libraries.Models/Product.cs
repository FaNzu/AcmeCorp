using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Libraries.Models
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
		[Required]
        public string ImageURL { get; set; }

		public Product(string name, string description, double price, string imageURL)
		{
			Name = name;
			Description = description;
			Price = price;
			ImageURL = imageURL;
		}
	}
}
