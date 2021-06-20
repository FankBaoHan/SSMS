using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSMS
{
    public partial class LoginForm : System.Windows.Forms.Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.Image = Image.FromFile(Application.StartupPath + "\\Resources\\进入大.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.Image = Image.FromFile(Application.StartupPath + "\\Resources\\进入.png");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(Properties.Settings.Default.user) &&
                textBox2.Text.Equals(Properties.Settings.Default.password))
            {
                this.Hide();
                new Form2().ShowDialog();
            }
            else
            {
                MessageBox.Show("用户名或密码错误!","登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
