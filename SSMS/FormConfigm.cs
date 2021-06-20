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
    public partial class FormConfigm : Form
    {
        public FormConfigm()
        {
            InitializeComponent();

            textBoxMdb.Text = Properties.Settings.Default.mdbPath;
            textBoxData.Text = Properties.Settings.Default.dataPath;
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
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxMdb.Text.Equals("") || textBoxData.Text.Equals(""))
            {
                MessageBox.Show("路径设置不能为空!", "设置错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Properties.Settings.Default.mdbPath = textBoxMdb.Text;
            Properties.Settings.Default.dataPath = textBoxData.Text;
            Properties.Settings.Default.Save();

            MessageBox.Show("目录设置成功!", "设置完成", MessageBoxButtons.OK);

            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// 数据库选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "mdb files (*.mdb)|*.mdb";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBoxMdb.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Data路径选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.folderBrowserDialog1.SelectedPath.Trim() != "")
                    this.textBoxData.Text = this.folderBrowserDialog1.SelectedPath.Trim();
            }
        }

        /// <summary>
        /// 调整按钮大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConfigm_Resize(object sender, EventArgs e)
        {
            button3.Width = (panel1.Width - 6) / 2;
            button2.Width = (panel1.Width - 6) / 2;
        }

        /// <summary>
        /// Data路径选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.folderBrowserDialog1.SelectedPath.Trim() != "")
                    this.textBoxData.Text = this.folderBrowserDialog1.SelectedPath.Trim();
            }
        }
    }
}
