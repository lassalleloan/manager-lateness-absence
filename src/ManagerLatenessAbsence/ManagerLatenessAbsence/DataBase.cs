/*
 * -------------- Gestionnaire des retards et des absences --------------
 * Auteur : S. Martignier et L. Lassalle
 * Date : Mai 2014
 * Description :
 * Application permettant la saisie et le suivi des retards et absences
 * d'un èleve d'une classe en fonction des périodes de cours.
 * ----------------------------------------------------------------------
*/

// Bibliothèque des éléments MySql
// Ajouter la référence "MySql.Data"
using MySql.Data.MySqlClient;
using System.Resources;
using System.Windows.Forms;

namespace ManagerLatenessAbsence
{
    public class DataBase
    {
        private MySqlConnection connectionDataBase = new MySqlConnection();

        /// <summary>
        /// Constructeur
        /// </summary>
        public DataBase(string serverSent, string dataBaseSent, string userIdSent, string passwordSent)
        {
            string connectionParameters = "Server=" + serverSent + ";" + "Database=" + dataBaseSent + ";" + "UserId=" + userIdSent + ";" + "Password=" + passwordSent + ";";

            connectionDataBase.ConnectionString = connectionParameters;
        }

        /// <summary>
        /// Authentification de l'enseignant au moyen de son nom d'utilisateur et de son mot de passe.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Boolean : True -> Authentification réussite. False -> Authentification échouée ou génération d'une erreur.</returns>
        public bool Authentication(TextBox txtUsernameSent, TextBox txtPasswordSent)
        {
            if (OpenConnection())
            {
                // Création d'une commande MySql.
                MySqlCommand commandSQL = new MySqlCommand("SELECT Username, Password FROM Teacher WHERE Username='" + txtUsernameSent.Text + "'", connectionDataBase);

                // Flux de lecture de données dans la base de données.
                MySqlDataReader readerDataBase = commandSQL.ExecuteReader();

                using (readerDataBase)
                {
                    // Vérification du contenu de la textBox "txtUsername" avec les valeurs contenues dans le champ Username de la table Teacher.
                    if (readerDataBase.HasRows)
                    {
                        while (readerDataBase.Read())
                        {
                            // Vérification du contenu de la textBox "txtPassword" avec la valeur du champ Password associé au Username.
                            if ((txtPasswordSent.Text.Equals((string)readerDataBase["Password"])))
                            {
                                CloseConnection();
                                return true;
                            }
                        }
                        CloseConnection();
                        MessageBox.Show(ChangeInterfaceLanguage("messageBoxTextAuthentication"));
                        txtPasswordSent.Focus();
                        return false;
                    }
                    CloseConnection();
                    MessageBox.Show(ChangeInterfaceLanguage("messageBoxErrorTextAuthentication"));
                    txtUsernameSent.Focus();                    
                    return false;
                }
            }
            CloseConnection();
            return false;
        }

        /// <summary>
        /// Verification du mot de passe pour son changement et changement du mot de passe de l'enseignant.
        /// </summary>
        /// <param name="idTeacherSent"></param>
        /// <param name="txtOldPasswordSent"></param>
        /// <param name="txtNewPasswordSent"></param>
        /// <param name="confirmationPasswordSent"></param>
        /// <returns>Boolean : True -> Vérification et changement du mot de passe réussi. False -> Vérification et changement du mot de passe échoué ou génération d'une erreur.</returns>
        public bool CheckAndChangePassword(string idTeacherSent, TextBox txtOldPasswordSent, TextBox txtNewPasswordSent, TextBox txtConfirmationPasswordSent)
        {
            if (OpenConnection())
            {
                // Création d'une commande MySql.
                MySqlCommand commandSelect = new MySqlCommand("SELECT Password FROM Teacher WHERE idTeacher='" + idTeacherSent + "'", connectionDataBase);

                // Flux de lecture de données dans la base de données.
                MySqlDataReader readerDataBase = commandSelect.ExecuteReader();

                using (readerDataBase)
                {
                    if (readerDataBase.HasRows)
                    {
                        while (readerDataBase.Read())
                        {
                            // Vérification du contenu de la textBox "txtPassword" avec la valeur du champ Password associé au Username.
                            if ((txtOldPasswordSent.Text.Equals((string)readerDataBase["Password"])))
                            {
                                CloseConnection();
                                string commandUpdate;

                                if ((!txtNewPasswordSent.Text.Equals("")) && (txtConfirmationPasswordSent.Text.Equals(txtNewPasswordSent.Text)))
                                {
                                    commandUpdate = "UPDATE `Teacher` SET `Password` = '" + txtNewPasswordSent.Text + "' WHERE `idTeacher` = " + idTeacherSent + ";";
                                    return CommandSQL(commandUpdate);
                                }
                                CloseConnection();
                                MessageBox.Show(ChangeInterfaceLanguage("messageBoxTextCheckAndChangePassword"));
                                txtOldPasswordSent.Text = "";
                                txtNewPasswordSent.Text = "";
                                txtConfirmationPasswordSent.Text = "";
                                txtOldPasswordSent.Focus();
                                return false;
                            }
                            CloseConnection();
                            MessageBox.Show(ChangeInterfaceLanguage("messageBoxErrorTextCheckAndChangePassword"));
                            txtOldPasswordSent.Text = "";
                            txtNewPasswordSent.Text = "";
                            txtConfirmationPasswordSent.Text = "";
                            txtOldPasswordSent.Focus();
                            return false;
                        }
                        CloseConnection();
                        return false;
                    }
                    CloseConnection();
                    return false;
                }
            }
            CloseConnection();
            return false;
        }

