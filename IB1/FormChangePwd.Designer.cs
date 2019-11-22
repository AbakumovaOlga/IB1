namespace IB1
{
    partial class FormChangePwd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_OldPwd = new System.Windows.Forms.TextBox();
            this.textBox_NewPwd = new System.Windows.Forms.TextBox();
            this.textBox_RepPwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Repeat Password";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(201, 175);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(87, 33);
            this.button_OK.TabIndex = 6;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_OldPwd
            // 
            this.textBox_OldPwd.Location = new System.Drawing.Point(190, 49);
            this.textBox_OldPwd.Name = "textBox_OldPwd";
            this.textBox_OldPwd.Size = new System.Drawing.Size(100, 26);
            this.textBox_OldPwd.TabIndex = 7;
            // 
            // textBox_NewPwd
            // 
            this.textBox_NewPwd.Location = new System.Drawing.Point(188, 84);
            this.textBox_NewPwd.Name = "textBox_NewPwd";
            this.textBox_NewPwd.Size = new System.Drawing.Size(100, 26);
            this.textBox_NewPwd.TabIndex = 8;
            // 
            // textBox_RepPwd
            // 
            this.textBox_RepPwd.Location = new System.Drawing.Point(190, 123);
            this.textBox_RepPwd.Name = "textBox_RepPwd";
            this.textBox_RepPwd.Size = new System.Drawing.Size(100, 26);
            this.textBox_RepPwd.TabIndex = 9;
            // 
            // FormChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 231);
            this.Controls.Add(this.textBox_RepPwd);
            this.Controls.Add(this.textBox_NewPwd);
            this.Controls.Add(this.textBox_OldPwd);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormChangePwd";
            this.Text = "FormChangePwd";
            this.Load += new System.EventHandler(this.FormChangePwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_OldPwd;
        private System.Windows.Forms.TextBox textBox_NewPwd;
        private System.Windows.Forms.TextBox textBox_RepPwd;
    }
}