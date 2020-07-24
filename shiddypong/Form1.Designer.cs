namespace shiddypong
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
            this.components = new System.ComponentModel.Container();
            this.PBMAIN = new System.Windows.Forms.PictureBox();
            this.GAMELOOP = new System.Windows.Forms.Timer(this.components);
            this.MOVLOOP = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PBMAIN)).BeginInit();
            this.SuspendLayout();
            // 
            // PBMAIN
            // 
            this.PBMAIN.Location = new System.Drawing.Point(12, 12);
            this.PBMAIN.Name = "PBMAIN";
            this.PBMAIN.Size = new System.Drawing.Size(500, 250);
            this.PBMAIN.TabIndex = 0;
            this.PBMAIN.TabStop = false;
            // 
            // GAMELOOP
            // 
            this.GAMELOOP.Interval = 30;
            this.GAMELOOP.Tick += new System.EventHandler(this.GAMELOOP_Tick);
            // 
            // MOVLOOP
            // 
            this.MOVLOOP.Interval = 5;
            this.MOVLOOP.Tick += new System.EventHandler(this.MOVLOOP_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 280);
            this.Controls.Add(this.PBMAIN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Bullshit pong";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBMAIN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBMAIN;
        private System.Windows.Forms.Timer GAMELOOP;
        private System.Windows.Forms.Timer MOVLOOP;
    }
}

