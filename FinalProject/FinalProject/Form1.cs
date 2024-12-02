using System.IO;
using System.Text;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FromClient fromclient = new FromClient();
        String Name = null;
        private void bt_Send_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMes.Text))
            {
                fromclient.SendMes(tbMes.Text);
                listBox1.Items.Add("You: " + tbMes.Text);
                tbMes.Clear();
            }
            else
            {
                MessageBox.Show("Please, Type your name before send message.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string s = await fromclient.ThreadReadMesAsync();  // Đợi kết quả bất đồng bộ

                if (!string.IsNullOrEmpty(s))
                {
                    listBox1.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading message: " + ex.Message);
            }
        }

        private void btName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                tbName.Enabled = false;
                tbMes.Enabled = true;
                fromclient.SendMes("Name: " + tbName.Text);
                tbName.Clear();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            fromclient.SendMes("EXIT");
        }
    }
}
