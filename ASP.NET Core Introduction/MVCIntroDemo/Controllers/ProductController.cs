namespace MVCIntroDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using MVCIntroDemo.ViewModels.Product;
    using Newtonsoft.Json;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using static Seeding.ProductsData;

    public class ProductController : Controller
    {
        [Route("Product/My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var product = Products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

                return View(product);
            }

            return View(Products);
        }

        public IActionResult ById(string id)
        {
            ProductViewModel? product = Products.FirstOrDefault(p => p.Id.ToString().Equals(id));

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            //string products = JsonConvert.SerializeObject(Products, Formatting.Indented);

            //return Json(products);

            return Json(Products, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        public IActionResult AllAsText()
        {
            StringBuilder sb = new StringBuilder();

            var text = string.Empty;

            foreach (var product in Products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} {product.Price} lv.");
            }

            return Content(sb.ToString().Trim());
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ProductViewModel product in Products)
            {
                sb.AppendLine($"Product: {product.Name} - {product.Price:f2} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().Trim()), "text/plain");
        }
    }
}
