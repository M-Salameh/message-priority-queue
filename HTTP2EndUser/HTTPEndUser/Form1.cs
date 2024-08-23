using Grpc.Net.Client;
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
            Message message = getMessage();
            string address = "https://localhost:9091";
            using var channel = GrpcChannel.ForAddress(address);

            
            try
            {
                var client = new Send.SendClient(channel);
                var reply = client.SendMessage(message);
                
                if (reply.ReplyCode.Contains("OK" , StringComparison.OrdinalIgnoreCase))
                {
                    Response.Text = "Response : " + reply.ReplyCode + "\n" + reply.RequestID;
                    Response.ForeColor = Color.Green;
                }

                else
                {
                    Response.Text = "Response : " + reply.ReplyCode + "\n" + reply.RequestID;
                    Response.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Text = "Response : " + ex.Message;
                Response.ForeColor = Color.Red;
            }

        }

        private Message getMessage()
        {
            Message message = new Message();
            message.Text = MessageContent.Text;
            message.ApiKey = ApiKey.Text;
            message.ClientID = ClientID.Text;
            message.MsgId = ";";
            message.PhoneNumber = Receiver.Text;
            message.Tag = Tag.Text;

            message.LocalPriority = 1 + Priority.SelectedIndex;

            DateTime s = DatePicker.Value;
            message.Year = s.Year;
            message.Month = s.Month;
            message.Day = s.Day;

            try
            {
                message.Hour = int.Parse(Hours.Text);
                message.Hour = (message.Hour >= 0 && message.Hour <= 23) ? message.Hour : 23;
            }
            catch (Exception ex)
            {
                message.Hour = 23;
            }
            try
            {
                message.Minute = int.Parse(Minutes.Text);
                message.Minute = (message.Minute >= 0 && message.Minute <= 59) ? message.Minute : 30;
            }
            catch (Exception ex)
            {
                message.Minute = 30;
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