namespace CinemaTicketSalesAutomation
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
            this.label1_date = new System.Windows.Forms.Label();
            this.button1_next = new System.Windows.Forms.Button();
            this.button2_previous = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1_date
            // 
            this.label1_date.AutoSize = true;
            this.label1_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_date.Location = new System.Drawing.Point(523, 20);
            this.label1_date.Name = "label1_date";
            this.label1_date.Size = new System.Drawing.Size(0, 29);
            this.label1_date.TabIndex = 0;
            // 
            // button1_next
            // 
            this.button1_next.Location = new System.Drawing.Point(941, 20);
            this.button1_next.Name = "button1_next";
            this.button1_next.Size = new System.Drawing.Size(164, 47);
            this.button1_next.TabIndex = 1;
            this.button1_next.Text = "Next =>";
            this.button1_next.UseVisualStyleBackColor = true;
            this.button1_next.Click += new System.EventHandler(this.button1_next_Click);
            // 
            // button2_previous
            // 
            this.button2_previous.Enabled = false;
            this.button2_previous.Location = new System.Drawing.Point(76, 20);
            this.button2_previous.Name = "button2_previous";
            this.button2_previous.Size = new System.Drawing.Size(164, 47);
            this.button2_previous.TabIndex = 2;
            this.button2_previous.Text = "<= Previous";
            this.button2_previous.UseVisualStyleBackColor = true;
            this.button2_previous.Click += new System.EventHandler(this.button2_previous_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.button2_previous);
            this.Controls.Add(this.button1_next);
            this.Controls.Add(this.label1_date);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_date;
        private System.Windows.Forms.Button button1_next;
        private System.Windows.Forms.Button button2_previous;
    }
}

