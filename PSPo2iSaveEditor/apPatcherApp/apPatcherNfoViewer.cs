namespace apPatcherApp
{
    using apPatcherApp.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public class apPatcherNfoViewer : Form
    {
        private IContainer components;
        private RichTextBox txtNfoArea;
        private Panel panel1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openNFOToolStripMenuItem;
        public MenuStrip menuStrip1;
        public ToolStripMenuItem themeToolStripMenuItem;
        public ToolStripMenuItem themeToolStripMenuItem1;
        public ToolStripMenuItem themeToolStripMenuItem2;
        public ToolStripMenuItem themeToolStripMenuItem3;
        public ToolStripMenuItem themeToolStripMenuItem4;
        public ToolStripMenuItem themeToolStripMenuItem5;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem fontSizeToolStripMenuItem;
        private ToolStripMenuItem pxToolStripMenuItem7;
        private ToolStripMenuItem pxToolStripMenuItem8;
        private ToolStripMenuItem pxToolStripMenuItem9;
        private ToolStripMenuItem pxToolStripMenuItem10;
        private ToolStripMenuItem exitToolStripMenuItem;
        public string hash = "";
        public string fn = "";
        private int formheight;

        public apPatcherNfoViewer()
        {
            this.InitializeComponent();
        }

        private void apPatcherNfoViewer_Resize(object sender, EventArgs e)
        {
            this.txtNfoArea.Height += base.Height - this.formheight;
            this.panel1.Height += base.Height - this.formheight;
            this.formheight = base.Height;
        }

        private void apPatcherNfoViewer_ResizeBegin(object sender, EventArgs e)
        {
            this.formheight = base.Height;
        }

        private void apPatcherNfoViewer_ResizeEnd(object sender, EventArgs e)
        {
            this.txtNfoArea.Height += base.Height - this.formheight;
            this.panel1.Height += base.Height - this.formheight;
            this.formheight = base.Height;
        }

        private void apPatcherNfoViewer_Shown(object sender, EventArgs e)
        {
            if (Settings.Default.NFOTheme != "")
            {
                this.themeToolStripMenuItem1.Checked = false;
                this.themeToolStripMenuItem2.Checked = false;
                this.themeToolStripMenuItem3.Checked = false;
                this.themeToolStripMenuItem4.Checked = false;
                this.themeToolStripMenuItem5.Checked = false;
                string nFOTheme = Settings.Default.NFOTheme;
                if (nFOTheme != null)
                {
                    if (nFOTheme == "Theme #1")
                    {
                        this.themeToolStripMenuItem1.Checked = true;
                    }
                    else if (nFOTheme == "Theme #2")
                    {
                        this.themeToolStripMenuItem2.Checked = true;
                    }
                    else if (nFOTheme == "Theme #3")
                    {
                        this.themeToolStripMenuItem3.Checked = true;
                    }
                    else if (nFOTheme == "Theme #4")
                    {
                        this.themeToolStripMenuItem4.Checked = true;
                    }
                    else if (nFOTheme == "Theme #5")
                    {
                        this.themeToolStripMenuItem5.Checked = true;
                    }
                }
            }
            if (Settings.Default.NFOSize != "")
            {
                this.pxToolStripMenuItem7.Checked = false;
                this.pxToolStripMenuItem8.Checked = false;
                this.pxToolStripMenuItem9.Checked = false;
                this.pxToolStripMenuItem10.Checked = false;
                string nFOSize = Settings.Default.NFOSize;
                if (nFOSize != null)
                {
                    if (nFOSize == "7px")
                    {
                        this.pxToolStripMenuItem7.Checked = true;
                    }
                    else if (nFOSize == "8px")
                    {
                        this.pxToolStripMenuItem8.Checked = true;
                    }
                    else if (nFOSize == "9px")
                    {
                        this.pxToolStripMenuItem8.Checked = true;
                    }
                    else if (nFOSize == "10px")
                    {
                        this.pxToolStripMenuItem10.Checked = true;
                    }
                }
            }
            if (this.hash != "")
            {
                this.fn = "data/web/nfo/" + this.hash + ".nfo";
                this.loadNfo(this.fn);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Dispose();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(apPatcherNfoViewer));
            this.txtNfoArea = new RichTextBox();
            this.panel1 = new Panel();
            this.menuStrip1 = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.openNFOToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.themeToolStripMenuItem = new ToolStripMenuItem();
            this.themeToolStripMenuItem1 = new ToolStripMenuItem();
            this.themeToolStripMenuItem2 = new ToolStripMenuItem();
            this.themeToolStripMenuItem3 = new ToolStripMenuItem();
            this.themeToolStripMenuItem4 = new ToolStripMenuItem();
            this.themeToolStripMenuItem5 = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.fontSizeToolStripMenuItem = new ToolStripMenuItem();
            this.pxToolStripMenuItem7 = new ToolStripMenuItem();
            this.pxToolStripMenuItem8 = new ToolStripMenuItem();
            this.pxToolStripMenuItem9 = new ToolStripMenuItem();
            this.pxToolStripMenuItem10 = new ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.txtNfoArea.BackColor = Color.Black;
            this.txtNfoArea.BorderStyle = BorderStyle.None;
            this.txtNfoArea.DetectUrls = false;
            this.txtNfoArea.Dock = DockStyle.Top;
            this.txtNfoArea.Font = new Font("Lucida Console", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtNfoArea.ForeColor = Color.White;
            this.txtNfoArea.Location = new Point(10, 0);
            this.txtNfoArea.Name = "txtNfoArea";
            this.txtNfoArea.ReadOnly = true;
            this.txtNfoArea.Size = new Size(0x281, 0x19c);
            this.txtNfoArea.TabIndex = 0;
            this.txtNfoArea.TabStop = false;
            this.txtNfoArea.Text = "";
            this.txtNfoArea.WordWrap = false;
            this.panel1.BackColor = Color.Black;
            this.panel1.Controls.Add(this.txtNfoArea);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0x18);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(10, 0, 0, 0);
            this.panel1.Size = new Size(0x28b, 0x19c);
            this.panel1.TabIndex = 1;
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.fileToolStripMenuItem, this.themeToolStripMenuItem };
            this.menuStrip1.Items.AddRange(toolStripItems);
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x28b, 0x18);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            ToolStripItem[] itemArray2 = new ToolStripItem[] { this.openNFOToolStripMenuItem, this.exitToolStripMenuItem };
            this.fileToolStripMenuItem.DropDownItems.AddRange(itemArray2);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(0x25, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.openNFOToolStripMenuItem.Image = Resources.open1;
            this.openNFOToolStripMenuItem.Name = "openNFOToolStripMenuItem";
            this.openNFOToolStripMenuItem.Size = new Size(0x8a, 0x16);
            this.openNFOToolStripMenuItem.Text = "Open NFO...";
            this.openNFOToolStripMenuItem.Click += new EventHandler(this.openNFOToolStripMenuItem_Click);
            this.exitToolStripMenuItem.Image = Resources.exit1;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(0x8a, 0x16);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            ToolStripItem[] itemArray3 = new ToolStripItem[] { this.themeToolStripMenuItem1, this.themeToolStripMenuItem2, this.themeToolStripMenuItem3, this.themeToolStripMenuItem4, this.themeToolStripMenuItem5, this.toolStripSeparator1, this.fontSizeToolStripMenuItem };
            this.themeToolStripMenuItem.DropDownItems.AddRange(itemArray3);
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new Size(0x34, 20);
            this.themeToolStripMenuItem.Text = "Theme";
            this.themeToolStripMenuItem1.BackColor = Color.Black;
            this.themeToolStripMenuItem1.Checked = true;
            this.themeToolStripMenuItem1.CheckOnClick = true;
            this.themeToolStripMenuItem1.CheckState = CheckState.Checked;
            this.themeToolStripMenuItem1.ForeColor = Color.White;
            this.themeToolStripMenuItem1.Name = "themeToolStripMenuItem1";
            this.themeToolStripMenuItem1.Size = new Size(0x7b, 0x16);
            this.themeToolStripMenuItem1.Text = "Theme #1";
            this.themeToolStripMenuItem1.CheckedChanged += new EventHandler(this.themeToolStripMenuItem_CheckedChanged);
            this.themeToolStripMenuItem2.BackColor = Color.Black;
            this.themeToolStripMenuItem2.CheckOnClick = true;
            this.themeToolStripMenuItem2.ForeColor = Color.Lime;
            this.themeToolStripMenuItem2.Name = "themeToolStripMenuItem2";
            this.themeToolStripMenuItem2.Size = new Size(0x7b, 0x16);
            this.themeToolStripMenuItem2.Text = "Theme #2";
            this.themeToolStripMenuItem2.CheckedChanged += new EventHandler(this.themeToolStripMenuItem_CheckedChanged);
            this.themeToolStripMenuItem3.BackColor = Color.Black;
            this.themeToolStripMenuItem3.CheckOnClick = true;
            this.themeToolStripMenuItem3.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            this.themeToolStripMenuItem3.Name = "themeToolStripMenuItem3";
            this.themeToolStripMenuItem3.Size = new Size(0x7b, 0x16);
            this.themeToolStripMenuItem3.Text = "Theme #3";
            this.themeToolStripMenuItem3.CheckedChanged += new EventHandler(this.themeToolStripMenuItem_CheckedChanged);
            this.themeToolStripMenuItem4.BackColor = Color.Black;
            this.themeToolStripMenuItem4.CheckOnClick = true;
            this.themeToolStripMenuItem4.ForeColor = Color.Red;
            this.themeToolStripMenuItem4.Name = "themeToolStripMenuItem4";
            this.themeToolStripMenuItem4.Size = new Size(0x7b, 0x16);
            this.themeToolStripMenuItem4.Text = "Theme #4";
            this.themeToolStripMenuItem4.CheckedChanged += new EventHandler(this.themeToolStripMenuItem_CheckedChanged);
            this.themeToolStripMenuItem5.BackColor = Color.White;
            this.themeToolStripMenuItem5.CheckOnClick = true;
            this.themeToolStripMenuItem5.Name = "themeToolStripMenuItem5";
            this.themeToolStripMenuItem5.Size = new Size(0x7b, 0x16);
            this.themeToolStripMenuItem5.Text = "Theme #5";
            this.themeToolStripMenuItem5.CheckedChanged += new EventHandler(this.themeToolStripMenuItem_CheckedChanged);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(120, 6);
            ToolStripItem[] itemArray4 = new ToolStripItem[] { this.pxToolStripMenuItem7, this.pxToolStripMenuItem8, this.pxToolStripMenuItem9, this.pxToolStripMenuItem10 };
            this.fontSizeToolStripMenuItem.DropDownItems.AddRange(itemArray4);
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new Size(0x7b, 0x16);
            this.fontSizeToolStripMenuItem.Text = "Font Size";
            this.pxToolStripMenuItem7.CheckOnClick = true;
            this.pxToolStripMenuItem7.Name = "pxToolStripMenuItem7";
            this.pxToolStripMenuItem7.Size = new Size(0x62, 0x16);
            this.pxToolStripMenuItem7.Text = "7px";
            this.pxToolStripMenuItem7.CheckedChanged += new EventHandler(this.pxToolStripMenuItem_CheckedChanged);
            this.pxToolStripMenuItem8.CheckOnClick = true;
            this.pxToolStripMenuItem8.Name = "pxToolStripMenuItem8";
            this.pxToolStripMenuItem8.Size = new Size(0x62, 0x16);
            this.pxToolStripMenuItem8.Text = "8px";
            this.pxToolStripMenuItem8.CheckedChanged += new EventHandler(this.pxToolStripMenuItem_CheckedChanged);
            this.pxToolStripMenuItem9.Checked = true;
            this.pxToolStripMenuItem9.CheckOnClick = true;
            this.pxToolStripMenuItem9.CheckState = CheckState.Checked;
            this.pxToolStripMenuItem9.Name = "pxToolStripMenuItem9";
            this.pxToolStripMenuItem9.Size = new Size(0x62, 0x16);
            this.pxToolStripMenuItem9.Text = "9px";
            this.pxToolStripMenuItem9.CheckedChanged += new EventHandler(this.pxToolStripMenuItem_CheckedChanged);
            this.pxToolStripMenuItem10.CheckOnClick = true;
            this.pxToolStripMenuItem10.Name = "pxToolStripMenuItem10";
            this.pxToolStripMenuItem10.Size = new Size(0x62, 0x16);
            this.pxToolStripMenuItem10.Text = "10px";
            this.pxToolStripMenuItem10.CheckedChanged += new EventHandler(this.pxToolStripMenuItem_CheckedChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x28b, 0x1b4);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.menuStrip1);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "apPatcherNfoViewer";
            this.Text = "DS-Scene Rom Tool: NFO Viewer";
            base.Shown += new EventHandler(this.apPatcherNfoViewer_Shown);
            base.ResizeBegin += new EventHandler(this.apPatcherNfoViewer_ResizeBegin);
            base.ResizeEnd += new EventHandler(this.apPatcherNfoViewer_ResizeEnd);
            base.Resize += new EventHandler(this.apPatcherNfoViewer_Resize);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void loadNfo(string fn)
        {
            File file = new File(fn, Resources.ConversionString);
            file.Load();
            string str = "\r\n";
            foreach (string str2 in file.Lines)
            {
                str = str + str2 + "\r\n";
            }
            this.txtNfoArea.Text = str;
        }

        private void openNFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Title = "DS-Scene Rom Tool: Open NFO File",
                Filter = "NFO File|*.nfo",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.fn = dialog.FileName;
                this.loadNfo(this.fn);
            }
        }

        private void pxToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem objB = (ToolStripMenuItem) sender;
            if (objB.Checked)
            {
                if (!ReferenceEquals(this.pxToolStripMenuItem7, objB))
                {
                    this.pxToolStripMenuItem7.Checked = false;
                }
                if (!ReferenceEquals(this.pxToolStripMenuItem8, objB))
                {
                    this.pxToolStripMenuItem8.Checked = false;
                }
                if (!ReferenceEquals(this.pxToolStripMenuItem9, objB))
                {
                    this.pxToolStripMenuItem9.Checked = false;
                }
                if (!ReferenceEquals(this.pxToolStripMenuItem10, objB))
                {
                    this.pxToolStripMenuItem10.Checked = false;
                }
                objB.Checked = true;
                string str = objB.ToString();
                if (str != null)
                {
                    if (str == "7px")
                    {
                        this.txtNfoArea.Font = new Font("Lucida Console", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    }
                    else if (str == "8px")
                    {
                        this.txtNfoArea.Font = new Font("Lucida Console", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    }
                    else if (str == "9px")
                    {
                        this.txtNfoArea.Font = new Font("Lucida Console", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    }
                    else if (str == "10px")
                    {
                        this.txtNfoArea.Font = new Font("Lucida Console", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    }
                }
                Settings.Default.NFOSize = objB.ToString();
            }
        }

        private void themeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem objB = (ToolStripMenuItem) sender;
            if (objB.Checked)
            {
                if (!ReferenceEquals(this.themeToolStripMenuItem1, objB))
                {
                    this.themeToolStripMenuItem1.Checked = false;
                }
                if (!ReferenceEquals(this.themeToolStripMenuItem2, objB))
                {
                    this.themeToolStripMenuItem2.Checked = false;
                }
                if (!ReferenceEquals(this.themeToolStripMenuItem3, objB))
                {
                    this.themeToolStripMenuItem3.Checked = false;
                }
                if (!ReferenceEquals(this.themeToolStripMenuItem4, objB))
                {
                    this.themeToolStripMenuItem4.Checked = false;
                }
                if (!ReferenceEquals(this.themeToolStripMenuItem5, objB))
                {
                    this.themeToolStripMenuItem5.Checked = false;
                }
                this.txtNfoArea.BackColor = objB.BackColor;
                this.txtNfoArea.ForeColor = objB.ForeColor;
                this.panel1.BackColor = objB.BackColor;
                objB.Checked = true;
                Settings.Default.NFOTheme = objB.ToString();
            }
        }

        internal class File
        {
            private const byte LINE_FEED = 10;
            private const byte CARRIAGE_RETURN = 13;
            private const byte TAB = 9;
            private string _fileName;
            private string _conversion;
            private List<string> _lines = new List<string>();
            private int _size;

            public File(string fileName, string conversion)
            {
                this._fileName = fileName;
                this._conversion = conversion;
            }

            public bool Load()
            {
                bool flag = false;
                this._size = 0;
                this._lines.Clear();
                StringBuilder builder = new StringBuilder();
                using (FileStream stream = new FileStream(this.FullPath, FileMode.Open, FileAccess.Read))
                {
                    this._size = (int) stream.Length;
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        bool flag2 = false;
                        bool flag3 = false;
                        bool flag4 = false;
                        byte[] buffer = reader.ReadBytes(this.Size);
                        int index = 0;
                        while (true)
                        {
                            if (index >= buffer.Length)
                            {
                                this._lines.Add(builder.ToString());
                                flag = true;
                                break;
                            }
                            byte num2 = buffer[index];
                            if (num2 == 13)
                            {
                                if (flag4)
                                {
                                    flag4 = false;
                                }
                                else if (flag3)
                                {
                                    this._lines.Add(Environment.NewLine);
                                    this._lines.Add(Environment.NewLine);
                                    flag2 = true;
                                    flag3 = false;
                                }
                                else if (flag2)
                                {
                                    flag3 = true;
                                }
                                else
                                {
                                    flag2 = true;
                                    this._lines.Add(builder.ToString());
                                    builder.Length = 0;
                                }
                            }
                            else if (num2 == 10)
                            {
                                if (flag3)
                                {
                                    flag3 = false;
                                }
                                else if (!flag2)
                                {
                                    this._lines.Add(builder.ToString());
                                    builder.Length = 0;
                                }
                                flag2 = false;
                                flag4 = true;
                            }
                            else if (num2 == 9)
                            {
                                builder.Append("    ");
                                flag2 = false;
                                flag3 = false;
                                flag4 = false;
                            }
                            else if (num2 == 0xff)
                            {
                                builder.Append(" ");
                                flag2 = false;
                                flag3 = false;
                                flag4 = false;
                            }
                            else if (num2 < 0x20)
                            {
                                builder.Append(Resources.NonPrintingChar);
                                flag2 = false;
                                flag3 = false;
                                flag4 = false;
                            }
                            else if ((num2 - 0x21) < 0)
                            {
                                builder.Append(" ");
                            }
                            else
                            {
                                builder.Append(this._conversion[num2 - 0x21]);
                                flag2 = false;
                                flag3 = false;
                                flag4 = false;
                            }
                            index++;
                        }
                    }
                }
                return flag;
            }

            public DateTime LastModified =>
                System.IO.File.GetLastWriteTime(this.FullPath);

            public string FullPath =>
                Path.GetFullPath(this._fileName);

            public string FileName =>
                Path.GetFileName(this._fileName);

            public string[] Lines =>
                this._lines.ToArray();

            public int Size =>
                this._size;
        }
    }
}

