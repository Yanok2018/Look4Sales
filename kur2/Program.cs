﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace kur2
{
    class Program
    {
        static void Main(string[] args)
        {
           //////////////////////////////////////////////// 
                //sd.SendMessege("Удачи","supernikd@gmail.com");

            ///////////////////////////////////
            using (CourseworkEntities6 db = new CourseworkEntities6())
            {
                    Dig dig = new Dig();
                /// dig.GetItemsFox();
                dig.GetItemsRoz();

                List<NewUser> newusers = new List<NewUser>();
                var users = db.Users;
                foreach (User u in users)
                {
                    NewUser nu = new NewUser();
                    nu.id = u.UserId;
                    nu.mail = u.Email;
                    nu.password = u.Password;
                    nu.favorites = u.Favorites;
                    newusers.Add(nu);
                    Console.WriteLine($"{u.UserId} {u.Email} {u.Password} {u.Favorites}");
                }
                List<NewProduct> newproduct = new List<NewProduct>();
                var products = db.Products;
                foreach (Product p in products)
                {
                    NewProduct np = new NewProduct();
                    np.ProductId = p.ProductId;
                    np.NameProduct = p.NameProduct;
                    np.Description = p.Description;
                    np.Cost = p.Cost;
                    np.SiteId = p.SiteId;
                    newproduct.Add(np);
                    Console.WriteLine($"{p.ProductId} {p.NameProduct} {p.Description} {p.Cost} {p.SiteId}");
                }

                List<NewOrder> neworder = new List<NewOrder>();
                var orders = db.Orders;
                foreach (Order o in orders)
                {
                    NewOrder no = new NewOrder();
                    no.OrderId = o.OrderId;
                    no.ClientId = o.ClientId;
                    no.ProductID = o.ProductID;
                    neworder.Add(no);
                    Console.WriteLine($"{o.OrderId} {o.ClientId} {o.ProductID}");
                }

                List<NewSite> newsite = new List<NewSite>();
                var sites = db.Sites;
                foreach (Site s in sites)
                {
                    NewSite ns = new NewSite();
                    ns.SiteId = s.SiteId;
                    ns.Link = s.Link;
                    newsite.Add(ns);
                    Console.WriteLine($"{s.SiteId} {s.Link}");
                }

                List<NewProduct_List> newproduct_list = new List<NewProduct_List>();
                var product_lists = db.Product_List;
                foreach (Product_List pl in product_lists)
                {
                    NewProduct_List nps = new NewProduct_List();
                    nps.Group = pl.Group;
                    nps.ProductID = pl.ProductID;
                    Console.WriteLine($"{pl.ProductID} {pl.Group}");
                }

            }
            Console.Clear();
            Methods m = new Methods();
            Console.WriteLine("Test");
            /// Console.WriteLine("Add user");
            /// m.AddUsers("qqq@gmail.com", "111");
            /// m.AddUsers("test3", "111");
            ///   m.AddUsers("test4", "111");
            ///   m.AddUsers("test5", "111");
            ///   m.AddUsers("test6", "111");
            //   m.AddUsers("test8", "111", null);
                //////   Console.WriteLine("Add site");
                ////// m.AddSites("https://rozetka.com.ua");
                ////// m.AddSites("https://www.foxtrot.com.ua");
                ////// //  m.AddSites("htt2");
            //  Console.WriteLine("Add product");
            //  m.AddProducts("Phone", "Test", 1000,1);
            //  Console.WriteLine("Del user");
            //  m.DeleteUser("test5");
          //  m.ReductUserEmail("test9", "test8");

        }
    }
}
