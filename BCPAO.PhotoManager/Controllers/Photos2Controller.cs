using BCPAO.PhotoManager.Data;
using BCPAO.PhotoManager.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BCPAO.PhotoManager.Controllers
{
	public class Photos2Controller : Controller
    {
        private readonly DatabaseContext _context;

        public Photos2Controller(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Permit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Photos.ToListAsync());
        }

        // GET: Permit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos.SingleOrDefaultAsync(m => m.PhotoId == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // GET: Permit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PhotoId,PropertyId,ParcelId,PermitNumber,Photostatus,IssueDate,FinalDate,PermitValue,PermitDesc,PermitCode,DistrictAuthority,CreateDate")] Photo permit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permit);
        }

        // GET: Permit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos.SingleOrDefaultAsync(m => m.PhotoId == id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }

        // POST: Permit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PhotoId,PropertyId")] Photo photo)
        {
            if (id != photo.PhotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingPermitExists(photo.PhotoId))
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
            return View(photo);
        }

        // GET: Permit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingPermit = await _context.Photos
                .SingleOrDefaultAsync(m => m.PhotoId == id);
            if (buildingPermit == null)
            {
                return NotFound();
            }

            return View(buildingPermit);
        }

        // POST: Permit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingPermit = await _context.Photos.SingleOrDefaultAsync(m => m.PhotoId == id);
            _context.Photos.Remove(buildingPermit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingPermitExists(int id)
        {
            return _context.Photos.Any(e => e.PhotoId == id);
        }
    }
}
