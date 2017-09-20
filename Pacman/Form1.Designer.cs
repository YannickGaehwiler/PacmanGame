using System.Windows.Forms;
using Pacman.Maze;

namespace Pacman
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
            this.pacmanPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pacmanPanel
            // 
            this.pacmanPanel.BackColor = System.Drawing.Color.Yellow;
            this.pacmanPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pacmanPanel.Location = new System.Drawing.Point(30, 30);
            this.pacmanPanel.Name = "pacmanPanel";
            this.pacmanPanel.Size = new System.Drawing.Size(30, 30);
            this.pacmanPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 434);
            this.Controls.Add(this.pacmanPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public Panel pacmanPanel;
    }
}

