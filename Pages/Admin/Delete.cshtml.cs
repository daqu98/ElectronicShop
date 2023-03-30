using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop.Data;
using MyEshop.Models;
namespace MyEshop.Pages.Admin;

public class DeleteModel : PageModel
{
    #nullable disable
    private MyEshopContext _context;
    [BindProperty]
    public Product Product { get; set; }
    public DeleteModel(MyEshopContext context)
    {
        _context = context;
    }
    public void OnGet(int id)
    {
        Product = _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public IActionResult OnPost()
    {
        var product = _context.Products.Find(Product.Id);
        var item = _context.Items.First(p => p.Id == product.ItemId);
        _context.Items.Remove(item);
        _context.Products.Remove(product);

        _context.SaveChanges();

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", product.Id + ".jpg");
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }

        return RedirectToPage("Index");
    }
}

