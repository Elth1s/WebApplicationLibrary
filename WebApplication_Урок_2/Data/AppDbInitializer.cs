using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Урок_2.Data.Models;

namespace WebApplication_Урок_2.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            //using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            //    if (!context.Books.Any())
            //    {
            //        context.Books.AddRange(
            //        new Book()
            //        {
            //            Title = "C# Programming in Easy Steps",
            //            Description = "2-е издание книги C# Programming in Easy Steps, научит вас программировать приложения и продемонстрирует все аспекты языка Cи, которые вам понадобятся для получения профессиональных результатов программирования. Все примеры отображают четкий код с выделенным синтаксисом, демонстрирующий основы языка Cи, включая переменные, массивы, логику, циклы, методы и классы.",
            //            Author = "Mike McGrath",
            //            IsRead = true,
            //            DateRead = DateTime.Now.AddDays(-52),
            //            Rate = 4,
            //            Genre = "Programming",
            //            Image = "https://www.britishbook.ua/upload/resize_cache/iblock/5d9/369_450_174b5ed2089e1946312e2a80dcd26f146/kniga_c_programming_in_easy_steps.jpeg",
            //            DateAdded = DateTime.Now.AddDays(-120)
            //        },
            //        new Book()
            //        {
            //            Title = "The DevOps Handbook",
            //            Description = "More than ever, the effective management of technology is critical for business competitiveness. For decades, technology leaders have struggled to balance agility, reliability, and security. The consequences of failure have never been greater―whether it's the healthcare.gov debacle, cardholder.",
            //            Author = "Patrick Debois",
            //            IsRead = false,
            //            DateRead = DateTime.Now.AddDays(-30),
            //            Rate = 4,
            //            Genre = "DevOps",
            //            Image = "https://images-na.ssl-images-amazon.com/images/I/51Z6uQ57ilL._SX324_BO1,204,203,200_.jpg",
            //            DateAdded = DateTime.Now.AddDays(-60),
                         
            //        });
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}
