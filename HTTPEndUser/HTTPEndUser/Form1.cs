using System.Text;
using System.Text.Json;

namespace HTTPEndUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void SendMessageAsync(object sender, EventArgs e)
        {
            MessageDTO message = getMessage();

            var client = new HttpClient();

            StringContent payload = new(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage reply =  await client.PostAsync("http://localhost:7095/queue-msg", payload);
                
                Response.Text = "Respose : " + reply.Content.ToString();
                Response.ForeColor = Color.Green;


                //Console.WriteLine(reply.Content.ToString());
            }
            catch (Exception ex)
            {
                Response.Text = "Response : " + ex.Message;
                Response.ForeColor = Color.Red;
                //Console.Error.WriteLine("Error Processing - Connection Problem");
            }

        }

        private MessageDTO getMessage()
        {
            MessageDTO message = new MessageDTO();
            message.text = MessageContent.Text;
            message.apiKey = ApiKey.Text;
            message.clientID = ClientID.Text;
            message.msgId = ";";
            message.phoneNumber = Receiver.Text;
            message.tag = Tag.Text;

            message.localPriority = 1 + Priority.SelectedIndex;

            DateTime s = DatePicker.Value;
            message.year = s.Year;
            message.month = s.Month;
            message.day = s.Day;

            try
            {
                message.hour = int.Parse(Hours.Text);
                message.hour = (message.hour >= 0 && message.hour <= 23) ? message.hour : 23;
            }
            catch (Exception ex)
            {
                message.hour = 23;
            }
            try
            {
                message.minute = int.Parse(Minutes.Text);
                message.minute = (message.minute >= 0 && message.minute <= 59) ? message.minute : 30;
            }
            catch (Exception ex)
            {
                message.minute = 30;
            }
            return message;

        }

        private void ClearContent(object sender, EventArgs e)
        {
            MessageContent.Clear();

        }

        private void ClearClientID(object sender, EventArgs e)
        {
            ClientID.Clear();
        }

        private void ClearApiKey(object sender, EventArgs e)
        {
            ApiKey.Clear();
        }

        private void ClearTag(object sender, EventArgs e)
        {
            Tag.Clear();
        }

        private void ClearReceiver(object sender, EventArgs e)
        {
            Receiver.Clear();
        }

        private void ClearHours(object sender, EventArgs e)
        {
            Hours.Clear();
        }

        private void ClearMinutes(object sender, EventArgs e)
        {
            Minutes.Clear();
        }

    }
}