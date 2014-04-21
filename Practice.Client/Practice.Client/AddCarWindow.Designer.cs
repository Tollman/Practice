namespace Practice.Client
{
    partial class AddCarWindow
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
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ColorBox = new System.Windows.Forms.TextBox();
            this.MarkBox = new System.Windows.Forms.TextBox();
            this.CostBox = new System.Windows.Forms.TextBox();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.MarkLabel = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(411, 225);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(411, 254);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ColorBox
            // 
            this.ColorBox.Location = new System.Drawing.Point(12, 104);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(100, 20);
            this.ColorBox.TabIndex = 6;
            // 
            // MarkBox
            // 
            this.MarkBox.Location = new System.Drawing.Point(12, 64);
            this.MarkBox.Name = "MarkBox";
            this.MarkBox.Size = new System.Drawing.Size(100, 20);
            this.MarkBox.TabIndex = 7;
            // 
            // CostBox
            // 
            this.CostBox.Location = new System.Drawing.Point(12, 24);
            this.CostBox.Name = "CostBox";
            this.CostBox.Size = new System.Drawing.Size(100, 20);
            this.CostBox.TabIndex = 8;
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Location = new System.Drawing.Point(12, 88);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(34, 13);
            this.ColorLabel.TabIndex = 3;
            this.ColorLabel.Text = "Color:";
            // 
            // MarkLabel
            // 
            this.MarkLabel.AutoSize = true;
            this.MarkLabel.Location = new System.Drawing.Point(12, 48);
            this.MarkLabel.Name = "MarkLabel";
            this.MarkLabel.Size = new System.Drawing.Size(34, 13);
            this.MarkLabel.TabIndex = 4;
            this.MarkLabel.Text = "Mark:";
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Location = new System.Drawing.Point(12, 9);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(31, 13);
            this.CostLabel.TabIndex = 5;
            this.CostLabel.Text = "Cost:";
            // 
            // AddCarWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 289);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.MarkBox);
            this.Controls.Add(this.CostBox);
            this.Controls.Add(this.ColorLabel);
            this.Controls.Add(this.MarkLabel);
            this.Controls.Add(this.CostLabel);
            this.Name = "AddCarWindow";
            this.Text = "AddCarWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox ColorBox;
        private System.Windows.Forms.TextBox MarkBox;
        private System.Windows.Forms.TextBox CostBox;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Label MarkLabel;
        private System.Windows.Forms.Label CostLabel;
    }
}