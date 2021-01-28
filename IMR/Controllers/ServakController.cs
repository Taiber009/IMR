using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLibrary;


namespace IMR.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class ServakController : ControllerBase
    {
        private readonly IComicsService _service = new TestLibrary.TestService();
        private readonly ILogger<ServakController> _logger;

        public ServakController(ILogger<ServakController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [EnableCors]
        [Route("comics")]
        public object[] ComicsGetAll()
        {
            PagedResult<ComicsModel> t = _service.ComicsGetAll();
            return GetPagedResultAsArray(t);
        }

        [HttpGet]
        [EnableCors]
        [Route("comics/id/{id:int}")]
        public object[] ComicsGetById(int id)
        {
            var t = _service.ComicsGetById(id);
            return GetPagedResultAsArray(t);
        }

        /*[HttpGet]
        [EnableCors]
        [Route("comics/page/{page:int}/pagecount/{pagecount:int}")]
        public object[] ComicsGetByPageAndPagecount(int page, int pagecount)
        {
            var t = _service.ComicsGetByPageAndPagecount(page, pagecount);
            return GetPagedResultAsArray(t);
        }*/

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