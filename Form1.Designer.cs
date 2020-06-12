namespace Otomax_Addon
{
    partial class MainFrom
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRequestCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMyCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statuslabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.RichTextBox();
            this.MyWorker = new System.ComponentModel.BackgroundWorker();
            this.inboxTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Peru;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRequestCodeToolStripMenuItem,
            this.viewMyCodesToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // addRequestCodeToolStripMenuItem
            // 
            this.addRequestCodeToolStripMenuItem.Name = "addRequestCodeToolStripMenuItem";
            this.addRequestCodeToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.addRequestCodeToolStripMenuItem.Text = "Add Request Code";
            this.addRequestCodeToolStripMenuItem.Click += new System.EventHandler(this.addRequestCodeToolStripMenuItem_Click);
            // 
            // viewMyCodesToolStripMenuItem
            // 
            this.viewMyCodesToolStripMenuItem.Name = "viewMyCodesToolStripMenuItem";
            this.viewMyCodesToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.viewMyCodesToolStripMenuItem.Text = "View My Codes";
            this.viewMyCodesToolStripMenuItem.Click += new System.EventHandler(this.viewMyCodesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statuslabel
            // 
            this.statuslabel.AutoSize = true;
            this.statuslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslabel.Location = new System.Drawing.Point(342, 168);
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(53, 20);
            this.statuslabel.TabIndex = 2;
            this.statuslabel.Text = "status";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(337, 208);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(95, 24);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(12, 44);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(310, 317);
            this.statusBox.TabIndex = 4;
            this.statusBox.Text = "";
            // 
            // MyWorker
            // 
            this.MyWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MyWorker_DoWork);
            // 
            // inboxTimer
            // 
            this.inboxTimer.Interval = 2000;
            this.inboxTimer.Tick += new System.EventHandler(this.inboxTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(346, 337);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(75, 23);
            this.restartButton.TabIndex = 6;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(444, 377);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.statuslabel);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrom";
            this.Text = "Otomax Addons";
            this.Load += new System.EventHandler(this.MainFrom_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRequestCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMyCodesToolStripMenuItem;
        private System.Windows.Forms.Label statuslabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox statusBox;
        private System.ComponentModel.BackgroundWorker MyWorker;
        private System.Windows.Forms.Timer inboxTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button restartButton;
    }
}

