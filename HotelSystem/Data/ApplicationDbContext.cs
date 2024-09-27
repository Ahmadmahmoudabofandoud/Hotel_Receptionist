using HotelSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Data
{
	public class ApplicationDbContext : DbContext
	{
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guestt> Guestts { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
	}
}
