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
    public partial class FormComfigpas : Form
    {
        public FormComfigpas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text.Equals("") || textBoxPassword.Text.Equals(""))
            {
                MessageBox.Show("用户名或密码不能为空!", "设置错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!textBoxPassword.Text.Equals(textBoxPassword2.Text))
            {
                MessageBox.Show("请确认两次密码输入一致!", "设置错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Properties.Settings.Default.user = textBoxUser.Text;
            Properties.Settings.Default.password = textBoxPassword.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("设置用户名密码成功!", "设置完成", MessageBoxButtons.OK);

            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// 调整按钮大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormComfigpas_Resize(object sender, EventArgs e)
        {
            button1.Width = (panel1.Width - 6) / 2;
            button2.Width = (panel1.Width - 6) / 2;
        }
    }
}
