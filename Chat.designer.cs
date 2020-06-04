namespace E_Justice
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            this.Name2 = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Name1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Name3 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lbIp = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Name2
            // 
            this.Name2.Interval = 1300;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(302, 325);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 20);
            this.button5.TabIndex = 33;
            this.button5.Text = "Kill Connection";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(55, 325);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(241, 20);
            this.textBox5.TabIndex = 32;
            this.textBox5.Text = "Nick ";
            // 
            // Name1
            // 
            this.Name1.Interval = 1300;
            this.Name1.Tick += new System.EventHandler(this.Name1_Tick_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(318, 299);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 20);
            this.button4.TabIndex = 31;
            this.button4.Text = "Unmute User";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(55, 299);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(257, 20);
            this.textBox4.TabIndex = 30;
            this.textBox4.Text = "Nick ";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(324, 275);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 20);
            this.button3.TabIndex = 29;
            this.button3.Text = "Mute User";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(55, 275);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(263, 20);
            this.textBox3.TabIndex = 28;
            this.textBox3.Text = "Nick";
            // 
            // Name3
            // 
            this.Name3.Interval = 1300;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(348, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 20);
            this.button1.TabIndex = 25;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 248);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(287, 20);
            this.textBox1.TabIndex = 24;
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Location = new System.Drawing.Point(55, 55);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(344, 190);
            this.txtLog.TabIndex = 23;
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Location = new System.Drawing.Point(68, 33);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(99, 13);
            this.lbIp.TabIndex = 22;
            this.lbIp.Text = "Host IP (TCP 1986)";
            // 
            // txtIp
            // 
            this.txtIp.BackColor = System.Drawing.Color.Silver;
            this.txtIp.ForeColor = System.Drawing.Color.White;
            this.txtIp.Location = new System.Drawing.Point(173, 30);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(116, 20);
            this.txtIp.TabIndex = 21;
            this.txtIp.Text = "127.0.0.1";
            // 
            // btnListen
            // 
            this.btnListen.BackColor = System.Drawing.Color.Black;
            this.btnListen.ForeColor = System.Drawing.Color.White;
            this.btnListen.Location = new System.Drawing.Point(295, 29);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(104, 20);
            this.btnListen.TabIndex = 20;
            this.btnListen.Text = "Connect";
            this.btnListen.UseVisualStyleBackColor = false;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click_1);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(455, 448);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lbIp);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.btnListen);
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Name2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Timer Name1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Timer Name3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Button btnListen;
    }
}