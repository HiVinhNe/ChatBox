namespace FinalProject
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            tbMes = new TextBox();
            bt_Send = new Button();
            listBox1 = new ListBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tbName = new TextBox();
            btName = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // tbMes
            // 
            tbMes.Enabled = false;
            tbMes.Font = new Font("Segoe UI", 15F);
            tbMes.Location = new Point(12, 448);
            tbMes.Name = "tbMes";
            tbMes.Size = new Size(714, 41);
            tbMes.TabIndex = 1;
            // 
            // bt_Send
            // 
            bt_Send.Location = new Point(732, 448);
            bt_Send.Name = "bt_Send";
            bt_Send.Size = new Size(94, 41);
            bt_Send.TabIndex = 2;
            bt_Send.Text = "Send";
            bt_Send.UseVisualStyleBackColor = true;
            bt_Send.Click += bt_Send_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.FromArgb(255, 192, 128);
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(814, 424);
            listBox1.TabIndex = 3;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 15F);
            tbName.Location = new Point(832, 59);
            tbName.Name = "tbName";
            tbName.Size = new Size(181, 41);
            tbName.TabIndex = 4;
            // 
            // btName
            // 
            btName.Location = new Point(1019, 59);
            btName.Name = "btName";
            btName.Size = new Size(94, 41);
            btName.TabIndex = 5;
            btName.Text = "Send";
            btName.UseVisualStyleBackColor = true;
            btName.Click += btName_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(255, 224, 192);
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(832, 12);
            label1.Name = "label1";
            label1.Size = new Size(198, 35);
            label1.TabIndex = 6;
            label1.Text = "Type Your Name";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(1125, 512);
            Controls.Add(label1);
            Controls.Add(btName);
            Controls.Add(tbName);
            Controls.Add(listBox1);
            Controls.Add(bt_Send);
            Controls.Add(tbMes);
            Name = "Form1";
            Text = "Chat Box";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbMes;
        private Button bt_Send;
        private ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private TextBox tbName;
        private Button btName;
        private Label label1;
    }
}
