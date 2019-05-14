using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kur2
{
    class ParsingForFoxtrot : IParser
    {
        public string GetName(string html)
        {
            string name = "";

            var htmlDoc = new HtmlDocument();//для парсінга
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection NoAltElements = htmlDoc.DocumentNode.SelectNodes("//meta[@name='keywords']");//вибрання вузлів з ім'ям

            foreach (var item in NoAltElements)
            {
                name = item.GetAttributeValue("content", "");
                //  Console.WriteLine(item.GetAttributeValue("content", ""));//test
            }

            return name;
        }

        public string GetDiscriptoin(string html)
        {
            string dis = GetName(html);
            return dis;
        }

        public string GetPrice(string html)
        {
            string price = "";
            int ind1 = html.IndexOf("class=\"numb\">"), ind2 = 0;
            for (int i = ind1; i < html.Length; i++)
            {
                if (string.Compare(html[i].ToString(), "<") == 0)
                {
                    ind2 = i;
                    break;
                }
            }
            for (int i = ind1 + 13; i < ind2; i++)
            {
                price += html[i];
            }
            // Console.WriteLine(price);
            return price;
        }

        public List<string> GetNewGoodsOnPage(string html)//повернення ссилок на всі товари
        {
            List<string> goods = new List<string>();
            int ind1 = html.IndexOf("\"product-listing\"");
            string newhtml = "";
            for (int i = ind1; i < html.Length; i++)
            {
                newhtml += html[i];
            }

            var htmlDoc = new HtmlDocument();//для парсінга
            htmlDoc.LoadHtml(newhtml);
            try
            {
                HtmlNodeCollection NoAltElements = htmlDoc.DocumentNode.SelectNodes("//a[@class='listing-link detail-link']");//вибрання вузлів з ім'ям
                foreach (var item in NoAltElements)
                {
                    // Console.WriteLine("https://www.foxtrot.com.ua" + item.GetAttributeValue("href", ""));//TEST!!!
                    goods.Add("https://www.foxtrot.com.ua" + item.GetAttributeValue("href", ""));
                }

                NoAltElements = htmlDoc.DocumentNode.SelectNodes("//a[@class='listing-item__img-container detail-link']");//вибрання вузлів з ім'ям

                foreach (var item in NoAltElements)
                {
                    //  Console.WriteLine("https://www.foxtrot.com.ua" + item.GetAttributeValue("href", ""));//TEST!!!
                    goods.Add("https://www.foxtrot.com.ua" + item.GetAttributeValue("href", ""));
                }

                NoAltElements = htmlDoc.DocumentNode.SelectNodes("//a[@class='reviews-link']");//вибрання вузлів з ім'ям

                foreach (var item in NoAltElements)
                {
                    //   Console.WriteLine("https://www.foxtrot.com.ua" + item.GetAttributeValue("href", ""));//TEST!!!
                    goods.Add("https://www.foxtrot.com.ua" + item.GetAttributeValue("href", ""));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            return goods;
        }

        public List<string> GetNewPages(string html, string thispage)
        {
            List<string> pages = new List<string>();

            var htmlDoc = new HtmlDocument();//для парсінга
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection NoAltElements = htmlDoc.DocumentNode.SelectNodes("//span[@class='pagination-text']");//вибрання вузлів з ім'ям

            string count_of_pages = NoAltElements[NoAltElements.Count - 2].InnerText;

            for (int i = 1; i < int.Parse(count_of_pages) + 1; i++)
            {
                //Console.WriteLine(thispage + "?page=" + i);
                pages.Add(thispage /*+ "?page=" + i*/);
            }


            return pages;
        }

        public List<string> GetNewClasses()
        {
            List<string> classes = new List<string>() {
                "https://www.foxtrot.com.ua/ru/shop/processori.html?page=1",
                "https://www.foxtrot.com.ua/ru/shop/materinskie_plati.html?page=1",
                "https://www.foxtrot.com.ua/ru/shop/videokarti.html?page=1" };
            return classes;
        }

    }
}
