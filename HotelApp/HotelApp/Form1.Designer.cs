
namespace HotelApp
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
            this.headPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.AddClient = new System.Windows.Forms.Button();
            this.RemoveClientButton = new System.Windows.Forms.Button();
            this.bookingButton = new System.Windows.Forms.Button();
            this.addService = new System.Windows.Forms.Button();
            this.buttonScore = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.headPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.Blue;
            this.headPanel.Controls.Add(this.label1);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(613, 100);
            this.headPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(202, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hottel App";
            // 
            // AddClient
            // 
            this.AddClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddClient.Location = new System.Drawing.Point(58, 34);
            this.AddClient.Name = "AddClient";
            this.AddClient.Size = new System.Drawing.Size(150, 50);
            this.AddClient.TabIndex = 1;
            this.AddClient.Text = "Добавит нового клиента";
            this.AddClient.UseVisualStyleBackColor = true;
            this.AddClient.Click += new System.EventHandler(this.AddClient_Click);
            // 
            // RemoveClientButton
            // 
            this.RemoveClientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveClientButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemoveClientButton.Location = new System.Drawing.Point(58, 111);
            this.RemoveClientButton.Name = "RemoveClientButton";
            this.RemoveClientButton.Size = new System.Drawing.Size(150, 50);
            this.RemoveClientButton.TabIndex = 2;
            this.RemoveClientButton.Text = "Выселить клиента";
            this.RemoveClientButton.UseVisualStyleBackColor = true;
            this.RemoveClientButton.Click += new System.EventHandler(this.RemoveClientButton_Click);
            // 
            // bookingButton
            // 
            this.bookingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bookingButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bookingButton.Location = new System.Drawing.Point(58, 193);
            this.bookingButton.Name = "bookingButton";
            this.bookingButton.Size = new System.Drawing.Size(150, 50);
            this.bookingButton.TabIndex = 3;
            this.bookingButton.Text = "Забронировать номер";
            this.bookingButton.UseVisualStyleBackColor = true;
            this.bookingButton.Click += new System.EventHandler(this.BookingButton_Click);
            // 
            // addService
            // 
            this.addService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addService.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addService.Location = new System.Drawing.Point(58, 275);
            this.addService.Name = "addService";
            this.addService.Size = new System.Drawing.Size(150, 50);
            this.addService.TabIndex = 4;
            this.addService.Text = "Добавить услугу";
            this.addService.UseVisualStyleBackColor = true;
            this.addService.Click += new System.EventHandler(this.addService_Click);
            // 
            // buttonScore
            // 
            this.buttonScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonScore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonScore.Location = new System.Drawing.Point(69, 55);
            this.buttonScore.Name = "buttonScore";
            this.buttonScore.Size = new System.Drawing.Size(150, 50);
            this.buttonScore.TabIndex = 5;
            this.buttonScore.Text = "Создать запрос";
            this.buttonScore.UseVisualStyleBackColor = true;
            this.buttonScore.Click += new System.EventHandler(this.buttonScore_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.AddClient);
            this.groupBox1.Controls.Add(this.RemoveClientButton);
            this.groupBox1.Controls.Add(this.addService);
            this.groupBox1.Controls.Add(this.bookingButton);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(13, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 331);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Операции по номерам";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonScore);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(321, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 332);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Получение списков из БД";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(613, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.headPanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddClient;
        private System.Windows.Forms.Button RemoveClientButton;
        private System.Windows.Forms.Button bookingButton;
        private System.Windows.Forms.Button addService;
        private System.Windows.Forms.Button buttonScore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

