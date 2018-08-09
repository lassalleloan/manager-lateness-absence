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
    public partial class frmHome : Form
    {
        private DataBase dataBase = null;
        private frmAuthentication formAuthentication = null;

        private int idTeacher = -1;
        private string username = null;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="dataBaseSent"></param>
        /// <param name="formAuthenticationSent"></param>
        /// <param name="usernameSent"></param>
        public frmHome(DataBase dataBaseSent, frmAuthentication formAuthenticationSent, string usernameSent)
        {
            InitializeComponent();

            ChangeInterfaceLanguage();

            this.dataBase = dataBaseSent;
            this.formAuthentication = formAuthenticationSent;
            
            this.username = usernameSent;
            this.idTeacher = dataBaseSent.ElementSearchedFromReference("idTeacher", "Teacher", "Username", usernameSent);

            TeacherFullNameOnLabel();
            DisciplineNameOnButton();
        }

        /// <summary>
        /// Affectation de la langue chiosie sur le texte des contrôles du formulaire "frmHome".
        /// </summary>
        private void ChangeInterfaceLanguage()
        {
            ResourceManager ResourceManagerHome = new ResourceManager("ManagerLatenessAbsence." + this.Name, typeof(frmHome).Assembly);

            this.Text = ResourceManagerHome.GetString("this.Text");         

            lblWelcome.Text = ResourceManagerHome.GetString("lblWelcome.Text");

            cmdChangePassword.Text = ResourceManagerHome.GetString("cmdChangePassword.Text");
            cmdLogout.Text = ResourceManagerHome.GetString("cmdLogout.Text");

            lblDay1.Text = ResourceManagerHome.GetString("lblDay1.Text");
            lblDay2.Text = ResourceManagerHome.GetString("lblDay2.Text");
            lblDay3.Text = ResourceManagerHome.GetString("lblDay3.Text");
            lblDay4.Text = ResourceManagerHome.GetString("lblDay4.Text");
            lblDay5.Text = ResourceManagerHome.GetString("lblDay5.Text");
        }

        /// <summary>
        /// Lors du clique sur le bouton "cmdChangePassword" :
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangePassword_Click(object sender, EventArgs e)
        {
            dataBase.CloseConnection();
            this.Hide();

            frmChangePassword formChangePassword = new frmChangePassword(dataBase, this, idTeacher);
            formChangePassword.Show();
            formChangePassword.BringToFront();
        }
                
        /// <summary>
        /// Lors du clique sur un bouton "cmdDayPeriod" : affichage du formulaire "frmClassManager"
        /// Puis masquage du formulaire "frmHome" et affichage du formulaire "frmClassManager".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDayPeriod_Click(object sender, EventArgs e)
        {
            Button cmdDayPeriodClick = (Button)sender;
            string date = null;
            int idCourse = -1;
            string idPeriod = null;                

            date = dataBase.DateFromIdDate(cmdDayPeriodClick);
            idPeriod = cmdDayPeriodClick.Name.Substring(13);
            idCourse = dataBase.ElementSearchedFromReference("idCourse", "Course", "idPeriod", idPeriod, "AND idTeacher='" + idTeacher.ToString() + "' AND date='" + date + "'");

            dataBase.CloseConnection();

            if (!idCourse.Equals(null))
            {
                this.Hide();

                frmClassManager formClassManager = new frmClassManager(dataBase, formAuthentication, this, idCourse);
                formClassManager.Show();
                formClassManager.BringToFront();
            }
        }

        /// <summary>
        /// Lors du clique surle bouton "cmdDeconnexion" : fermeture de la connextion à la base de donnée
        /// Puis fermeture du formulaire "frmHome" et affichage du formulaire "frmAuthentication".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDeconnexion_Click(object sender, EventArgs e)
        {
            dataBase.CloseConnection();
            this.Close();

            formAuthentication.Show();
            formAuthentication.BringToFront();
        }

        /// <summary>
        /// Affectation du nom des matières par période sur les boutons.
        /// </summary>
        private void DisciplineNameOnButton()
        {
            string date = null;
            int idDiscipline = -1;
            string idPeriod = null;
            string disciplineName = null;

            foreach (Control c in this.Controls)
            {
                if (c is Button && c.Name.StartsWith("cmdDay"))
                {
                    date = dataBase.DateFromIdDate(c);
                    idPeriod = c.Name.Substring(13);
                    idDiscipline = dataBase.ElementSearchedFromReference("idDiscipline", "Course", "idPeriod", idPeriod, "And idTeacher='" + idTeacher.ToString() + "' And date='" + date + "'");
                    disciplineName = dataBase.ElementNameSearchedFromReference("Name", "Discipline", "idDiscipline", idDiscipline.ToString());
                    c.Text = disciplineName;

                    if (c.Text.Equals(""))
                    {
                        c.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Lors de la fermeture du formulaire "frmHome" : fermeture de la connextion à la base de donnée
        /// Puis affichage du formulaire "frmAuthentication".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataBase.CloseConnection();

            formAuthentication.Show();
            formAuthentication.BringToFront();
        }

        /// <summary>
        /// Affectation du nom et prénom de l'enseignant sur le label.
        /// </summary>
        private void TeacherFullNameOnLabel()
        {
            lblTeacherFullName.Text = dataBase.ElementFullNameFromReference("Teacher", "Username", username);
        }

    }
}
