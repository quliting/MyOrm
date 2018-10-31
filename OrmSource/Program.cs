using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OrmSource.Entity;
using OrmSource.Method;

namespace OrmSource
{
    class Program
    {
        static void Main(string[] args)
        {
            Phones phones = new Phones();
            phones.Phone = "1304118";
            phones.Remake = "屈立亭";
            phones.ModifyTime = DateTime.Now;
            phones.CreateTime = DateTime.Now;
            phones.Status = 1;


            int result = phones.Insert();
            Console.WriteLine("影响行数：" + result);
            Console.ReadKey();
        }
    }
}
