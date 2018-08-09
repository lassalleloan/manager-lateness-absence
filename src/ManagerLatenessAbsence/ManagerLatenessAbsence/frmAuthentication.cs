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
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace ManagerLatenessAbsence
{
    public partial class frmAuthentication : Form
    {
        private DataBase dataBase = new DataBase("localhost", "managementLatenessAbsence", "root", "");

        /// <summary>
        /// Constructeur
        /// </summary>
        public frmAuthentication()
        {
            InitializeComponent();

            ChangeInterfaceLanguage(new CultureInfo("fr-CH"));
        }

        /// <summary>
        /// Affectation de la langue chiosie sur le texte des contrôles du formulaire "frmAuthentication".
        /// </summary>
        private void ChangeInterfaceLanguage(CultureInfo currentLanguageSent)
        {
            Thread.CurrentThread.CurrentUICulture = currentLanguageSent;
            ResourceManager ResourceManagerAuthentication = new ResourceManager("ManagerLatenessAbsence." + this.Name, typeof(frmAuthentication).Assembly);

            tsmLanguages.Text = ResourceManagerAuthentication.GetString("tsmLanguages.Text");
            this.Text = ResourceManagerAuthentication.GetString("this.Text");

            lblUsername.Text = ResourceManagerAuthentication.GetString("lblUsername.Text");
            lblPassword.Text = ResourceManagerAuthentication.GetString("lblPassword.Text");
            cmdLogin.Text = ResourceManagerAuthentication.GetString("cmdLogin.Text");
        }

        /// <summary>
        /// Lors du clique sur le bouton "cmdConnexion" : vérification de la réussite de l'authentification
        /// Puis masquage du formulaire "frmAuthentication", affichage de formulaire "frmHome" et suppression du contenu des textBox du formulaire "frmAuthetication".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConnection_Click(object sender, EventArgs e)
        {
            if (dataBase.Authentication(txtUsername, txtPassword))
            {
                dataBase.CloseConnection();
                this.Hide();
                frmHome formHome = new frmHome(dataBase, this, txtUsername.Text);

                formHome.Show();
                formHome.BringToFront();

                txtUsername.Text = "";
                txtPassword.Text = "";
            }
        }

        /// <summary>
        /// Lors de la fermeture du formulaire "frmAuthentification" : fermeture de la connextion à la base de donnée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAuthentication_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataBase.CloseConnection();
        }

        /// <summary>
        /// Lors du clique sur un item du toolStripMenu "tsmLanguages" : affectation de la langue choisie
        /// Puis changement de l'affichage des contrôles. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmLanguages_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (tsmEnglish.Selected)
            {
                ChangeInterfaceLanguage(new CultureInfo("en-US"));
            }

            if (tsmGerman.Selected)
            {
                ChangeInterfaceLanguage(new CultureInfo("de-CH"));
            }

            if (tsmFrench.Selected)
            {
                ChangeInterfaceLanguage(new CultureInfo("fr-CH"));
            }

            if (tsmItalian.Selected)
            {
                ChangeInterfaceLanguage(new CultureInfo("it-CH"));
            }
        }
        
    }
}
