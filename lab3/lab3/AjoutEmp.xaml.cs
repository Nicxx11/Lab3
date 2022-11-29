using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Text.RegularExpressions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace lab3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutEmp : Page
    {
        public AjoutEmp()
        {
            this.InitializeComponent();
        }

        private void btnAjoutEmp_Click(object sender, RoutedEventArgs e)
        {
            var regexMat = new Regex(@"[a-zA-z]+");
            var regexNom = new Regex(@"[1-9]+");
            bool erreur = false;
            matError.Visibility = Visibility.Collapsed;
            nomError.Visibility = Visibility.Collapsed;
            prenomError.Visibility = Visibility.Collapsed;

            if (tbMat.Text.Length > 7)
            {
                empValide.Visibility = Visibility.Collapsed;
                matError.Visibility = Visibility.Visible;
                matError.Text = "Le matricule entré doit être composé d'au maximum 7 chiffres";
                erreur = true;
            }
            else if (tbMat.Text.Length == 0)
            {
                empValide.Visibility = Visibility.Collapsed;
                matError.Visibility = Visibility.Visible;
                matError.Text = "Vous devez entrez un matricule";
                erreur = true;
            }
            if (tbNom.Text.Length > 30)
            {
                empValide.Visibility = Visibility.Collapsed;
                nomError.Visibility = Visibility.Visible;
                nomError.Text = "Le nom entré doit être composé d'au maximum 30 chiffres";
                erreur = true;
            }
            else if (tbNom.Text.Length == 0)
            {
                empValide.Visibility = Visibility.Collapsed;
                nomError.Visibility = Visibility.Visible;
                nomError.Text = "Vous devez entrez un nom";
                erreur = true;
            }
            if (tbPrenom.Text.Length > 20)
            {
                empValide.Visibility = Visibility.Collapsed;
                prenomError.Visibility = Visibility.Visible;
                prenomError.Text = "Le prenom entré doit être composé d'au maximum 30 chiffres";
                erreur = true;
            }
            else if (tbPrenom.Text.Length == 0)
            {
                empValide.Visibility = Visibility.Collapsed;
                prenomError.Visibility = Visibility.Visible;
                prenomError.Text = "Vous devez entrez un prenom";
                erreur = true;
            }
            if (regexMat.IsMatch(tbMat.Text))
            {
                empValide.Visibility = Visibility.Collapsed;
                matError.Visibility = Visibility.Visible;
                matError.Text = "Le matricule entré doit être composé de chiffres";
                erreur = true;
            }
            if (regexNom.IsMatch(tbNom.Text))
            {
                empValide.Visibility = Visibility.Collapsed;
                nomError.Visibility = Visibility.Visible;
                nomError.Text = "Le nom entré doit être composé de lettres";
                erreur = true;
            }
            if (regexNom.IsMatch(tbPrenom.Text))
            {
                empValide.Visibility = Visibility.Collapsed;
                prenomError.Visibility = Visibility.Visible;
                prenomError.Text = "Le prenom entré doit être composé de lettres";
                erreur = true;
            }
            if (erreur == false)
            {
                matError.Visibility = Visibility.Collapsed;
                nomError.Visibility = Visibility.Collapsed;
                prenomError.Visibility = Visibility.Collapsed;

                Employe em = new Employe()
                {
                    Matricule = tbMat.Text,
                    Nom = tbNom.Text,
                    Prenom = tbPrenom.Text
                };

                if (GestionBD.getInstance().ajouterEmploye(em) > 0)
                {
                    empValide.Visibility = Visibility.Visible;

                }
                else
                {
                    empValide.Visibility = Visibility.Collapsed;
                    matError.Text = "Matricule entrez déjà existant";
                    matError.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
