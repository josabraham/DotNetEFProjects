using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactsMVCCore.Models;

namespace ContactsMVCCore.Controllers
{
    public class ContactGroupsController : Controller
    {
        private readonly ContactsMVCCoreDBContext _context;

        public ContactGroupsController(ContactsMVCCoreDBContext context)
        {
            _context = context;
        }

        // GET: ContactGroups
        public async Task<IActionResult> Index()
        {
              return _context.ContactGroups != null ? 
                          View(await _context.ContactGroups.ToListAsync()) :
                          Problem("Entity set 'ContactsMVCCoreDBContext.ContactGroups'  is null.");
        }

        // GET: ContactGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactGroups == null)
            {
                return NotFound();
            }

            var contactGroup = await _context.ContactGroups
                .FirstOrDefaultAsync(m => m.ContactGroupId == id);
            if (contactGroup == null)
            {
                return NotFound();
            }

            return View(contactGroup);
        }

        // GET: ContactGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactGroupId,GroupName")] ContactGroup contactGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactGroup);
        }

        // GET: ContactGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactGroups == null)
            {
                return NotFound();
            }

            var contactGroup = await _context.ContactGroups.FindAsync(id);
            if (contactGroup == null)
            {
                return NotFound();
            }
            return View(contactGroup);
        }

        // POST: ContactGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactGroupId,GroupName")] ContactGroup contactGroup)
        {
            if (id != contactGroup.ContactGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactGroupExists(contactGroup.ContactGroupId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactGroup);
        }

        // GET: ContactGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactGroups == null)
            {
                return NotFound();
            }

            var contactGroup = await _context.ContactGroups
                .FirstOrDefaultAsync(m => m.ContactGroupId == id);
            if (contactGroup == null)
            {
                return NotFound();
            }

            return View(contactGroup);
        }

        // POST: ContactGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactGroups == null)
            {
                return Problem("Entity set 'ContactsMVCCoreDBContext.ContactGroups'  is null.");
            }
            var contactGroup = await _context.ContactGroups.FindAsync(id);
            if (contactGroup != null)
            {
                _context.ContactGroups.Remove(contactGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactGroupExists(int id)
        {
          return (_context.ContactGroups?.Any(e => e.ContactGroupId == id)).GetValueOrDefault();
        }
    }
}
