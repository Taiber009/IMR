using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Interfaces;
using ModelsLibrary;
using MySql.Data.MySqlClient;

namespace TestLibrary
{
    public class TestService : IComicsService
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
                    Name = $"" + s1[rand.Next(s1.Length)] + s2[rand.Next(s2.Length)],
                    ID = i
                });
            }
        }

        /*public TestService()
        {
            // Equivalent connection string:
            // "Uid=<DB_USER>;Pwd=<DB_PASS>;Host=<DB_HOST>;Database=<DB_NAME>;"
            var connectionString = new MySqlConnectionStringBuilder()
            {
                // The Cloud SQL proxy provides encryption between the proxy and instance.
                SslMode = MySqlSslMode.None,

                // Remember - storing secrets in plaintext is potentially unsafe. Consider using
                // something like https://cloud.google.com/secret-manager/docs/overview to help keep
                // secrets secret.
                Server = Environment.GetEnvironmentVariable("imr2-303014:us-central1:comics-sql"),   // e.g. '127.0.0.1'
                // Set Host to 'cloudsql' when deploying to App Engine Flexible environment
                UserID = Environment.GetEnvironmentVariable("root"),   // e.g. 'my-db-user'
                Password = Environment.GetEnvironmentVariable("1234"), // e.g. 'my-db-password'
                Database = Environment.GetEnvironmentVariable("ComicsDB"), // e.g. 'my-database'
            };
            connectionString.Pooling = true;
            // Specify additional properties here.
            // ...
            MySqlConnection connection =
                new MySqlConnection(connectionString.ConnectionString);


            for (int i = 0; i < 30; i++)
            {
                _test.Add(new ComicsModel
                {
                    Name = $"" + new MySqlCommand("SELECT Name FROM comics WHERE ID = "+i, connection).ExecuteScalar().ToString(),
                ID = i
                });
            }
        }*/

        public List<ComicsModel> ComicsGetById(int id)
        {
            List<ComicsModel> tres = new List<ComicsModel>();
            foreach (var item in _test)
            {
                if (item.ID == id)
                {
                    tres.Add(item);
                    break;
                }
            }
            return tres;

        }

        public List<ComicsModel> ComicsGetAll()
        {
            return _test;

        }

        /*public PagedResult<ComicsModel> ComicsGetByPageAndPagecount(int page, int pagecount)
        {
            var rr = new PagedResult<ComicsModel>();
            var ttx = _test.Skip((page - 1) * pagecount).Take(pagecount).ToArray();
            rr.Page = ttx;
            rr.PageCount = _test.Count() / pagecount + 1;
            return rr;
        }*/
    }
}
