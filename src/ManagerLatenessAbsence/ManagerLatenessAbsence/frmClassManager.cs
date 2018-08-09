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
using System.Collections.Generic;
using System.Resources;
using System.Windows.Forms;

namespace ManagerLatenessAbsence
{
    public partial class frmClassManager : Form
    {
        private DataBase dataBase = null;
        private frmAuthentication formAuthentication = null;
        private frmHome formHome = null;

        private int idClass = -1;
        private int idCourse = -1;

        private List<int> idStudentsPictures = new List<int>();
        private List<PictureBox> studentsPictures = new List<PictureBox>();

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="dataBaseSent"></param>
        /// <param name="formAuthenticationSent"></param>
        /// <param name="formHomeSent"></param>
        /// <param name="idCourseSent"></param>
        public frmClassManager(DataBase dataBaseSent, frmAuthentication formAuthenticationSent, frmHome formHomeSent, int idCourseSent)
        {
            InitializeComponent();

            ChangeInterfaceLanguage();

            List<Label> studentsLabels = new List<Label>();

            this.dataBase = dataBaseSent;
            this.formAuthentication = formAuthenticationSent;
            this.formHome = formHomeSent;

            this.idCourse = idCourseSent;

            ClassNameOnLabel();
            DisciplineNameOnLabel();            

            foreach (Control c in this.Controls)
            {
                if ((c is Label) && (c.Name.StartsWith("lblStudent")))
                {
                    studentsLabels.Add((Label)c);
                }
                if (c is PictureBox)
                {
                    studentsPictures.Add((PictureBox)c);
                    idStudentsPictures.Add(-1);
                }
            }

            for(int index = 0; index < studentsPictures.Count; index++)
            {
                if (index.Equals(0) || idStudentsPictures.Count.Equals(0))
                {
                    StudentFullNameAndPicture(studentsLabels, studentsPictures, idStudentsPictures, index);
                }
                else
                {
                    StudentFullNameAndPicture(studentsLabels, studentsPictures, idStudentsPictures, index, " AND idStudent='" + ((idStudentsPictures[index - 1]) + 1).ToString() + "'");                   
                }
            }            
        }

        /// <summary>
        /// Affectation de la langue chiosie sur le texte des contrôles du formulaire "frmClassManager".
        /// </summary>
        private void ChangeInterfaceLanguage()
        {
            ResourceManager ResourceManagerClassManager = new ResourceManager("ManagerLatenessAbsence." + this.Name, typeof(frmClassManager).Assembly);

            this.Text = ResourceManagerClassManager.GetString("this.Text");

            lblDiscipline.Text = ResourceManagerClassManager.GetString("lblDiscipline.Text");
            lblClass.Text = ResourceManagerClassManager.GetString("lblClass.Text");

            cmdBack.Text = ResourceManagerClassManager.GetString("cmdBack.Text");
            cmdLogout.Text = ResourceManagerClassManager.GetString("cmdLogout.Text");
        }

        /// <summary>
        /// Affectation du nom de la classe sur le label "lblClassName".
        /// </summary>
        private void ClassNameOnLabel()
        {
            idClass = dataBase.ElementSearchedFromReference("idClass", "Course", "idCourse", idCourse.ToString());
            lblClassName.Text = dataBase.ElementNameSearchedFromReference("Name", "Class", "idClass", idClass.ToString());
        }

        /// <summary>
        /// Lors du clique sur le bouton "cmdBack" : fermeture du formulaire "frmClassManager"
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
        /// Lors du clique sur le bouton "cmdDisconnection" : fermeture de la connexion à la base de donnée
        /// Puis fermeture du formulaire "frmClassManager", fermeture du formulaire "frmHome" et affichage du formulaire "frmAuthentication".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDisconnection_Click(object sender, EventArgs e)
        {
            dataBase.CloseConnection();
            this.Close();
            formHome.Close();

            formAuthentication.Show();
            formAuthentication.BringToFront();
        }

