namespace ManagerLatenessAbsence
{
    partial class frmAuthentication
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuthentication));
            this.cmdLogin = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.msLanguages = new System.Windows.Forms.MenuStrip();
            this.tsmLanguages = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGerman = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFrench = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItalian = new System.Windows.Forms.ToolStripMenuItem();
            this.msLanguages.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdLogin
            // 
            this.cmdLogin.AutoSize = true;
            this.cmdLogin.Location = new System.Drawing.Point(197, 96);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(75, 23);
            this.cmdLogin.TabIndex = 4;
            this.cmdLogin.Text = "Connexion";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdConnection_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 24);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Nom d\'utilisateur";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 63);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(71, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Mot de passe";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(15, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(150, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(15, 79);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // msLanguages
            // 
            this.msLanguages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLanguages});
            this.msLanguages.Location = new System.Drawing.Point(0, 0);
            this.msLanguages.Name = "msLanguages";
            this.msLanguages.Size = new System.Drawing.Size(284, 24);
            this.msLanguages.TabIndex = 5;
            // 
            // tsmLanguages
            // 
            this.tsmLanguages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEnglish,
            this.tsmGerman,
            this.tsmFrench,
            this.tsmItalian});
            this.tsmLanguages.Name = "tsmLanguages";
            this.tsmLanguages.Size = new System.Drawing.Size(63, 20);
            this.tsmLanguages.Text = "Langues";
            this.tsmLanguages.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmLanguages_DropDownItemClicked);
            // 
            // tsmEnglish
            // 
            this.tsmEnglish.Name = "tsmEnglish";
            this.tsmEnglish.Size = new System.Drawing.Size(117, 22);
            this.tsmEnglish.Text = "English";
            // 
            // tsmGerman
            // 
            this.tsmGerman.Name = "tsmGerman";
            this.tsmGerman.Size = new System.Drawing.Size(117, 22);
            this.tsmGerman.Text = "Deutsch";
            // 
            // tsmFrench
            // 
            this.tsmFrench.Name = "tsmFrench";
            this.tsmFrench.Size = new System.Drawing.Size(117, 22);
            this.tsmFrench.Text = "Français";
            // 
            // tsmItalian
            // 
            this.tsmItalian.Name = "tsmItalian";
            this.tsmItalian.Size = new System.Drawing.Size(117, 22);
            this.tsmItalian.Text = "Italiano";
            // 
            // frmAuthentication
            // 
            this.AcceptButton = this.cmdLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.cmdLogin);
            this.Controls.Add(this.msLanguages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msLanguages;
            this.MaximizeBox = false;
            this.Name = "frmAuthentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentification";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAuthentication_FormClosing);
            this.msLanguages.ResumeLayout(false);
            this.msLanguages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.MenuStrip msLanguages;
        private System.Windows.Forms.ToolStripMenuItem tsmLanguages;
        private System.Windows.Forms.ToolStripMenuItem tsmEnglish;
        private System.Windows.Forms.ToolStripMenuItem tsmGerman;
        private System.Windows.Forms.ToolStripMenuItem tsmFrench;
        private System.Windows.Forms.ToolStripMenuItem tsmItalian;
    }
}