        /// <summary>
        /// Verification du mot de passe pour son changement.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Boolean : True -> Mot de passe correct. False -> Mot de passe incorrect, manquant ou génération d'une erreur.</returns>

        /// <summary>
        /// Fermeture la connexion à la base de données
        /// </summary>
        /// <returns>Boolean : True -> Fermeture de la connexion réussie. False -> Fermeture de la connexion échouée ou génération d'une erreur.</returns>
        public bool CloseConnection()
        {
            // Essaie de la fermeture de la connexion à la base de données.
            try
            {
                connectionDataBase.Close();
                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show(ChangeInterfaceLanguage("messageBoxErrorTextCloseConnection"));
                return false;
            }
        }

        /// <summary>
        /// Passage de commandes SQL pour intéragir avec la base de données
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Boolean : True -> Exécution réussite. False -> Exécution échouée ou génération d'une erreur.</returns>
        public bool CommandSQL(string querySent)
        {
            if (OpenConnection())
            {
                MySqlCommand commandSQL = new MySqlCommand(querySent, connectionDataBase);

                commandSQL.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        /// <summary>
        /// Sélection de la date d'après une idDate.
        /// </summary>
        /// <param name="buttonSent"></param>
        /// <returns></returns>
        public string DateFromIdDate(Control buttonSent)
        {
            string idDate = buttonSent.Name.Substring(6, 1);

            switch (idDate)
            {
                case "1":
                    return "2014-04-28";

                case "2":
                    return "2014-04-29";

                case "3":
                    return "2014-04-30";

                case "4":
                    return "2014-05-01";

                case "5":
                    return "2014-05-02";

                default:
                    return null;
            }
        }

        /// <summary>
        /// Vérification de l'existance d'un élément dans la base de données.
        /// </summary>
        /// <param name="elementSearchedSent"></param>
        /// <param name="tableSent"></param>
        /// <param name="referenceSent"></param>
        /// <param name="valueReferenceSent"></param>
        /// <param name="additionalReferenceSent"></param>
        /// <returns>Boolean : True -> Existence de l'élément recherché. False -> Inexistence de l'élément ou génération d'une erreur.</returns>
        public bool ElementExistFromReference(string elementSearchedSent, string tableSent, string referenceSent, string valeurReferenceSent, string additionalReferenceSent = "")
        {
            if (OpenConnection())
            {
                // Création d'une commande MySql.
                MySqlCommand commandSelect = new MySqlCommand("SELECT " + elementSearchedSent + " FROM " + tableSent + " WHERE " + referenceSent + "='" + valeurReferenceSent + "'" + additionalReferenceSent + "", connectionDataBase);

                // Flux de lecture de données dans la base de données
                MySqlDataReader readerDataBase = commandSelect.ExecuteReader();

                using (readerDataBase)
                {
                    if (readerDataBase.HasRows)
                    {
                        CloseConnection();
                        return true;
                    }
                    CloseConnection();
                    return false;
                }
            }
            CloseConnection();
            return false;
        }

        /// <summary>
        /// Recherche du nom et prénom d'un élément dans la base de données.
        /// </summary>
        /// <param name="tableSent"></param>
        /// <param name="referenceSent"></param>
        /// <param name="valueReferenceSent"></param>
        /// <param name="additionalReferenceSent"></param>
        /// <returns>String : Réussite -> Nom et prénom de la référence. Echec ou erreur -> Valeur null.</returns>
        public string ElementFullNameFromReference(string tableSent, string referenceSent, string valueReferenceSent, string additionalReferenceSent = "")
        {
            if (OpenConnection())
            {
                // Création d'une commande MySql.
                MySqlCommand commandSelect = new MySqlCommand("SELECT Name, FirstName FROM " + tableSent + " WHERE " + referenceSent + "='" + valueReferenceSent + "'" + additionalReferenceSent + "", connectionDataBase);

                // Flux de lecture de données dans la base de données
                MySqlDataReader readerDataBase = commandSelect.ExecuteReader();

                using (readerDataBase)
                {
                    string elementFullName = null;

                    while (readerDataBase.Read())
                    {
                        elementFullName = (string)readerDataBase["Name"] + " " + (string)readerDataBase["FirstName"];
                    }
                    CloseConnection();
                    return elementFullName;
                }
            }
            CloseConnection();
            return null;
        }

        /// <summary>
        /// Recherche du nom d'un élément dans la base de données.
        /// </summary>
        /// <param name="nameElementSearchedSent"></param>
        /// <param name="tableSent"></param>
        /// <param name="referenceSent"></param>
        /// <param name="valueReferenceSent"></param>
        /// <param name="additionalReferenceSent"></param>
        /// <returns>String : Réussite ->  Nom de l'élément recherché. Echec ou erreur -> Valeur null.</returns>
        public string ElementNameSearchedFromReference(string nameElementSearchedSent, string tableSent, string referenceSent, string valueReferenceSent, string additionalReferenceSent = "")
        {
            if (OpenConnection())
            {
                // Création d'une commande MySql.
                MySqlCommand commandSelect = new MySqlCommand("SELECT " + nameElementSearchedSent + " FROM " + tableSent + " WHERE " + referenceSent + "='" + valueReferenceSent + "'" + additionalReferenceSent + "", connectionDataBase);

                // Flux de lecture de données dans la base de données
                MySqlDataReader readerDataBase = commandSelect.ExecuteReader();

                using (readerDataBase)
                {
                    if (readerDataBase.HasRows)
                    {
                        string elementNameSearchResult = null;

                        while (readerDataBase.Read())
                        {
                            elementNameSearchResult = (string)readerDataBase["" + nameElementSearchedSent + ""];
                        }
                        CloseConnection();
                        return elementNameSearchResult;
                    }
                    CloseConnection();
                    return null;
                }
            }
            CloseConnection();
            return null;
        }

        /// <summary>
        /// Recherche d'un nombre d'un élément dans la base de données.
        /// </summary>
        /// <param name="elementSearchedSent"></param>
        /// <param name="tableSent"></param>
        /// <param name="referenceSent"></param>
        /// <param name="valueReferenceSent"></param>
        /// <param name="additionalReferenceSent"></param>
        /// <returns>Integer : Réussite -> Nombre de l'élément recherché. Echec ou erreur -> Valeur -1.</returns>
        public int ElementSearchedFromReference(string elementSearchedSent, string tableSent, string referenceSent, string valueReferenceSent, string additionalReferenceSent = "")
        {
            if (OpenConnection())
            {
                // Création d'une commande MySql.
                MySqlCommand commandSelect = new MySqlCommand("SELECT " + elementSearchedSent + " FROM " + tableSent + " WHERE " + referenceSent + "='" + valueReferenceSent + "'" + additionalReferenceSent + "", connectionDataBase);

                // Flux de lecture de données dans la base de données
                MySqlDataReader readerDataBase = commandSelect.ExecuteReader();

                using (readerDataBase)
                {
                    if (readerDataBase.HasRows)
                    {
                        int elementSearchedResult = -1;

                        while (readerDataBase.Read())
                        {
                            elementSearchedResult = (int)readerDataBase["" + elementSearchedSent + ""];
                            CloseConnection();
                            return elementSearchedResult;
                        }
                        CloseConnection();
                        return -1;
                    }
                    CloseConnection();
                    return -1;
                }
            }
            CloseConnection();
            return -1;
        }

        /// <summary>
        /// Enregistrement d'une nouvelle entrée pour le status d'un élève. 
        /// </summary>
        public bool NewEntryStudentProfil(string idStudentSent, string idCourseSent)
        {
            string commandInsert;

            commandInsert = "INSERT INTO `StatusStudent` (`idStudent`, `idCourse`, `Lateness`, `Absent`) VALUES ('" + idStudentSent + "', '" + idCourseSent + "', '0', '0');";
            return CommandSQL(commandInsert);
        }

        /// <summary>
        /// Affectation de la langue chiosie sur le texte utilisé dans la classe "DataBase".
        /// </summary>
        /// <param name="textSent"></param>
        /// <returns></returns>
        public string ChangeInterfaceLanguage(string textSent)
        {
            ResourceManager ResourceManager = new ResourceManager("ManagerLatenessAbsence.DataBase", typeof(DataBase).Assembly);

            return ResourceManager.GetString(textSent);
        }

        /// <summary>
        /// Vérification de l'existence du status d'un élément dans la base de données.
        /// </summary>
        /// <param name="statusSearchedSent"></param>
        /// <param name="tableSent"></param>
        /// <param name="referenceSent"></param>
        /// <param name="valueReferenceSent"></param>
        /// <param name="additionalReferenceSent"></param>
        /// <returns>Boulean : True ->  Existence du status de la référence. False -> Inexistence du status de la référence ou génération d'une erreur.</returns>
        public bool StatusFromReference(string statusSearchedSent, string tableSent, string referenceSent, string valueReferenceSent, string additionalReferenceSent = "")
        {
            if (OpenConnection())
            {
                // Création d'une commande MySql.
                MySqlCommand commandSelect = new MySqlCommand("SELECT " + statusSearchedSent + " FROM " + tableSent + " WHERE " + referenceSent + "='" + valueReferenceSent + "'" + additionalReferenceSent + "", connectionDataBase);

                // Flux de lecture de données dans la base de données
                MySqlDataReader readerDataBase = commandSelect.ExecuteReader();

                using (readerDataBase)
                {
                    if (readerDataBase.HasRows)
                    {
                        bool isStatus = false;

                        while (readerDataBase.Read())
                        {
                            isStatus = (bool)readerDataBase["" + statusSearchedSent + ""];                            
                        }
                        CloseConnection();
                        return isStatus;
                    }
                    CloseConnection();
                    return false;
                }
            }
            CloseConnection();
            return false;
        }

        /// <summary>
        /// Ouverture de la connexion à la base de données.
        /// </summary>
        /// <returns>Boolean : True -> Ouverture de la connexion réussie. False -> Ouverture de la connexion échouée ou génération d'une erreur.</returns>
        public bool OpenConnection()
        {
            try
            {
                connectionDataBase.Open();
                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show(ChangeInterfaceLanguage("messageBoxErrorTextOpenConnection"));
                return false;
            }
        }

        /// <summary>
        /// Mise à jour du nombre du status de l'élève.
        /// </summary>
        /// <param name="updatedStatusSent"></param>
        /// <param name="checkBoxCheckedSent"></param>
        /// <param name="oldStatusSent"></param>
        /// <param name="oldNumberStatusSent"></param>
        /// <returns></returns>
        public bool UpdateNumberStatus(string idStudentSent, string updatedStatusSent, bool checkBoxCheckedSent, bool oldStatusSent, int oldNumberStatusSent)
        {
            string commandUpdate = "UPDATE `Student` SET `" + updatedStatusSent + "` = 'currentNumberStatus' WHERE `idStudent` = " + idStudentSent + ";";
            int currentNumberStatus;

            if (checkBoxCheckedSent && !oldStatusSent)
            {
                currentNumberStatus = oldNumberStatusSent + 1;
                return CommandSQL(commandUpdate.Replace("'currentNumberStatus'", "'" + currentNumberStatus + "'"));
            }
            else if (!checkBoxCheckedSent && oldStatusSent)
            {
                currentNumberStatus = oldNumberStatusSent - 1;
                return CommandSQL(commandUpdate.Replace("'currentNumberStatus'", "'" + currentNumberStatus + "'"));
            }
            return true;
        }

        /// <summary>
        /// Mise à jour du status en cours de l'élève.
        /// </summary>
        /// <param name="updatedStatusSent"></param>
        /// <param name="checkBoxCheckedSent"></param>
        /// <returns></returns>
        public bool UpdateStatusStudent(string idStudentSent, string updatedStatusSent, string idCourseSent, bool checkBoxCheckedSent)
        {
            string commandUpdate = "UPDATE `StatusStudent` SET `" + updatedStatusSent + "` = '1' WHERE `idStudent` = " + idStudentSent + " AND `idCourse` = " + idCourseSent + ";";

            if (checkBoxCheckedSent)
            {
                return CommandSQL(commandUpdate);
            }
            return CommandSQL(commandUpdate.Replace("'1'", "'0'"));
        }

    }
}
