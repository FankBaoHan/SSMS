using SSMS.Model;
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
    public partial class FormLesson : Form
    {
        public FormLesson()
        {
            InitializeComponent();
        }

        public FormLesson(string content, string time)
        {
            InitializeComponent();
            textBoxLesson.Text = content;
            numericUpDownTime.Value = (decimal)Convert.ToSingle(time);
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            Lesson lesson = new Lesson();
            lesson.Content = textBoxLesson.Text;
            lesson.Time = (float)numericUpDownTime.Value;

            this.Tag = lesson;
        }
    }
}
