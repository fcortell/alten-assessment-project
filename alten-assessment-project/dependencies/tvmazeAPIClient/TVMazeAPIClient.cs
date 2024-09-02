using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json;
using tvmazeAPIClient.Model;

namespace tvmazeAPIClient
{
    public class TVMazeAPIClient
    {
        public async Task<List<TVMazeShow>> GetShows()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = await client.GetStringAsync("http://api.tvmaze.com/shows");
                    var shows = JsonConvert.DeserializeObject<List<TVMazeShow>>(result);


                    return shows;
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
