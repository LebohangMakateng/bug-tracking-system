using aspnet.Data;
using aspnet.Enitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BugsController : Controller
{
    private readonly BugContext _context;

    public BugsController(BugContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBugs() // Only authorized QA/RD can access
    {
        // Implement logic to retrieve bugs based on user role (QA can see all, RD can see assigned)
        var bugs = _context.Bugs.ToList();
        return Json(bugs);
    }

    [HttpGet("{id}")]
    public IActionResult GetBug(int id)
    {
        var bug = _context.Bugs.Find(id);
        if (bug == null)
        {
            return NotFound();
        }
        return Json(bug);
    }

    [HttpPost]
    public IActionResult CreateBug([FromBody] Bug bug) // Only authorized QA can create
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        bug.CreatedDate = DateTime.Now;
        _context.Bugs.Add(bug);
        _context.SaveChanges();

        return CreatedAtRoute("GetBug", new { id = bug.Id }, bug);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBug(int id, [FromBody] Bug bug) // Only authorized QA can edit
    {
        if (id != bug.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        bug.UpdatedDate = DateTime.Now;
        _context.Entry(bug).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBug(int id) // Only authorized QA can delete
    {
        var bug = _context.Bugs.Find(id);
        if (bug == null)
        {
            return NotFound();
        }

        _context.Bugs.Remove(bug);
        _context.SaveChanges();

        return NoContent();
    }
}
