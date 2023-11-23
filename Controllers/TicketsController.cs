using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using farouk.Models;
using Microsoft.Extensions.Logging; 
using farouk;
using Microsoft.EntityFrameworkCore;
namespace farouk.Controllers
{
  
    public class TicketsController : Controller
    {
      private readonly StoresContext _context;

 public TicketsController(StoresContext context)
{
    _context = context;
}
        // Locally store tickets list
        public static List<Ticket> Tickets = new List<Ticket>();

        public IActionResult Index()
        {
            ViewBag.Tickets = _context.tickets.ToList();
            return View();
        }

        [BindProperty]
        public Ticket Ticket { get; set; }
        
          public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Ticket Ticket)
        {
            //Tickets.Add(Ticket);
            _context.tickets.Add(Ticket);
            _context.SaveChanges();
            

            return RedirectToAction("Index");
        }

        
            
      
        public IActionResult Edit(int id)
        {
            Ticket ticket = _context.tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound(); // You can return an error view or a custom error page.
            }
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Update(Ticket updatedTicket)
        {
            Ticket existingTicket = _context.tickets.FirstOrDefault(t => t.Id == updatedTicket.Id);
            if (existingTicket == null)
            {
                return NotFound();
            }

            // Update the existing ticket with new values
            existingTicket.Title = updatedTicket.Title;

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        //[HttpPost]
        /*public IActionResult Delete(int id)
        {
            
            Ticket ticket = Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            Tickets.Remove(ticket);
            return RedirectToAction("Index");
        }*/
  [HttpPost]
    public IActionResult Delete(Ticket frTicket)
    { 
        try
        {
            // Find the ticket to delete by its Id
           Ticket ticket = _context.tickets.FirstOrDefault(t => t.Id == frTicket.Id);

            if (ticket == null)
            {
                return NotFound(); 
            }

            // Remove the found ticket from the Tickets list
            _context.tickets.Remove(frTicket);
            _context.SaveChanges(); 

            return RedirectToAction("Index"); 
        }
        catch (Exception ex)
        {
            // Handle exceptions as needed
            return RedirectToAction("Index");
        }
    }

    public IActionResult Delete(int Id)
    {
        Ticket ticket = _context.tickets.FirstOrDefault(t => t.Id == Id);
        if (ticket == null)
        {
            return NotFound();
        }
        return View(ticket);
    }
}
}