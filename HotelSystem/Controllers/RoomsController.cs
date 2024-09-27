using HotelSystem.Data;
using HotelSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Controllers
{
	public class RoomsController : Controller
	{
		ApplicationDbContext _context;
		IWebHostEnvironment _WebHostEnvironment;

		public RoomsController(IWebHostEnvironment web, ApplicationDbContext context)
		{
			_context = context;
			_WebHostEnvironment = web;
		}
        public IActionResult GetIndexView()
        {
            return View("Index", _context.Rooms.OrderBy(d=>d.Id).ToList());
        }


        public IActionResult GetDetailsView(int id)
        {
            Room room = _context.Rooms.Include(d=>d.Guestts).FirstOrDefault(e => e.Id == id);
            return View("Details", room);
        }

        public IActionResult GetCheckInView()
        {
            return View("CheckIn", _context.Rooms.Where(d=>d.Status=="Available").OrderBy(d => d.MaxCapacity).ToList());

        }

        public IActionResult GetCheckOutView()
        {
            return View("CheckOut", _context.Rooms.Include(d=>d.Guestts).Where(d => d.Status == "Booked").OrderBy(d => d.MaxCapacity).ToList());

        }
        public IActionResult GetCreateView()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult AddNew(Room room)
        {
            if (room.Floor > 4 || room.Floor < 1)
            {
                ModelState.AddModelError(string.Empty, "Floor must be between 4 and 1.");
            }
            if (ModelState.IsValid)
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
                return View("Create", room);
        }
    }
}
