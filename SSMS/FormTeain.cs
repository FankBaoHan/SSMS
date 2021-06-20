using SSMS.Model;
using SSMS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSMS
{
    public partial class FormTeain : Form
    {
        public FormTeain()
        {
            InitializeComponent();
            listViewData.SmallImageList = imageList1;
        }

        /// <summary>
        /// 增加课程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            FormLesson userDialog = new FormLesson();
            if (userDialog.ShowDialog() == DialogResult.OK)
            {
                Lesson lesson = userDialog.Tag as Lesson;

                foreach (ListViewItem l in listViewLesson.Items)
                {
                    if (l.SubItems[0].Text.Equals(lesson.Content))
                    {
                        MessageBox.Show("已存在该课程内容，请重新添加!", "重复添加", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                ListViewItem lvi = new ListViewItem();

                lvi.Text = lesson.Content;
                lvi.SubItems.Add(lesson.Time.ToString());

                this.listViewLesson.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 删除课程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listViewLesson.SelectedItems)
            {
                listViewLesson.Items.Remove(lvi);
            }
        }

        /// <summary>
        /// 添加资质证书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "all files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;

                foreach (ListViewItem l in listViewData.Items)
                {
                    if (l.Tag.ToString().Equals(fileName))
                    {
                        MessageBox.Show("已存在该内容!", "重复添加", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                FileInfo f = new FileInfo(fileName);

                if (!imageList1.Images.Keys.Contains(f.Extension))
                {
                    imageList1.Images.Add(f.Extension, Icon.ExtractAssociatedIcon(f.FullName));
                }

                ListViewItem lvi = new ListViewItem();
                lvi.Tag = fileName;
                lvi.Text = f.Name;
                lvi.ImageIndex = imageList1.Images.Keys.IndexOf(f.Extension);

                listViewData.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 删除资质证书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in listViewData.SelectedItems)
            {
                listViewData.Items.Remove(l);
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        //确认按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.mdbPath.Equals("") || Properties.Settings.Default.dataPath.Equals(""))
            {
                MessageBox.Show("请先在目录设置中配置mdb文件路径和数据路径!", "目录未设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (textBoxName.Text.Trim().Equals("") || comboBoxGender.Text.Trim().Equals("") || textBoxID.Text.Trim().Equals("") ||
                textBoxPost.Text.Trim().Equals("") || textBoxDBNumber.Text.Trim().Equals("") || textBoxCardID.Text.Trim().Equals(""))
            {
                MessageBox.Show("基本信息存在未填信息，请补全!", "信息未填", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OleDbConnection conn = MdbUtil.getOpenedConn(Properties.Settings.Default.mdbPath);

            if (null == conn)
            {
                MessageBox.Show("mdb文件配置错误或损坏，请检查!", "mdb文件错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string dataFilePath = Properties.Settings.Default.dataPath + "\\ID" + textBoxID.Text.Trim() + "\\";

            if (Directory.Exists(dataFilePath))
            {
                MessageBox.Show("该身份证已被使用，请检查!", "重复添加", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //创建Data存放文件夹,复制证书文件
            Directory.CreateDirectory(dataFilePath);

            foreach (ListViewItem l in listViewData.Items)
            {
                if (File.Exists(l.Tag.ToString()))
                {
                    File.Copy(l.Tag.ToString(), dataFilePath + l.Text, true);//若存储路径有相同文件是否替换
                }
            }

            //写入课程数据库，外键为身份证号
            foreach (ListViewItem l in listViewLesson.Items)
            {
                string tempSql = "INSERT INTO TeacherLesson ([OwnerID],[Content],[Time]) VALUES ('"
                    + textBoxID.Text + "','"
                    + l.SubItems[0].Text.Trim() + "','"
                    + l.SubItems[1].Text.Trim() + "')";

                try
                {
                    OleDbCommand cmd = new OleDbCommand(tempSql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            //写入基本数据库
            string sql = "INSERT INTO Teacher ([DbNumber],[Name],[Gender],[ID],[Post],[CardID],[DataPath]) VALUES ('"
                    + textBoxDBNumber.Text.Trim() + "','"
                    + textBoxName.Text.Trim() + "','"
                    + comboBoxGender.Text.Trim() + "','"
                    + textBoxID.Text.Trim() + "','"
                    + textBoxPost.Text.Trim() + "','"
                    + textBoxCardID.Text.Trim() + "','"
                    + dataFilePath.Trim() + "')";

            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("添加教师信息完成!", "添加成功", MessageBoxButtons.OK);

            //关闭连接
            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// 编辑课程内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewLesson.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择课程!", "选择错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string content = listViewLesson.SelectedItems[0].SubItems[0].Text;
            string time = listViewLesson.SelectedItems[0].SubItems[1].Text;

            FormLesson userDialog = new FormLesson(content, time);
            if (userDialog.ShowDialog() == DialogResult.OK)
            {
                Lesson lesson = userDialog.Tag as Lesson;

                if (!lesson.Content.Equals(""))
                {
                    listViewLesson.SelectedItems[0].SubItems[0].Text = lesson.Content;
                    listViewLesson.SelectedItems[0].SubItems[1].Text = lesson.Time.ToString();
                }
                else
                {
                    MessageBox.Show("课程内容不能为空!", "数据错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 自动调整按钮宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTeain_Resize(object sender, EventArgs e)
        {
            button1.Width = (panel2.Width - 6) / 2;
            button2.Width = (panel2.Width - 6) / 2;
        }

        /// <summary>
        /// 双击打开Data文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listViewData.HitTest(e.X, e.Y);

            if (info.Item != null)
            {
                System.Diagnostics.Process.Start(info.Item.Tag.ToString());
            }
        }
    }
}
