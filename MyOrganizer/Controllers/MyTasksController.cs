using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyOrganizer.Data;
using MyOrganizer.Models;
using MyOrganizer.ViewModels;

namespace MyOrganizer.Controllers
{
    public class MyTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyTasks
        public async Task<IActionResult> Index(int? categoryId, string userName, string userId, int pageNumber = 1)
        {
            AppUser appUser;

            if (userName == null)
            {
                appUser = _context.AppUsers.Single(u => u.Id == userId);
            }
            else
            {
                appUser = _context.AppUsers.Single(u => u.UserName == userName);
            }

            var tasks = _context.Tasks.Where(t => t.AppUser == appUser).Include(t => t.Category).ToList();

            if (categoryId != null && categoryId != 0)
            {
                tasks = tasks.Where(t => t.CategoryId == categoryId).ToList();
            }

            int pageSize = 3;
            int count = tasks.Count;

            List<Category> categories = await _context.Categories.ToListAsync();
            categories.Insert(0, new Category() { Id = 0, Name = "Всі категорії" });

            PageViewModel paginator = new(count, pageNumber, pageSize);

            TasksViewModel viewModel = new()
            {
                Tasks = tasks.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                Categories = new SelectList(categories, "Id", "Name"),
                AppUser = appUser,
                Paginator = paginator
            };

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["AppUserId"] = _context.AppUsers.Single(u => u.UserName == userName).Id;
            return View(viewModel);
        }

        // GET: MyTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTask = await _context.Tasks
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myTask == null)
            {
                return NotFound();
            }

            return View(myTask);
        }

        // GET: MyTasks/Create
        public IActionResult Create(string userName)
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["AppUserId"] = _context.AppUsers.Single(u => u.UserName == userName).Id;
            return View();
        }

        // POST: MyTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,PublishDate,PublishTime,CategoryId,AppUserId")] MyTask myTask)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(myTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new
                {
                    categoryId = myTask.CategoryId,
                    userName = _context.AppUsers.Single(u => u.Id == myTask.AppUserId).UserName,
                });
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", myTask.CategoryId);
            return View(myTask);
        }

        // GET: MyTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTask = await _context.Tasks.FindAsync(id);
            if (myTask == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", myTask.CategoryId);
            ViewData["AppUserId"] = myTask.AppUserId;
            return View(myTask);
        }

        // POST: MyTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,PublishDate,PublishTime,IsDone,CategoryId,AppUserId")] MyTask myTask)
        {
            if (id != myTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyTaskExists(myTask.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new
                {
                    categoryId = myTask.CategoryId,
                    userName = _context.AppUsers.Single(u => u.Id == myTask.AppUserId).UserName,
                });
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", myTask.CategoryId);
            return View(myTask);
        }

        // GET: MyTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTask = await _context.Tasks
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myTask == null)
            {
                return NotFound();
            }

            ViewData["AppUserId"] = myTask.AppUserId;
            return View(myTask);
        }

        // POST: MyTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myTask = await _context.Tasks.FindAsync(id);
            var categoryId = myTask.CategoryId;
            var userName = _context.AppUsers.Single(u => u.Id == myTask.AppUserId).UserName;
            _context.Tasks.Remove(myTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new
            {
                categoryId,
                userName,
            });
        }

        private bool MyTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
