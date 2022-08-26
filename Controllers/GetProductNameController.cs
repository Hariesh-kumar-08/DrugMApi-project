using DrugMApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductNameController : ControllerBase
    {
        private mdContext db;

        public GetProductNameController(mdContext db)
        {
            this.db = db;
        }
        [HttpGet("GetProductName/{id}")]
        public List<String> GetProductName(int id)
        {
            List<String> products = new List<String>();
            List<OrderDetail> l = (from i in db.OrderDetails where i.UserId == id
                                   && i.PurchaseId!=null  select i).ToList();
            foreach (var item in l)
            {
                foreach (var p in db.Products)
                {
                    if (p.ProductId == item.ProductId)
                    {
                        products.Add(p.ProductName);
                    }
                }



            }
            return products;
        }
    }
}
