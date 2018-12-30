namespace Adler32
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.sDlugoscCiagu = new System.Windows.Forms.TextBox();
            this.sIloscWyrazow = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8_threads = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sDlugoscCiagu
            // 
            this.sDlugoscCiagu.Location = new System.Drawing.Point(25, 55);
            this.sDlugoscCiagu.Name = "sDlugoscCiagu";
            this.sDlugoscCiagu.Size = new System.Drawing.Size(140, 20);
            this.sDlugoscCiagu.TabIndex = 0;
            this.sDlugoscCiagu.Text = "19";
            // 
            // sIloscWyrazow
            // 
            this.sIloscWyrazow.Location = new System.Drawing.Point(215, 55);
            this.sIloscWyrazow.Name = "sIloscWyrazow";
            this.sIloscWyrazow.Size = new System.Drawing.Size(140, 20);
            this.sIloscWyrazow.TabIndex = 1;
            this.sIloscWyrazow.Text = "5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Jeden wątek.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Długość ciągu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ilość wyrazów:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(215, 100);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(315, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 20);
            this.button2.TabIndex = 6;
            this.button2.Text = "Wiele Wątków";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Postęp wyszukiwania:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Wynik jednowątkowy.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "0";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(215, 175);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(315, 23);
            this.progressBar2.Step = 1;
            this.progressBar2.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Wynik wielowątkowy.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "0";
            // 
            // label8_threads
            // 
            this.label8_threads.AutoSize = true;
            this.label8_threads.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8_threads.Location = new System.Drawing.Point(370, 25);
            this.label8_threads.Name = "label8_threads";
            this.label8_threads.Size = new System.Drawing.Size(131, 13);
            this.label8_threads.TabIndex = 13;
            this.label8_threads.Text = "Liczba wykrytych wątków:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 261);
            this.Controls.Add(this.label8_threads);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sIloscWyrazow);
            this.Controls.Add(this.sDlugoscCiagu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sDlugoscCiagu;
        private System.Windows.Forms.TextBox sIloscWyrazow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8_threads;
    }
}

