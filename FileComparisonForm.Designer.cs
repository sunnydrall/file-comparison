namespace FileComparisonIgnou
{
    partial class FileComparisonForm
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
            this.fileAOutputTextbox = new System.Windows.Forms.RichTextBox();
            this.fileBOutputTextbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // fileAOutputTextbox
            // 
            this.fileAOutputTextbox.Location = new System.Drawing.Point(2, 4);
            this.fileAOutputTextbox.Name = "fileAOutputTextbox";
            this.fileAOutputTextbox.Size = new System.Drawing.Size(463, 605);
            this.fileAOutputTextbox.TabIndex = 0;
            this.fileAOutputTextbox.Text = "";
            // 
            // fileBOutputTextbox
            // 
            this.fileBOutputTextbox.Location = new System.Drawing.Point(471, 4);
            this.fileBOutputTextbox.Name = "fileBOutputTextbox";
            this.fileBOutputTextbox.Size = new System.Drawing.Size(447, 605);
            this.fileBOutputTextbox.TabIndex = 1;
            this.fileBOutputTextbox.Text = "";
            // 
            // FileComparisonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 610);
            this.Controls.Add(this.fileBOutputTextbox);
            this.Controls.Add(this.fileAOutputTextbox);
            this.Name = "FileComparisonForm";
            this.Text = "File Comparison";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox fileAOutputTextbox;
        private System.Windows.Forms.RichTextBox fileBOutputTextbox;
    }
}