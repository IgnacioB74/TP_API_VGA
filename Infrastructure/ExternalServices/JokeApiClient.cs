using System.Net.Http;
using System.Text.Json;
using Application.Interfaces;
using Application.Models.ExternalDTO;

public class JokeApiClient : IJokeService
{
    private readonly HttpClient _httpClient;

    public JokeApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<JokeDTO>> GetJokesAsync()
    {
        var response = await _httpClient.GetAsync("random_ten");

        if (!response.IsSuccessStatusCode)
            return new List<JokeDTO>();

        var content = await response.Content.ReadAsStringAsync();

        var jokes = JsonSerializer.Deserialize<List<JokeDTO>>(
            content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return jokes ?? new List<JokeDTO>();
    }
}