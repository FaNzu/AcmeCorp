using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Libraries.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Decimal Price { get; set; }
		public string ImageURL { get; set; }

		public Product(string name, string description, decimal price, string imageURL)
		{
			Name = name;
			Description = description;
			Price = price;
			ImageURL = imageURL;
		}
	}
}
