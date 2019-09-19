using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdsCategories.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ProdsCategories.Controllers
{
    public class HomeController : Controller
    {
        private ProdCateContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(ProdCateContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
               IndexViewModel model = new IndexViewModel()
            {
                Products = dbContext.Products.ToList()

            };
            System.Console.WriteLine(JsonConvert.SerializeObject(model));
            return View(model);
        }

        [HttpGet("categories")]
        public IActionResult Categories()
        {
               CategoryViewModel model = new CategoryViewModel()
            {
                Categories = dbContext.Categories.ToList()
            };
            return View(model);
        }

       [HttpPost("Create/Product")]
        public IActionResult Create(IndexViewModel newProd)
        {
            System.Console.WriteLine("made it to the create method");
            Console.WriteLine(newProd);
            Console.WriteLine(newProd.NewProduct.Name);
            Console.WriteLine(newProd.NewProduct.Description);
            Console.WriteLine(newProd.NewProduct.Price);

            if(ModelState.IsValid)
            {
                dbContext.Add(newProd.NewProduct);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
       [HttpPost("Create/Category")]
        public IActionResult CreateCategory(CategoryViewModel newCate)
        {
            System.Console.WriteLine("made it to the create method*************************************************************************************************************************************************************************************************************************");
            Console.WriteLine(newCate);
            Console.WriteLine(newCate.NewCategory.Name);


            if(ModelState.IsValid)
            {
                dbContext.Add(newCate.NewCategory);
                dbContext.SaveChanges();
                return RedirectToAction("Categories");
            }
            else
            {
                return View("Categories");
            }
        }

        [HttpGet("product/{id}")]
        public IActionResult Product(int id)
        {
            AddCategoryViewModel model = new AddCategoryViewModel()
            {
                Product = dbContext.Products
            .Include(product => product.Associations)
            .ThenInclude(cate => cate.Category)
            .FirstOrDefault(product => product.ProductId == id),
            
            Categories = dbContext.Categories.Where(c=>c.Associations.All(a=>a.ProductId != id)).ToList()
            };
    
            return View(model);
        }

       [HttpPost("product/Add")]
        public IActionResult AddCategory(AddCategoryViewModel newCate)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newCate.Association);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        } 
        












        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
