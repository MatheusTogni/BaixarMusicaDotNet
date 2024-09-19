using SpotifyAPI.Web;
using YoutubeExplode;
using System.Threading.Tasks;

namespace Classes
{
    public class Music
    {
        private static SpotifyClient spotifyClient;
        private static YoutubeClient youtubeClient;

        public static async Task SearchOnSpotify(string query)
        {
            var searchResponse = await spotifyClient.Search.Item(new SearchRequest(SearchRequest.Types.Track, query));
            foreach (var track in searchResponse.Tracks.Items)
            {
                Console.WriteLine($"Encontrado no Spotify: {track.Name} por {track.Artists[0].Name}");
            }
        }

        public static async Task SearchOnYoutube(string query)
        {
            var youtube = new YoutubeClient();
            var videos = await youtube.Search.GetVideosAsync(query);

            foreach (var video in videos)
            {
                Console.WriteLine($"Encontrado no YouTube: {video.Title} - {video.Url}");
            }
        }
    }
}
