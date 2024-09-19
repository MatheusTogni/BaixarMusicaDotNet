using SpotifyAPI.Web;

namespace Classes
{
    public class Spotify
    {
        private static SpotifyClient client;

        public static async void Authenticate()
        {
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest("SPOTIFY_CLIENT_ID", "SPOTIFY_CLIENT_SECRET");
            var response = await new OAuthClient(config).RequestToken(request);

            client = new SpotifyClient(response.AccessToken);
        }

        public static async void DownloadAlbum(string url)
        {
            var albumId = ExtractIdFromUrl(url);
            var album = await client.Albums.Get(albumId);

            Console.WriteLine($"Baixando álbum: {album.Name}");
            // Lógica de download aqui
        }

        public static async void DownloadPlaylist(string url)
        {
            var playlistId = ExtractIdFromUrl(url);
            var playlist = await client.Playlists.Get(playlistId);

            Console.WriteLine($"Baixando playlist: {playlist.Name}");
            // Lógica de download aqui
        }

        private static string ExtractIdFromUrl(string url)
        {
            // Lógica para extrair o ID da URL
            return url.Split('/').Last();
        }
    }
}
