using DrugMApi.Models;
using DrugMApi.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductRepo obj1;

        public ProductsController()
        {
            obj1 = new ProductRepo(new mdContext());
        }

        [HttpPost]
        public ActionResult<List<Product>> Create(Product p)
        {
            obj1.Create(p);
            return obj1.Get();

        }

        [HttpGet]

        public ActionResult<List<Product>> Index()
        {

            return obj1.Get();

        }



        [HttpGet("{id}")]

        public Product Details(int id)
        {
            var result = obj1.Details(id);
            return result;
        }

        [HttpPut("{id}")]

        public Product Edit(Product p)
        {
            var e = obj1.Update(p);
            obj1.Save();
            return e;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            obj1.Delete(id);
            obj1.Save();
            var products = from i in obj1.Get() select i;
            return Ok(products);
        }
       

    }
}
