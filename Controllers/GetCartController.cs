using DrugMApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCartController : ControllerBase
    {
        private mdContext db;

        public GetCartController(mdContext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("{id}")]
        public OrderDetail Edit(int id)
        {
            OrderDetail l = db.OrderDetails.Find(id);
            return l;
        }
        [HttpPut("OrderDetail")]
        public OrderDetail EditCart(OrderDetail orderDetail)
        {
            var e = (from i in db.OrderDetails where i.OrderId == orderDetail.OrderId select i).SingleOrDefault();
           e.Quantity=orderDetail.Quantity;
            db.SaveChanges();
            return e;
          
        }

    }
}
