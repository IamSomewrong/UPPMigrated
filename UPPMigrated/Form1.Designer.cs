namespace UPPMigrated
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            button3 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            domainUpDown1 = new DomainUpDown();
            groupBox2 = new GroupBox();
            button2 = new Button();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            сменитьАккаунтToolStripMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            загрузитьToolStripMenuItem = new ToolStripMenuItem();
            label4 = new Label();
            label5 = new Label();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            listBox1 = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(16, 183);
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(290, 234);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Портфель";
            // 
            // button3
            // 
            button3.Location = new Point(166, 184);
            button3.Margin = new Padding(5, 4, 5, 4);
            button3.Name = "button3";
            button3.Size = new Size(114, 36);
            button3.TabIndex = 12;
            button3.Text = "Продать";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(10, 184);
            button1.Margin = new Padding(5, 4, 5, 4);
            button1.Name = "button1";
            button1.Size = new Size(114, 36);
            button1.TabIndex = 11;
            button1.Text = "Купить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(77, 153);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(221, 109);
            label7.Name = "label7";
            label7.Size = new Size(29, 20);
            label7.TabIndex = 3;
            label7.Text = "0%";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(208, 74);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 2;
            label6.Text = "0 у.е.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 74);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 1;
            label3.Text = "0 шт.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(110, 36);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 0;
            label2.Text = "Название";
            // 
            // domainUpDown1
            // 
            domainUpDown1.Items.Add("День");
            domainUpDown1.Items.Add("Неделя");
            domainUpDown1.Items.Add("Месяц");
            domainUpDown1.Items.Add("3 Месяца");
            domainUpDown1.Items.Add("6 Месяцев");
            domainUpDown1.Items.Add("Год");
            domainUpDown1.Items.Add("За все время");
            domainUpDown1.Location = new Point(1152, 173);
            domainUpDown1.Margin = new Padding(5, 4, 5, 4);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.ReadOnly = true;
            domainUpDown1.Size = new Size(101, 27);
            domainUpDown1.TabIndex = 6;
            domainUpDown1.Text = "Месяц";
            domainUpDown1.SelectedItemChanged += domainUpDown1_SelectedItemChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(16, 73);
            groupBox2.Margin = new Padding(5, 4, 5, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 4, 5, 4);
            groupBox2.Size = new Size(290, 100);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Баланс";
            // 
            // button2
            // 
            button2.Location = new Point(150, 41);
            button2.Margin = new Padding(5, 4, 5, 4);
            button2.Name = "button2";
            button2.Size = new Size(114, 36);
            button2.TabIndex = 10;
            button2.Text = "Пополнить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 57);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 7;
            label1.Text = "0 у.е.";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { сменитьАккаунтToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 3, 0, 3);
            menuStrip1.Size = new Size(1267, 30);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // сменитьАккаунтToolStripMenuItem
            // 
            сменитьАккаунтToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, загрузитьToolStripMenuItem });
            сменитьАккаунтToolStripMenuItem.Name = "сменитьАккаунтToolStripMenuItem";
            сменитьАккаунтToolStripMenuItem.Size = new Size(139, 24);
            сменитьАккаунтToolStripMenuItem.Text = "Сменить аккаунт";
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(169, 26);
            создатьToolStripMenuItem.Text = "Создать...";
            создатьToolStripMenuItem.Click += создатьToolStripMenuItem_Click;
            // 
            // загрузитьToolStripMenuItem
            // 
            загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            загрузитьToolStripMenuItem.Size = new Size(169, 26);
            загрузитьToolStripMenuItem.Text = "Загрузить...";
            загрузитьToolStripMenuItem.Click += загрузитьToolStripMenuItem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 48);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 13;
            label4.Text = "Здравствуйте, ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(126, 48);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 14;
            label5.Text = "label5";
            // 
            // plotView1
            // 
            plotView1.Location = new Point(325, 48);
            plotView1.Margin = new Padding(3, 4, 3, 4);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(746, 525);
            plotView1.TabIndex = 15;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Items.AddRange(new object[] { "AAPL", "MSFT", "TSLA", "NFLX", "GOOGL" });
            listBox1.Location = new Point(1088, 48);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(165, 104);
            listBox1.TabIndex = 16;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1267, 599);
            Controls.Add(domainUpDown1);
            Controls.Add(listBox1);
            Controls.Add(plotView1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ControlText;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            Text = "Брокерский виртуоз";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private DomainUpDown domainUpDown1;
        private GroupBox groupBox2;
        private Label label1;
        private MenuStrip menuStrip1;
        private Button button2;
        private ToolStripMenuItem сменитьАккаунтToolStripMenuItem;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem загрузитьToolStripMenuItem;
        private Label label4;
        private Label label5;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private ListBox listBox1;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label3;
        private Button button3;
        private Button button1;
        private TextBox textBox1;
    }
}

