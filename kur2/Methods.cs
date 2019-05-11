using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kur2
{
    public class Methods
    {
        public void AddUsers(string email, string pass)
        {
            using (CourseworkEntities db = new CourseworkEntities())
            {
                User u = new User { Email = email, Password = pass };
                db.Users.Add(u);
                db.SaveChanges();

                var users = db.Users.ToList();
                foreach (var us in users)
                {
                    Console.WriteLine($"{us.UserId} {us.Email} {us.Password}");
                }
            }
        }

        public void AddSites(string link)
        {
            using (CourseworkEntities db = new CourseworkEntities())
            {
                Site s = new Site { Link = link };
                db.Sites.Add(s);
                db.SaveChanges();

                var sites = db.Sites.ToList();
                foreach (Site st in sites)
                {
                Console.WriteLine($"{st.SiteId} {st.Link}");
                }
            }
        }

        public void AddProducts(string nameProduct, string description, int cost,int SiteId)
        {
            using (CourseworkEntities db = new CourseworkEntities())
            {
                Product p = new Product { NameProduct = nameProduct, Description = description, Cost = cost, SiteId= SiteId};
                db.Products.Add(p);
                db.SaveChanges();

               var products = db.Products.ToList();
               foreach (Product pr in products)
               {
                Console.WriteLine($"{pr.ProductId} {pr.NameProduct} {pr.Description} {pr.Cost} {pr.SiteId}");
               }
            }

        }

        public void AddOrders(int clientId, int productID)
        {
            using (CourseworkEntities db = new CourseworkEntities())
            {
                Order o = new Order { ClientId = clientId, ProductID = productID };
                db.Orders.Add(o);
                db.SaveChanges();

                var orders = db.Orders.ToList();
                foreach (Order or in orders)
                {
                Console.WriteLine($"{or.OrderId} {or.ClientId} {or.ProductID}");
                }
            }
        }

        public void AddProductList(string group)
        {
            using (CourseworkEntities db = new CourseworkEntities())
            {
                Product_List pl = new Product_List { Group = group };
                db.Product_List.Add(pl);
                db.SaveChanges();

                var productlists = db.Product_List.ToList();
                foreach (Product_List pls in productlists)
                {
                Console.WriteLine($"{pls.ProductID} {pls.Group}");
                }
            }
        }

        public void DeleteUser(string mail)
        {
            using (CourseworkEntities db = new CourseworkEntities())
            {
               User u1= db.Users.Select(a => a).Where(a=>a.Email==mail).First();
                if (u1 != null)
                {
                    db.Users.Remove(u1);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteOrder()


    }
}
