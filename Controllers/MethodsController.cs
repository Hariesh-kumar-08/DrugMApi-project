using DrugMApi.Models;
using DrugMApi.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MethodsController : ControllerBase
    {
        private readonly BuyerRepo obj;

        public MethodsController()
        {
            obj = new BuyerRepo(new mdContext());
        }
        [HttpPost]
        public Buyer Buy(Buyer b)
        {
            var c = obj.Buy(b);
            return c;
        }

        [HttpPut]

        public OrderDetail AddToCart(OrderDetail o)
        {
            var p = obj.orderDetail(o);
            return p;
        }

        [HttpGet]
        [Route("{id}")]
        public List<OrderDetail> Index(int id)
        {
            List<OrderDetail> l = obj.Index(id);
            return l;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            obj.Delete(id);

        }
       








    }
}
