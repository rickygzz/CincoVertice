using System.ComponentModel;

namespace CincoVertice.UI.Controls
{
    public class MDITab : TabControl
    {
        /// <summary>
        /// An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn.
        /// wParam   The redraw state.If this parameter is TRUE, the content can be redrawn after a change.
        ///          If this parameter is FALSE, the content cannot be redrawn after a change.
        /// </summary>
        private const int WMSETREDRAW = 11;

        private Point dragStartPosition = Point.Empty;

        private Brush brushMain = new SolidBrush(Color.FromArgb(132, 150, 176));

        // private Brush brushTaxCertificates = new SolidBrush(Color.FromArgb(189, 215, 238));
        // private Brush brushOrganization = new SolidBrush(Color.FromArgb(254, 229, 153));
        // private Brush brushScreens = new SolidBrush(Color.FromArgb(197, 224, 179));
        // private Brush brushInvoice = new SolidBrush(Color.FromArgb(112, 173, 71));
        // private Brush brushProduct = new SolidBrush(Color.FromArgb(146, 208, 80));
        // private Brush brushDarkText = new SolidBrush(Color.FromArgb(34, 42, 53));
        private Brush brushLightText = new SolidBrush(Color.FromArgb(255, 255, 255));

        /// <summary>
        /// Initializes a new instance of the <see cref="MDITab"/> class.
        /// </summary>
        public MDITab()
        {
            // Set initial TabControl settings
            this.Appearance = TabAppearance.Buttons;
            this.Dock = DockStyle.Top;
            this.AllowDrop = true;
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.Padding = new Point(18, 3);
            this.ItemSize = new Size(0, 30);
            this.MaximumSize = new Size(99999, 32);
            this.Size = new Size(10, 31);
            this.Visible = true;

            this.MouseDown += new MouseEventHandler(this.CtlTabs_MouseDown);
            this.MouseMove += new MouseEventHandler(this.CtlTabs_MouseMove);
            this.DragOver += new DragEventHandler(this.CtlTabs_DragOver);

            this.SelectedIndexChanged += new EventHandler(this.CtlTabs_SelectedIndexChanged);
            this.DrawItem += new DrawItemEventHandler(this.CtlTabs_DrawItem);
            this.MouseClick += new MouseEventHandler(this.CtlTabs_MouseClick);

            // To add MdiChildActivate event handler, we need the parent handle set at ParentChanged
            this.ParentChanged += new EventHandler(this.CtlTabs_ParentChanged);
        }

