
using HTTPMessageGenerator;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

MessageDTO message = new MessageDTO();
message.text = "Hello World !";
message.apiKey = "Api-Key";
message.clientID = "m-salameh";
message.localPriority = 1;
message.msgId = "msg-id=1";
message.phoneNumber = "043 33 00 83";
message.tag = "SYR";
//message.year = message.month = message.day = message.minute = 0;
message.year = 2024;
message.month = 8;
message.day = 16;
message.hour = 23;
message.minute = 59;

CancellationTokenSource cancel = new CancellationTokenSource();
/*
var client = new HttpClient();

StringContent payload = new(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json");

try
{
    HttpResponseMessage reply = await client.PostAsync("http://localhost:7095/queue-msg", payload);

    Console.WriteLine(reply.Content.ToString());
}
catch (Exception ex)
{
    Console.Error.WriteLine("Error Processing - Connection Problem");
}
*/
/*
var task1 = Task.Run(async () =>
{
    while (!cancel.IsCancellationRequested)
    {
        var client = new HttpClient();

        StringContent payload = new(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage reply = await client.PostAsync("http://localhost:7095/queue-msg", payload);

            Console.WriteLine(reply.Content.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error Processing - Connection Problem");
        }
        await Task.Delay(1000);
    }
});*/


Task[] tsks = new Task[6];
for (int i=0; i < tsks.Length; i++)
{
    tsks[i] = Task.Run(async () =>
    {
        while (!cancel.IsCancellationRequested)
        {
            var client = new HttpClient();

            StringContent payload = new(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage reply = await client.PostAsync("http://localhost:7095/queue-msg", payload);

                Console.WriteLine(reply.Content.ToString());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error Processing - Connection Problem");
            }
            await Task.Delay(1000);
        }
    });
}

Task.WaitAll(tsks);