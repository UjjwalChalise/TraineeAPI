
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;
using TraineeMVC.Data;

public class UserDetailsController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserDetailsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: USERDETAILSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.UserDetails.ToListAsync());
    }

    // GET: USERDETAILSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userdetails = await _context.UserDetails
            .FirstOrDefaultAsync(m => m.Id == id);
        if (userdetails == null)
        {
            return NotFound();
        }

        return View(userdetails);
    }

    // GET: USERDETAILSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: USERDETAILSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Username,PasswordHash,FirstName,LastName,DateOfBirth,Address,ProfileImagePath,Teacher,Student")] UserDetails userdetails)
    {
        if (ModelState.IsValid)
        {
            _context.Add(userdetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(userdetails);
    }

    // GET: USERDETAILSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userdetails = await _context.UserDetails.FindAsync(id);
        if (userdetails == null)
        {
            return NotFound();
        }
        return View(userdetails);
    }

    // POST: USERDETAILSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Username,PasswordHash,FirstName,LastName,DateOfBirth,Address,ProfileImagePath,Teacher,Student")] UserDetails userdetails)
    {
        if (id != userdetails.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(userdetails);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(userdetails.Id))
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
        return View(userdetails);
    }

    // GET: USERDETAILSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userdetails = await _context.UserDetails
            .FirstOrDefaultAsync(m => m.Id == id);
        if (userdetails == null)
        {
            return NotFound();
        }

        return View(userdetails);
    }

    // POST: USERDETAILSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var userdetails = await _context.UserDetails.FindAsync(id);
        if (userdetails != null)
        {
            _context.UserDetails.Remove(userdetails);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UserDetailsExists(int? id)
    {
        return _context.UserDetails.Any(e => e.Id == id);
    }
}
