namespace PoopPaint
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mainLayerBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.overlayBox = new System.Windows.Forms.PictureBox();
            this.toolGroupBoxes = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainLayerBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(49, 434);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainLayerBox
            // 
            this.mainLayerBox.BackColor = System.Drawing.Color.White;
            this.mainLayerBox.Location = new System.Drawing.Point(67, 76);
            this.mainLayerBox.Name = "mainLayerBox";
            this.mainLayerBox.Size = new System.Drawing.Size(720, 426);
            this.mainLayerBox.TabIndex = 1;
            this.mainLayerBox.TabStop = false;
            this.mainLayerBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.mainLayerBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.mainLayerBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // overlayBox
            // 
            this.overlayBox.BackColor = System.Drawing.Color.Transparent;
            this.overlayBox.Location = new System.Drawing.Point(68, 498);
            this.overlayBox.Name = "overlayBox";
            this.overlayBox.Size = new System.Drawing.Size(720, 426);
            this.overlayBox.TabIndex = 2;
            this.overlayBox.TabStop = false;
            this.overlayBox.Click += new System.EventHandler(this.overlayBox_Click);
            this.overlayBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.overlayBox_MouseDown);
            this.overlayBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.overlayBox_MouseUp);
            // 
            // toolGroupBoxes
            // 
            this.toolGroupBoxes.Location = new System.Drawing.Point(12, 2);
            this.toolGroupBoxes.Name = "toolGroupBoxes";
            this.toolGroupBoxes.Size = new System.Drawing.Size(775, 62);
            this.toolGroupBoxes.TabIndex = 3;
            this.toolGroupBoxes.TabStop = false;
            this.toolGroupBoxes.Text = "Tool settings";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.toolGroupBoxes);
            this.Controls.Add(this.overlayBox);
            this.Controls.Add(this.mainLayerBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "PoopPaint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainLayerBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox mainLayerBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox overlayBox;
        private System.Windows.Forms.GroupBox toolGroupBoxes;
    }
}

