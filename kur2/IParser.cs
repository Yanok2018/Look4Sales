using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kur2
{
    interface IParser
    {
        string GetDiscriptoin(string html);//повертає опис товару,приймає html в форматі string

        string GetPrice(string html);//повертає ціну товару,приймає html в форматі string

        string GetName(string html);//повертає назву товару,приймає html в форматі string

        List<string> GetNewGoodsOnPage(string html);//повертає ліст стрінгов з ссилками на всі товари сторінкиurn sites;

        List<string> GetNewPages(string html, string thispage);//повертає ліст стрінгов з ссилками на всі товари сторінки

        List<string> GetNewClasses();//поветрає ссилкі на старотові сторінки різних класів(відеокарта,процесор,мать і тд.)
    }
}
