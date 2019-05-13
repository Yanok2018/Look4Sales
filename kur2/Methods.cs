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
        public bool AddUsers(string email, string pass, Nullable<int> fav)
        {
            using (CourseworkEntities6 db = new CourseworkEntities6())
            {
                User u1 = db.Users.Select(a => a).Where(a => a.Email == email).First();
                if (u1 != null)
                {
                    User u = new User { Email = email, Password = pass, Favorites = fav };

                    db.Users.Add(u);
                    db.SaveChanges();

                    var users = db.Users.ToList();
                    foreach (var us in users)
                    {
                        Console.WriteLine($"{us.UserId} {us.Email} {us.Password} {us.Orders} {us.Favorites}");
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
        }

        public void AddSites(string link)
        {
            using (CourseworkEntities6 db = new CourseworkEntities6())
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
            using (CourseworkEntities6 db = new CourseworkEntities6())
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
            using (CourseworkEntities6 db = new CourseworkEntities6())
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
            using (CourseworkEntities6 db = new CourseworkEntities6())
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
            using (CourseworkEntities6 db = new CourseworkEntities6())
            {
               User u1= db.Users.Select(a => a).Where(a=>a.Email==mail).First();
                if (u1 != null)
                {
                    db.Users.Remove(u1);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteOrder(int clientId)
        {
            using (CourseworkEntities6 db = new CourseworkEntities6())
            {
                Order o1 = db.Orders.Select(a => a).Where(a => a.ClientId == clientId).First();
                if (o1 != null)
                {
                    db.Orders.Remove(o1);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteProduct(int IdProduct)
        {
            using (CourseworkEntities6 db = new CourseworkEntities6())
            {
                Product p1 = db.Products.Select(a => a).Where(a => a.ProductId == IdProduct).First();
                if (p1 != null)
                {
                    db.Products.Remove(p1);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteProduct_List(int IdProducta)
        {
            using (CourseworkEntities6 db = new CourseworkEntities6())
            {
                Product_List pl1 = db.Product_List.Select(a => a).Where(a => a.ProductID == IdProducta).First();
                if(pl1 != null)
                {
                    db.Product_List.Remove(pl1);
                    db.SaveChanges();
                }
            }
        }

        public void ReductUserEmail(string mail, string mail2)
        {
            using (CourseworkEntities6 db = new CourseworkEntities6())
            {
                try
                {
                    db.Users.Select(a => a).Where(a => a.Email == mail2).First();
                    Console.WriteLine("Эта почта уже используетса");

                }
                catch (Exception)
                {
                User u1 = db.Users.Select(a => a).Where(a => a.Email == mail).First();
                    if (u1 != null)
                    {
                        u1.Email = mail2;
                        db.SaveChanges();
                        var users = db.Users.ToList();
                        foreach (var us in users)
                        {
                            Console.WriteLine($"{us.UserId} {us.Email} {us.Password} {us.Orders} {us.Favorites}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Почта не найдена");
                    }              
                }
                }
            }
        }

}
