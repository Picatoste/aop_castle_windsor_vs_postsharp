namespace AOPSampleWinForm
{
    partial class TestForm
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
            this.btnPostSharp = new System.Windows.Forms.Button();
            this.btnCastleWindsor = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnPostSharp
            // 
            this.btnPostSharp.Location = new System.Drawing.Point(12, 12);
            this.btnPostSharp.Name = "btnPostSharp";
            this.btnPostSharp.Size = new System.Drawing.Size(165, 23);
            this.btnPostSharp.TabIndex = 0;
            this.btnPostSharp.Text = "Test PostSharp";
            this.btnPostSharp.UseVisualStyleBackColor = true;
            this.btnPostSharp.Click += new System.EventHandler(this.btnPostSharp_Click);
            // 
            // btnCastleWindsor
            // 
            this.btnCastleWindsor.Location = new System.Drawing.Point(199, 12);
            this.btnCastleWindsor.Name = "btnCastleWindsor";
            this.btnCastleWindsor.Size = new System.Drawing.Size(147, 23);
            this.btnCastleWindsor.TabIndex = 1;
            this.btnCastleWindsor.Text = "Test CastleWindsor";
            this.btnCastleWindsor.UseVisualStyleBackColor = true;
            this.btnCastleWindsor.Click += new System.EventHandler(this.btnCastleWindsor_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtOutput.ForeColor = System.Drawing.Color.Lime;
            this.txtOutput.Location = new System.Drawing.Point(0, 98);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(618, 604);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.Text = "";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 702);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnCastleWindsor);
            this.Controls.Add(this.btnPostSharp);
            this.Name = "TestForm";
            this.Text = "Test AOP";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPostSharp;
        private System.Windows.Forms.Button btnCastleWindsor;
        private System.Windows.Forms.RichTextBox txtOutput;
    }
}

