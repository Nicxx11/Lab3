using Microsoft.UI.Xaml;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;

namespace lab3
{
    internal class GestionBD
    {
        MySqlConnection con;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            this.con = new MySqlConnection("Server=localhost;Database=lab3;Uid=root;Pwd=root;"); ;
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
        public ObservableCollection<Employe> getEmploye()
        {
            ObservableCollection<Employe> liste = new ObservableCollection<Employe>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select nom,prenom from employe";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Employe em = new Employe()
                {
                    //Matricule = r.GetString("matricule"),
                    Nom = r.GetString("nom"),
                    Prenom = r.GetString("prenom"),
                };
                liste.Add(em);
            }
            r.Close();
            con.Close();

            return liste;

        }

        public ObservableCollection<Projet> getProjet()
        {
            ObservableCollection<Projet> liste = new ObservableCollection<Projet>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from projet";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Projet pr = new Projet()
                {
                    Numero = r.GetString("numero"),
                    DateDebut = r.GetString("debut"),
                    Budget = r.GetInt32("budget"),
                    Description = r.GetString("description"),
                    Employe = r.GetString("employe")
                };
                liste.Add(pr);
            }
            r.Close();
            con.Close();

            return liste;

        }

        public int ajouterEmploye(Employe em)
        {
            string matricule = em.Matricule;
            string nom = em.Nom;
            string prenom = em.Prenom;
            int i = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("P_ajout_employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;


                commande.Parameters.AddWithValue("@newMat", matricule);
                commande.Parameters.AddWithValue("@newNom", nom);
                commande.Parameters.AddWithValue("@newPrenom", prenom);


                con.Open();
                commande.Prepare();
                i = commande.ExecuteNonQuery();
                con.Close();



            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

                i = 0;
            }

            return i;
        }
        public int ajouterProjet(Projet pr)
        {
            string numero = pr.Numero;
            string debut = pr.DateDebut;
            int budget = pr.Budget;
            string description = pr.Description;
            string employe = pr.Employe;
            int i = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("P_ajout_projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;


                commande.Parameters.AddWithValue("@newNum", numero);
                commande.Parameters.AddWithValue("@newDebut", debut);
                commande.Parameters.AddWithValue("@newBudget", budget);
                commande.Parameters.AddWithValue("@newDesc", description);
                commande.Parameters.AddWithValue("@newEmploye", employe);


                con.Open();
                commande.Prepare();
                i = commande.ExecuteNonQuery();
                con.Close();



            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

                i = 0;
            }

            return i;
        }

        public ObservableCollection<Employe> rechercheEmploye(string texte)
        {
            ObservableCollection<Employe> liste = new ObservableCollection<Employe>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe where matricule like @texte or nom like @texte or prenom like @texte";

            con.Open();
            commande.Parameters.AddWithValue("@texte", "%"+texte+"%");
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                Employe em = new Employe()
                {
                    Matricule = r.GetString("matricule"),
                    Nom = r.GetString("nom"),
                    Prenom = r.GetString("prenom"),
                };
                liste.Add(em);
            }
            r.Close();
            con.Close();

            return liste;

        }

        public ObservableCollection<Projet> rechercheProj(string texte)
        {
            ObservableCollection<Projet> liste = new ObservableCollection<Projet>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from projet where numero like @texte or debut like @texte or employe like @texte or budget like @texte";

            con.Open();
            commande.Parameters.AddWithValue("@texte", "%" + texte + "%");
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                Projet pr = new Projet()
                {
                    Numero = r.GetString("numero"),
                    DateDebut = r.GetString("debut"),
                    Budget = r.GetInt32("budget"),
                    Employe = r.GetString("employe")
                };
                liste.Add(pr);
            }
            r.Close();
            con.Close();

            return liste;

        }
    }
}
