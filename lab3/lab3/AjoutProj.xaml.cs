// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace lab3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutProj : Page
    {
        public AjoutProj()
        {
            this.InitializeComponent();
            CbEmploye.ItemsSource = GestionBD.getInstance().getEmploye();
        }

        private void btnAjoutProjet_Click(object sender, RoutedEventArgs e)
        {
            var regexNum = new Regex(@"[a-zA-z]+");
            bool erreur = false;

            numError.Visibility = Visibility.Collapsed;
            dateError.Visibility = Visibility.Collapsed;
            budgetError.Visibility = Visibility.Collapsed;
            descError.Visibility = Visibility.Collapsed;
            employeError.Visibility = Visibility.Collapsed;

            if (tbNum.Text.Length > 14 || tbNum.Text == "")
            {
                numError.Visibility = Visibility.Visible;
                numError.Text = "Numero de projet invalide. Longueur entre 1 et 14 caracteres";
                erreur = true;
            }
            if (regexNum.IsMatch(tbBudget.Text))
            {
                budgetError.Visibility = Visibility.Visible;
                budgetError.Text = "Le budget doit contenir une valeur numerique";
                erreur = true;
            }
            else if (Int32.Parse(tbBudget.Text) < 10000 || tbBudget.Text == "")
            {
                budgetError.Visibility = Visibility.Visible;
                budgetError.Text = "Le budget doit être au dessus de 10 000$";
                erreur = true;
            }
            else if (Int32.Parse(tbBudget.Text) > 100000)
            {
                budgetError.Visibility = Visibility.Visible;
                budgetError.Text = "Le budget doit être sous 100 000$";
                erreur = true;
            }
            else if (tbBudget.Text.Length > 6)
            {
                budgetError.Visibility = Visibility.Visible;
                budgetError.Text = "Le budget doit être sous 100 000$";
                erreur = true;
            }
            if (cdp.Date.Value.ToString() == "")
            {
                dateError.Visibility = Visibility.Visible;
                dateError.Text = "Selectionnez une date";
                erreur = true;
            }
            if (tbDesc.Text.Length > 200)
            {
                descError.Visibility = Visibility.Visible;
                descError.Text = "Maximum 200 caracteres";
                erreur = true;
            }
            //AJOUTER ERREUR EMPLOYE SI AUCUN SELECTIONNER COMBO BOX!!!

            if (erreur == false)
            { 
                Projet pr = new Projet()
                {
                    Numero = tbNum.Text,
                    DateDebut = cdp.Date.Value.ToString("yyyy-MM-dd"),
                    Budget = Int32.Parse(tbBudget.Text),
                    Description = tbDesc.Text,
                    Employe = CbEmploye.SelectedItem.ToString(),
                };

                if (GestionBD.getInstance().ajouterProjet(pr) > 0)
                {
                    projetValide.Visibility = Visibility.Visible;

                }
                else
                {
                    projetValide.Visibility = Visibility.Collapsed;
                    numError.Visibility = Visibility.Visible;
                    numError.Text = "Numero de projet deja existant";
                }
            }
        }

      
    }
}
