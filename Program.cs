using ScreenSound.Modelos;
using System.Text.Json;
using ScreenSound.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        //Console.WriteLine(resposta);
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Michel Teló");

        var musicasPreferidasDoDaniel = new MusicasPreferidas("Daniel");
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[377]);
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[4]);
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[6]);
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[1467]);

        musicasPreferidasDoDaniel.ExibirMusicasFavoritas();

        var musicasPreferidasDaEmilly = new MusicasPreferidas("Emilly");
        musicasPreferidasDaEmilly.AdicionarMusicasFavoritas(musicas[500]);
        musicasPreferidasDaEmilly.AdicionarMusicasFavoritas(musicas[637]);
        musicasPreferidasDaEmilly.AdicionarMusicasFavoritas(musicas[428]);
        musicasPreferidasDaEmilly.AdicionarMusicasFavoritas(musicas[13]);
        musicasPreferidasDaEmilly.AdicionarMusicasFavoritas(musicas[71]);

        musicasPreferidasDaEmilly.ExibirMusicasFavoritas();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}