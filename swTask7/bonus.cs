using System.Text;
using System.Text.Json;
public class cntSolutions
{
    public static int CntSolutions(double a, double b, double c)
    {
        double d = b * b - 4 * a * c;
        if (d < 0) return 0;
        else if (d == 0) return 1;
        else return 2
    }

}

public static class BuildTask
{
    public static readonly HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com"), };
    public static async void Task(HttpClient client)
    {
        string host = "https://api.tracker.yandex.net";
        client.BaseAddress = new Uri(host);
        string direct = "/v2/issues";
        string token = "y0_AgAAAABdx8V8AAr6sgAAAAD0lRNoGTu4N5UlS82mwTRCNB7t4tHHwLE";
        client.DefaultRequestHeaders.Add("Authorizaton", $"OAuth {token}");

        string orgID = "bpfbmihbfa98v3kflolj";
        client.DefaultRequestHeaders.Add("X-Cloud-Org-ID", orgID );

        string[] arr = { "protsuk.yuriy", "iwhanter" };

        StringContent json = new(JsonSerializer.Serialize(new
        {
            queue = "TEAMCITYBUILDFA",
            summary = "И восстали машины из пепла ядерного огня",
            description = "машины не восстали",
            type = "task",
            priority = "critical",
            followers = arr,
            author = "dstrigin11",
            assignee = "dstrigin11",
        }),Encoding.UTF8, "application/json");
        var response = client.PostAsync(host + direct, json).Result; 
        if (response.IsSuccessStatusCode) 
        {
            string responseBody = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine($"Response: {responseBody}");
        }
        else
        {
            Console.WriteLine($"error: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }
}


class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine(cntSolutions.CntSolutions(1, 1, 1));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Задача создана");
            BuildTask.Task(BuildTask.httpClient);
        }

    }
}
