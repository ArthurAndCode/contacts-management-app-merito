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
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Users");

            var contacts = await _context.Contacts
                .Where(c => c.UserId == userId)
                .ToListAsync();

            contacts = SearchContacts(searchString, contacts);
            return View(contacts);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Users");

            contact.UserId = userId.Value;
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateBusiness() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBusiness(BusinessContact businessContact)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Users");

            businessContact.UserId = userId.Value;
            _context.Add(businessContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contacts.FindAsync(id);
            return contact switch
            {
                null => NotFound(),
                BusinessContact businessContact => View("EditBusiness", businessContact),
                _ => View(contact)
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Contact contact)
        {
            if (id != contact.Id) return NotFound();
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Users");

            if (!ModelState.IsValid) return View(contact);

            try
            {   
                contact.UserId = userId.Value;
                _context.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(contact.Id)) return NotFound();
                throw;
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBusiness(int id, BusinessContact businessContact)
        {
            if (id != businessContact.Id) return NotFound();
            var userId = HttpContext.Session.GetInt32("UserId");

            if (!ModelState.IsValid) return View();

            try
            {
                if (userId != null) businessContact.UserId = userId.Value;
                _context.Update(businessContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(businessContact.Id)) return NotFound();
                throw;
            }
        }

        private static List<Contact> SearchContacts(string? searchString, List<Contact> contacts)
        {
            if (string.IsNullOrEmpty(searchString)) 
                return contacts;

            return contacts.Where(c => 
                c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                c.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                (c is BusinessContact bc && 
                 (bc.CompanyName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                  bc.Position.Contains(searchString, StringComparison.OrdinalIgnoreCase)))
            ).ToList();
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
            if (contact != null) _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}

