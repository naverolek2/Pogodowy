using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Pogodowy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string url = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current_weather=true&timezone=Europe%2FBerlin";

            HttpClient client = new HttpClient();
            string response = client.GetStringAsync(url).Result;
            JsonDocument document = JsonDocument.Parse(response);
            JsonElement element = document.RootElement.GetProperty("current_weather");
            textBox1.Text = element.GetProperty("temperature").ToString();
            textBox2.Text = element.GetProperty("windspeed").ToString();
            int num = int.Parse(element.GetProperty("weathercode").ToString());
            if(num == 0)
            {
                textBox3.Text = "Clear Sky";
            }
            else if(num == 1 || num == 2 || num == 3)
            {
                textBox3.Text = "Mainly clear, partly cloudy, and overcast";
            }
            else if (num == 45 || num == 48)
            {
                textBox3.Text = "Fog and depositing rime fog";
            }
            else if (num == 51 || num == 53 || num == 55)
            {
                textBox3.Text = "Drizzle: Light, moderate, and dense intensity";
            }
            // I tak dalej 
        }

  
    }
}