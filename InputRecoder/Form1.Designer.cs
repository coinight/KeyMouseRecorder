using System.Windows.Forms;

namespace InputRecoder
{
    partial class InputRecoder
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonTriggerRocoder = new System.Windows.Forms.Button();
            this.clearLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_test = new System.Windows.Forms.Button();
            this.ChooseFIle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LastChooseText = new System.Windows.Forms.TextBox();
            this.RunScript = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTriggerRocoder
            // 
            this.buttonTriggerRocoder.Location = new System.Drawing.Point(188, 129);
            this.buttonTriggerRocoder.Name = "buttonTriggerRocoder";
            this.buttonTriggerRocoder.Size = new System.Drawing.Size(75, 23);
            this.buttonTriggerRocoder.TabIndex = 1;
            this.buttonTriggerRocoder.Text = "开关";
            this.buttonTriggerRocoder.UseVisualStyleBackColor = true;
            this.buttonTriggerRocoder.Click += new System.EventHandler(this.buttonTriggerRocoder_Click);
            // 
            // clearLog
            // 
            this.clearLog.Location = new System.Drawing.Point(188, 158);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(75, 23);
            this.clearLog.TabIndex = 2;
            this.clearLog.Text = "清空log";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 159);
            this.label1.TabIndex = 3;
            this.label1.Text = "信息框,滚轮可以查看";
            this.label1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.textMouseWheelEvent);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "当前页数";
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(190, 40);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 23);
            this.btn_test.TabIndex = 5;
            this.btn_test.Text = "test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.test);
            // 
            // ChooseFIle
            // 
            this.ChooseFIle.Location = new System.Drawing.Point(188, 100);
            this.ChooseFIle.Name = "ChooseFIle";
            this.ChooseFIle.Size = new System.Drawing.Size(75, 23);
            this.ChooseFIle.TabIndex = 6;
            this.ChooseFIle.Text = "选择文件";
            this.ChooseFIle.UseVisualStyleBackColor = true;
            this.ChooseFIle.Click += new System.EventHandler(this.ChooseFIle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "选择脚本:";
            // 
            // LastChooseText
            // 
            this.LastChooseText.Location = new System.Drawing.Point(57, 1);
            this.LastChooseText.Name = "LastChooseText";
            this.LastChooseText.Size = new System.Drawing.Size(208, 21);
            this.LastChooseText.TabIndex = 8;
            this.LastChooseText.TextChanged += new System.EventHandler(this.LastChooseText_TextChanged);
            // 
            // RunScript
            // 
            this.RunScript.Enabled = false;
            this.RunScript.Location = new System.Drawing.Point(188, 71);
            this.RunScript.Name = "RunScript";
            this.RunScript.Size = new System.Drawing.Size(75, 23);
            this.RunScript.TabIndex = 9;
            this.RunScript.Text = "运行脚本";
            this.RunScript.UseVisualStyleBackColor = true;
            this.RunScript.Click += new System.EventHandler(this.RunScript_Click);
            // 
            // InputRecoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 193);
            this.Controls.Add(this.RunScript);
            this.Controls.Add(this.LastChooseText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChooseFIle);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearLog);
            this.Controls.Add(this.buttonTriggerRocoder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InputRecoder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Win64自动化录制器-阿辰";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button buttonTriggerRocoder;
        private Button clearLog;
        private Label label1;
        private Label label2;
        private Button btn_test;
        private Button ChooseFIle;
        private Label label3;
        private TextBox LastChooseText;
        private Button RunScript;
    }
}

