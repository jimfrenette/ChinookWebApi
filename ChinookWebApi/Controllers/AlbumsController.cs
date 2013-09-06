using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChinookWebApi.Controllers
{
    public class AlbumsController : ApiController
    {
        // GET api/albums
        public HttpResponseMessage Get()
        {
            var value = Chinook.Albums(0);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        public HttpResponseMessage Get(int id)
        {
            var value = Chinook.Albums(id);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        public HttpResponseMessage Get(string artistId)
        {
            int id = Convert.ToInt32(artistId);
            var value = Chinook.AlbumsByArtist(id);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

    }
}
