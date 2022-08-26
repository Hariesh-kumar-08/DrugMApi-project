using DrugMApi.Models;

namespace DrugMApi.Repos
{
    public class ProductRepo
    {
        private readonly mdContext _db;



        public ProductRepo(mdContext db)
        {
            _db = db;
        }

        public Product Create(Product products)
        {
            _db.Products.Add(products);
            _db.SaveChanges();
            return products;

        }

        public void Delete(int id)
        {
            var products = _db.Products.Find(id);
            _db.Products.Remove(products);
            //return products;

        }

        public Product Details(int id)
        {
            var d = _db.Products.Find(id);
            return d;
        }

        public List<Product> Get()
        {
            var p = _db?.Products.ToList();
            return p;
        }

        public Product Update(Product products)
        {
            //_db.products.Find(id);
            _db.Products.Update(products);
            return products;
        }

      
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

