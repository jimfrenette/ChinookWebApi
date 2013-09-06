using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ChinookWebApi
{
    using Models;

    public class Chinook
    {

        public static List<Albums> Albums(int albumId)
        {
            var albumList = new List<Albums>();
            var conn = new SqlConnection(Config.ChinookConnection);
            conn.Open();
            var cmd = new SqlCommand("GetAlbums", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", albumId);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                albumList.Add(new Albums
                {
                    AlbumId = Convert.ToInt32(dr["AlbumId"]),
                    Title = dr["Title"].ToString(),
                    ArtistId = Convert.ToInt32(dr["ArtistId"])
                });
            }
            dr.Close();
            conn.Close();

            return albumList;
        }

        public static List<Albums> AlbumsByArtist(int artistId)
        {
            var albumList = new List<Albums>();
            var conn = new SqlConnection(Config.ChinookConnection);
            conn.Open();
            var cmd = new SqlCommand("GetAlbums", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ArtistId", artistId);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                albumList.Add(new Albums
                {
                    AlbumId = Convert.ToInt32(dr["AlbumId"]),
                    Title = dr["Title"].ToString(),
                    ArtistId = Convert.ToInt32(dr["ArtistId"])
                });
            }
            dr.Close();
            conn.Close();

            return albumList;
        }

        public static List<Artists> Artists(int artistId)
        {
            var artistList = new List<Artists>();
            var conn = new SqlConnection(Config.ChinookConnection);
            conn.Open();
            var cmd = new SqlCommand("GetArtists", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", artistId);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                artistList.Add(new Artists
                {
                    ArtistId = Convert.ToInt32(dr["ArtistId"]),
                    Name = dr["Name"].ToString()
                });
            }
            dr.Close();
            conn.Close();

            return artistList;
        }

        public static void DeleteTrack(int trackId)
        {
            var conn = new SqlConnection(Config.ChinookConnection);
            conn.Open();
            var cmd = new SqlCommand("DeleteTrack", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", trackId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        public static List<Tracks> Tracks(int trackId)
        {
            var trackList = new List<Tracks>();
            var conn = new SqlConnection(Config.ChinookConnection);
            conn.Open();
            var cmd = new SqlCommand("GetTracks", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", trackId);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                trackList.Add(new Tracks
                {
                    TrackId = Convert.ToInt32(dr["TrackId"]),
                    Name = dr["Name"].ToString(),
                    AlbumId = Convert.ToInt32(dr["AlbumId"]),
                    MediaTypeId = Convert.ToInt32(dr["MediaTypeId"]),
                    GenreId = Convert.ToInt32(dr["GenreId"]),
                    Composer = dr["Composer"].ToString(),
                    Milliseconds = Convert.ToInt32(dr["Milliseconds"]),
                    Bytes = Convert.ToInt32(dr["Bytes"]),
                    UnitPrice = Convert.ToDouble(dr["UnitPrice"]),
                });
            }
            dr.Close();
            conn.Close();

            return trackList;
        }

        public static List<Tracks> TracksByAlbum(int albumId)
        {
            var trackList = new List<Tracks>();
            var conn = new SqlConnection(Config.ChinookConnection);
            conn.Open();
            var cmd = new SqlCommand("GetTracks", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@AlbumId", albumId);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                trackList.Add(new Tracks
                {
                    TrackId = Convert.ToInt32(dr["TrackId"]),
                    Name = dr["Name"].ToString(),
                    AlbumId = Convert.ToInt32(dr["AlbumId"]),
                    MediaTypeId = Convert.ToInt32(dr["MediaTypeId"]),
                    GenreId = Convert.ToInt32(dr["GenreId"]),
                    Composer = dr["Composer"].ToString(),
                    Milliseconds = Convert.ToInt32(dr["Milliseconds"]),
                    Bytes = Convert.ToInt32(dr["Bytes"]),
                    UnitPrice = Convert.ToDouble(dr["UnitPrice"]),
                });
            }
            dr.Close();
            conn.Close();

            return trackList;
        }

        public static Tracks UpsertTrack(Tracks tracks)
        {
            var conn = new SqlConnection(Config.ChinookConnection);
            conn.Open();
            var cmd = new SqlCommand("UpsertTrack", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            // Return value as parameter
            SqlParameter returnValue = new SqlParameter("returnVal", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            cmd.Parameters.AddWithValue("@AlbumId", tracks.AlbumId);
            cmd.Parameters.AddWithValue("@Bytes", tracks.Bytes);
            cmd.Parameters.AddWithValue("@Composer", tracks.Composer);
            cmd.Parameters.AddWithValue("@GenreId", tracks.GenreId);
            cmd.Parameters.AddWithValue("@MediaTypeId", tracks.MediaTypeId);
            cmd.Parameters.AddWithValue("@Milliseconds", tracks.Milliseconds);
            cmd.Parameters.AddWithValue("@Name", tracks.Name);
            cmd.Parameters.AddWithValue("@TrackId", tracks.TrackId);
            cmd.Parameters.AddWithValue("@UnitPrice", tracks.UnitPrice);
            cmd.ExecuteNonQuery();

            int id = Convert.ToInt32(returnValue.Value);
            tracks.TrackId = id;

            conn.Close();

            return tracks;
        }


        private class Config
        {
            static public String ChinookConnection { get { return WebConfigurationManager.ConnectionStrings["ChinookConnection"].ConnectionString; } }
        }

    }
}