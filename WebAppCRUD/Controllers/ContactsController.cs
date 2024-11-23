using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Data;
using WebAppCRUD.Models;

namespace WebAppCRUD.Controllers
{
    public class ContactsController : Controller
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchString)
        {
            ViewData["CurrentFilter"] = searchString;
    
            var contacts = await _context.Contacts.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(c => c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                               || c.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                               || c.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                               || (c is BusinessContact bc && 
                                                   (bc.CompanyName.Contains(searchString, StringComparison.OrdinalIgnoreCase) 
                                                    || bc.Position.Contains(searchString, StringComparison.OrdinalIgnoreCase))))
                    .ToList();
            }

            return View(contacts);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        public IActionResult CreateBusiness()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBusiness(BusinessContact businessContact)
        {
            if (!ModelState.IsValid) return View(businessContact);
            _context.Add(businessContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null) return NotFound();

            if (contact is BusinessContact businessContact)
            {
                return View("EditBusiness", businessContact);
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Contact contact)
        {
            if (id != contact.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if (contact is BusinessContact businessContact)
                    {
                        _context.Update(businessContact);
                    }
                    else
                    {
                        _context.Update(contact);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null) return NotFound();

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
