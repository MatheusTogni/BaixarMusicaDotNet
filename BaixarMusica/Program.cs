using System;
using Classes;
﻿using YoutubeExplode;

class Program
{
    static void Main(string[] args)
    {
        // Mensagem de boas-vindas
        Console.WriteLine("Bem vindo, bora baixar musicas, qualquer duvida digite -h para demonstrar os comandos");

        if (args.Length == 0)
        {
            Console.WriteLine("Por favor, insira um comando válido.");
            return;
        }

        string comando = args[0];
        string url = args.Length > 1 ? args[1] : string.Empty;

        switch (comando)
        {
            case "-h":
                ExibirAjuda();
                break;

            case "-m":
                if (!string.IsNullOrEmpty(url))
                {
                    BaixarMusica.DownloadFromYoutube(url);
                }
                else
                {
                    Console.WriteLine("URL da música não fornecida!");
                }
                break;

            case "-a":
                if (!string.IsNullOrEmpty(url))
                {
                    Spotify.DownloadAlbum(url);
                }
                else
                {
                    Console.WriteLine("URL do álbum não fornecida!");
                }
                break;

            case "-p":
                if (!string.IsNullOrEmpty(url))
                {
                    Spotify.DownloadPlaylist(url);
                }
                else
                {
                    Console.WriteLine("URL da playlist não fornecida!");
                }
                break;

            default:
                Console.WriteLine("Comando não reconhecido.");
                break;
        }
    }

    static void ExibirAjuda()
    {
        Console.WriteLine("Lista de comandos disponíveis:");
        Console.WriteLine("-h: Exibe este menu de ajuda.");
        Console.WriteLine("-m \"URL\": Baixa uma música do YouTube utilizando a URL fornecida.");
        Console.WriteLine("-a \"URL\": Baixa um álbum do Spotify utilizando a URL fornecida.");
        Console.WriteLine("-p \"URL\": Baixa uma playlist do Spotify utilizando a URL fornecida.");
    }
}
