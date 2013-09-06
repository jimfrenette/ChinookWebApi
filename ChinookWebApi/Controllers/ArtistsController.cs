using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChinookWebApi.Controllers
{
    public class ArtistsController : ApiController
    {
        // GET api/artists
        public HttpResponseMessage Get()
        {
            var value = Chinook.Artists(0);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        public HttpResponseMessage Get(int id)
        {
            var value = Chinook.Artists(id);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

    }
}
