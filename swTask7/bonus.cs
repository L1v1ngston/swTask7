using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

class bonus
{
    static async Task Main()
    {
        var apiToken = "y0_AgAAAABdx8V8AAr6sgAAAAD0lRNoGTu4N5UlS82mwTRCNB7t4tHHwLE"; // Замените на ваш токен
        var queueId = "TEAMCITYBUILDFA";   // ID созданной очереди
        var ownerId = "aje5onvp7suh6hbr1jhh";   // ID владельца очереди
        var orgId = "bpfbmihbfa98v3kflolj";       // ID вашей организации в Yandex Tracker

        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"OAuth {apiToken}");
        client.DefaultRequestHeaders.Add("X-Org-ID", orgId);

        var url = "https://tracker.yandex.ru/createTicket?queue=TEAMCITYBUILDFA&_form=false";
        var data = new
        {
            queue = queueId,
            summary = "Build Failure in TeamCity",
            description = "A build has failed in TeamCity. Please investigate.",
            assignee = ownerId
        };

        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, content);
        

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Task created successfully");
        }
        else
        {
            Console.WriteLine("Failed to create task");
        }
    }
}
