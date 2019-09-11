using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicModels.Models
{
    public class ProductRepository
    {
        private ClassicModelsDatabaseContext db;

        public ProductRepository(ClassicModelsDatabaseContext db)
        {
            this.db = db;
        }

        public List<ProductLines> ProductLines()
        {
            var productLines = new List<ProductLines>();

            using (IDbConnection conn = this.db.Conn())
            {
                try
                {
                    var sql = @"select productLineId, productLine, textDescription, image from productlines";
                    productLines = conn.Query<ProductLines>(sql).ToList();
                }
                catch (Exception ex)
                {
                    Log.Error("SELECT failed in ProductRepository method 'ProductLines'. " + ex.Message);
                }
            }

            return productLines;
        }

        public List<Product> ProductLine(int productLineId)
        {
            var products = new List<Product>();

            using (IDbConnection conn = this.db.Conn())
            {
                try
                {
                    var sql = @"select p.*, c.productLine
                                from products as p
                                left join productlines as c
                                on p.productLineId = c.productLineId
                                where p.productLineId = @id";
                    products = conn.Query<Product>(sql, new { id = productLineId }).ToList();
                }
                catch (Exception ex)
                {
                    Log.Error("SELECT failed in ProductRepository method 'ProductsByCategory'. " + ex.Message);
                }
            }

            return products;
        }

        public Product Product(string productCode)
        {
            Product product = new Product();

            using (IDbConnection conn = this.db.Conn())
            {
                try
                {
                    var sql = @"select p.*, c.productLine
                                from products as p
                                left join productlines as c
                                on p.productLineId = c.productLineId
                                where p.productCode = @pc";
                    product = conn.Query<Product>(sql, new { pc = productCode }).Single();
                }
                catch (Exception ex)
                {
                    Log.Error("SELECT failed in ProductRepository method 'SingleProduct'. " + ex.Message);
                }
            }

            return product;
        }
    }
}