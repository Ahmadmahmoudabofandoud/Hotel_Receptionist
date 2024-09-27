using HotelSystem.Data;
using HotelSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Controllers
{
    public class GuesttController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _WebHostEnvironment;
        static int RoomId = 0;
        static int RoomId_Leave = 0;
        public GuesttController(IWebHostEnvironment web, ApplicationDbContext context)
        {
            _context = context;
            _WebHostEnvironment = web;
        }

        public IActionResult GetIndexView()
        {
            return View("Index", _context.Guestts.OrderBy(e=>e.CheckInDate).ToList());
        }

        public IActionResult GetDetailsView(int Id)
        {
            Guestt guest = _context.Guestts.Include(e => e.Room).FirstOrDefault(e => e.Id == Id);
            return View("Details", guest);
        }
        public IActionResult GetLeaveView(int id)
        {
            RoomId_Leave = id;
            Guestt guest = _context.Guestts.OrderBy(e=>e.CheckInDate).Include(e => e.Room).FirstOrDefault(e => e.Id == id);
            return View("Leave", guest);
        }
        [HttpPost]
        public IActionResult LeaveHotel(int Id)
        {
            Guestt guest = _context.Guestts.Include(e => e.Room).FirstOrDefault(e => e.Id == Id);
            if (ModelState.IsValid)
            {
                Room room = _context.Rooms.FirstOrDefault(r => r.Id == guest.RoomId);
                room.Status = "Available";
                guest.Room = room;
                guest.RoomId = room.Id;
                guest.CheckOutDate = DateTime.Now;
                _context.Rooms.Update(room);
                _context.Guestts.Update(guest);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                return View("Reservation", guest);
            }
        }
        public IActionResult GetReservationView(int id)
        {
            RoomId = id;
            return View("Reservation");
        }
        [HttpPost]
        public IActionResult MakeReservation(Guestt guest, IFormFile? imageFile)
        {
            if (imageFile != null)
            {
                string imgExtension = Path.GetExtension(imageFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imgName = imgGuid + imgExtension;
                string imgUrl = "\\Images\\" + imgName;
                guest.ImageUrl = imgUrl;
                string imgPath = _WebHostEnvironment.WebRootPath + imgUrl;
                FileStream imgstream = new FileStream(imgPath, FileMode.Create);
                imageFile.CopyTo(imgstream);
                imgstream.Dispose();
            }
            else
            {
                guest.ImageUrl = "\\Images\\No_Image.png";
            }

            if (ModelState.IsValid)
            {
                Room room = _context.Rooms.FirstOrDefault(r => r.Id == RoomId);
                room.Status = "Booked";
                guest.Room = room;
                guest.RoomId = room.Id;
                _context.Rooms.Update(room);
                _context.Guestts.Add(guest);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                return View("Reservation", guest);
            }
        }
        

    } 
}
