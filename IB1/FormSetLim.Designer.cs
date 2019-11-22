namespace IB1
{
    partial class FormSetLim
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
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Block = new System.Windows.Forms.CheckBox();
            this.numericUpDown_Limit = new System.Windows.Forms.NumericUpDown();
            this.button_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Limit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "login:";
            // 
            // textBox_Login
            // 
            this.textBox_Login.Enabled = false;
            this.textBox_Login.Location = new System.Drawing.Point(29, 44);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(205, 26);
            this.textBox_Login.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Count ";
            // 
            // checkBox_Block
            // 
            this.checkBox_Block.AutoSize = true;
            this.checkBox_Block.Location = new System.Drawing.Point(286, 46);
            this.checkBox_Block.Name = "checkBox_Block";
            this.checkBox_Block.Size = new System.Drawing.Size(74, 24);
            this.checkBox_Block.TabIndex = 4;
            this.checkBox_Block.Text = "Block";
            this.checkBox_Block.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_Limit
            // 
            this.numericUpDown_Limit.Location = new System.Drawing.Point(422, 44);
            this.numericUpDown_Limit.Name = "numericUpDown_Limit";
            this.numericUpDown_Limit.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown_Limit.TabIndex = 6;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(224, 122);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(97, 37);
            this.button_OK.TabIndex = 7;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // FormSetLim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 180);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.numericUpDown_Limit);
            this.Controls.Add(this.checkBox_Block);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Login);
            this.Controls.Add(this.label1);
            this.Name = "FormSetLim";
            this.Text = "FormSetLim";
            this.Load += new System.EventHandler(this.FormSetLim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Limit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_Block;
        private System.Windows.Forms.NumericUpDown numericUpDown_Limit;
        private System.Windows.Forms.Button button_OK;
    }
}