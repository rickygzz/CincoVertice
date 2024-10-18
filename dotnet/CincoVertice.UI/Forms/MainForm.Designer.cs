namespace CincoVertice
{
    partial class MainForm
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
            checkBox1 = new CheckBox();
            mdiTab = new CincoVertice.UI.Controls.MdiTab.MdiTab();
            menu = new MenuStrip();
            mnuAbout = new ToolStripMenuItem();
            mdiTab.SuspendLayout();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(23, 64);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += MouseMove_Checked;
            // 
            // mdiTab1
            // 
            mdiTab.AllowDrop = true;
            mdiTab.Appearance = TabAppearance.Buttons;
            mdiTab.Dock = DockStyle.Top;
            mdiTab.DrawMode = TabDrawMode.OwnerDrawFixed;
            mdiTab.ItemSize = new Size(0, 30);
            mdiTab.Location = new Point(0, 24);
            mdiTab.MaximumSize = new Size(800, 31);
            mdiTab.Name = "mdiTab1";
            mdiTab.Padding = new Point(18, 3);
            mdiTab.SelectedIndex = 0;
            mdiTab.Size = new Size(800, 31);
            mdiTab.TabIndex = 1;
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { mnuAbout });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(800, 24);
            menu.TabIndex = 2;
            menu.Text = "menuStrip1";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(52, 20);
            mnuAbout.Text = "&About";
            mnuAbout.Click += MnuAbout_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mdiTab);
            Controls.Add(menu);
            IsMdiContainer = true;
            MainMenuStrip = menu;
            Name = "MainForm";
            Text = "5Vertice";
            Load += MainForm_Load;
            mdiTab.ResumeLayout(false);
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private CincoVertice.UI.Controls.MdiTab.MdiTab mdiTab;
        private MenuStrip menu;
        private ToolStripMenuItem mnuAbout;
    }
}