        /// <summary>
        /// Gets or sets size property.
        /// </summary>
        [DefaultValue(typeof(Size), "10, 31")]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = new Size(value.Width, 31); }
        }

        /// <summary>
        /// Gets or sets MaximumSize property
        /// </summary>
        [DefaultValue(typeof(Size), "99999, 32")]
        public new Size MaximumSize
        {
            get { return base.Size; }
            set { base.Size = new Size(value.Width, 32); }
        }

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure
        /// for the specified window and does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="hWnd">Window whose window procedure will receive the message.</param>
        /// <param name="wMsg">Message to be sent</param>
        /// <param name="wParam">wParam Additional message-specific information.</param>
        /// <param name="lParam">lParam Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);

        private void CtlTabs_ParentChanged(object sender, EventArgs e)
        {
            // As soon as the parent is set, wire the MdiChildActivate event handler
            ((Form)this.Parent).MdiChildActivate += new EventHandler(this.ParentForm_MdiChildActivate);
        }

        private void CtlTabs_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            if (this.SelectedIndex != -1)
            {
                Rectangle rectTab = this.GetTabRect(this.SelectedIndex);

                if (this.SelectedIndex != 0)
                {
                    // Check if close icon was pressed
                    Rectangle rectClose = new Rectangle(
                        rectTab.X + rectTab.Width - this.Padding.X - 5,
                        rectTab.Y,
                        this.Padding.X + 5,
                        rectTab.Height);

                    if (rectClose.Contains(e.Location))
                    {
                        ((TabPageTag)this.SelectedTab.Tag).OwnerForm.Close();
                    }
                }

                if (rectTab.Contains(e.Location)) // && e.Button == MouseButtons.Right)
                {
                    if (this.SelectedTab != null && ((TabPageTag)this.SelectedTab.Tag).Menu != null)
                    {
                        Rectangle rect = this.GetTabRect(this.TabPages.IndexOf(this.SelectedTab));
                        Point pt = this.PointToScreen(new Point(rect.X, rect.Y + rect.Height));

                        ((TabPageTag)this.SelectedTab.Tag).Menu.Show(pt);
                    }
                }
            }
        }

        private void CtlTabs_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            TabPage tp = this.HoverTab();
            if (tp != null)
            {
                Rectangle rectTab = this.GetTabRect(this.TabPages.IndexOf(tp));

                Rectangle rectClose = new Rectangle(
                    rectTab.X + rectTab.Width - this.Padding.X,
                    rectTab.Y,
                    this.Padding.X,
                    rectTab.Height);

                if (!rectClose.Contains(e.Location))
                {
                    this.dragStartPosition = new Point(e.X, e.Y);
                }
            }
            else
            {
                this.dragStartPosition = Point.Empty;
            }
        }

        private void CtlTabs_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            if (e.Button != MouseButtons.Left || this.dragStartPosition == Point.Empty)
            {
                return;
            }

            // When moving the mouse while holding the left button
            // Get the hovered tab
            TabPage tp = this.HoverTab();

            if (tp != null)
            {
                if (Math.Abs(e.X - this.dragStartPosition.X) > 6 || Math.Abs(e.Y - this.dragStartPosition.Y) > 6)
                {
                    // Start dragging the clicked TabPage
                    this.DoDragDrop(tp, DragDropEffects.All);
                    this.dragStartPosition = Point.Empty;
                }
            }
        }

        private void CtlTabs_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            // Get the tab it is dragging over to
            TabPage hoverTab = this.HoverTab();

            if (hoverTab == null)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                if (e.Data.GetDataPresent(typeof(TabPage)))
                {
                    e.Effect = DragDropEffects.Move;
                    TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));

                    if (hoverTab == dragTab)
                    {
                        return;
                    }

                    Rectangle tabRect = this.GetTabRect(this.TabPages.IndexOf(hoverTab));
                    tabRect.Inflate(-3, -3);
                    if (tabRect.Contains(this.PointToClient(new Point(e.X, e.Y))))
                    {
                        this.SwapTabPages(dragTab, hoverTab);
                        this.SelectedTab = dragTab;
                    }
                }
            }
        }

        /// <summary>
        /// Check if cursor position is within a TabPage area
        /// TabIndex = 0 is omitted
        /// </summary>
        /// <returns>Hovered TabPage</returns>
        private TabPage HoverTab()
        {
            for (int index = 1; index <= this.TabCount - 1; index++)
            {
                if (this.GetTabRect(index).Contains(this.PointToClient(Cursor.Position)))
                {
                    // Cursor position is within this tabpage
                    return this.TabPages[index];
                }
            }

            return null;
        }

        private void SwapTabPages(TabPage tp1, TabPage tp2)
        {
            int index1 = this.TabPages.IndexOf(tp1);
            int index2 = this.TabPages.IndexOf(tp2);

            this.TabPages[index1] = tp2;
            this.TabPages[index2] = tp1;
        }

        /// <summary>
        /// Occurs when a multiple-document interface (MDI) child form is activated or closed within an MDI application.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ParentForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            Form parent = (Form)this.Parent;

            if (parent.ActiveMdiChild == null)
            {
                // There is no MDI Child. Hide the tab control
                this.Visible = false;
            }
            else
            {
                // Always maximize the child forms
                parent.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                // If the child form is new and it has no tab page, create one
                if (parent.ActiveMdiChild.Tag == null)
                {
                    Form tabForm = parent.ActiveMdiChild;

                    TabPage tp = new TabPage(tabForm.Text);

                    // Tab page points to the MDI Child
                    tp.Tag = new TabPageTag() { OwnerForm = tabForm, Menu = tabForm.ContextMenuStrip };
                    tabForm.ContextMenuStrip = null;

                    tp.Parent = this;

                    // MDI Child tag property points to the tabpage, used on FormClosed
                    tabForm.Tag = tp;

                    // To dispose the tab in case the form is closed programmaticaly
                    tabForm.FormClosed += new FormClosedEventHandler(this.ActiveMdiChild_FormClosed);

                    // To update the tab text in case the form text is updated after the tab is created.
                    tabForm.TextChanged += new EventHandler(this.ActiveMdiChild_Text);

                    this.SelectedTab = tp;
                }
                else
                {
                    this.SelectedTab = (TabPage)parent.ActiveMdiChild.Tag;
                }

                // Make tabs visible since it is not empty
                if (!this.Visible)
                {
                    this.Visible = true;
                }
            }
        }

        private void ActiveMdiChild_Text(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            Form form = sender as Form;

            if (form.Tag != null)
            {
                (form.Tag as TabPage).Text = form.Text;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            // Destroy the corresponding tab pages
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void CtlTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            if ((this.SelectedTab != null) && (this.SelectedTab.Tag != null))
            {
                // SETREDRAW = false
                SendMessage(this.Handle, WMSETREDRAW, false, 0);

                ((TabPageTag)this.SelectedTab.Tag).OwnerForm.Select();

                // SETREDRAW = true
                SendMessage(this.Handle, WMSETREDRAW, true, 0);

                // this.Invalidate(true);
                // this.Update();
                // https://blogs.msdn.microsoft.com/subhagpo/2005/02/22/whats-the-difference-between-control-invalidate-control-update-and-control-refresh/
                this.Refresh();
            }
        }

        private void CtlTabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            Brush brushBackground;
            Brush brushText;

            TabPage page = this.TabPages[e.Index];

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -1 : 1;
            yOffset += (paddedBounds.Height / 2) - (int)(e.Font.GetHeight() / 2);
            paddedBounds.Offset(1, yOffset);

            if (e.Index == 0)
            {
                paddedBounds.Offset(14, 0);

                brushBackground = this.brushMain;
                brushText = this.brushLightText;

                e.Graphics.FillRectangle(brushBackground, e.Bounds);
            }
            else
            {
                brushBackground = new SolidBrush(page.BackColor);
                brushText = new SolidBrush(page.ForeColor);

                e.Graphics.FillRectangle(brushBackground, e.Bounds);

                // Adjust tabcontrol.padding width to allocate space for the image
                // TextRenderer.DrawText(e.Graphics, page.Text, this.TabForms.Font, paddedBounds, page.ForeColor);
                //e.Graphics.DrawImage(Properties.Resources.Close16, e.Bounds.Right - 21, 7);
            }

            // if (e.Index == 0)
            // {
            //    brushBackground = this.brushMain;

            //    brushText = this.brushLightText;

            //    paddedBounds.Offset(14, 0);

            //    e.Graphics.FillRectangle(brushBackground, e.Bounds);
            // }
            // else
            // {
            //    Form f = ((TabPageTag)page.Tag).OwnerForm;

            //    if (f.GetType() == typeof(FrmOrganization))
            //    {
            //        brushBackground = this.brushOrganization;
            //    }
            //    else if (f.GetType() == typeof(FrmTaxCertificates))
            //    {
            //        brushBackground = this.brushTaxCertificates;
            //    }
            //    else if (f.GetType() == typeof(FrmScreens))
            //    {
            //        brushBackground = this.brushScreens;
            //    }
            //    else if (f.GetType() == typeof(FrmInvoice))
            //    {
            //        brushText = this.brushLightText;
            //        brushBackground = this.brushInvoice;
            //    }
            //    else if (f.GetType() == typeof(FrmInvoiceCatalog))
            //    {
            //        brushText = this.brushLightText;
            //        brushBackground = this.brushInvoice;
            //    }
            //    else if (f.GetType() == typeof(FrmProduct))
            //    {
            //        brushBackground = this.brushProduct;
            //    }

            //    e.Graphics.FillRectangle(brushBackground, e.Bounds);

            //    // Adjust tabcontrol.padding width to allocate space for the image
            //    // TextRenderer.DrawText(e.Graphics, page.Text, this.TabForms.Font, paddedBounds, page.ForeColor);
            //    e.Graphics.DrawImage(Properties.Resources.Close16, e.Bounds.Right - 21, 7);
            // }

            e.Graphics.DrawString(page.Text, e.Font, brushText, paddedBounds);
        }

        /// <summary>
        /// Used for the TabPage tag, to hold more than one object.
        /// </summary>
        public class TabPageTag
        {
            /// <summary>
            /// Gets or sets form linked to the TabPage.
            /// </summary>
            public Form OwnerForm { get; set; } = null;

            /// <summary>
            /// Gets or sets menu linked to the TabPage.
            /// </summary>
            public ContextMenuStrip Menu { get; set; } = null;
        }

        /// <summary>
        /// OpenMDI. Uses Generics.
        /// </summary>
        /// <typeparam name="T">Form </typeparam>
        /// <param name="multipleInstances">If form is open, then close</param>
        /// <returns>Returns the open or new form</returns>
        public Form OpenMDI<T>(bool multipleInstances)
            where T : Form, new()
        {
            Form parentForm = this.Parent as Form;

            if (multipleInstances == false)
            {
                // Look if the form is open
                foreach (Form f in parentForm.MdiChildren)
                {
                    // same as if (f.GetType() == typeof(T))
                    if (f is T)
                    {
                        // Found an open instance. If minimized, maximize and activate
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Maximized;
                        }

                        f.Activate();
                        return f;
                    }
                }
            }

            T newForm = new T();
            newForm.MdiParent = parentForm;
            newForm.Show();

            return newForm;
        }
    }
}
