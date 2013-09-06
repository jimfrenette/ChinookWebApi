using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChinookWebApi.Controllers
{
    using ChinookWebApi.Models;

    public class TracksController : ApiController
    {
        // GET api/tracks
        public HttpResponseMessage Get()
        {
            var value = Chinook.Tracks(0);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        public HttpResponseMessage Get(int id)
        {
            var value = Chinook.Tracks(id);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        public HttpResponseMessage Get(string albumId)
        {
            int id = Convert.ToInt32(albumId);
            var value = Chinook.TracksByAlbum(id);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        // POST api/tracks
        public HttpResponseMessage Post([FromBody]Tracks tracks)
        {
            var value = Chinook.UpsertTrack(tracks);
            return Request.CreateResponse(HttpStatusCode.OK, tracks);
        }

        // PUT api/tracks/5
        public HttpResponseMessage Put(int id, [FromBody]Tracks tracks)
        {
            tracks.TrackId = id;
            var value = Chinook.UpsertTrack(tracks);
            return Request.CreateResponse(HttpStatusCode.OK, tracks);
        }

        // DELETE api/tracks
        public HttpResponseMessage Delete([FromBody]int[] value)
        {
            foreach (int id in value)
            {
                Chinook.DeleteTrack(id);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/tracks/5
        public HttpResponseMessage Delete(int id)
        {
            Chinook.DeleteTrack(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
