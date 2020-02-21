using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepository.Models
{
	public class Order
	{
		public int Id { get; set; }
		[ForeignKey("ProductId")]
		public long ProductId { get; set; }
		public int Quantity { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsDeleted { get; set; }
		public virtual Product Product { get; set; }
	}
}
