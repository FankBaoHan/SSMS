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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            customDesign();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 隐藏子菜单,初始化用
        /// </summary>
        private void customDesign()
        {
            panelStudent.Visible = false;
            panelTeacher.Visible = false;
            panelConfig.Visible = false;

            hidePanelSelect();
        }

        /// <summary>
        /// 隐藏选中条
        /// </summary>
        private void hidePanelSelect()
        {
            pStuin.Visible = false;
            pStuqr.Visible = false;
            pTeain.Visible = false;
            pTeaqr.Visible = false;
            pConm.Visible = false;
            pConpa.Visible = false;
        }

        /// <summary>
        /// 显示选中条
        /// </summary>
        /// <param name="pSelect"></param>
        private void showPanelSelect(Panel pSelect)
        {
            hidePanelSelect();

            pSelect.Visible = true;
        }

        /// <summary>
        /// 子菜单展示隐藏
        /// </summary>
        /// <param name="subMenu"></param>
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                //hideSubMenu();
                subMenu.Visible = true;
            }
            else 
            {
                subMenu.Visible = false;
            }
        }

        #region 子按钮点击事件
        private void buttonStudent_Click(object sender, EventArgs e)
        {
            showSubMenu(panelStudent);
        }

        private void buttonTeacher_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTeacher);
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            showSubMenu(panelConfig);
        }

        private void buttonStuin_Click(object sender, EventArgs e)
        {
            showPanelSelect(pStuin);
            openChildForm(new FormStuin());
        }

        private void buttonStuqr_Click(object sender, EventArgs e)
        {
            showPanelSelect(pStuqr);
            openChildForm(new FormStuqr());
        }

        private void buttonTeain_Click(object sender, EventArgs e)
        {
            showPanelSelect(pTeain);
            openChildForm(new FormTeain());
        }

        private void buttonTeaqr_Click(object sender, EventArgs e)
        {
            showPanelSelect(pTeaqr);
            openChildForm(new FormTeaqr());
        }

        private void buttonConm_Click(object sender, EventArgs e)
        {
            showPanelSelect(pConm);
            openChildForm(new FormConfigm());
        }

        private void buttonConpas_Click(object sender, EventArgs e)
        {
            showPanelSelect(pConpa);
            openChildForm(new FormComfigpas());
        }

        #endregion 

        private Form activeForm = null;

        /// <summary>
        /// 在content窗口打开子窗体
        /// </summary>
        /// <param name="childForm"></param>
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
    }
}
