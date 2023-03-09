using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SD_330_F22SD_Labs.Data;
using SD_330_F22SD_Labs.Models;

namespace SD_330_F22SD_Labs.Controllers
{
    public class CustomerAddressesController : Controller
    {
        private readonly Lab1Context _context;

        public CustomerAddressesController(Lab1Context context)
        {
            _context = context;
        }

        // GET: CustomerAddresses
        public async Task<IActionResult> Index()
        {
            var lab1Context = _context.customerAddresses.Include(c => c.Address).Include(c => c.Customer);
            return View(await lab1Context.ToListAsync());
        }


        // GET: CustomerAddres/Compare

        public async Task<IActionResult> Compare()
        {
            var lab1Context = _context.customerAddresses.Include(c => c.Address).Include(c => c.Customer);
            return View(await lab1Context.ToListAsync());
        }


        // GET: CustomerAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.customerAddresses == null)
            {
                return NotFound();
            }

            var customerAddress = await _context.customerAddresses
                .Include(c => c.Address)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerAddress == null)
            {
                return NotFound();
            }

            return View(customerAddress);
        }

        // GET: CustomerAddresses/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            return View();
        }

        // POST: CustomerAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,AddressId,IsOwner")] CustomerAddress customerAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", customerAddress.AddressId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", customerAddress.CustomerId);
            return View(customerAddress);
        }

        // GET: CustomerAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.customerAddresses == null)
            {
                return NotFound();
            }

            var customerAddress = await _context.customerAddresses.FindAsync(id);
            if (customerAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", customerAddress.AddressId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", customerAddress.CustomerId);
            return View(customerAddress);
        }

        // POST: CustomerAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,AddressId,IsOwner")] CustomerAddress customerAddress)
        {
            if (id != customerAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerAddressExists(customerAddress.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", customerAddress.AddressId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", customerAddress.CustomerId);
            return View(customerAddress);
        }

        // GET: CustomerAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.customerAddresses == null)
            {
                return NotFound();
            }

            var customerAddress = await _context.customerAddresses
                .Include(c => c.Address)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerAddress == null)
            {
                return NotFound();
            }

            return View(customerAddress);
        }

        // POST: CustomerAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.customerAddresses == null)
            {
                return Problem("Entity set 'Lab1Context.customerAddresses'  is null.");
            }
            var customerAddress = await _context.customerAddresses.FindAsync(id);
            if (customerAddress != null)
            {
                _context.customerAddresses.Remove(customerAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerAddressExists(int id)
        {
          return _context.customerAddresses.Any(e => e.Id == id);
        }
    }
}
