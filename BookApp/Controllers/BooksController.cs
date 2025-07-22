using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using BookApp.Services;

namespace BookApp.Controllers;

public class BooksController : Controller
{
    private readonly BookService _service;

    public BooksController(BookService service) => _service = service;

    public IActionResult Index() => View(_service.GetAll());

    public IActionResult Details(int id)
    {
        var book = _service.Get(id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (!ModelState.IsValid) return View(book);
        _service.Create(book);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var book = _service.Get(id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(int id, Book book)
    {
        if (!ModelState.IsValid) return View(book);
        if (!_service.Update(id, book)) return NotFound();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
