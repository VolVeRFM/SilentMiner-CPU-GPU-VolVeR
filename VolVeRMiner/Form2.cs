using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolVeRMiner
{
    public partial class DRM : Form
    {

        public DRM()
        {
            InitializeComponent();
            textBox1.Text = "Title";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "Description";
            textBox2.ForeColor = Color.Gray;
            textBox3.Text = "Company";
            textBox3.ForeColor = Color.Gray;
            textBox4.Text = "Product";
            textBox4.ForeColor = Color.Gray;
            textBox5.Text = "Copyright";
            textBox5.ForeColor = Color.Gray;
            textBox6.Text = "Trademark";
            textBox6.ForeColor = Color.Gray;



        }


     
        public bool ch1
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public string ch2
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        public string ch3
        {
            get => textBox2.Text;
            set => textBox2.Text = value;
        }

        public string ch4
        {
            get => textBox3.Text;
            set => textBox3.Text = value;
        }

        public string ch5
        {
            get => textBox4.Text;
            set => textBox4.Text = value;
        }

        public string ch6
        {
            get => textBox5.Text;
            set => textBox5.Text = value;
        }

        public string ch7
        {
            get => textBox6.Text;
            set => textBox6.Text = value;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var  intro = new OpenFileDialog();
            intro.Filter = "Executable |*.exe";
            if (intro.ShowDialog() == DialogResult.OK)
            {
                var info = FileVersionInfo.GetVersionInfo(intro.FileName);
                try
                {
                    textBox1.Text = info.InternalName;
                    textBox2.Text = info.FileDescription;
                    textBox3.Text = info.CompanyName;
                    textBox4.Text = info.ProductName;
                    textBox5.Text = info.LegalCopyright;
                    textBox6.Text = info.LegalTrademarks;
                }
                catch { }
            }

            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
              DRM VRF = new DRM();

            VRF.Hide();
        }
    }
}
