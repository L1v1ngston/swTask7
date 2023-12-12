using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class bonus
{
    static async Task Main(string[] args)
    {
        var apiUrl = "https://tracker.yandex.ru/createTicket?queue=TEAMCITYBUILDFA&_form=false";
        var apiToken = "y0_AgAAAABdx8V8AAr6sgAAAAD0lRNoGTu4N5UlS82mwTRCNB7t4tHHwLE";
        var orgId = "bpfbmihbfa98v3kflolj";
        var queueId = "TEAMCITYBUILDFA";
        var ownerId = "aje5onvp7suh6hbr1jhh";

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"OAuth {apiToken}");
            client.DefaultRequestHeaders.Add("X-Org-ID", orgId);

            var json = $"{{\"queue\": \"{queueId}\", \"summary\": \"Build Failure in TeamCity\", \"description\": \"A build has failed in TeamCity. Please investigate.\", \"assignee\": \"{ownerId}\"}}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Task created successfully");
            }
            else
            {
                Console.WriteLine($"Failed to create task: {response.StatusCode}");
            }
        }
    }
}