/*
 * -------------- Gestionnaire des retards et des absences --------------
 * Auteur : S. Martignier et L. Lassalle
 * Date : Mai 2014
 * Description :
 * Application permettant la saisie et le suivi des retards et absences
 * d'un èleve d'une classe en fonction des périodes de cours.
 * ----------------------------------------------------------------------
*/

using System;
using System.Resources;
using System.Windows.Forms;

namespace ManagerLatenessAbsence
{
    public partial class frmChangePassword : Form
    {
        private DataBase dataBase = null;
        private frmHome formHome = null;

        private string messageBoxText = null;

        private int idTeacher = -1;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="dataBaseSent"></param>
        /// <param name="formHomeSent"></param>
        /// <param name="usernameSent"></param>
        public frmChangePassword(DataBase dataBaseSent, frmHome formHomeSent, int idTeacherSent)
        {
            InitializeComponent();
            
            ChangeInterfaceLanguage();

            this.dataBase = dataBaseSent;
            this.formHome = formHomeSent;

            this.idTeacher = idTeacherSent;
        }

        /// <summary>
        /// Affectation de la langue chiosie sur le texte des contrôles du formulaire "frmChangePassword".
        /// </summary>
        private void ChangeInterfaceLanguage()
        {
            ResourceManager ResourceManagerChangePassword = new ResourceManager("ManagerLatenessAbsence." + this.Name, typeof(frmChangePassword).Assembly);
            
            this.Text = ResourceManagerChangePassword.GetString("this.Text");

            lblOldPassword.Text = ResourceManagerChangePassword.GetString("lblOldPassword.Text");
            lblNewPassword.Text = ResourceManagerChangePassword.GetString("lblNewPassword.Text");
            lblConfirmationPassword.Text = ResourceManagerChangePassword.GetString("lblConfirmationPassword.Text");

            cmdBack.Text = ResourceManagerChangePassword.GetString("cmdBack.Text");
            cmdSave.Text = ResourceManagerChangePassword.GetString("cmdSave.Text");

            messageBoxText = ResourceManagerChangePassword.GetString("messageBoxText");
        }

        /// <summary>
        /// Lors du clique sur le bouton "cmdBack" : fermeture du formulaire "frmChangePassword"
        /// Puis affichage du formulaire "frmHome".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBack_Click(object sender, EventArgs e)
        {
            dataBase.CloseConnection();
            this.Close();

            formHome.Show();
            formHome.BringToFront();
        }

        /// <summary>
        /// Lors du clique sur le bouton "cmdSave" : enregistrement des modification apporter au mot de passe de l'enseignant
        /// Puis affichage d'un message de confirmation ou d'échec.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (dataBase.CheckAndChangePassword(idTeacher.ToString(), txtOldPassword, txtNewPassword, txtConfirmationPassword))
            {
                MessageBox.Show(messageBoxText);
                dataBase.CloseConnection();
                this.Close();

                formHome.Show();
                formHome.BringToFront();
            }
        }

        /// <summary>
        /// Lors de la fermeture du formulaire "frmChangePassword" : fermeture de la connextion à la base de donnée
        /// Puis affichage du formulaire "frmHome".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataBase.CloseConnection();

            formHome.Show();
            formHome.BringToFront();
        }

    }
}