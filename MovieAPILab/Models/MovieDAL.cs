using System;
using Newtonsoft.Json;
using System.Net;

namespace MovieAPILab.Models
{
	public class MovieDAL
	{
        public static MovieModel GetMovie(string searchTerm) //adjust here (output type and method name)
        {
            //Setup
            string url = $"https://www.omdbapi.com/?t={searchTerm}&apikey=7ed57eb1";

            //Request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert it to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Convert to C#
            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result;
            //adjust here (change to match object name)
        }
    }
}

