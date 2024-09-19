using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Classes
{
    public class BaixarMusica
    {
        public static async void DownloadFromYoutube(string url)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(url);

            var diretorio = "C:\\Musicas";  // Defina o diretório onde as músicas serão salvas
            var caminhoArquivo = System.IO.Path.Combine(diretorio, video.Title + ".mp3");

            await youtube.Videos.DownloadAsync(url, caminhoArquivo);

            Console.WriteLine($"Música {video.Title} baixada com sucesso em {caminhoArquivo}");
        }
    }
}
