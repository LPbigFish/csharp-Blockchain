namespace Blockchain_inplementation
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.Verify_Btn = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.PhraseBTN = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Wallet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 47);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(487, 177);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(399, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Sign Message";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(256, 246);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(243, 175);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // Verify_Btn
            // 
            this.Verify_Btn.Location = new System.Drawing.Point(293, 12);
            this.Verify_Btn.Name = "Verify_Btn";
            this.Verify_Btn.Size = new System.Drawing.Size(100, 29);
            this.Verify_Btn.TabIndex = 4;
            this.Verify_Btn.Text = "Verify Message";
            this.Verify_Btn.UseVisualStyleBackColor = true;
            this.Verify_Btn.Click += new System.EventHandler(this.Verify_Btn_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(12, 246);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(238, 175);
            this.richTextBox3.TabIndex = 5;
            this.richTextBox3.Text = "";
            // 
            // PhraseBTN
            // 
            this.PhraseBTN.Location = new System.Drawing.Point(118, 12);
            this.PhraseBTN.Name = "PhraseBTN";
            this.PhraseBTN.Size = new System.Drawing.Size(100, 29);
            this.PhraseBTN.TabIndex = 6;
            this.PhraseBTN.Text = "GetPhrase";
            this.PhraseBTN.UseVisualStyleBackColor = true;
            this.PhraseBTN.Click += new System.EventHandler(this.PhraseBTN_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 436);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 29);
            this.button3.TabIndex = 7;
            this.button3.Text = "Start The Chain";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 472);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.PhraseBTN);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.Verify_Btn);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button Verify_Btn;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button PhraseBTN;
        private System.Windows.Forms.Button button3;
    }
}

