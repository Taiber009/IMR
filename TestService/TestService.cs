using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using ModelsLibrary;

namespace TestLibrary
{
    public class TestService : IComics
    {
        private readonly List<ComicsModel> _test = new List<ComicsModel>();

        public TestService()
        {
            string[] s1 = new string[] { "Человек-", "Супер-", "Чудо-", "Железный ", "Адский ", "Серебряный ", "Женщина-" },
                     s2 = new string[] { "Паук", "Мэн", "Паук", "Кошка", "Таракан", "Жук", "Женщина", "Человек", "Соболь", "Кабан", "Воин" };
            Random rand = new Random();

            for (int i = 0; i < 30; i++)
            {
                _test.Add(new ComicsModel
                {
                    Name = $""+s1[rand.Next(s1.Length)]+ s2[rand.Next(s2.Length)],
                    ID = i
                });
            }
        }

        public PagedResult<ComicsModel> ComicsGetById(int id)
        {
            var newpage = new PagedResult<ComicsModel>();
            List<ComicsModel> tres = new List<ComicsModel>();
            foreach (var item in _test)
            {
                if (item.ID == id)
                {
                    tres.Add(item);
                    break;
                }
            }
            newpage.Page = tres.ToArray();
            newpage.PageCount = 1;
            return newpage;

        }

        public PagedResult<ComicsModel> ComicsGetAll()
        {
            var newpage = new PagedResult<ComicsModel>
            {
                Page = _test.ToArray(),
                PageCount = 1
            };
            return newpage;

        }

        public PagedResult<ComicsModel> ComicsGetByPageAndPagecount(int page, int pagecount)
        {
            var newpage = new PagedResult<ComicsModel>();
            //var ttx = _test.Skip((page - 1) * pagecount).Take(pagecount).ToArray();
            newpage.Page = _test.Skip((page - 1) * pagecount).Take(pagecount).ToArray(); ;
            newpage.PageCount = _test.Count() / pagecount + 1;
            return newpage;
        }
    }
}
