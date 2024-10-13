using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{
    private readonly DataContext _context;

    public ToDoController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItem>> Get()
    {
        return _context.ToDoItems.Where(item => item.CompletedDate == null).ToList();
    }


    [HttpGet("{id}")]
    public ActionResult<ToDoItem> Get(int id)
    {
        var item = _context.ToDoItems.Find(id);
        if (item == null) return NotFound();
        return item;
    }


    [HttpPost]
    public ActionResult<ToDoItem> Post([FromBody] ToDoItem item)
    {
        _context.ToDoItems.Add(item);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ToDoItem item)
    {
        var existingItem = _context.ToDoItems.Find(id);
        if (existingItem == null) return NotFound();

        existingItem.CompletedDate = DateTime.Now;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.ToDoItems.Find(id);
        if (item == null) return NotFound();

        _context.ToDoItems.Remove(item);
        _context.SaveChanges();
        return NoContent();
    }

}