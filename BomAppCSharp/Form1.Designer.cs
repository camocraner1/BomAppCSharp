namespace BomAppCSharp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RefLabel = new System.Windows.Forms.Label();
            this.SortLabel = new System.Windows.Forms.Label();
            this.RefTextBox = new System.Windows.Forms.TextBox();
            this.SortedTextBox = new System.Windows.Forms.TextBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalCountBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RowCountText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cell1 = new System.Windows.Forms.TextBox();
            this.Cell2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RefLabel
            // 
            this.RefLabel.AutoSize = true;
            this.RefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefLabel.Location = new System.Drawing.Point(18, 24);
            this.RefLabel.Name = "RefLabel";
            this.RefLabel.Size = new System.Drawing.Size(107, 20);
            this.RefLabel.TabIndex = 0;
            this.RefLabel.Text = "References:";
            // 
            // SortLabel
            // 
            this.SortLabel.AutoSize = true;
            this.SortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortLabel.Location = new System.Drawing.Point(248, 24);
            this.SortLabel.Name = "SortLabel";
            this.SortLabel.Size = new System.Drawing.Size(68, 20);
            this.SortLabel.TabIndex = 1;
            this.SortLabel.Text = "Sorted:";
            // 
            // RefTextBox
            // 
            this.RefTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefTextBox.Location = new System.Drawing.Point(22, 47);
            this.RefTextBox.Multiline = true;
            this.RefTextBox.Name = "RefTextBox";
            this.RefTextBox.Size = new System.Drawing.Size(194, 311);
            this.RefTextBox.TabIndex = 2;
            // 
            // SortedTextBox
            // 
            this.SortedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortedTextBox.Location = new System.Drawing.Point(252, 47);
            this.SortedTextBox.Multiline = true;
            this.SortedTextBox.Name = "SortedTextBox";
            this.SortedTextBox.Size = new System.Drawing.Size(217, 311);
            this.SortedTextBox.TabIndex = 3;
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.Location = new System.Drawing.Point(144, 469);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(93, 66);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SortButton
            // 
            this.SortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortButton.Location = new System.Drawing.Point(252, 469);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(92, 66);
            this.SortButton.TabIndex = 5;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new System.Drawing.Point(203, 541);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(83, 42);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total Count:";
            // 
            // TotalCountBox
            // 
            this.TotalCountBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalCountBox.Location = new System.Drawing.Point(494, 434);
            this.TotalCountBox.Name = "TotalCountBox";
            this.TotalCountBox.Size = new System.Drawing.Size(23, 26);
            this.TotalCountBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(497, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Row Count:";
            // 
            // RowCountText
            // 
            this.RowCountText.AutoSize = true;
            this.RowCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RowCountText.Location = new System.Drawing.Point(513, 50);
            this.RowCountText.Name = "RowCountText";
            this.RowCountText.Size = new System.Drawing.Size(0, 16);
            this.RowCountText.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enter cell range to load:";
            // 
            // Cell1
            // 
            this.Cell1.Location = new System.Drawing.Point(160, 437);
            this.Cell1.Name = "Cell1";
            this.Cell1.Size = new System.Drawing.Size(28, 20);
            this.Cell1.TabIndex = 12;
            // 
            // Cell2
            // 
            this.Cell2.Location = new System.Drawing.Point(214, 437);
            this.Cell2.Name = "Cell2";
            this.Cell2.Size = new System.Drawing.Size(28, 20);
            this.Cell2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(194, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 591);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cell2);
            this.Controls.Add(this.Cell1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RowCountText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TotalCountBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SortedTextBox);
            this.Controls.Add(this.RefTextBox);
            this.Controls.Add(this.SortLabel);
            this.Controls.Add(this.RefLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Bom Sort";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RefLabel;
        private System.Windows.Forms.Label SortLabel;
        private System.Windows.Forms.TextBox RefTextBox;
        private System.Windows.Forms.TextBox SortedTextBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TotalCountBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RowCountText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Cell1;
        private System.Windows.Forms.TextBox Cell2;
        private System.Windows.Forms.Label label4;
    }
}

