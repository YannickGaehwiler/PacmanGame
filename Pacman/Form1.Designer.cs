using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pacman = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 10);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "wall";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(10, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 10);
            this.panel2.TabIndex = 1;
            this.panel2.Tag = "wall";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.panel13);
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Location = new System.Drawing.Point(10, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 333);
            this.panel3.TabIndex = 2;
            this.panel3.Tag = "wall";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Black;
            this.panel13.Location = new System.Drawing.Point(3, 252);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(103, 10);
            this.panel13.TabIndex = 10;
            this.panel13.Tag = "wall";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Black;
            this.panel11.Location = new System.Drawing.Point(8, 252);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(180, 10);
            this.panel11.TabIndex = 9;
            this.panel11.Tag = "wall";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(570, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 333);
            this.panel4.TabIndex = 3;
            this.panel4.Tag = "wall";
            // 
            // pacman
            // 
            this.pacman.BackColor = System.Drawing.Color.Yellow;
            this.pacman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pacman.Location = new System.Drawing.Point(209, 130);
            this.pacman.Name = "pacman";
            this.pacman.Size = new System.Drawing.Size(20, 20);
            this.pacman.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(39, 120);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(110, 10);
            this.panel5.TabIndex = 7;
            this.panel5.Tag = "wall";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(40, 180);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(110, 10);
            this.panel6.TabIndex = 8;
            this.panel6.Tag = "wall";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(99, 49);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 51);
            this.panel7.TabIndex = 8;
            this.panel7.Tag = "wall";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Location = new System.Drawing.Point(20, 150);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(99, 10);
            this.panel8.TabIndex = 8;
            this.panel8.Tag = "wall";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Black;
            this.panel9.Location = new System.Drawing.Point(69, 69);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(10, 51);
            this.panel9.TabIndex = 9;
            this.panel9.Tag = "wall";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Black;
            this.panel10.Location = new System.Drawing.Point(39, 49);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(10, 51);
            this.panel10.TabIndex = 10;
            this.panel10.Tag = "wall";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Black;
            this.panel12.Location = new System.Drawing.Point(109, 90);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(103, 10);
            this.panel12.TabIndex = 9;
            this.panel12.Tag = "wall";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Black;
            this.panel14.Location = new System.Drawing.Point(39, 39);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(70, 10);
            this.panel14.TabIndex = 10;
            this.panel14.Tag = "wall";
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Black;
            this.panel15.Location = new System.Drawing.Point(139, 130);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(10, 32);
            this.panel15.TabIndex = 10;
            this.panel15.Tag = "wall";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.Black;
            this.panel16.Location = new System.Drawing.Point(20, 210);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(180, 10);
            this.panel16.TabIndex = 9;
            this.panel16.Tag = "wall";
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Black;
            this.panel17.Location = new System.Drawing.Point(167, 159);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(10, 51);
            this.panel17.TabIndex = 9;
            this.panel17.Tag = "wall";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 434);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.pacman);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        public Panel pacman;
        public Timer timer1;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private Panel panel13;
        private Panel panel11;
        private Panel panel12;
        private Panel panel14;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
    }
}

