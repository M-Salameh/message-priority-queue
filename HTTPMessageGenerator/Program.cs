// See https://aka.ms/new-console-template for more information


using HTTPMessageGenerator;
using System.Net;
using System.Text;
using System.Text.Json;

MessageDTO message = new MessageDTO();
message.text = "Hello World !";
message.apiKey = "Api-Key";
message.clientID = "m-salameh";
message.localPriority = 1;
message.msgId = "msg-id=1";
message.phoneNumber = "043 33 00 83";
message.tag = "SYYR";


var client = new HttpClient();

StringContent payload = new (JsonSerializer.Serialize(message) , Encoding.UTF8 , "application/json");

try
{
    HttpResponseMessage reply = await client.PostAsync("https://localhost:7095/queue-msg", payload);


    Console.WriteLine(reply.Content.ToString());
}
catch (Exception ex)
{
    Console.Error.WriteLine("Error Processing - Connection Problem");
}
//Console.WriteLine(reply.Result);
