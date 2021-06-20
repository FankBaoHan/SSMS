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
    public partial class FormTeaqr : Form
    {
        public FormTeaqr()
        {
            InitializeComponent();

            queryAllData();
        }

        /// <summary>
        /// 调整column宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            int width = listView1.Width;

            listView1.Columns[0].Width = width / 7;
            listView1.Columns[1].Width = width / 7;
            listView1.Columns[2].Width = (int)(width / 5.83);
            listView1.Columns[3].Width = (int)(width / 17.5);

            listView1.Columns[4].Width = width / 7;
            listView1.Columns[5].Width = (int)(width / 3.89);
            listView1.Columns[6].Width = (int)(width / 11.7);
        }

        /// <summary>
        /// 刷新全部数据
        /// </summary>
        private void queryAllData()
        {
            if (Properties.Settings.Default.mdbPath.Equals("") || Properties.Settings.Default.dataPath.Equals(""))
            {
                MessageBox.Show("请先在目录设置中配置mdb文件路径和数据路径!", "目录未设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OleDbConnection conn = MdbUtil.getConn(Properties.Settings.Default.mdbPath);

            List<Teacher> list = MdbUtil.loadTeacherFromMdb(conn);

            listView1.Items.Clear();
            listView1.BeginUpdate();
            foreach (Teacher t in list)
            {
                ListViewItem li = new ListViewItem();

                li.Text = t.DbNumber;
                li.SubItems.Add(t.Name);
                li.SubItems.Add(t.CardID);
                li.SubItems.Add(t.Gender);
                li.SubItems.Add(t.Post);
                li.SubItems.Add(t.ID);
                li.SubItems.Add(t.TeachTime);
                li.Tag = t.DataPath;

                listView1.Items.Add(li);
            }
            listView1.EndUpdate();
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string cardID = textBoxCardID.Text.Trim();
            string id = textBoxID.Text.Trim();
            string dbNumber = textBoxDBNumber.Text.Trim();

            if (name.Equals("") &&
                cardID.Equals("") &&
                id.Equals("") &&
                dbNumber.Equals(""))
            {
                MessageBox.Show("请输入至少一个查询条件!", "查询条件填写错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string sql = "SELECT * FROM Teacher WHERE " +
                (name.Equals("") ? "" : "Name='" + name + "'") +
                (cardID.Equals("") ? "" : (name.Equals("") ? "" : " AND") + " CardID='" + cardID + "'") +
                (id.Equals("") ? "" : (name.Equals("") && cardID.Equals("") ? "" : " AND") + " ID='" + id + "'") +
                (dbNumber.Equals("") ? "" : (name.Equals("") && cardID.Equals("") && id.Equals("") ? "" : " AND") + " DbNumber='" + dbNumber + "'");

            System.Console.WriteLine(sql);

            OleDbConnection conn = MdbUtil.getConn(Properties.Settings.Default.mdbPath);
            List<Teacher> list = MdbUtil.queryTeacherFromMdb(sql, conn);

            listView1.Items.Clear();
            listView1.BeginUpdate();
            foreach (Teacher s in list)
            {
                ListViewItem li = new ListViewItem();

                li.Text = s.DbNumber;
                li.SubItems.Add(s.Name);
                li.SubItems.Add(s.CardID);
                li.SubItems.Add(s.Gender);
                li.SubItems.Add(s.Post);
                li.SubItems.Add(s.ID);
                li.SubItems.Add(s.TeachTime);

                listView1.Items.Add(li);
            }
            listView1.EndUpdate();

            MessageBox.Show("查询完成，共找到" + list.Count + "条结果!", "条件查询结果", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 右键菜单详情按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择单行数据查看详情!", "选择错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OleDbConnection conn = MdbUtil.getConn(Properties.Settings.Default.mdbPath);

            string id = listView1.SelectedItems[0].SubItems[5].Text;
            List<Teacher> list = MdbUtil.queryTeacherFromMdb("SELECT * FROM Teacher WHERE ID='" + id + "'", conn);

            if (new TeacherInfo(list[0]).ShowDialog() == DialogResult.OK)
            {
                //刷新数据
                queryAllData();
                //((Form2)this.ParentForm).openChildForm(new FormStuqr());
            }
        }

        /// <summary>
        /// 右键菜单删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择单行数据查看详情!", "选择错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FormDelete userDialog = new FormDelete();
            if (userDialog.ShowDialog() == DialogResult.OK)
            {
                string id = listView1.SelectedItems[0].SubItems[5].Text;
                OleDbConnection conn = MdbUtil.getOpenedConn(Properties.Settings.Default.mdbPath);

                //Student表删除
                string sql = "DELETE * FROM Teacher WHERE ID='" + id + "'";

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


                //StudentLesson表删除
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

                //DataPath删除
                Directory.Delete(listView1.SelectedItems[0].Tag.ToString(), true);

                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        /// <summary>
        /// 双击item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);

            if (info.Item != null)
            {
                OleDbConnection conn = MdbUtil.getConn(Properties.Settings.Default.mdbPath);

                string id = info.Item.SubItems[5].Text;
                List<Teacher> list = MdbUtil.queryTeacherFromMdb("SELECT * FROM Teacher WHERE ID='" + id + "'", conn);

                if (new TeacherInfo(list[0]).ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                    queryAllData();
                    //((Form2)this.ParentForm).openChildForm(new FormStuqr());
                }
            }
        }
    }
}
