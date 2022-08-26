using DrugMApi.Models;
using DrugMApi.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        

        private readonly BuyerRepo obj;

        public TransactionsController()
        {
            obj = new BuyerRepo(new mdContext());
        }
        [HttpGet]
        [Route("{id}")]
        public List<Buyer> Transactions(int id)
        {
            var u = obj.Transactions(id);
            return u;
        }
    }
}
