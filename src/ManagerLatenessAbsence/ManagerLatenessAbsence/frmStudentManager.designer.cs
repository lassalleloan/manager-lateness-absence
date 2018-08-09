namespace ManagerLatenessAbsence
{
    partial class frmStudentManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentManager));
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblDisciplineName = new System.Windows.Forms.Label();
            this.lblNumberAbsence = new System.Windows.Forms.Label();
            this.lblStudentFullName = new System.Windows.Forms.Label();
            this.lblAbsence = new System.Windows.Forms.Label();
            this.lblLateness = new System.Windows.Forms.Label();
            this.lblNumberLateness = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.pctStudent = new System.Windows.Forms.PictureBox();
            this.chkLateness = new System.Windows.Forms.CheckBox();
            this.chkAbsent = new System.Windows.Forms.CheckBox();
            this.lblDiscipline = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdBack
            // 
            this.cmdBack.Location = new System.Drawing.Point(179, 270);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(90, 25);
            this.cmdBack.TabIndex = 3;
            this.cmdBack.Text = "Retour";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(275, 270);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(90, 25);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Sauvegarder";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblDisciplineName
            // 
            this.lblDisciplineName.AutoSize = true;
            this.lblDisciplineName.Location = new System.Drawing.Point(74, 9);
            this.lblDisciplineName.Name = "lblDisciplineName";
            this.lblDisciplineName.Size = new System.Drawing.Size(64, 13);
            this.lblDisciplineName.TabIndex = 100;
            this.lblDisciplineName.Text = "NomMatiere";
            // 
            // lblNumberAbsence
            // 
            this.lblNumberAbsence.AutoSize = true;
            this.lblNumberAbsence.Location = new System.Drawing.Point(272, 235);
            this.lblNumberAbsence.Name = "lblNumberAbsence";
            this.lblNumberAbsence.Size = new System.Drawing.Size(57, 13);
            this.lblNumberAbsence.TabIndex = 100;
            this.lblNumberAbsence.Text = "QAbsence";
            // 
            // lblStudentFullName
            // 
            this.lblStudentFullName.AutoSize = true;
            this.lblStudentFullName.Location = new System.Drawing.Point(27, 98);
            this.lblStudentFullName.Name = "lblStudentFullName";
            this.lblStudentFullName.Size = new System.Drawing.Size(92, 13);
            this.lblStudentFullName.TabIndex = 100;
            this.lblStudentFullName.Text = "NomPrenomEleve";
            // 
            // lblAbsence
            // 
            this.lblAbsence.AutoSize = true;
            this.lblAbsence.Location = new System.Drawing.Point(165, 235);
            this.lblAbsence.Name = "lblAbsence";
            this.lblAbsence.Size = new System.Drawing.Size(102, 13);
            this.lblAbsence.TabIndex = 100;
            this.lblAbsence.Text = "Nombre d\'absence :";
            // 
            // lblLateness
            // 
            this.lblLateness.AutoSize = true;
            this.lblLateness.Location = new System.Drawing.Point(165, 200);
            this.lblLateness.Name = "lblLateness";
            this.lblLateness.Size = new System.Drawing.Size(95, 13);
            this.lblLateness.TabIndex = 100;
            this.lblLateness.Text = "Nombre de retard :";
            // 
            // lblNumberLateness
            // 
            this.lblNumberLateness.AutoSize = true;
            this.lblNumberLateness.Location = new System.Drawing.Point(272, 200);
            this.lblNumberLateness.Name = "lblNumberLateness";
            this.lblNumberLateness.Size = new System.Drawing.Size(47, 13);
            this.lblNumberLateness.TabIndex = 100;
            this.lblNumberLateness.Text = "QRetard";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(74, 39);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(60, 13);
            this.lblClassName.TabIndex = 100;
            this.lblClassName.Text = "NomClasse";
            // 
            // pctStudent
            // 
            this.pctStudent.Location = new System.Drawing.Point(30, 145);
            this.pctStudent.Name = "pctStudent";
            this.pctStudent.Size = new System.Drawing.Size(100, 150);
            this.pctStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctStudent.TabIndex = 9;
            this.pctStudent.TabStop = false;
            // 
            // chkLateness
            // 
            this.chkLateness.AutoSize = true;
            this.chkLateness.Location = new System.Drawing.Point(168, 157);
            this.chkLateness.Name = "chkLateness";
            this.chkLateness.Size = new System.Drawing.Size(69, 17);
            this.chkLateness.TabIndex = 101;
            this.chkLateness.Text = "En retard";
            this.chkLateness.UseVisualStyleBackColor = true;
            this.chkLateness.CheckedChanged += new System.EventHandler(this.chkLateness_CheckedChanged);
            // 
            // chkAbsent
            // 
            this.chkAbsent.AutoSize = true;
            this.chkAbsent.Location = new System.Drawing.Point(168, 180);
            this.chkAbsent.Name = "chkAbsent";
            this.chkAbsent.Size = new System.Drawing.Size(59, 17);
            this.chkAbsent.TabIndex = 102;
            this.chkAbsent.Text = "Absent";
            this.chkAbsent.UseVisualStyleBackColor = true;
            this.chkAbsent.CheckedChanged += new System.EventHandler(this.chkAbsent_CheckedChanged);
            // 
            // lblDiscipline
            // 
            this.lblDiscipline.AutoSize = true;
            this.lblDiscipline.Location = new System.Drawing.Point(12, 9);
            this.lblDiscipline.Name = "lblDiscipline";
            this.lblDiscipline.Size = new System.Drawing.Size(42, 13);
            this.lblDiscipline.TabIndex = 103;
            this.lblDiscipline.Text = "Matière";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(12, 39);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(38, 13);
            this.lblClass.TabIndex = 104;
            this.lblClass.Text = "Classe";
            // 
            // frmStudentManager
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 321);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblDiscipline);
            this.Controls.Add(this.chkAbsent);
            this.Controls.Add(this.chkLateness);
            this.Controls.Add(this.pctStudent);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.lblNumberLateness);
            this.Controls.Add(this.lblLateness);
            this.Controls.Add(this.lblAbsence);
            this.Controls.Add(this.lblStudentFullName);
            this.Controls.Add(this.lblNumberAbsence);
            this.Controls.Add(this.lblDisciplineName);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStudentManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionnaire d\'élève";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStudentManager_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pctStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblDisciplineName;
        private System.Windows.Forms.Label lblNumberAbsence;
        private System.Windows.Forms.Label lblStudentFullName;
        private System.Windows.Forms.Label lblAbsence;
        private System.Windows.Forms.Label lblLateness;
        private System.Windows.Forms.Label lblNumberLateness;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.PictureBox pctStudent;
        private System.Windows.Forms.CheckBox chkLateness;
        private System.Windows.Forms.CheckBox chkAbsent;
        private System.Windows.Forms.Label lblDiscipline;
        private System.Windows.Forms.Label lblClass;
    }
}