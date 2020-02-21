using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepository.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Detail { get; set; }
		public string Unit { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int Quantity { get; set; }
		public decimal? Price { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
	}
}
