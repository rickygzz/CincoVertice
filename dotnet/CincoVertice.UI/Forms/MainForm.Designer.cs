namespace VerticeLib
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
            mdiTab1 = new CincoVertice.UI.Controls.MdiTab.MdiTab();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            mdiTab1.SuspendLayout();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 56);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += MouseMove_Checked;
            // 
            // mdiTab1
            // 
            mdiTab1.AllowDrop = true;
            mdiTab1.Appearance = TabAppearance.Buttons;
            mdiTab1.Controls.Add(tabPage1);
            mdiTab1.Controls.Add(tabPage2);
            mdiTab1.Dock = DockStyle.Top;
            mdiTab1.DrawMode = TabDrawMode.OwnerDrawFixed;
            mdiTab1.ItemSize = new Size(0, 30);
            mdiTab1.Location = new Point(0, 0);
            mdiTab1.MaximumSize = new Size(800, 31);
            mdiTab1.Name = "mdiTab1";
            mdiTab1.Padding = new Point(18, 3);
            mdiTab1.SelectedIndex = 0;
            mdiTab1.Size = new Size(800, 31);
            mdiTab1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 0);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 0);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mdiTab1);
            Controls.Add(checkBox1);
            Name = "MainForm";
            Text = "5Vertice";
            Load += MainForm_Load;
            mdiTab1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private CincoVertice.UI.Controls.MdiTab.MdiTab mdiTab1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
