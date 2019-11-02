namespace WindowsFormsApplication1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.müşteriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biletBulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seferlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seferEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seferDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otobüsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otobüsEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otobüsDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Red;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşteriToolStripMenuItem,
            this.seferlerToolStripMenuItem,
            this.otobüsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(700, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // müşteriToolStripMenuItem
            // 
            this.müşteriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.biletBulToolStripMenuItem});
            this.müşteriToolStripMenuItem.Name = "müşteriToolStripMenuItem";
            this.müşteriToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.müşteriToolStripMenuItem.Text = "Müşteri";
            // 
            // biletBulToolStripMenuItem
            // 
            this.biletBulToolStripMenuItem.Name = "biletBulToolStripMenuItem";
            this.biletBulToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.biletBulToolStripMenuItem.Text = "Bilet Düzenle";
            this.biletBulToolStripMenuItem.Click += new System.EventHandler(this.biletBulToolStripMenuItem_Click);
            // 
            // seferlerToolStripMenuItem
            // 
            this.seferlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seferEkleToolStripMenuItem,
            this.seferDüzenleToolStripMenuItem});
            this.seferlerToolStripMenuItem.Name = "seferlerToolStripMenuItem";
            this.seferlerToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.seferlerToolStripMenuItem.Text = "Seferler";
            // 
            // seferEkleToolStripMenuItem
            // 
            this.seferEkleToolStripMenuItem.Name = "seferEkleToolStripMenuItem";
            this.seferEkleToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.seferEkleToolStripMenuItem.Text = "Sefer Ekle";
            this.seferEkleToolStripMenuItem.Click += new System.EventHandler(this.seferEkleToolStripMenuItem_Click);
            // 
            // seferDüzenleToolStripMenuItem
            // 
            this.seferDüzenleToolStripMenuItem.Name = "seferDüzenleToolStripMenuItem";
            this.seferDüzenleToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.seferDüzenleToolStripMenuItem.Text = "Sefer Düzenle";
            this.seferDüzenleToolStripMenuItem.Click += new System.EventHandler(this.seferDüzenleToolStripMenuItem_Click);
            // 
            // otobüsToolStripMenuItem
            // 
            this.otobüsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otobüsEkleToolStripMenuItem,
            this.otobüsDüzenleToolStripMenuItem});
            this.otobüsToolStripMenuItem.Name = "otobüsToolStripMenuItem";
            this.otobüsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.otobüsToolStripMenuItem.Text = "Otobüs";
            // 
            // otobüsEkleToolStripMenuItem
            // 
            this.otobüsEkleToolStripMenuItem.Name = "otobüsEkleToolStripMenuItem";
            this.otobüsEkleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.otobüsEkleToolStripMenuItem.Text = "Otobüs Ekle";
            this.otobüsEkleToolStripMenuItem.Click += new System.EventHandler(this.otobüsEkleToolStripMenuItem_Click);
            // 
            // otobüsDüzenleToolStripMenuItem
            // 
            this.otobüsDüzenleToolStripMenuItem.Name = "otobüsDüzenleToolStripMenuItem";
            this.otobüsDüzenleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.otobüsDüzenleToolStripMenuItem.Text = "Otobüs Düzenle";
            this.otobüsDüzenleToolStripMenuItem.Click += new System.EventHandler(this.otobüsDüzenleToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(48, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "NEREDEN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(48, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "NEREYE";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Akcakoca",
            "Eregli",
            "Hopa",
            "Ankara",
            "İzmir",
            "Artvin Merkez",
            "Kastamonu",
            "Artvin",
            "Gebze",
            "İstanbul(Dudullu)\t"});
            this.comboBox1.Location = new System.Drawing.Point(164, 110);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Akcakoca";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Akcakoca",
            "Eregli",
            "Hopa",
            "Ankara",
            "İzmir",
            "Artvin Merkez",
            "Kastamonu",
            "Artvin",
            "Gebze",
            "İstanbul(Dudullu)"});
            this.comboBox2.Location = new System.Drawing.Point(164, 144);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.Text = "Akcakoca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(48, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "TARİH";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(164, 188);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(184, 20);
            this.dateTimePicker1.TabIndex = 7;
            
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(32, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(263, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "HIZLI BİLET SORGULA";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "ARA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 268);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem müşteriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seferlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seferEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seferDüzenleToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem otobüsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otobüsEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otobüsDüzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biletBulToolStripMenuItem;
    }
}