        /// <summary>
        /// Affectation du nom de la matière sur le label "lblDisciplineName".
        /// </summary>
        private void DisciplineNameOnLabel()
        {
            int idDiscipline;

            idDiscipline = dataBase.ElementSearchedFromReference("idDiscipline", "Course", "idCourse", idCourse.ToString());
            lblDisciplineName.Text = dataBase.ElementNameSearchedFromReference("Name", "Discipline", "idDiscipline", idDiscipline.ToString());
        }

        /// <summary>
        /// Affectation des chemins d'accès des photos des élèves.
        /// </summary>
        /// <param name="studentsLabelsSent"></param>
        /// <param name="studentsPicturesSent"></param>
        /// <param name="indexSent"></param>
        private void DisplayPictures(List<Label> studentsLabelsSent, List<PictureBox> studentsPicturesSent, int indexSent)
        {
            string imagePath = "StudentsPictures\\";
            string imagePathEnd = ".jpg";
            string imagePathStudent = null;

            imagePathStudent = studentsLabelsSent[indexSent].Text.Replace(" ", "");
            imagePath += imagePathStudent + imagePathEnd;
            studentsPicturesSent[indexSent].ImageLocation = imagePath;
        }

        /// <summary>
        /// Lors de la fermeture du formulaire "frmClassManager" : fermeture de la connextion à la base de donnée
        /// Puis affichage du formulaire "frmHome".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmClassManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataBase.CloseConnection();

            formHome.Show();
            formHome.BringToFront();
        }

        /// <summary>
        /// Lors du clique sur une pictureBox "pctStudent" : fermeture de la connexion à la base de donnée
        /// Puis masquage du formulaire "frmClassManager" et affichage du formulaire "frmStudentManager".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctStudent_Click(object sender, EventArgs e)
        {
            PictureBox pctStudentClicked = (PictureBox)sender;
            int indexOfIdStudent = studentsPictures.IndexOf(pctStudentClicked);

            this.Hide();

            frmStudentManager formStudentManager = new frmStudentManager(dataBase, this, idStudentsPictures[indexOfIdStudent], idCourse, pctStudentClicked.ImageLocation);
            formStudentManager.Show();
            formStudentManager.BringToFront();
        }

        /// <summary>
        /// Affectation des nom et des photos des élèves.
        /// </summary>
        /// <param name="studentsLabelsSent"></param>
        /// <param name="studentsPicturesSent"></param>
        /// <param name="idStudentsPicturesSent"></param>
        /// <param name="indexSent"></param>
        /// <param name="additionalReferenceSent"></param>
        private void StudentFullNameAndPicture(List<Label> studentsLabelsSent, List<PictureBox> studentsPicturesSent, List<int> idStudentsPicturesSent, int indexSent, string additionalReferenceSent = "")
        {
            int idStudent = dataBase.ElementSearchedFromReference("idStudent", "Student", "idClass", idClass.ToString(), additionalReferenceSent);

            if (!idStudent.Equals(-1))
            {
                StudentFullNameOnLabel(studentsLabelsSent, idStudentsPicturesSent, idStudent, indexSent);
                DisplayPictures(studentsLabelsSent, studentsPicturesSent, indexSent);
            }
            else
            {
                studentsLabelsSent[indexSent].Text = "";
                studentsPicturesSent[indexSent].ImageLocation = "";
                studentsPicturesSent[indexSent].Enabled = false;
            }
        }

        /// <summary>
        /// Affectation du nom des élèves sur les labels "lblStudentFullName".
        /// </summary>
        /// <param name="studentsLabelsSent"></param>
        /// <param name="idStudentsPicturesSent"></param>
        /// <param name="idStudentSent"></param>
        /// <param name="indexSent"></param>
        private void StudentFullNameOnLabel(List<Label> studentsLabelsSent, List<int> idStudentsPicturesSent, int idStudentSent, int indexSent)
        {
            studentsLabelsSent[indexSent].Text = dataBase.ElementFullNameFromReference("Student", "idStudent", idStudentSent.ToString());
            idStudentsPicturesSent[indexSent] = idStudentSent;
        }

    }
}
