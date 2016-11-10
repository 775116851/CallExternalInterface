using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace 分析网页
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.Default;
            string s = wc.DownloadString("http://news.sohu.com/20140621/n401153658.shtml");
            //Console.WriteLine(s);
            HTMLDocumentClass doc = new HTMLDocumentClass();
            doc.IHTMLDocument2_write(s);
            Console.WriteLine(doc.title);
            Console.WriteLine(doc.body.innerText);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$4");
            Console.WriteLine(doc.getElementById("contentText").innerText);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$5");
            foreach(IHTMLElement e in doc.links)
            {
                Console.WriteLine(e.innerText + e.getAttribute("href",0));
            }
        }
    }
}
