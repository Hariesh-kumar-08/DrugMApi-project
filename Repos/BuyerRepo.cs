using DrugMApi.Models;

namespace DrugMApi.Repos
{
    public class BuyerRepo
    {
        private mdContext db;

        public BuyerRepo(mdContext db)
        {
            this.db = db;
        }

        public Buyer Buy(Buyer b)
        {
            db.Buyers.Add(b);
            db.SaveChanges();
            List<OrderDetail> p=db.OrderDetails.ToList();
            // p.LastOrDefault(i=>i.PurchaseId==b.PurchaseId);
            foreach (var a in p)
            {

                if (a.UserId == b.UserId&&a.PurchaseId==null)
                {
                    a.PurchaseId = b.PurchaseId;
                }
            }
            db.SaveChanges();
            List<OrderDetail> orderDetails = (from i in db.OrderDetails where i.PurchaseId == b.PurchaseId select i).ToList();
           List<Product> p1 = db.Products.ToList();

            foreach(var c in orderDetails)
            { 
                foreach (var d in p1)
                {
                    
                    if (c.ProductId == d.ProductId)
                    {
                        d.Stock -= c.Quantity;

                    }
                }
            }
            db.SaveChanges();
            return b;
        }

        public OrderDetail orderDetail(OrderDetail orderDetail)
           {
            var o = (from i in db.OrderDetails where (i.ProductId == orderDetail.ProductId )&&( i.UserId==orderDetail.UserId)&&i.PurchaseId==null select i).SingleOrDefault();
            if (o==null)
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return orderDetail;
            }
            else
            {
                o.Quantity+= orderDetail.Quantity;
                db.SaveChanges();
                return o;
            }
        }

       
        public List<OrderDetail> Index(int id)
        {
            List<OrderDetail> order = (from i in db.OrderDetails where i.UserId == id select i).ToList();
            return order;
        }

        public void Delete(int id)
        {
            var d = (from i in db.OrderDetails where i.OrderId == id select i).SingleOrDefault();
            db.OrderDetails.Remove(d);
            db.SaveChanges();
            
        }

        public List<Buyer> Transactions(int id)
        {
            var t = (from i in db.Buyers where i.UserId == id select i).ToList();
            return t;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}

