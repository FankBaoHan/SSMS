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
    public partial class TeacherInfo : Form
    {
        private Teacher teacher;

        public TeacherInfo(Teacher teacher)
        {
            InitializeComponent();

            this.teacher = teacher;
            listViewData.SmallImageList = imageList1;

            init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            //加载基本信息
            textBoxName.Text = teacher.Name;
            comboBoxGender.Text = teacher.Gender;
            textBoxID.Text = teacher.ID;
            textBoxPost.Text = teacher.Post;
            textBoxDBNumber.Text = teacher.DbNumber;
            textBoxCardID.Text = teacher.CardID;

            textBoxID.Enabled = false;

            //加载学习课程
            OleDbConnection conn = MdbUtil.getConn(Properties.Settings.Default.mdbPath);
            List<Lesson> list = MdbUtil.getTeacherLessonsByID(teacher.ID, conn);

            listViewLesson.BeginUpdate();
            foreach (Lesson l in list)
            {
                ListViewItem li = new ListViewItem();
                li.Text = l.Content;
                li.SubItems.Add(l.Time.ToString("0.0"));

                listViewLesson.Items.Add(li);
            }
            listViewLesson.EndUpdate();

            //加载证书文件
            DirectoryInfo di = new DirectoryInfo(teacher.DataPath);

            if (!Directory.Exists(teacher.DataPath))
            {
                Directory.CreateDirectory(teacher.DataPath);
            }

            //不存在文件夹则结束
            if (!di.Exists)
            {
                return;
            }

            foreach (FileInfo fi in di.GetFiles())
            {
                if (!imageList1.Images.Keys.Contains(fi.Extension))
                {
                    imageList1.Images.Add(fi.Extension, Icon.ExtractAssociatedIcon(fi.FullName));
                }

                ListViewItem lvi = new ListViewItem();
                lvi.Tag = fi.FullName;
                lvi.Text = fi.Name;
                lvi.ImageIndex = imageList1.Images.Keys.IndexOf(fi.Extension);

                listViewData.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 课程右键编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewLesson.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择单行数据查看详情!", "选择错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        /// 课程添加
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
        /// 课程删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listViewLesson.SelectedItems)
            {
                FormDelete userDialog = new FormDelete();
                if (userDialog.ShowDialog() == DialogResult.OK)
                {
                    listViewLesson.Items.Remove(lvi);
                }
            }
        }

        /// <summary>
        /// 证书添加
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

                //直接作复制处理
                File.Copy(fileName, teacher.DataPath + f.Name, true);//若存储路径有相同文件是否替换
            }
        }

        /// <summary>
        /// 证书删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in listViewData.SelectedItems)
            {
                FormDelete userDialog = new FormDelete();
                if (userDialog.ShowDialog() == DialogResult.OK)
                {
                    //直接删除
                    string filePath = teacher.DataPath + l.Text;
                    File.Delete(filePath);

                    listViewData.Items.Remove(l);
                }
            }
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = MdbUtil.getOpenedConn(Properties.Settings.Default.mdbPath);

            //update基本信息
            string name = textBoxName.Text.Trim();
            string gender = comboBoxGender.Text.Trim();
            string id = textBoxID.Text.Trim();
            string post = textBoxPost.Text.Trim();
            string dbNumber = textBoxDBNumber.Text.Trim();
            string cardID = textBoxCardID.Text.Trim();

            string sql = "UPDATE Teacher SET DbNumber='" + dbNumber + "',"
                    + "Name='" + name + "',"
                    + "Gender='" + gender + "',"
                    + "Post='" + post + "',"
                    + "CardID='" + cardID + "' WHERE "
                    + "ID='" + id + "'";

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

            //delete课程
            sql = "DELETE * FROM TeacherLesson WHERE OwnerID='" + id + "'";

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

            //insert课程
            foreach (ListViewItem l in listViewLesson.Items)
            {
                sql = "INSERT INTO TeacherLesson ([OwnerID],[Content],[Time]) VALUES ('"
                + id + "','"
                + l.SubItems[0].Text.Trim() + "','"
                + l.SubItems[1].Text.Trim() + "')";

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
            }

            //完成
            MessageBox.Show("更新教师信息完成!", "更新成功", MessageBoxButtons.OK);
            this.DialogResult = DialogResult.OK;

            this.Close();
            this.Dispose();
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

        /// <summary>
        /// 打开数据文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listViewData.HitTest(e.X, e.Y);

            if (info.Item != null)
            {
                System.Diagnostics.Process.Start(teacher.DataPath + info.Item.Text);
            }
        }
    }
}
