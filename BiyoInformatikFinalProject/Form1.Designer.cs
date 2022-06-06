namespace BiyoInformatikFinalProject
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.sequenceGroupBox = new System.Windows.Forms.GroupBox();
            this.txtSequencePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.sequenceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sequenceGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1348, 721);
            this.panel1.TabIndex = 0;
            // 
            // sequenceGroupBox
            // 
            this.sequenceGroupBox.Controls.Add(this.btnBrowse);
            this.sequenceGroupBox.Controls.Add(this.txtSequencePath);
            this.sequenceGroupBox.Location = new System.Drawing.Point(50, 38);
            this.sequenceGroupBox.Name = "sequenceGroupBox";
            this.sequenceGroupBox.Size = new System.Drawing.Size(354, 166);
            this.sequenceGroupBox.TabIndex = 0;
            this.sequenceGroupBox.TabStop = false;
            this.sequenceGroupBox.Text = "Select Sequence Txt";
            // 
            // txtSequencePath
            // 
            this.txtSequencePath.Location = new System.Drawing.Point(6, 44);
            this.txtSequencePath.Name = "txtSequencePath";
            this.txtSequencePath.Size = new System.Drawing.Size(342, 27);
            this.txtSequencePath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(135, 99);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(94, 29);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.sequenceGroupBox.ResumeLayout(false);
            this.sequenceGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private GroupBox sequenceGroupBox;
        private Button btnBrowse;
        private TextBox txtSequencePath;
    }
}