using System.Net.Http.Json;
using System.Text.Json;
using Domain.Dtos;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PageHttpClient : IPageService
{
    private readonly HttpClient client;

    public PageHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(PageCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Page", dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<ICollection<Page>> GetAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/Page");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Page> pages = JsonSerializer.Deserialize<ICollection<Page>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return pages;
    }

    public async Task<BasicIdPage> GetByIdAsync(int id)
    {
        string uri = "/Page";
        
        HttpResponseMessage response = await client.GetAsync($"/Page/{id}");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        BasicIdPage page = JsonSerializer.Deserialize<BasicIdPage>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return page;
    }
}