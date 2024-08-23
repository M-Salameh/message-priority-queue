namespace HTTPEndUser
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
            this.ClientID = new System.Windows.Forms.TextBox();
            this.ApiKey = new System.Windows.Forms.TextBox();
            this.MessageContent = new System.Windows.Forms.RichTextBox();
            this.LeaveDate = new System.Windows.Forms.TextBox();
            this.Tag = new System.Windows.Forms.TextBox();
            this.Receiver = new System.Windows.Forms.TextBox();
            this.Priority = new System.Windows.Forms.ComboBox();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Minutes = new System.Windows.Forms.TextBox();
            this.Hours = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Response = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClientID
            // 
            this.ClientID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClientID.Location = new System.Drawing.Point(33, 49);
            this.ClientID.Multiline = true;
            this.ClientID.Name = "ClientID";
            this.ClientID.Size = new System.Drawing.Size(324, 61);
            this.ClientID.TabIndex = 2;
            this.ClientID.Text = "Enter Your Client ID";
            this.ClientID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClientID.Click += new System.EventHandler(this.ClearClientID);
            // 
            // ApiKey
            // 
            this.ApiKey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ApiKey.Location = new System.Drawing.Point(33, 154);
            this.ApiKey.Multiline = true;
            this.ApiKey.Name = "ApiKey";
            this.ApiKey.Size = new System.Drawing.Size(324, 61);
            this.ApiKey.TabIndex = 3;
            this.ApiKey.Text = "Enter Your ApiKey";
            this.ApiKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ApiKey.Click += new System.EventHandler(this.ClearApiKey);
            // 
            // MessageContent
            // 
            this.MessageContent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MessageContent.Location = new System.Drawing.Point(56, 493);
            this.MessageContent.Name = "MessageContent";
            this.MessageContent.Size = new System.Drawing.Size(898, 129);
            this.MessageContent.TabIndex = 4;
            this.MessageContent.Text = "Write Your Message";
            this.MessageContent.Click += new System.EventHandler(this.ClearContent);
            // 
            // LeaveDate
            // 
            this.LeaveDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LeaveDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LeaveDate.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LeaveDate.ForeColor = System.Drawing.Color.Red;
            this.LeaveDate.Location = new System.Drawing.Point(672, 63);
            this.LeaveDate.Multiline = true;
            this.LeaveDate.Name = "LeaveDate";
            this.LeaveDate.Size = new System.Drawing.Size(259, 34);
            this.LeaveDate.TabIndex = 6;
            this.LeaveDate.Text = "Choose Date";
            this.LeaveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tag
            // 
            this.Tag.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Tag.Location = new System.Drawing.Point(33, 258);
            this.Tag.Multiline = true;
            this.Tag.Name = "Tag";
            this.Tag.Size = new System.Drawing.Size(324, 60);
            this.Tag.TabIndex = 7;
            this.Tag.Text = "Enter Provider";
            this.Tag.Click += new System.EventHandler(this.ClearTag);
            // 
            // Receiver
            // 
            this.Receiver.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Receiver.Location = new System.Drawing.Point(33, 368);
            this.Receiver.Multiline = true;
            this.Receiver.Name = "Receiver";
            this.Receiver.Size = new System.Drawing.Size(324, 66);
            this.Receiver.TabIndex = 8;
            this.Receiver.Text = "Enter Receiver";
            this.Receiver.Click += new System.EventHandler(this.ClearReceiver);
            // 
            // Priority
            // 
            this.Priority.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Priority.FormattingEnabled = true;
            this.Priority.Items.AddRange(new object[] {
            "Very Low",
            "Low ",
            "Medium",
            "High",
            "Very High"});
            this.Priority.Location = new System.Drawing.Point(691, 364);
            this.Priority.Name = "Priority";
            this.Priority.Size = new System.Drawing.Size(250, 36);
            this.Priority.TabIndex = 9;
            this.Priority.Text = "Set Priority";
            // 
            // DatePicker
            // 
            this.DatePicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatePicker.Location = new System.Drawing.Point(691, 103);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(263, 34);
            this.DatePicker.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(672, 186);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 29);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Set Time  , Hours are in 24 Base";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Minutes
            // 
            this.Minutes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Minutes.Location = new System.Drawing.Point(808, 236);
            this.Minutes.Multiline = true;
            this.Minutes.Name = "Minutes";
            this.Minutes.Size = new System.Drawing.Size(175, 38);
            this.Minutes.TabIndex = 12;
            this.Minutes.Text = "Minutes (0-59)";
            this.Minutes.Click += new System.EventHandler(this.ClearMinutes);
            // 
            // Hours
            // 
            this.Hours.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Hours.Location = new System.Drawing.Point(600, 236);
            this.Hours.Multiline = true;
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(163, 38);
            this.Hours.TabIndex = 13;
            this.Hours.Text = "Hours (0-23)";
            this.Hours.Click += new System.EventHandler(this.ClearHours);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(769, 236);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(33, 36);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = ":";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Response
            // 
            this.Response.BackColor = System.Drawing.SystemColors.Menu;
            this.Response.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Response.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Response.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Response.Location = new System.Drawing.Point(12, 746);
            this.Response.Multiline = true;
            this.Response.Name = "Response";
            this.Response.Size = new System.Drawing.Size(942, 92);
            this.Response.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(398, 657);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 72);
            this.button1.TabIndex = 16;
            this.button1.Text = "Send Message";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SendMessageAsync);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 850);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Response);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Hours);
            this.Controls.Add(this.Minutes);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.Priority);
            this.Controls.Add(this.Receiver);
            this.Controls.Add(this.Tag);
            this.Controls.Add(this.LeaveDate);
            this.Controls.Add(this.MessageContent);
            this.Controls.Add(this.ApiKey);
            this.Controls.Add(this.ClientID);
            this.Name = "Form1";
            this.Text = "Send HTTP Message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox ClientID;
        private TextBox ApiKey;
        private RichTextBox MessageContent;
        private TextBox LeaveDate;
        private TextBox Tag;
        private TextBox Receiver;
        private ComboBox Priority;
        private DateTimePicker DatePicker;
        private TextBox textBox1;
        private TextBox Minutes;
        private TextBox Hours;
        private TextBox textBox2;
        private TextBox Response;
        private Button button1;
    }
}