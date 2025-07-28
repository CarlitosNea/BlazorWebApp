using System;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BlazorApp;

public class DocumentoService
{
    private readonly HttpClient _httpClient;

    public DocumentoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "ae8bad44-7348-11ee-b962-0242ac120002");
    }

    public async Task<List<Documento>> GetDocumentosAsync()
    {
        var response = await _httpClient.GetAsync("https://mainserver.ziursoftware.com/ziur.API/basedatos_01/ZiurServiceRest.svc/api/DocumentosFillsCombos");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Documento>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}