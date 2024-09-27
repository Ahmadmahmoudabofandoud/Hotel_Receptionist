using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HotelSystem.Models
{
    public class Guestt
    {

        [Display(Name = "ID")]
        public int Id { get; set; }

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "You have to provide a valid full name.")]
        [MinLength(8, ErrorMessage = "Full name mustn't be less than 8 Characters.")]
        [MaxLength(100, ErrorMessage = "Full name mustn't exceed 100 Characters.")]
        public string FullName { get; set; }

        [DisplayName("Check In Date")]
        public DateTime CheckInDate { get; set; }

        [DisplayName("Check Out Date")]
        public DateTime? CheckOutDate { get; set; }

        [DisplayName("Room")]
        public int RoomId { get; set; }

        [ValidateNever]
        public Room Room { get; set; }

		[DisplayName("National ID")]
		[Required(ErrorMessage = "You have to provide a valid National ID.")]
		[StringLength(14, ErrorMessage = "The National ID must be 14 characters long.", MinimumLength = 14)]
		[MaxLength(14)]
		public string NationalId { get; set; }

		[DisplayName("Phone Number")]
		[Required(ErrorMessage = "You have to provide a valid Phone Number.")]
		[MinLength(8, ErrorMessage = "Full name mustn't be less than 8 Characters.")]
		[MaxLength(14, ErrorMessage = "Full name mustn't exceed 14 Characters.")]
		public string PhoneNum { get; set; }

		[ValidateNever]
		public string Gender { get; set; }

        [DisplayName("Profile Image")]
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
