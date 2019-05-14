using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kur2
{
    class Dig
    {
        string GetHtml(string site)
        {
            string html = "", line;
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            Stream data = client.OpenRead(site);//видерання html 
            StreamReader reader = new StreamReader(data, Encoding.UTF8);
            while ((line = reader.ReadLine()) != null)//заповнення html типу string
            {
                line = reader.ReadLine();
                html += line;
                html += "\n";
            }
            data.Close();
            reader.Close();
            // Console.WriteLine(html);
            return html;
        }

        string GetHtmlRoz(string site)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            string data = client.DownloadString(site);//видерання html 
            return data;
        }

        public List<MyItem> GetItemsFox()
        {
            List<MyItem> items = new List<MyItem>();
            ParsingForFoxtrot fox = new ParsingForFoxtrot();

            List<string> classes = fox.GetNewClasses();

            for (int i = 0; i < classes.Count; i++)
            {
                string site1 = fox.GetNewClasses()[i + 1];
                string html1 = GetHtmlRoz(site1);

                for (int j = 0; j < fox.GetNewPages(html1, site1).Count; j++)
                {
                    string site2 = fox.GetNewPages(html1, site1)[j];
                    string html2 = GetHtmlRoz(site2);
                    for (int g = 0; g < fox.GetNewGoodsOnPage(html2).Count; g++)
                    {
                        string site3 = fox.GetNewGoodsOnPage(html2)[g];
                        string html3 = GetHtmlRoz(site3);
                        MyItem item = new MyItem();
                        item.name = fox.GetName(html3);
                        item.discription = fox.GetDiscriptoin(html3);
                        item.price = fox.GetPrice(html3);
                        item.magaz = "fox";
                        items.Add(item);
                        Console.WriteLine($"Name:{item.name} Discription:{item.discription} Price:{item.price}");
                        Methods met = new Methods();
                        string fds = item.price;

                        fds = fds.Replace("грн", string.Empty);
                        fds = fds.Replace(" ", string.Empty);
                        string ns = "";
                        for (int s = 0; s < fds.Length - 1; s++)
                        {
                            ns += fds[s];
                        }
                        met.AddProducts(item.name, item.discription, int.Parse(ns), 8);
                    }
                }
            }

            return items;
        }

        public List<MyItem> GetItemsRoz()
        {
            List<MyItem> items = new List<MyItem>();
            ParsingForRozetka roz = new ParsingForRozetka();

            List<string> classes = roz.GetNewClasses();

            for (int i = 0; i < classes.Count; i++)
            {
                string site1 = roz.GetNewClasses()[i + 1];
                string html1 = GetHtmlRoz(site1);

                for (int j = 0; j < roz.GetNewPages(html1, site1).Count; j++)
                {
                    string site2 = roz.GetNewPages(html1, site1)[j];
                    string html2 = GetHtmlRoz(site2);
                    for (int g = 0; g < roz.GetNewGoodsOnPage(html2).Count; g++)
                    {
                        string site3 = roz.GetNewGoodsOnPage(html2)[g];
                        string html3 = GetHtmlRoz(site3);
                        MyItem item = new MyItem();
                        item.name = roz.GetName(html3);
                        item.discription = roz.GetDiscriptoin(html3);
                        item.price = roz.GetPrice(html3);
                        item.magaz = "fox";
                        items.Add(item);
                        Console.WriteLine($"Name:{item.name} Discription:{item.discription} Price:{item.price}");
                        Methods met = new Methods();
                        string fds = item.price;
                        
                        fds = fds.Replace("грн", string.Empty);
                        fds = fds.Replace(" ", string.Empty);
                        string ns = "";
                        for (int s = 0; s < fds.Length-1; s++)
                        {
                            ns += fds[s];
                        }
                        met.AddProducts(item.name, item.discription, int.Parse(ns), 7);
                    }
                }
            }

            return items;
        }
    }
}
