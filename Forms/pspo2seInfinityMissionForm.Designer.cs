using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class pspo2seInfinityMissionForm : Form
    {
        private IContainer components;
        private TextBox txtHex;
        private GroupBox groupBox1;
        private ComboBox comboArea;
        private ComboBox comboLength;
        private GroupBox groupBox2;
        private ComboBox comboEnemyLevelMod;
        private ComboBox comboEnemyLevel;
        private GroupBox groupBox3;
        private ComboBox comboEnemy1Mod;
        private ComboBox comboEnemy1;
        private GroupBox groupBox4;
        private ComboBox comboEnemy2;
        private GroupBox groupBox5;
        private ComboBox comboBoss;
        private Button btnCancel;
        private Button btnApply;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private TextBox txtCreator;
        private GroupBox groupBox8;
        private Label label1;
        private ComboBox comboMapMod1;
        private ComboBox comboEnemyTable2;
        private ComboBox comboEnemyTable1;
        private GroupBox groupBox9;
        private Label label7;
        private NumericUpDown numClearedInf;
        private Label label5;
        private NumericUpDown numClearedS;
        private Label label6;
        private NumericUpDown numClearedA;
        private Label label4;
        private NumericUpDown numClearedB;
        private Label label3;
        private NumericUpDown numClearedC;
        private Label label2;
        private NumericUpDown numSynthPoint;
        private ComboBox comboMapMod3;
        private ComboBox comboMapMod2;
        private PictureBox picMap1;
        private GroupBox grpArea1;
        private PictureBox picArea1;
        private GroupBox grpArea2;
        private PictureBox picArea2;
        private PictureBox picMap2;
        private GroupBox grpArea3;
        private PictureBox picArea3;
        private PictureBox picMap3;
        private PictureBox picBoss;
        private ImageList imgListMaps;
        private ImageList imgListAreaThemes;
        private ImageList imgListBoss;
        private Button btnModHex;
        private Button btnEditSpecialHex;
        private TextBox txtSpecialHex;
        private GroupBox groupBox10;
        private CheckBox chkEnemyTable1Mod;
        private ComboBox comboEnemyTable2Mod;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pspo2seInfinityMissionForm));
            this.txtHex = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboLength = new System.Windows.Forms.ComboBox();
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.comboMapMod3 = new System.Windows.Forms.ComboBox();
            this.comboMapMod2 = new System.Windows.Forms.ComboBox();
            this.comboMapMod1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboEnemyLevelMod = new System.Windows.Forms.ComboBox();
            this.comboEnemyLevel = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboEnemy1Mod = new System.Windows.Forms.ComboBox();
            this.comboEnemy1 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboEnemy2 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.picBoss = new System.Windows.Forms.PictureBox();
            this.comboBoss = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnModHex = new System.Windows.Forms.Button();
            this.btnEditSpecialHex = new System.Windows.Forms.Button();
            this.txtSpecialHex = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtCreator = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboEnemyTable2Mod = new System.Windows.Forms.ComboBox();
            this.chkEnemyTable1Mod = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboEnemyTable2 = new System.Windows.Forms.ComboBox();
            this.comboEnemyTable1 = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numClearedInf = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numClearedS = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numClearedA = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numClearedB = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numClearedC = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numSynthPoint = new System.Windows.Forms.NumericUpDown();
            this.picMap1 = new System.Windows.Forms.PictureBox();
            this.grpArea1 = new System.Windows.Forms.GroupBox();
            this.picArea1 = new System.Windows.Forms.PictureBox();
            this.grpArea2 = new System.Windows.Forms.GroupBox();
            this.picArea2 = new System.Windows.Forms.PictureBox();
            this.picMap2 = new System.Windows.Forms.PictureBox();
            this.grpArea3 = new System.Windows.Forms.GroupBox();
            this.picArea3 = new System.Windows.Forms.PictureBox();
            this.picMap3 = new System.Windows.Forms.PictureBox();
            this.imgListMaps = new System.Windows.Forms.ImageList(this.components);
            this.imgListAreaThemes = new System.Windows.Forms.ImageList(this.components);
            this.imgListBoss = new System.Windows.Forms.ImageList(this.components);
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoss)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedInf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSynthPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap1)).BeginInit();
            this.grpArea1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArea1)).BeginInit();
            this.grpArea2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArea2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap2)).BeginInit();
            this.grpArea3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArea3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap3)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHex
            // 
            this.txtHex.BackColor = System.Drawing.SystemColors.Window;
            this.txtHex.Enabled = false;
            this.txtHex.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHex.Location = new System.Drawing.Point(15, 19);
            this.txtHex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHex.Multiline = true;
            this.txtHex.Name = "txtHex";
            this.txtHex.ReadOnly = true;
            this.txtHex.Size = new System.Drawing.Size(237, 98);
            this.txtHex.TabIndex = 0;
            this.txtHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboLength);
            this.groupBox1.Controls.Add(this.comboArea);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(271, 84);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // comboLength
            // 
            this.comboLength.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboLength.FormattingEnabled = true;
            this.comboLength.Items.AddRange(new object[] {
            "1 Area (Hack)",
            "2 Areas",
            "3 Areas"});
            this.comboLength.Location = new System.Drawing.Point(14, 46);
            this.comboLength.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboLength.Name = "comboLength";
            this.comboLength.Size = new System.Drawing.Size(237, 21);
            this.comboLength.TabIndex = 1;
            this.comboLength.SelectedIndexChanged += new System.EventHandler(this.comboBoss_SelectedIndexChanged);
            // 
            // comboArea
            // 
            this.comboArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(14, 20);
            this.comboArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(237, 21);
            this.comboArea.TabIndex = 0;
            this.comboArea.SelectedIndexChanged += new System.EventHandler(this.comboArea_SelectedIndexChanged);
            // 
            // comboMapMod3
            // 
            this.comboMapMod3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboMapMod3.FormattingEnabled = true;
            this.comboMapMod3.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboMapMod3.Location = new System.Drawing.Point(14, 121);
            this.comboMapMod3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboMapMod3.Name = "comboMapMod3";
            this.comboMapMod3.Size = new System.Drawing.Size(237, 21);
            this.comboMapMod3.TabIndex = 10;
            this.comboMapMod3.SelectedIndexChanged += new System.EventHandler(this.comboMapMod3_SelectedIndexChanged);
            // 
            // comboMapMod2
            // 
            this.comboMapMod2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboMapMod2.FormattingEnabled = true;
            this.comboMapMod2.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboMapMod2.Location = new System.Drawing.Point(14, 121);
            this.comboMapMod2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboMapMod2.Name = "comboMapMod2";
            this.comboMapMod2.Size = new System.Drawing.Size(237, 21);
            this.comboMapMod2.TabIndex = 9;
            this.comboMapMod2.SelectedIndexChanged += new System.EventHandler(this.comboMapMod2_SelectedIndexChanged);
            // 
            // comboMapMod1
            // 
            this.comboMapMod1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboMapMod1.FormattingEnabled = true;
            this.comboMapMod1.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboMapMod1.Location = new System.Drawing.Point(14, 121);
            this.comboMapMod1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboMapMod1.Name = "comboMapMod1";
            this.comboMapMod1.Size = new System.Drawing.Size(237, 21);
            this.comboMapMod1.TabIndex = 6;
            this.comboMapMod1.SelectedIndexChanged += new System.EventHandler(this.comboMapMod1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboEnemyLevelMod);
            this.groupBox2.Controls.Add(this.comboEnemyLevel);
            this.groupBox2.Location = new System.Drawing.Point(300, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(271, 84);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enemy Level";
            // 
            // comboEnemyLevelMod
            // 
            this.comboEnemyLevelMod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboEnemyLevelMod.FormattingEnabled = true;
            this.comboEnemyLevelMod.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboEnemyLevelMod.Location = new System.Drawing.Point(14, 46);
            this.comboEnemyLevelMod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboEnemyLevelMod.Name = "comboEnemyLevelMod";
            this.comboEnemyLevelMod.Size = new System.Drawing.Size(237, 21);
            this.comboEnemyLevelMod.TabIndex = 3;
            this.comboEnemyLevelMod.SelectedIndexChanged += new System.EventHandler(this.comboEnemyLevel_SelectedIndexChanged);
            // 
            // comboEnemyLevel
            // 
            this.comboEnemyLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboEnemyLevel.FormattingEnabled = true;
            this.comboEnemyLevel.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboEnemyLevel.Location = new System.Drawing.Point(14, 20);
            this.comboEnemyLevel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboEnemyLevel.Name = "comboEnemyLevel";
            this.comboEnemyLevel.Size = new System.Drawing.Size(237, 21);
            this.comboEnemyLevel.TabIndex = 2;
            this.comboEnemyLevel.SelectedIndexChanged += new System.EventHandler(this.comboEnemyLevel_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboEnemy1Mod);
            this.groupBox3.Controls.Add(this.comboEnemy1);
            this.groupBox3.Location = new System.Drawing.Point(300, 262);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(271, 82);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Primary Enemy";
            // 
            // comboEnemy1Mod
            // 
            this.comboEnemy1Mod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboEnemy1Mod.FormattingEnabled = true;
            this.comboEnemy1Mod.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboEnemy1Mod.Location = new System.Drawing.Point(14, 48);
            this.comboEnemy1Mod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboEnemy1Mod.Name = "comboEnemy1Mod";
            this.comboEnemy1Mod.Size = new System.Drawing.Size(237, 21);
            this.comboEnemy1Mod.TabIndex = 3;
            this.comboEnemy1Mod.SelectedIndexChanged += new System.EventHandler(this.comboEnemy1_SelectedIndexChanged);
            // 
            // comboEnemy1
            // 
            this.comboEnemy1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboEnemy1.FormattingEnabled = true;
            this.comboEnemy1.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboEnemy1.Location = new System.Drawing.Point(14, 21);
            this.comboEnemy1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboEnemy1.Name = "comboEnemy1";
            this.comboEnemy1.Size = new System.Drawing.Size(237, 21);
            this.comboEnemy1.TabIndex = 2;
            this.comboEnemy1.SelectedIndexChanged += new System.EventHandler(this.comboEnemy1_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboEnemy2);
            this.groupBox4.Location = new System.Drawing.Point(300, 349);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(271, 56);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Secondary Enemy";
            // 
            // comboEnemy2
            // 
            this.comboEnemy2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboEnemy2.FormattingEnabled = true;
            this.comboEnemy2.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboEnemy2.Location = new System.Drawing.Point(14, 21);
            this.comboEnemy2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboEnemy2.Name = "comboEnemy2";
            this.comboEnemy2.Size = new System.Drawing.Size(237, 21);
            this.comboEnemy2.TabIndex = 2;
            this.comboEnemy2.SelectedIndexChanged += new System.EventHandler(this.comboEnemy2_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.picBoss);
            this.groupBox5.Controls.Add(this.comboBoss);
            this.groupBox5.Location = new System.Drawing.Point(300, 102);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(271, 152);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Boss";
            // 
            // picBoss
            // 
            this.picBoss.Location = new System.Drawing.Point(14, 19);
            this.picBoss.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBoss.Name = "picBoss";
            this.picBoss.Size = new System.Drawing.Size(129, 96);
            this.picBoss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoss.TabIndex = 15;
            this.picBoss.TabStop = false;
            // 
            // comboBoss
            // 
            this.comboBoss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoss.FormattingEnabled = true;
            this.comboBoss.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboBoss.Location = new System.Drawing.Point(14, 121);
            this.comboBoss.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoss.Name = "comboBoss";
            this.comboBoss.Size = new System.Drawing.Size(237, 21);
            this.comboBoss.TabIndex = 2;
            this.comboBoss.SelectedIndexChanged += new System.EventHandler(this.comboBoss_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(777, 553);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Location = new System.Drawing.Point(684, 553);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 27);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnModHex);
            this.groupBox6.Controls.Add(this.btnEditSpecialHex);
            this.groupBox6.Controls.Add(this.txtSpecialHex);
            this.groupBox6.Location = new System.Drawing.Point(587, 274);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Size = new System.Drawing.Size(271, 103);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Special Hex Data";
            // 
            // btnModHex
            // 
            this.btnModHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModHex.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModHex.Location = new System.Drawing.Point(103, 67);
            this.btnModHex.Name = "btnModHex";
            this.btnModHex.Size = new System.Drawing.Size(75, 23);
            this.btnModHex.TabIndex = 2;
            this.btnModHex.Text = "use mod";
            this.btnModHex.UseVisualStyleBackColor = true;
            this.btnModHex.Click += new System.EventHandler(this.btnModHex_Click);
            // 
            // btnEditSpecialHex
            // 
            this.btnEditSpecialHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditSpecialHex.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSpecialHex.Location = new System.Drawing.Point(178, 67);
            this.btnEditSpecialHex.Name = "btnEditSpecialHex";
            this.btnEditSpecialHex.Size = new System.Drawing.Size(75, 23);
            this.btnEditSpecialHex.TabIndex = 1;
            this.btnEditSpecialHex.Text = "edit hex";
            this.btnEditSpecialHex.UseVisualStyleBackColor = true;
            this.btnEditSpecialHex.Click += new System.EventHandler(this.btnEditSpecialHex_Click);
            // 
            // txtSpecialHex
            // 
            this.txtSpecialHex.BackColor = System.Drawing.SystemColors.Window;
            this.txtSpecialHex.Enabled = false;
            this.txtSpecialHex.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecialHex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSpecialHex.Location = new System.Drawing.Point(15, 23);
            this.txtSpecialHex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSpecialHex.Multiline = true;
            this.txtSpecialHex.Name = "txtSpecialHex";
            this.txtSpecialHex.ReadOnly = true;
            this.txtSpecialHex.Size = new System.Drawing.Size(237, 38);
            this.txtSpecialHex.TabIndex = 0;
            this.txtSpecialHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtCreator);
            this.groupBox7.Location = new System.Drawing.Point(587, 213);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Size = new System.Drawing.Size(271, 56);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Mission Created By";
            // 
            // txtCreator
            // 
            this.txtCreator.Location = new System.Drawing.Point(14, 19);
            this.txtCreator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCreator.MaxLength = 32;
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(237, 21);
            this.txtCreator.TabIndex = 0;
            this.txtCreator.TextChanged += new System.EventHandler(this.txtCreator_TextChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboEnemyTable2Mod);
            this.groupBox8.Controls.Add(this.chkEnemyTable1Mod);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.comboEnemyTable2);
            this.groupBox8.Controls.Add(this.comboEnemyTable1);
            this.groupBox8.Location = new System.Drawing.Point(300, 410);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Size = new System.Drawing.Size(271, 164);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Enemy Table Modifiers";
            // 
            // comboEnemyTable2Mod
            // 
            this.comboEnemyTable2Mod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboEnemyTable2Mod.FormattingEnabled = true;
            this.comboEnemyTable2Mod.Items.AddRange(new object[] {
            "Mod 00",
            "Mod 01",
            "Mod 02"});
            this.comboEnemyTable2Mod.Location = new System.Drawing.Point(160, 57);
            this.comboEnemyTable2Mod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboEnemyTable2Mod.Name = "comboEnemyTable2Mod";
            this.comboEnemyTable2Mod.Size = new System.Drawing.Size(105, 21);
            this.comboEnemyTable2Mod.TabIndex = 9;
            this.comboEnemyTable2Mod.SelectedIndexChanged += new System.EventHandler(this.comboEnemyTable2_SelectedIndexChanged);
            // 
            // chkEnemyTable1Mod
            // 
            this.chkEnemyTable1Mod.AutoSize = true;
            this.chkEnemyTable1Mod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEnemyTable1Mod.Location = new System.Drawing.Point(161, 33);
            this.chkEnemyTable1Mod.Name = "chkEnemyTable1Mod";
            this.chkEnemyTable1Mod.Size = new System.Drawing.Size(101, 17);
            this.chkEnemyTable1Mod.TabIndex = 8;
            this.chkEnemyTable1Mod.Text = "Table 01 Mod";
            this.chkEnemyTable1Mod.UseVisualStyleBackColor = true;
            this.chkEnemyTable1Mod.CheckedChanged += new System.EventHandler(this.chkEnemyTable1Mod_CheckedChanged);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(14, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 71);
            this.label1.TabIndex = 7;
            this.label1.Text = "** WARNING **\r\n\r\nSpecific values are unknown and some selections may cause the ga" +
    "me to crash or behave unexpectedly.";
            // 
            // comboEnemyTable2
            // 
            this.comboEnemyTable2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboEnemyTable2.FormattingEnabled = true;
            this.comboEnemyTable2.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboEnemyTable2.Location = new System.Drawing.Point(14, 57);
            this.comboEnemyTable2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboEnemyTable2.Name = "comboEnemyTable2";
            this.comboEnemyTable2.Size = new System.Drawing.Size(140, 21);
            this.comboEnemyTable2.TabIndex = 5;
            this.comboEnemyTable2.SelectedIndexChanged += new System.EventHandler(this.comboEnemyTable2_SelectedIndexChanged);
            // 
            // comboEnemyTable1
            // 
            this.comboEnemyTable1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboEnemyTable1.FormattingEnabled = true;
            this.comboEnemyTable1.Items.AddRange(new object[] {
            "1 Star (Hack)",
            "2 Stars",
            "3 Stars"});
            this.comboEnemyTable1.Location = new System.Drawing.Point(14, 30);
            this.comboEnemyTable1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboEnemyTable1.Name = "comboEnemyTable1";
            this.comboEnemyTable1.Size = new System.Drawing.Size(140, 21);
            this.comboEnemyTable1.TabIndex = 4;
            this.comboEnemyTable1.SelectedIndexChanged += new System.EventHandler(this.comboEnemyTable1_SelectedIndexChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.numClearedInf);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.numClearedS);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.numClearedA);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.numClearedB);
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.numClearedC);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.numSynthPoint);
            this.groupBox9.Location = new System.Drawing.Point(587, 12);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox9.Size = new System.Drawing.Size(271, 194);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Cleared Mission Data";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "∞ Rank Cleared";
            // 
            // numClearedInf
            // 
            this.numClearedInf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numClearedInf.Location = new System.Drawing.Point(141, 165);
            this.numClearedInf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numClearedInf.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numClearedInf.Name = "numClearedInf";
            this.numClearedInf.Size = new System.Drawing.Size(111, 21);
            this.numClearedInf.TabIndex = 10;
            this.numClearedInf.ValueChanged += new System.EventHandler(this.numClearedInf_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "S Rank Cleared";
            // 
            // numClearedS
            // 
            this.numClearedS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numClearedS.Location = new System.Drawing.Point(141, 139);
            this.numClearedS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numClearedS.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numClearedS.Name = "numClearedS";
            this.numClearedS.Size = new System.Drawing.Size(111, 21);
            this.numClearedS.TabIndex = 8;
            this.numClearedS.ValueChanged += new System.EventHandler(this.numClearedS_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "A Rank Cleared";
            // 
            // numClearedA
            // 
            this.numClearedA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numClearedA.Location = new System.Drawing.Point(141, 113);
            this.numClearedA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numClearedA.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numClearedA.Name = "numClearedA";
            this.numClearedA.Size = new System.Drawing.Size(111, 21);
            this.numClearedA.TabIndex = 6;
            this.numClearedA.ValueChanged += new System.EventHandler(this.numClearedA_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "B Rank Cleared";
            // 
            // numClearedB
            // 
            this.numClearedB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numClearedB.Location = new System.Drawing.Point(141, 87);
            this.numClearedB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numClearedB.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numClearedB.Name = "numClearedB";
            this.numClearedB.Size = new System.Drawing.Size(111, 21);
            this.numClearedB.TabIndex = 4;
            this.numClearedB.ValueChanged += new System.EventHandler(this.numClearedB_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "C Rank Cleared";
            // 
            // numClearedC
            // 
            this.numClearedC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numClearedC.Location = new System.Drawing.Point(141, 61);
            this.numClearedC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numClearedC.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numClearedC.Name = "numClearedC";
            this.numClearedC.Size = new System.Drawing.Size(111, 21);
            this.numClearedC.TabIndex = 2;
            this.numClearedC.ValueChanged += new System.EventHandler(this.numClearedC_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Synthesis Points";
            // 
            // numSynthPoint
            // 
            this.numSynthPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numSynthPoint.Location = new System.Drawing.Point(141, 26);
            this.numSynthPoint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numSynthPoint.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSynthPoint.Name = "numSynthPoint";
            this.numSynthPoint.Size = new System.Drawing.Size(111, 21);
            this.numSynthPoint.TabIndex = 0;
            this.numSynthPoint.ValueChanged += new System.EventHandler(this.numSynthPoint_ValueChanged);
            // 
            // picMap1
            // 
            this.picMap1.Location = new System.Drawing.Point(103, 19);
            this.picMap1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picMap1.Name = "picMap1";
            this.picMap1.Size = new System.Drawing.Size(149, 96);
            this.picMap1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMap1.TabIndex = 13;
            this.picMap1.TabStop = false;
            // 
            // grpArea1
            // 
            this.grpArea1.Controls.Add(this.picArea1);
            this.grpArea1.Controls.Add(this.picMap1);
            this.grpArea1.Controls.Add(this.comboMapMod1);
            this.grpArea1.Location = new System.Drawing.Point(14, 102);
            this.grpArea1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpArea1.Name = "grpArea1";
            this.grpArea1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpArea1.Size = new System.Drawing.Size(271, 152);
            this.grpArea1.TabIndex = 14;
            this.grpArea1.TabStop = false;
            this.grpArea1.Text = "Area Map #1";
            // 
            // picArea1
            // 
            this.picArea1.Location = new System.Drawing.Point(14, 19);
            this.picArea1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picArea1.Name = "picArea1";
            this.picArea1.Size = new System.Drawing.Size(82, 53);
            this.picArea1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArea1.TabIndex = 14;
            this.picArea1.TabStop = false;
            // 
            // grpArea2
            // 
            this.grpArea2.Controls.Add(this.picArea2);
            this.grpArea2.Controls.Add(this.comboMapMod2);
            this.grpArea2.Controls.Add(this.picMap2);
            this.grpArea2.Location = new System.Drawing.Point(14, 262);
            this.grpArea2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpArea2.Name = "grpArea2";
            this.grpArea2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpArea2.Size = new System.Drawing.Size(271, 152);
            this.grpArea2.TabIndex = 15;
            this.grpArea2.TabStop = false;
            this.grpArea2.Text = "Area Map #2";
            this.grpArea2.EnabledChanged += new System.EventHandler(this.grpArea2_EnabledChanged);
            // 
            // picArea2
            // 
            this.picArea2.Location = new System.Drawing.Point(14, 19);
            this.picArea2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picArea2.Name = "picArea2";
            this.picArea2.Size = new System.Drawing.Size(82, 53);
            this.picArea2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArea2.TabIndex = 14;
            this.picArea2.TabStop = false;
            // 
            // picMap2
            // 
            this.picMap2.Location = new System.Drawing.Point(103, 19);
            this.picMap2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picMap2.Name = "picMap2";
            this.picMap2.Size = new System.Drawing.Size(149, 96);
            this.picMap2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMap2.TabIndex = 13;
            this.picMap2.TabStop = false;
            // 
            // grpArea3
            // 
            this.grpArea3.Controls.Add(this.comboMapMod3);
            this.grpArea3.Controls.Add(this.picArea3);
            this.grpArea3.Controls.Add(this.picMap3);
            this.grpArea3.Location = new System.Drawing.Point(14, 421);
            this.grpArea3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpArea3.Name = "grpArea3";
            this.grpArea3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpArea3.Size = new System.Drawing.Size(271, 152);
            this.grpArea3.TabIndex = 16;
            this.grpArea3.TabStop = false;
            this.grpArea3.Text = "Area Map #3";
            this.grpArea3.EnabledChanged += new System.EventHandler(this.grpArea3_EnabledChanged);
            // 
            // picArea3
            // 
            this.picArea3.Location = new System.Drawing.Point(14, 19);
            this.picArea3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picArea3.Name = "picArea3";
            this.picArea3.Size = new System.Drawing.Size(82, 53);
            this.picArea3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArea3.TabIndex = 14;
            this.picArea3.TabStop = false;
            // 
            // picMap3
            // 
            this.picMap3.Enabled = false;
            this.picMap3.Location = new System.Drawing.Point(103, 19);
            this.picMap3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picMap3.Name = "picMap3";
            this.picMap3.Size = new System.Drawing.Size(149, 96);
            this.picMap3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMap3.TabIndex = 13;
            this.picMap3.TabStop = false;
            // 
            // imgListMaps
            // 
            this.imgListMaps.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListMaps.ImageStream")));
            this.imgListMaps.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListMaps.Images.SetKeyName(0, "area_0_0.png");
            this.imgListMaps.Images.SetKeyName(1, "area_0_1.png");
            this.imgListMaps.Images.SetKeyName(2, "area_0_2.png");
            this.imgListMaps.Images.SetKeyName(3, "area_0_3.png");
            this.imgListMaps.Images.SetKeyName(4, "area_0_4.png");
            this.imgListMaps.Images.SetKeyName(5, "area_0_5.png");
            this.imgListMaps.Images.SetKeyName(6, "area_0_6.png");
            this.imgListMaps.Images.SetKeyName(7, "area_0_7.png");
            this.imgListMaps.Images.SetKeyName(8, "area_0_8.png");
            this.imgListMaps.Images.SetKeyName(9, "area_0_9.png");
            this.imgListMaps.Images.SetKeyName(10, "area_1_0.png");
            this.imgListMaps.Images.SetKeyName(11, "area_1_1.png");
            this.imgListMaps.Images.SetKeyName(12, "area_1_2.png");
            this.imgListMaps.Images.SetKeyName(13, "area_1_3.png");
            this.imgListMaps.Images.SetKeyName(14, "area_1_4.png");
            this.imgListMaps.Images.SetKeyName(15, "area_1_5.png");
            this.imgListMaps.Images.SetKeyName(16, "area_1_6.png");
            this.imgListMaps.Images.SetKeyName(17, "area_1_7.png");
            this.imgListMaps.Images.SetKeyName(18, "area_1_8.png");
            this.imgListMaps.Images.SetKeyName(19, "area_1_9.png");
            this.imgListMaps.Images.SetKeyName(20, "area_2_0.png");
            this.imgListMaps.Images.SetKeyName(21, "area_2_1.png");
            this.imgListMaps.Images.SetKeyName(22, "area_2_2.png");
            this.imgListMaps.Images.SetKeyName(23, "area_2_3.png");
            this.imgListMaps.Images.SetKeyName(24, "area_2_4.png");
            this.imgListMaps.Images.SetKeyName(25, "area_2_5.png");
            this.imgListMaps.Images.SetKeyName(26, "area_2_6.png");
            this.imgListMaps.Images.SetKeyName(27, "area_2_7.png");
            this.imgListMaps.Images.SetKeyName(28, "area_2_8.png");
            this.imgListMaps.Images.SetKeyName(29, "area_2_9.png");
            this.imgListMaps.Images.SetKeyName(30, "area_3_0.png");
            this.imgListMaps.Images.SetKeyName(31, "area_3_1.png");
            this.imgListMaps.Images.SetKeyName(32, "area_3_2.png");
            this.imgListMaps.Images.SetKeyName(33, "area_3_3.png");
            this.imgListMaps.Images.SetKeyName(34, "area_3_4.png");
            this.imgListMaps.Images.SetKeyName(35, "area_3_5.png");
            this.imgListMaps.Images.SetKeyName(36, "area_3_6.png");
            this.imgListMaps.Images.SetKeyName(37, "area_3_7.png");
            this.imgListMaps.Images.SetKeyName(38, "area_3_8.png");
            this.imgListMaps.Images.SetKeyName(39, "area_3_9.png");
            this.imgListMaps.Images.SetKeyName(40, "area_4_0.png");
            this.imgListMaps.Images.SetKeyName(41, "area_4_1.png");
            this.imgListMaps.Images.SetKeyName(42, "area_4_2.png");
            this.imgListMaps.Images.SetKeyName(43, "area_4_3.png");
            this.imgListMaps.Images.SetKeyName(44, "area_4_4.png");
            this.imgListMaps.Images.SetKeyName(45, "area_4_5.png");
            this.imgListMaps.Images.SetKeyName(46, "area_4_6.png");
            this.imgListMaps.Images.SetKeyName(47, "area_4_7.png");
            this.imgListMaps.Images.SetKeyName(48, "area_4_8.png");
            this.imgListMaps.Images.SetKeyName(49, "area_4_9.png");
            this.imgListMaps.Images.SetKeyName(50, "area_5_0.png");
            this.imgListMaps.Images.SetKeyName(51, "area_5_1.png");
            this.imgListMaps.Images.SetKeyName(52, "area_5_2.png");
            this.imgListMaps.Images.SetKeyName(53, "area_5_3.png");
            this.imgListMaps.Images.SetKeyName(54, "area_5_4.png");
            this.imgListMaps.Images.SetKeyName(55, "area_5_5.png");
            this.imgListMaps.Images.SetKeyName(56, "area_5_6.png");
            this.imgListMaps.Images.SetKeyName(57, "area_5_7.png");
            this.imgListMaps.Images.SetKeyName(58, "area_5_8.png");
            this.imgListMaps.Images.SetKeyName(59, "area_5_9.png");
            this.imgListMaps.Images.SetKeyName(60, "area_6_0.png");
            this.imgListMaps.Images.SetKeyName(61, "area_6_1.png");
            this.imgListMaps.Images.SetKeyName(62, "area_6_2.png");
            this.imgListMaps.Images.SetKeyName(63, "area_6_3.png");
            this.imgListMaps.Images.SetKeyName(64, "area_6_4.png");
            this.imgListMaps.Images.SetKeyName(65, "area_6_5.png");
            this.imgListMaps.Images.SetKeyName(66, "area_6_6.png");
            this.imgListMaps.Images.SetKeyName(67, "area_6_7.png");
            this.imgListMaps.Images.SetKeyName(68, "area_6_8.png");
            this.imgListMaps.Images.SetKeyName(69, "area_6_9.png");
            this.imgListMaps.Images.SetKeyName(70, "area_7_0.png");
            this.imgListMaps.Images.SetKeyName(71, "area_7_1.png");
            this.imgListMaps.Images.SetKeyName(72, "area_7_2.png");
            this.imgListMaps.Images.SetKeyName(73, "area_7_3.png");
            this.imgListMaps.Images.SetKeyName(74, "area_7_4.png");
            this.imgListMaps.Images.SetKeyName(75, "area_7_5.png");
            this.imgListMaps.Images.SetKeyName(76, "area_7_6.png");
            this.imgListMaps.Images.SetKeyName(77, "area_7_7.png");
            this.imgListMaps.Images.SetKeyName(78, "area_7_8.png");
            this.imgListMaps.Images.SetKeyName(79, "area_7_9.png");
            this.imgListMaps.Images.SetKeyName(80, "area_8_0.png");
            this.imgListMaps.Images.SetKeyName(81, "area_8_1.png");
            this.imgListMaps.Images.SetKeyName(82, "area_8_2.png");
            this.imgListMaps.Images.SetKeyName(83, "area_8_3.png");
            this.imgListMaps.Images.SetKeyName(84, "area_8_4.png");
            this.imgListMaps.Images.SetKeyName(85, "area_8_5.png");
            this.imgListMaps.Images.SetKeyName(86, "area_8_6.png");
            this.imgListMaps.Images.SetKeyName(87, "area_8_7.png");
            this.imgListMaps.Images.SetKeyName(88, "area_8_8.png");
            this.imgListMaps.Images.SetKeyName(89, "area_8_9.png");
            this.imgListMaps.Images.SetKeyName(90, "area_9_0.png");
            this.imgListMaps.Images.SetKeyName(91, "area_9_1.png");
            this.imgListMaps.Images.SetKeyName(92, "area_9_2.png");
            this.imgListMaps.Images.SetKeyName(93, "area_9_3.png");
            this.imgListMaps.Images.SetKeyName(94, "area_9_4.png");
            this.imgListMaps.Images.SetKeyName(95, "area_9_5.png");
            this.imgListMaps.Images.SetKeyName(96, "area_9_6.png");
            this.imgListMaps.Images.SetKeyName(97, "area_9_7.png");
            this.imgListMaps.Images.SetKeyName(98, "area_9_8.png");
            this.imgListMaps.Images.SetKeyName(99, "area_9_9.png");
            this.imgListMaps.Images.SetKeyName(100, "no_map.png");
            // 
            // imgListAreaThemes
            // 
            this.imgListAreaThemes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListAreaThemes.ImageStream")));
            this.imgListAreaThemes.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListAreaThemes.Images.SetKeyName(0, "theme_0.png");
            this.imgListAreaThemes.Images.SetKeyName(1, "theme_1.png");
            this.imgListAreaThemes.Images.SetKeyName(2, "theme_2.png");
            this.imgListAreaThemes.Images.SetKeyName(3, "theme_3.png");
            this.imgListAreaThemes.Images.SetKeyName(4, "theme_4.png");
            this.imgListAreaThemes.Images.SetKeyName(5, "theme_5.png");
            this.imgListAreaThemes.Images.SetKeyName(6, "theme_6.png");
            this.imgListAreaThemes.Images.SetKeyName(7, "theme_7.png");
            this.imgListAreaThemes.Images.SetKeyName(8, "theme_8.png");
            this.imgListAreaThemes.Images.SetKeyName(9, "theme_9.png");
            this.imgListAreaThemes.Images.SetKeyName(10, "theme_10.png");
            this.imgListAreaThemes.Images.SetKeyName(11, "theme_11.png");
            this.imgListAreaThemes.Images.SetKeyName(12, "theme_12.png");
            this.imgListAreaThemes.Images.SetKeyName(13, "theme_13.png");
            this.imgListAreaThemes.Images.SetKeyName(14, "theme_14.png");
            this.imgListAreaThemes.Images.SetKeyName(15, "theme_15.png");
            this.imgListAreaThemes.Images.SetKeyName(16, "theme_16.png");
            this.imgListAreaThemes.Images.SetKeyName(17, "theme_17.png");
            this.imgListAreaThemes.Images.SetKeyName(18, "theme_18.png");
            this.imgListAreaThemes.Images.SetKeyName(19, "theme_19.png");
            this.imgListAreaThemes.Images.SetKeyName(20, "theme_20.png");
            // 
            // imgListBoss
            // 
            this.imgListBoss.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBoss.ImageStream")));
            this.imgListBoss.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBoss.Images.SetKeyName(0, "boss_00.jpg");
            this.imgListBoss.Images.SetKeyName(1, "boss_01.jpg");
            this.imgListBoss.Images.SetKeyName(2, "boss_02.jpg");
            this.imgListBoss.Images.SetKeyName(3, "boss_03.jpg");
            this.imgListBoss.Images.SetKeyName(4, "boss_04.jpg");
            this.imgListBoss.Images.SetKeyName(5, "boss_05.jpg");
            this.imgListBoss.Images.SetKeyName(6, "boss_06.jpg");
            this.imgListBoss.Images.SetKeyName(7, "boss_07.jpg");
            this.imgListBoss.Images.SetKeyName(8, "boss_08.jpg");
            this.imgListBoss.Images.SetKeyName(9, "boss_09.jpg");
            this.imgListBoss.Images.SetKeyName(10, "boss_10.jpg");
            this.imgListBoss.Images.SetKeyName(11, "boss_11.jpg");
            this.imgListBoss.Images.SetKeyName(12, "boss_12.jpg");
            this.imgListBoss.Images.SetKeyName(13, "boss_13.jpg");
            this.imgListBoss.Images.SetKeyName(14, "boss_14.jpg");
            this.imgListBoss.Images.SetKeyName(15, "boss_15.jpg");
            this.imgListBoss.Images.SetKeyName(16, "boss_16.jpg");
            this.imgListBoss.Images.SetKeyName(17, "boss_17.jpg");
            this.imgListBoss.Images.SetKeyName(18, "boss_18.jpg");
            this.imgListBoss.Images.SetKeyName(19, "boss_19.jpg");
            this.imgListBoss.Images.SetKeyName(20, "boss_20.jpg");
            this.imgListBoss.Images.SetKeyName(21, "boss_21.jpg");
            this.imgListBoss.Images.SetKeyName(22, "boss_22.jpg");
            this.imgListBoss.Images.SetKeyName(23, "boss_23.jpg");
            this.imgListBoss.Images.SetKeyName(24, "boss_24.jpg");
            this.imgListBoss.Images.SetKeyName(25, "boss_25.jpg");
            this.imgListBoss.Images.SetKeyName(26, "boss_26.jpg");
            this.imgListBoss.Images.SetKeyName(27, "boss_27.jpg");
            this.imgListBoss.Images.SetKeyName(28, "boss_28.jpg");
            this.imgListBoss.Images.SetKeyName(29, "boss_29.jpg");
            this.imgListBoss.Images.SetKeyName(30, "boss_30.jpg");
            this.imgListBoss.Images.SetKeyName(31, "boss_31.jpg");
            this.imgListBoss.Images.SetKeyName(32, "boss_32.jpg");
            this.imgListBoss.Images.SetKeyName(33, "boss_33.jpg");
            this.imgListBoss.Images.SetKeyName(34, "boss_34.jpg");
            this.imgListBoss.Images.SetKeyName(35, "boss_35.jpg");
            this.imgListBoss.Images.SetKeyName(36, "boss_36.jpg");
            this.imgListBoss.Images.SetKeyName(37, "boss_37.jpg");
            this.imgListBoss.Images.SetKeyName(38, "boss_38.jpg");
            this.imgListBoss.Images.SetKeyName(39, "boss_39.jpg");
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtHex);
            this.groupBox10.Location = new System.Drawing.Point(587, 410);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox10.Size = new System.Drawing.Size(271, 131);
            this.groupBox10.TabIndex = 12;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Hex";
            // 
            // pspo2seInfinityMissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 580);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpArea3);
            this.Controls.Add(this.grpArea2);
            this.Controls.Add(this.grpArea1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(889, 623);
            this.MinimumSize = new System.Drawing.Size(889, 623);
            this.Name = "pspo2seInfinityMissionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Infinity Mission Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pspo2seInfinityMissionForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.pspo2seInfinityMissionForm_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoss)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedInf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearedC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSynthPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap1)).EndInit();
            this.grpArea1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picArea1)).EndInit();
            this.grpArea2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picArea2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap2)).EndInit();
            this.grpArea3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picArea3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap3)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

    }
}