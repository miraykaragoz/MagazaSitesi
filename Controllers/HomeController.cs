using MagazaSitesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagazaSitesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var product = new List<Product>();

            using StreamReader reader = new StreamReader("AppData/products/index.txt");
            var productData = reader.ReadToEnd();
            var productLines = productData.Split('\n');
            foreach (var line in productLines)
            {
                var productParts = line.Split('|');
                product.Add(
                    new Product()
                    {
                        ProductName = productParts[0],
                        ProductPrice = int.Parse(productParts[1]),
                        ProductCurrency = productParts[2],
                        ProductImg = productParts[3]
                    }
                );
            }

            return View(product);
        }
    }
}
