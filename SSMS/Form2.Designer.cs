
namespace SSMS
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonStudent = new System.Windows.Forms.Button();
            this.panelStudent = new System.Windows.Forms.Panel();
            this.buttonStuin = new System.Windows.Forms.Button();
            this.panelTeacher = new System.Windows.Forms.Panel();
            this.buttonTeain = new System.Windows.Forms.Button();
            this.buttonTeacher = new System.Windows.Forms.Button();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.buttonConm = new System.Windows.Forms.Button();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.buttonStuqr = new System.Windows.Forms.Button();
            this.buttonTeaqr = new System.Windows.Forms.Button();
            this.buttonConpas = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pStuin = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pStuqr = new System.Windows.Forms.Panel();
            this.pTeain = new System.Windows.Forms.Panel();
            this.pTeaqr = new System.Windows.Forms.Panel();
            this.pConm = new System.Windows.Forms.Panel();
            this.pConpa = new System.Windows.Forms.Panel();
            this.panelBottom.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelStudent.SuspendLayout();
            this.panelTeacher.SuspendLayout();
            this.panelConfig.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pStuin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.statusStrip1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 545);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(934, 26);
            this.panelBottom.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.panelLeft.Controls.Add(this.panelConfig);
            this.panelLeft.Controls.Add(this.buttonConfig);
            this.panelLeft.Controls.Add(this.panelTeacher);
            this.panelLeft.Controls.Add(this.buttonTeacher);
            this.panelLeft.Controls.Add(this.panelStudent);
            this.panelLeft.Controls.Add(this.buttonStudent);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 545);
            this.panelLeft.TabIndex = 2;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(734, 545);
            this.panelMain.TabIndex = 3;
            // 
            // buttonStudent
            // 
            this.buttonStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStudent.FlatAppearance.BorderSize = 0;
            this.buttonStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStudent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.buttonStudent.Image = ((System.Drawing.Image)(resources.GetObject("buttonStudent.Image")));
            this.buttonStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStudent.Location = new System.Drawing.Point(0, 0);
            this.buttonStudent.Name = "buttonStudent";
            this.buttonStudent.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonStudent.Size = new System.Drawing.Size(183, 61);
            this.buttonStudent.TabIndex = 0;
            this.buttonStudent.Text = "学生信息管理";
            this.buttonStudent.UseVisualStyleBackColor = true;
            this.buttonStudent.Click += new System.EventHandler(this.buttonStudent_Click);
            // 
            // panelStudent
            // 
            this.panelStudent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelStudent.Controls.Add(this.pStuqr);
            this.panelStudent.Controls.Add(this.pStuin);
            this.panelStudent.Controls.Add(this.buttonStuqr);
            this.panelStudent.Controls.Add(this.buttonStuin);
            this.panelStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStudent.Location = new System.Drawing.Point(0, 61);
            this.panelStudent.Name = "panelStudent";
            this.panelStudent.Size = new System.Drawing.Size(183, 124);
            this.panelStudent.TabIndex = 1;
            // 
            // buttonStuin
            // 
            this.buttonStuin.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStuin.FlatAppearance.BorderSize = 0;
            this.buttonStuin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStuin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStuin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.buttonStuin.Image = ((System.Drawing.Image)(resources.GetObject("buttonStuin.Image")));
            this.buttonStuin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStuin.Location = new System.Drawing.Point(0, 0);
            this.buttonStuin.Name = "buttonStuin";
            this.buttonStuin.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.buttonStuin.Size = new System.Drawing.Size(183, 61);
            this.buttonStuin.TabIndex = 0;
            this.buttonStuin.Text = "学生信息录入";
            this.buttonStuin.UseVisualStyleBackColor = true;
            this.buttonStuin.Click += new System.EventHandler(this.buttonStuin_Click);
            // 
            // panelTeacher
            // 
            this.panelTeacher.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTeacher.Controls.Add(this.pTeain);
            this.panelTeacher.Controls.Add(this.pTeaqr);
            this.panelTeacher.Controls.Add(this.buttonTeaqr);
            this.panelTeacher.Controls.Add(this.buttonTeain);
            this.panelTeacher.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTeacher.Location = new System.Drawing.Point(0, 246);
            this.panelTeacher.Name = "panelTeacher";
            this.panelTeacher.Size = new System.Drawing.Size(183, 124);
            this.panelTeacher.TabIndex = 3;
            // 
            // buttonTeain
            // 
            this.buttonTeain.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTeain.FlatAppearance.BorderSize = 0;
            this.buttonTeain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTeain.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTeain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.buttonTeain.Image = ((System.Drawing.Image)(resources.GetObject("buttonTeain.Image")));
            this.buttonTeain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTeain.Location = new System.Drawing.Point(0, 0);
            this.buttonTeain.Name = "buttonTeain";
            this.buttonTeain.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.buttonTeain.Size = new System.Drawing.Size(183, 61);
            this.buttonTeain.TabIndex = 0;
            this.buttonTeain.Text = "教师信息录入";
            this.buttonTeain.UseVisualStyleBackColor = true;
            this.buttonTeain.Click += new System.EventHandler(this.buttonTeain_Click);
            // 
            // buttonTeacher
            // 
            this.buttonTeacher.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTeacher.FlatAppearance.BorderSize = 0;
            this.buttonTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTeacher.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTeacher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.buttonTeacher.Image = ((System.Drawing.Image)(resources.GetObject("buttonTeacher.Image")));
            this.buttonTeacher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTeacher.Location = new System.Drawing.Point(0, 185);
            this.buttonTeacher.Name = "buttonTeacher";
            this.buttonTeacher.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonTeacher.Size = new System.Drawing.Size(183, 61);
            this.buttonTeacher.TabIndex = 2;
            this.buttonTeacher.Text = "教师信息管理";
            this.buttonTeacher.UseVisualStyleBackColor = true;
            this.buttonTeacher.Click += new System.EventHandler(this.buttonTeacher_Click);
            // 
            // panelConfig
            // 
            this.panelConfig.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelConfig.Controls.Add(this.pConpa);
            this.panelConfig.Controls.Add(this.pConm);
            this.panelConfig.Controls.Add(this.buttonConpas);
            this.panelConfig.Controls.Add(this.buttonConm);
            this.panelConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfig.Location = new System.Drawing.Point(0, 431);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(183, 124);
            this.panelConfig.TabIndex = 5;
            // 
            // buttonConm
            // 
            this.buttonConm.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonConm.FlatAppearance.BorderSize = 0;
            this.buttonConm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonConm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.buttonConm.Image = ((System.Drawing.Image)(resources.GetObject("buttonConm.Image")));
            this.buttonConm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConm.Location = new System.Drawing.Point(0, 0);
            this.buttonConm.Name = "buttonConm";
            this.buttonConm.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.buttonConm.Size = new System.Drawing.Size(183, 61);
            this.buttonConm.TabIndex = 0;
            this.buttonConm.Text = "目录设置";
            this.buttonConm.UseVisualStyleBackColor = true;
            this.buttonConm.Click += new System.EventHandler(this.buttonConm_Click);
            // 
            // buttonConfig
            // 
            this.buttonConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonConfig.FlatAppearance.BorderSize = 0;
            this.buttonConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.buttonConfig.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfig.Image")));
            this.buttonConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConfig.Location = new System.Drawing.Point(0, 370);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonConfig.Size = new System.Drawing.Size(183, 61);
            this.buttonConfig.TabIndex = 4;
            this.buttonConfig.Text = "设置";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // buttonStuqr
            // 
            this.buttonStuqr.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStuqr.FlatAppearance.BorderSize = 0;
            this.buttonStuqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStuqr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStuqr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.buttonStuqr.Image = ((System.Drawing.Image)(resources.GetObject("buttonStuqr.Image")));
            this.buttonStuqr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStuqr.Location = new System.Drawing.Point(0, 61);
            this.buttonStuqr.Name = "buttonStuqr";
            this.buttonStuqr.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.buttonStuqr.Size = new System.Drawing.Size(183, 61);
            this.buttonStuqr.TabIndex = 4;
            this.buttonStuqr.Text = "学生信息查询";
            this.buttonStuqr.UseVisualStyleBackColor = true;
            this.buttonStuqr.Click += new System.EventHandler(this.buttonStuqr_Click);
            // 
            // buttonTeaqr
            // 
            this.buttonTeaqr.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTeaqr.FlatAppearance.BorderSize = 0;
            this.buttonTeaqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTeaqr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTeaqr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.buttonTeaqr.Image = ((System.Drawing.Image)(resources.GetObject("buttonTeaqr.Image")));
            this.buttonTeaqr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTeaqr.Location = new System.Drawing.Point(0, 61);
            this.buttonTeaqr.Name = "buttonTeaqr";
            this.buttonTeaqr.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.buttonTeaqr.Size = new System.Drawing.Size(183, 61);
            this.buttonTeaqr.TabIndex = 4;
            this.buttonTeaqr.Text = "教师信息查询";
            this.buttonTeaqr.UseVisualStyleBackColor = true;
            this.buttonTeaqr.Click += new System.EventHandler(this.buttonTeaqr_Click);
            // 
            // buttonConpas
            // 
            this.buttonConpas.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonConpas.FlatAppearance.BorderSize = 0;
            this.buttonConpas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConpas.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonConpas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.buttonConpas.Image = ((System.Drawing.Image)(resources.GetObject("buttonConpas.Image")));
            this.buttonConpas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConpas.Location = new System.Drawing.Point(0, 61);
            this.buttonConpas.Name = "buttonConpas";
            this.buttonConpas.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.buttonConpas.Size = new System.Drawing.Size(183, 61);
            this.buttonConpas.TabIndex = 4;
            this.buttonConpas.Text = "登录密码设置";
            this.buttonConpas.UseVisualStyleBackColor = true;
            this.buttonConpas.Click += new System.EventHandler(this.buttonConpas_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(734, 61);
            this.panelTop.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(258, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "学籍信息管理系统";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.pictureBox2);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 61);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(734, 484);
            this.panelContent.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(282, 148);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(153, 134);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox1.Image = global::SSMS.Properties.Resources.Book_Open_Page;
            this.pictureBox1.Location = new System.Drawing.Point(436, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 32);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pStuin
            // 
            this.pStuin.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pStuin.Controls.Add(this.panel1);
            this.pStuin.Location = new System.Drawing.Point(0, 0);
            this.pStuin.Name = "pStuin";
            this.pStuin.Size = new System.Drawing.Size(8, 61);
            this.pStuin.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 61);
            this.panel1.TabIndex = 6;
            // 
            // pStuqr
            // 
            this.pStuqr.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pStuqr.Location = new System.Drawing.Point(0, 61);
            this.pStuqr.Name = "pStuqr";
            this.pStuqr.Size = new System.Drawing.Size(8, 61);
            this.pStuqr.TabIndex = 6;
            // 
            // pTeain
            // 
            this.pTeain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pTeain.Location = new System.Drawing.Point(0, 0);
            this.pTeain.Name = "pTeain";
            this.pTeain.Size = new System.Drawing.Size(8, 61);
            this.pTeain.TabIndex = 8;
            // 
            // pTeaqr
            // 
            this.pTeaqr.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pTeaqr.Location = new System.Drawing.Point(0, 61);
            this.pTeaqr.Name = "pTeaqr";
            this.pTeaqr.Size = new System.Drawing.Size(8, 61);
            this.pTeaqr.TabIndex = 8;
            // 
            // pConm
            // 
            this.pConm.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pConm.Location = new System.Drawing.Point(0, 0);
            this.pConm.Name = "pConm";
            this.pConm.Size = new System.Drawing.Size(8, 61);
            this.pConm.TabIndex = 8;
            // 
            // pConpa
            // 
            this.pConpa.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pConpa.Location = new System.Drawing.Point(0, 61);
            this.pConpa.Name = "pConpa";
            this.pConpa.Size = new System.Drawing.Size(8, 61);
            this.pConpa.TabIndex = 9;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 571);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelStudent.ResumeLayout(false);
            this.panelTeacher.ResumeLayout(false);
            this.panelConfig.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pStuin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button buttonStudent;
        private System.Windows.Forms.Panel panelStudent;
        private System.Windows.Forms.Button buttonStuin;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Button buttonConm;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.Panel panelTeacher;
        private System.Windows.Forms.Button buttonTeain;
        private System.Windows.Forms.Button buttonTeacher;
        private System.Windows.Forms.Button buttonStuqr;
        private System.Windows.Forms.Button buttonTeaqr;
        private System.Windows.Forms.Button buttonConpas;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pStuin;
        private System.Windows.Forms.Panel pConpa;
        private System.Windows.Forms.Panel pConm;
        private System.Windows.Forms.Panel pTeaqr;
        private System.Windows.Forms.Panel pStuqr;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pTeain;
    }
}