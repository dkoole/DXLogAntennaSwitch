using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.WebSockets;
using System.Net;
using System.Threading;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.IO;

namespace DXLog.net
{
    public partial class DXLbuttonbar : KForm
    {
        public static string CusWinName
        {
            get { return "Antenna Switch"; }
        }

        public static int CusFormID
        {
            get { return 1021; }
        }
        
        private ClientWebSocket client = new ClientWebSocket();

        private Font _windowFont = new Font("Courier New", 10, FontStyle.Regular);

        private FrmMain mainForm = null;

        private String antennaSwitchIp = "";

        private delegate void newQsoSaved(DXQSO qso);

        public DXLbuttonbar()
        {
            InitializeComponent();

        }

        public DXLbuttonbar(ContestData cdata)
        {
            InitializeComponent();
            ColorSetTypes = new string[] { "Background", "Color", "Header back color", "Header color", "Footer back color", "Footer color", "Final score color", "Selection back color", "Selection color" };
            DefaultColors = new Color[] { Color.Turquoise, Color.Black, Color.Gray, Color.Black, Color.Silver, Color.Black, Color.Blue, Color.SteelBlue, Color.White };
            FormLayoutChangeEvent += new FormLayoutChange(Handle_FormLayoutChangeEvent);
            try
            {
                string assemblyFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string configFileName = Path.Combine(assemblyFolder, "antenna_switch.txt");
                string configString = File.ReadAllText(@configFileName);
                this.label1.Text = configString;
                try
                {
                    IPAddress address = IPAddress.Parse(configString);
                    antennaSwitchIp = configString;
                    this.label1.Text = antennaSwitchIp;
                    this.Connect.Enabled = true;
                } catch (Exception)
                {
                    this.label1.Text = "Could not parse IP";
                }
            }
            catch (Exception)
            {
                this.label1.Text = "No Config File";
            }
        }

        private async Task ReceiveWebsocketData()
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    while (client.State == WebSocketState.Open)
                    {
                        WebSocketReceiveResult result;
                        do
                        {
                            var messageBuffer = WebSocket.CreateClientBuffer(1024, 16);
                            result = await client.ReceiveAsync(messageBuffer, CancellationToken.None);
                            ms.Write(messageBuffer.Array, messageBuffer.Offset, result.Count);
                        }
                        while (!result.EndOfMessage);

                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            var msgString = Encoding.ASCII.GetString(ms.ToArray());
                            if (msgString == "ant1")
                            {
                                this.ANT1.BackColor = Color.Red;
                                this.ANT2.BackColor = SystemColors.Highlight;
                                this.ANT3.BackColor = SystemColors.Highlight;
                                this.ANT4.BackColor = SystemColors.Highlight;
                            }
                            else if (msgString == "ant2")
                            {
                                this.ANT1.BackColor = SystemColors.Highlight;
                                this.ANT2.BackColor = Color.Red;
                                this.ANT3.BackColor = SystemColors.Highlight;
                                this.ANT4.BackColor = SystemColors.Highlight;
                            }
                            else if (msgString == "ant3")
                            {
                                this.ANT1.BackColor = SystemColors.Highlight;
                                this.ANT2.BackColor = SystemColors.Highlight;
                                this.ANT3.BackColor = Color.Red;
                                this.ANT4.BackColor = SystemColors.Highlight;
                            }
                            else if (msgString == "ant4")
                            {
                                this.ANT1.BackColor = SystemColors.Highlight;
                                this.ANT2.BackColor = SystemColors.Highlight;
                                this.ANT3.BackColor = SystemColors.Highlight;
                                this.ANT4.BackColor = Color.Red;
                            }
                        }
                        ms.Seek(0, SeekOrigin.Begin);
                        ms.Position = 0;
                    }
                }
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void Handle_FormLayoutChangeEvent()
        {
            InitializeLayout();

        }

        public override void InitializeLayout()
        {
            InitializeLayout(_windowFont);
            if (FormLayout.FontName.Contains("Courier"))
                _windowFont = new Font(FormLayout.FontName, FormLayout.FontSize, FontStyle.Regular);
            else
                _windowFont = Helper.GetSpecialFont(FontStyle.Regular, FormLayout.FontSize);

            if (mainForm == null)
            {
                mainForm = (FrmMain)(ParentForm ?? Owner);
            }


            contextMenuStrip1.Items.RemoveByKey("fixWindowSizeToolStripMenuItem");
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private async void F1_Click(object sender, EventArgs e)
        {
            await client.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("ant1")), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async void F2_Click(object sender, EventArgs e)
        {
            await client.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("ant2")), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async void F3_Click(object sender, EventArgs e)
        {
            await client.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("ant3")), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async void F4_Click(object sender, EventArgs e)
        {
            await client.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("ant4")), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private void DXLbuttonbar_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void Connect_Click(object sender, EventArgs e)
        {
            if(client.State != WebSocketState.Open)
            {
                client = new ClientWebSocket();
                await client.ConnectAsync(new Uri($"ws://{antennaSwitchIp}/ws"), CancellationToken.None);
                this.Connect.Text = "Disconnect";
                this.ANT1.Enabled = true;
                this.ANT2.Enabled = true;
                this.ANT3.Enabled = true;
                this.ANT4.Enabled = true;
                await ReceiveWebsocketData();
            } else 
            {
                await client.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
                this.Connect.Text = "Connect";
                this.ANT1.BackColor = SystemColors.Highlight; 
                this.ANT2.BackColor = SystemColors.Highlight;
                this.ANT3.BackColor = SystemColors.Highlight;
                this.ANT4.BackColor = SystemColors.Highlight;
                this.ANT1.Enabled = false;
                this.ANT2.Enabled = false;
                this.ANT3.Enabled = false;
                this.ANT4.Enabled = false;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DXLbuttonbar_Shown(object sender, EventArgs e)
        {

        }

        private void DXLbuttonbar_Activated(object sender, EventArgs e)
        {

        }
    }

    public class AntennaSwitchConfig
    {
        public string IpAddress { get; set; }
    }

}
