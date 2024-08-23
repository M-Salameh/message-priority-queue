
using HTTPMessageGenerator;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

MessageDTO message = new MessageDTO();
message.text = "Hello World !";
message.apiKey = "a";
message.clientID = "1";
message.localPriority = 1;
message.msgId = "msg-id=1";
message.phoneNumber = "043 33 00 83";
message.tag = "mtn";
//message.year = message.month = message.day = message.minute = 0;
message.year = 0;
message.month = 0;
message.day = 0;
message.hour = 0;
message.minute = 0;

CancellationTokenSource cancel = new CancellationTokenSource();

var client = new HttpClient();

StringContent payload = new(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json");


try
{
    HttpResponseMessage rr = await client.PostAsync("http://localhost:7095/queue-msg", payload);
 
    string json = await rr.Content.ReadAsStringAsync();
    Reply reply = JsonSerializer.Deserialize<Reply>(json);

    // Access the properties of the parsed object
    Console.WriteLine($"replyCode: {reply.replyCode}");
    Console.WriteLine($"requestID: {reply.requestID}");
}
catch (Exception ex)
{
    Console.Error.WriteLine("Error Processing - Connection Problem");
}

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

/*
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

Task.WaitAll(tsks);*/