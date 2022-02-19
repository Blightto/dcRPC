using System;
using System.IO;
using System.Windows.Forms;
using DiscordRPC;

namespace dcRPC
{
    public partial class Form1 : Form
    {
        public DiscordRpcClient client;

        public string klasor = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @".pamukkRpc");
        public string dosya = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @".pamukkRpc\userinfo.pamuk");

        public Form1()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            client = new DiscordRpcClient(textBox1.Text);
            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = textBox2.Text,
                State = textBox3.Text,
                Assets = new Assets()
                {
                    LargeImageKey = textBox4.Text,
                    LargeImageText = textBox6.Text,
                    SmallImageKey = textBox5.Text
                }
            });
        }

        public void Deinitialize()
        {
            client.Dispose();
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;

            bool klasorVarMı = Directory.Exists(klasor);
            if (!klasorVarMı) Directory.CreateDirectory(klasor);
            bool dosyaVarMı = File.Exists(dosya);
            if (!dosyaVarMı)
            {
                FileStream fs = File.Create(dosya);
                fs.Close();
            }
            StreamReader inputfile = new StreamReader(dosya);
            textBox1.Text = inputfile.ReadLine();
            textBox2.Text = inputfile.ReadLine();
            textBox3.Text = inputfile.ReadLine();
            textBox4.Text = inputfile.ReadLine();
            textBox5.Text = inputfile.ReadLine();
            textBox6.Text = inputfile.ReadLine();
            inputfile.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
            Form2 form = new Form2();
            form.Show();

            StreamWriter writer = new StreamWriter(dosya);
            writer.WriteLine(textBox1.Text);
            writer.WriteLine(textBox2.Text);
            writer.WriteLine(textBox3.Text);
            writer.WriteLine(textBox4.Text);
            writer.WriteLine(textBox5.Text);
            writer.WriteLine(textBox6.Text);
            writer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
                Initialize();
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Initialize();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deinitialize();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }

    }
}
