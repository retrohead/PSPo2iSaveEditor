using System.ComponentModel;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class pspo2seEntryForm : Form
    {
        private IContainer components;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pspo2seEntryForm));
            this.txtNewText = new System.Windows.Forms.Label();
            this.txtCurText = new System.Windows.Forms.Label();
            this.txtEntryCurrent = new System.Windows.Forms.Label();
            this.txtEntryNew = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.comboEntryNew = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtNewText
            // 
            this.txtNewText.AutoSize = true;
            this.txtNewText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewText.Location = new System.Drawing.Point(11, 48);
            this.txtNewText.Name = "txtNewText";
            this.txtNewText.Size = new System.Drawing.Size(195, 13);
            this.txtNewText.TabIndex = 0;
            this.txtNewText.Text = "Please enter your new text below";
            // 
            // txtCurText
            // 
            this.txtCurText.AutoSize = true;
            this.txtCurText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurText.Location = new System.Drawing.Point(12, 9);
            this.txtCurText.Name = "txtCurText";
            this.txtCurText.Size = new System.Drawing.Size(81, 13);
            this.txtCurText.TabIndex = 1;
            this.txtCurText.Text = "Current Text:";
            // 
            // txtEntryCurrent
            // 
            this.txtEntryCurrent.AutoSize = true;
            this.txtEntryCurrent.Location = new System.Drawing.Point(12, 25);
            this.txtEntryCurrent.Name = "txtEntryCurrent";
            this.txtEntryCurrent.Size = new System.Drawing.Size(35, 13);
            this.txtEntryCurrent.TabIndex = 2;
            this.txtEntryCurrent.Text = "label3";
            // 
            // txtEntryNew
            // 
            this.txtEntryNew.Location = new System.Drawing.Point(13, 65);
            this.txtEntryNew.Name = "txtEntryNew";
            this.txtEntryNew.Size = new System.Drawing.Size(201, 20);
            this.txtEntryNew.TabIndex = 3;
            this.txtEntryNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entryNew_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(348, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(267, 80);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // comboEntryNew
            // 
            this.comboEntryNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboEntryNew.FormattingEnabled = true;
            this.comboEntryNew.Location = new System.Drawing.Point(13, 65);
            this.comboEntryNew.Name = "comboEntryNew";
            this.comboEntryNew.Size = new System.Drawing.Size(201, 21);
            this.comboEntryNew.TabIndex = 6;
            this.comboEntryNew.Visible = false;
            this.comboEntryNew.SelectedIndexChanged += new System.EventHandler(this.comboEntryNew_SelectedIndexChanged);
            this.comboEntryNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entryNew_KeyDown);
            // 
            // pspo2seEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 103);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtEntryNew);
            this.Controls.Add(this.txtEntryCurrent);
            this.Controls.Add(this.txtCurText);
            this.Controls.Add(this.txtNewText);
            this.Controls.Add(this.comboEntryNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(442, 146);
            this.MinimumSize = new System.Drawing.Size(442, 146);
            this.Name = "pspo2seEntryForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PSPo2se Entry Form";
            this.Shown += new System.EventHandler(this.pspo2seEntryForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
