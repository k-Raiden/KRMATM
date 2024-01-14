using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStarsApp.Data;
using MyStarsApp.Models;

namespace MyStarsApp.Controllers
{
    public class MyStarController : Controller
    {
        private readonly MYStarAppDBContext _context;

        public MyStarController(MYStarAppDBContext context)
        {
            _context = context;
        }

        // GET: MyStar
        public async Task<IActionResult> Index()
        {
              return _context.CustomersInfo != null ? 
                          View(await _context.CustomersInfo.ToListAsync()) :
                          Problem("Entity set 'MYStarAppDBContext.CustomersInfo'  is null.");
        }
        
        // GET: MyStar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomersInfo == null)
            {
                return NotFound();
            }

            var customersViewModel = await _context.CustomersInfo
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customersViewModel == null)
            {
                return NotFound();
            }

            return View(customersViewModel);
        }

        // GET: MyStar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyStar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,AccountNumber,PinNumber,Balance,NewBalance,DepositAmount,WithdrawAmount")] CustomersViewModel customersViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customersViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customersViewModel);
        }

        // GET: MyStar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomersInfo == null)
            {
                return NotFound();
            }

            var customersViewModel = await _context.CustomersInfo.FindAsync(id);
            if (customersViewModel == null)
            {
                return NotFound();
            }
            return View(customersViewModel);
        }

        // POST: MyStar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,AccountNumber,PinNumber,Balance,NewBalance,DepositAmount,WithdrawAmount")] CustomersViewModel customersViewModel)
        {
            if (id != customersViewModel.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customersViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersViewModelExists(customersViewModel.CustomerId))
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
            return View(customersViewModel);
        }

        // GET: MyStar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomersInfo == null)
            {
                return NotFound();
            }

            var customersViewModel = await _context.CustomersInfo
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customersViewModel == null)
            {
                return NotFound();
            }

            return View(customersViewModel);
        }

        // POST: MyStar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomersInfo == null)
            {
                return Problem("Entity set 'MYStarAppDBContext.CustomersInfo'  is null.");
            }
            var customersViewModel = await _context.CustomersInfo.FindAsync(id);
            if (customersViewModel != null)
            {
                _context.CustomersInfo.Remove(customersViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersViewModelExists(int id)
        {
          return (_context.CustomersInfo?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
       // public IActionResult CalculateNewBalance(CustomersViewModel model) 
       // {
      //      model.NewBalance = GetNewBalance(model.CustomerId,model.Balance,model.DepositAmount,model.NewBalance);

          //  return View("Deposit",model);
                
       // }


       // private decimal GetNewBalance(int customerId, decimal balance, decimal depositAmount,decimal newBalance)
       // {
            

          //  newBalance = balance + depositAmount;

          //  return newBalance;
       // }
    }
}
