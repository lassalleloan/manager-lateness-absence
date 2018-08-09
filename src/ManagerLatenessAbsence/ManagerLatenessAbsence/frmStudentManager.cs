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
    public partial class frmStudentManager : Form
    {
        private DataBase dataBase = null;
        private frmClassManager formClassManager = null;

        private string messageBoxText = null;
        private string messageBoxErrorText1 = null;
        private string messageBoxErrorText2 = null;

        private int idCourse = -1;
        private int idStudent = -1;

        private int oldNumberAbsence = -1;
        private int oldNumberLateness = -1;

        private bool oldAbsence = false;
        private bool oldLateness = false;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="dataBaseSent"></param>
        /// <param name="formClassManagerSent"></param>
        /// <param name="idStudentSent"></param>
        /// <param name="idCourseSent"></param>
        /// <param name="pathToFileSent"></param>
        public frmStudentManager(DataBase dataBaseSent, frmClassManager formClassManagerSent, int idStudentSent, int idCourseSent, string pathToFileSent)
        {
            InitializeComponent();

            ChangeInterfaceLanguage();

            this.dataBase = dataBaseSent;
            this.formClassManager = formClassManagerSent;

            this.idStudent = idStudentSent;
            this.idCourse = idCourseSent;

            pctStudent.ImageLocation = pathToFileSent;

            NewStudentProfil();

            ClasseNameOnLabel();
            DisciplineNameOnLabel();            

            StudentFullNameOnLabel();

            OldNumberAbsenceOnLabelAndCheckBox();
            OldNumberLatenessOnLabelAndCheckBox();
        }

        /// <summary>
        /// Affectation de la langue chiosie sur le texte des contrôles du formulaire "frmStudentManager".
        /// </summary>
        private void ChangeInterfaceLanguage()
        {
            ResourceManager ResourceManagerStudentManager = new ResourceManager("ManagerLatenessAbsence." + this.Name, typeof(frmStudentManager).Assembly);

            this.Text = ResourceManagerStudentManager.GetString("this.Text");  

            lblDiscipline.Text = ResourceManagerStudentManager.GetString("lblDiscipline.Text");
            lblClass.Text = ResourceManagerStudentManager.GetString("lblClass.Text");

            chkLateness.Text = ResourceManagerStudentManager.GetString("chkLateness.Text");
            chkAbsent.Text = ResourceManagerStudentManager.GetString("chkAbsent.Text");

            lblLateness.Text = ResourceManagerStudentManager.GetString("lblLateness.Text");
            lblAbsence.Text = ResourceManagerStudentManager.GetString("lblAbsence.Text");

            cmdBack.Text = ResourceManagerStudentManager.GetString("cmdBack.Text");
            cmdSave.Text = ResourceManagerStudentManager.GetString("cmdSave.Text");

            messageBoxText = ResourceManagerStudentManager.GetString("messageBoxText");
            messageBoxErrorText1 = ResourceManagerStudentManager.GetString("messageBoxErrorText1");
            messageBoxErrorText2 = ResourceManagerStudentManager.GetString("messageBoxErrorText2");
        }

        /// <summary>
        /// Vérification de la sélection d'un des deux checkBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAbsent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAbsent.Checked)
            {
                chkLateness.Checked = false;
            }
        }

        /// <summary>
        /// Vérification de la sélection d'un des deux checkBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkLateness_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLateness.Checked)
            {
                chkAbsent.Checked = false;
            }
        }

        /// <summary>
        /// Affectation du nom de la classe sur le label "lblClassName".
        /// </summary>
        private void ClasseNameOnLabel()
        {
            int idClass;

            idClass = dataBase.ElementSearchedFromReference("idClass", "Course", "idCourse", idCourse.ToString());
            lblClassName.Text = dataBase.ElementNameSearchedFromReference("Name", "Class", "idClass", idClass.ToString());
        }

        /// <summary>
        /// Lors du clique sur le bouton "cmdBack" : fermeture du formulaire "frmStudentManager"
        /// Puis affichage du formulaire "frmClassManager".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBack_Click(object sender, EventArgs e)
        {
            dataBase.CloseConnection();
            this.Close();

            formClassManager.Show();
            formClassManager.BringToFront();
        }

        /// <summary>
        /// Lors du clique sur le bouton "cmdSave" : enregistrement des modification apporter au profil de l'élève
        /// Puis affichage d'un message de confirmation ou d'échec.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            bool updateAbsentStudentSuccess = dataBase.UpdateStatusStudent(idStudent.ToString(), "Absent", idCourse.ToString(), chkAbsent.Checked);
            bool updateLatenessStudentSuccess = dataBase.UpdateStatusStudent(idStudent.ToString(), "Lateness", idCourse.ToString(), chkLateness.Checked);
            bool updateNumberAbsenceStudentSuccess = dataBase.UpdateNumberStatus(idStudent.ToString(), "NumberAbsence", chkAbsent.Checked, oldAbsence, oldNumberAbsence);
            bool updateNumberLatenessStudentSuccess = dataBase.UpdateNumberStatus(idStudent.ToString(), "NumberLateness", chkLateness.Checked, oldLateness, oldNumberLateness);

            if (updateAbsentStudentSuccess && updateLatenessStudentSuccess && updateNumberAbsenceStudentSuccess && updateNumberLatenessStudentSuccess)
            {
                dataBase.CloseConnection();
                MessageBox.Show(messageBoxText);

                this.Close();
                formClassManager.Show();
                formClassManager.BringToFront();
            }
            else
            {
                MessageBox.Show(messageBoxErrorText1);
            }
        }

        /// <summary>
        /// Affectation du nom de la matières sur le label "lblDisciplineName".
        /// </summary>
        private void DisciplineNameOnLabel()
        {
            int idDiscipline;

            idDiscipline = dataBase.ElementSearchedFromReference("idDiscipline", "Course", "idCourse", idCourse.ToString());
            lblDisciplineName.Text = dataBase.ElementNameSearchedFromReference("Name", "Discipline", "idDiscipline", idDiscipline.ToString());
        }

        /// <summary>
        /// Lors de la fermeture du formulaire "frmStudentManager" : fermeture de la connextion à la base de donnée
        /// Puis affichage du formulaire "formClassManager".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStudentManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataBase.CloseConnection();

            formClassManager.Show();
            formClassManager.BringToFront();
        }

        /// <summary>
        /// Enregistrement d'une nouvelle entrée pour le status d'un élève. 
        /// </summary>
        private void NewStudentProfil()
        {
            if (!dataBase.ElementExistFromReference("Lateness", "StatusStudent", "idStudent", idStudent.ToString(), " AND idCourse='" + idCourse.ToString() + "'"))
            {
                if (!dataBase.NewEntryStudentProfil(idStudent.ToString(), idCourse.ToString()))
                {
                    MessageBox.Show(messageBoxErrorText2);
                }
            }
        }

        /// <summary>
        /// Affectation du nombre d'absence sur le label "lblNumberAbsence" et la checkBox "chkAbsent".
        /// </summary>
        private void OldNumberAbsenceOnLabelAndCheckBox()
        {
            oldNumberAbsence = dataBase.ElementSearchedFromReference("NumberAbsence", "Student", "idStudent", idStudent.ToString());
            lblNumberAbsence.Text = oldNumberAbsence.ToString();
            oldAbsence = dataBase.StatusFromReference("Absent", "StatusStudent", "idStudent", idStudent.ToString(), " AND idCourse='" + idCourse.ToString() + "'");

            if (oldAbsence)
            {
                chkAbsent.Checked = true;
            }            
        }

        /// <summary>
        /// Affectation du nombre de retard sur le label "lblNumberLateness" et la checkBox "chkLateness".
        /// </summary>
        private void OldNumberLatenessOnLabelAndCheckBox()
        {
            oldNumberLateness = dataBase.ElementSearchedFromReference("NumberLateness", "Student", "idStudent", idStudent.ToString());
            lblNumberLateness.Text = oldNumberLateness.ToString();
            oldLateness = dataBase.StatusFromReference("Lateness", "StatusStudent", "idStudent", idStudent.ToString(), " AND idCourse='" + idCourse.ToString() + "'");

            if (oldLateness)
            {
                chkLateness.Checked = true;
            }
        }

        /// <summary>
        /// Affectation du nom et prénom de l'élève sur le label "lblStudentFullName".
        /// </summary>
        private void StudentFullNameOnLabel()
        {
            lblStudentFullName.Text = dataBase.ElementFullNameFromReference("Student", "idStudent", idStudent.ToString());
        }

    }
}
