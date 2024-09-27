using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HotelSystem.Models
{
	public class Room
	{
        [DisplayName("Room Number")]
        public int Id { get; set; }


		[DisplayName("Type")]
        [Required(ErrorMessage ="Choose a valid Type.")]
		public string Type { get; set; }

		[DisplayName("Floor")]
        [Required(ErrorMessage = "You have to provide a valid Floor.")]
        public int Floor { get; set; }

		[DisplayName("Price per Night")]

		public decimal Price { get; set; }

		[DisplayName("Status")]
		[Required]
		public string Status { get; set; }


        [Required(ErrorMessage = "You have to provide a valid Capacity.")]
        public int MaxCapacity { get; set; }

		[ValidateNever]
		public List<Guestt>Guestts { get; set; }

    }
}
