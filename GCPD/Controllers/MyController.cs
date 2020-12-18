using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLibrary;


namespace IMR.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class LaborExchangeController : ControllerBase
    {
        private readonly IComics _service = new TestLibrary.TestService();
        private readonly ILogger<LaborExchangeController> _logger;

        public LaborExchangeController(ILogger<LaborExchangeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("comics")]
        public object[] ComicsGetAll()
        {
            PagedResult<ComicsModel> t = _service.ComicsGetAll();
            return GetPagedResultAsArray(t);
        }
/*
        [HttpGet]
        [Route("comics/id/{id:int}")]
        public object[] ComicsGetById(int id)
        {
            var t = _service.ComicsGetById(id);
            return GetPagedResultAsArray(t);
        }

        [HttpGet]
        [Route("comics/page/{page:int}/pagecount/{pagecount:int}")]
        public object[] ComicsGetByPageAndPagecount(int page, int pagecount)
        {
            var t = _service.ComicsGetByPageAndPagecount(page, pagecount);
            return GetPagedResultAsArray(t);
        }
*/
        private object[] GetPagedResultAsArray<T>(PagedResult<T> t)
        {
            List<object> objs = new List<object>
            {
                t.PageCount,
                t.Page
            };
            return objs.ToArray();
        }
    }
}