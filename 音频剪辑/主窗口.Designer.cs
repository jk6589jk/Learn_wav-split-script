namespace 音频剪辑
{
    partial class 主窗口
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.按钮_打开音频文件 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.输入框_音频文件 = new System.Windows.Forms.TextBox();
            this.输入框_字幕文件 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.按钮_打开字幕文件 = new System.Windows.Forms.Button();
            this.按钮_开始剪辑 = new System.Windows.Forms.Button();
            this.显示框_信息显示 = new System.Windows.Forms.TextBox();
            this.按钮_选择保存路径 = new System.Windows.Forms.Button();
            this.输入框_保存路径 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.按钮_解析字幕 = new System.Windows.Forms.Button();
            this.进度条_剪辑音频 = new System.Windows.Forms.ProgressBar();
            this.输入框_开始序号 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.按钮__重命名 = new System.Windows.Forms.Button();
            this.进度条_重命名总进度 = new System.Windows.Forms.ProgressBar();
            this.进度条_复制文件 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // 按钮_打开音频文件
            // 
            this.按钮_打开音频文件.Location = new System.Drawing.Point(316, 6);
            this.按钮_打开音频文件.Name = "按钮_打开音频文件";
            this.按钮_打开音频文件.Size = new System.Drawing.Size(75, 23);
            this.按钮_打开音频文件.TabIndex = 0;
            this.按钮_打开音频文件.Text = "打开";
            this.按钮_打开音频文件.UseVisualStyleBackColor = true;
            this.按钮_打开音频文件.Click += new System.EventHandler(this.按钮_打开音频文件_点击);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "音频文件";
            // 
            // 输入框_音频文件
            // 
            this.输入框_音频文件.Location = new System.Drawing.Point(74, 6);
            this.输入框_音频文件.Name = "输入框_音频文件";
            this.输入框_音频文件.Size = new System.Drawing.Size(236, 23);
            this.输入框_音频文件.TabIndex = 2;
            // 
            // 输入框_字幕文件
            // 
            this.输入框_字幕文件.Location = new System.Drawing.Point(471, 6);
            this.输入框_字幕文件.Name = "输入框_字幕文件";
            this.输入框_字幕文件.Size = new System.Drawing.Size(236, 23);
            this.输入框_字幕文件.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "字幕文件";
            // 
            // 按钮_打开字幕文件
            // 
            this.按钮_打开字幕文件.Location = new System.Drawing.Point(713, 6);
            this.按钮_打开字幕文件.Name = "按钮_打开字幕文件";
            this.按钮_打开字幕文件.Size = new System.Drawing.Size(75, 23);
            this.按钮_打开字幕文件.TabIndex = 5;
            this.按钮_打开字幕文件.Text = "打开";
            this.按钮_打开字幕文件.UseVisualStyleBackColor = true;
            this.按钮_打开字幕文件.Click += new System.EventHandler(this.按钮_打开字幕文件_点击);
            // 
            // 按钮_开始剪辑
            // 
            this.按钮_开始剪辑.Location = new System.Drawing.Point(93, 354);
            this.按钮_开始剪辑.Name = "按钮_开始剪辑";
            this.按钮_开始剪辑.Size = new System.Drawing.Size(75, 23);
            this.按钮_开始剪辑.TabIndex = 6;
            this.按钮_开始剪辑.Text = "开始";
            this.按钮_开始剪辑.UseVisualStyleBackColor = true;
            this.按钮_开始剪辑.Click += new System.EventHandler(this.按钮_开始剪辑_点击);
            // 
            // 显示框_信息显示
            // 
            this.显示框_信息显示.AcceptsReturn = true;
            this.显示框_信息显示.AcceptsTab = true;
            this.显示框_信息显示.Location = new System.Drawing.Point(12, 64);
            this.显示框_信息显示.Multiline = true;
            this.显示框_信息显示.Name = "显示框_信息显示";
            this.显示框_信息显示.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.显示框_信息显示.Size = new System.Drawing.Size(776, 287);
            this.显示框_信息显示.TabIndex = 7;
            // 
            // 按钮_选择保存路径
            // 
            this.按钮_选择保存路径.Location = new System.Drawing.Point(713, 35);
            this.按钮_选择保存路径.Name = "按钮_选择保存路径";
            this.按钮_选择保存路径.Size = new System.Drawing.Size(75, 23);
            this.按钮_选择保存路径.TabIndex = 10;
            this.按钮_选择保存路径.Text = "选择";
            this.按钮_选择保存路径.UseVisualStyleBackColor = true;
            this.按钮_选择保存路径.Click += new System.EventHandler(this.按钮_选择保存路径_点击);
            // 
            // 输入框_保存路径
            // 
            this.输入框_保存路径.Location = new System.Drawing.Point(74, 35);
            this.输入框_保存路径.Name = "输入框_保存路径";
            this.输入框_保存路径.Size = new System.Drawing.Size(504, 23);
            this.输入框_保存路径.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "保存路径";
            // 
            // 按钮_解析字幕
            // 
            this.按钮_解析字幕.Location = new System.Drawing.Point(12, 354);
            this.按钮_解析字幕.Name = "按钮_解析字幕";
            this.按钮_解析字幕.Size = new System.Drawing.Size(75, 23);
            this.按钮_解析字幕.TabIndex = 11;
            this.按钮_解析字幕.Text = "解析字幕文件";
            this.按钮_解析字幕.UseVisualStyleBackColor = true;
            this.按钮_解析字幕.Click += new System.EventHandler(this.按钮_解析字幕_点击);
            // 
            // 进度条_剪辑音频
            // 
            this.进度条_剪辑音频.Location = new System.Drawing.Point(174, 357);
            this.进度条_剪辑音频.Name = "进度条_剪辑音频";
            this.进度条_剪辑音频.Size = new System.Drawing.Size(614, 20);
            this.进度条_剪辑音频.TabIndex = 12;
            // 
            // 输入框_开始序号
            // 
            this.输入框_开始序号.Location = new System.Drawing.Point(646, 35);
            this.输入框_开始序号.Name = "输入框_开始序号";
            this.输入框_开始序号.Size = new System.Drawing.Size(53, 23);
            this.输入框_开始序号.TabIndex = 13;
            this.输入框_开始序号.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(584, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "开始序号";
            // 
            // 按钮__重命名
            // 
            this.按钮__重命名.Location = new System.Drawing.Point(12, 383);
            this.按钮__重命名.Name = "按钮__重命名";
            this.按钮__重命名.Size = new System.Drawing.Size(156, 23);
            this.按钮__重命名.TabIndex = 15;
            this.按钮__重命名.Text = "降噪后一键重命名";
            this.按钮__重命名.UseVisualStyleBackColor = true;
            this.按钮__重命名.Click += new System.EventHandler(this.按钮_重命名_点击);
            // 
            // 进度条_重命名总进度
            // 
            this.进度条_重命名总进度.Location = new System.Drawing.Point(174, 386);
            this.进度条_重命名总进度.Name = "进度条_重命名总进度";
            this.进度条_重命名总进度.Size = new System.Drawing.Size(404, 20);
            this.进度条_重命名总进度.TabIndex = 16;
            // 
            // 进度条_复制文件
            // 
            this.进度条_复制文件.Location = new System.Drawing.Point(584, 386);
            this.进度条_复制文件.Name = "进度条_复制文件";
            this.进度条_复制文件.Size = new System.Drawing.Size(204, 20);
            this.进度条_复制文件.TabIndex = 17;
            // 
            // 主窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.进度条_复制文件);
            this.Controls.Add(this.进度条_重命名总进度);
            this.Controls.Add(this.按钮__重命名);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.输入框_开始序号);
            this.Controls.Add(this.进度条_剪辑音频);
            this.Controls.Add(this.按钮_解析字幕);
            this.Controls.Add(this.按钮_选择保存路径);
            this.Controls.Add(this.输入框_保存路径);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.显示框_信息显示);
            this.Controls.Add(this.按钮_开始剪辑);
            this.Controls.Add(this.按钮_打开字幕文件);
            this.Controls.Add(this.输入框_字幕文件);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.输入框_音频文件);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.按钮_打开音频文件);
            this.Name = "主窗口";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button 按钮_打开音频文件;
        private Label label1;
        private TextBox 输入框_音频文件;
        private TextBox 输入框_字幕文件;
        private Label label2;
        private Button 按钮_打开字幕文件;
        private Button 按钮_开始剪辑;
        private TextBox 显示框_信息显示;
        private Button 按钮_选择保存路径;
        private TextBox 输入框_保存路径;
        private Label label3;
        private Button 按钮_解析字幕;
        private ProgressBar 进度条_剪辑音频;
        private TextBox 输入框_开始序号;
        private Label label4;
        private Button 按钮__重命名;
        private ProgressBar 进度条_重命名总进度;
        private ProgressBar 进度条_复制文件;
    }
}