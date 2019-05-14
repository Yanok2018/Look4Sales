using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kur2
{
    class ParsingForRozetka : IParser
    {
        public string GetDiscriptoin(string html)//повертає опис товару,приймає html в форматі string
        {
            string dis = "";

            var htmlDoc = new HtmlDocument();//для парсінга
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection NoAltElements = htmlDoc.DocumentNode.SelectNodes("//div[@class='b-rich-text goods-description-content']");//вибрання вузлів з описом
            try
            {
                foreach (var item in NoAltElements)
                {
                    dis = item.InnerText;//видерання тексту опису
                }
                string newdis = "";
                for (int i = 0; i < dis.Length; i++)
                {
                    newdis += dis[i];
                    if (i >= 200 && dis[i] == '.')
                    {
                        dis = newdis;
                        break;
                    }
                }

            }
            catch (Exception)
            {
                dis = "Без описания";
            }

            return dis;
        }

        public string GetPrice(string html)//повертає ціну товару,приймає html в форматі string
        {
            string dis = "";

            var htmlDoc = new HtmlDocument();//для парсінга
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection NoAltElements = htmlDoc.DocumentNode.SelectNodes("//span[@class='detail-price-uah']");//вибрання вузлів з ціною товару

            foreach (var item in NoAltElements)
            {
                dis = item.InnerText.Replace("?", " ");//видерання тексту ціни
            }

            return dis;
        }

        public string GetName(string html)//повертає назву товару,приймає html в форматі string
        {
            string dis = "";

            var htmlDoc = new HtmlDocument();//для парсінга
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection NoAltElements = htmlDoc.DocumentNode.SelectNodes("//meta[@name='og:title']");//вибрання вузлів з ім'ям

            foreach (var item in NoAltElements)
            {
                dis = item.GetAttributeValue("content", "");//видерання імені товару
            }

            return dis;
        }

        public List<string> GetNewGoodsOnPage(string html)//повертає ліст стрінгов з ссилками на всі товари сторінки
        {
            List<string> sites = new List<string>();

            var htmlDoc = new HtmlDocument();//для парсінга
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection NoAltElements = htmlDoc.DocumentNode.SelectNodes("//li[@class='g-i-tile-review-l-i']//a");//вибрання вузлів з ссилкою

            foreach (var item in NoAltElements)
            {
                string ourhref = item.GetAttributeValue("href", "");
                //Console.WriteLine(ourhref);//тест!!!
                sites.Add(ourhref);//видерання ссилок на новий товар
            }

            return sites;
        }

        public List<string> GetNewPages(string html, string thispage)//повертає ліст стрінгов з ссилками на всі товари сторінки
        {
            List<string> sites = new List<string>();

            var htmlDoc = new HtmlDocument();//для парсінга
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection NoAltElements = htmlDoc.DocumentNode.SelectNodes("//span[@class='paginator-catalog-l-i-active hidden']");//вибрання вузлів з ссилкою

            int count_of_pages = int.Parse(NoAltElements[NoAltElements.Count - 1].InnerText);

            for (int i = 1; i < count_of_pages + 1; i++)
            {
                //  Console.WriteLine(thispage + $"page={i.ToString()};sort=action/");//test
                sites.Add(thispage + $"page={i.ToString()};sort=action/");
            }

            return sites;
        }

        public List<string> GetNewClasses()
        {
            List<string> classes = new List<string>() {
              //  "https://hard.rozetka.com.ua/ua/processors/c80083/",
              //  "https://hard.rozetka.com.ua/ua/videocards/c80087/",
                "https://hard.rozetka.com.ua/ua/cases/c80090/",
                };
            return classes;
        }
    }
}
