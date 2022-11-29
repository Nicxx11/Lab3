﻿using Microsoft.UI.Xaml;
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
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Protection.PlayReady;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace lab3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "AjoutEmp":
                    tblHeader.Text = "Ajout d'employé";
                    mainFrame.Navigate(typeof(AjoutEmp));
                    break;
                case "AjoutProj":
                    tblHeader.Text = "Ajout de projet";
                    mainFrame.Navigate(typeof(AjoutProj));
                    break;
                case "RechEmp":
                    tblHeader.Text = "Recherche d'employé";
                    //mainFrame.Navigate(typeof(Agenda));
                    break;
                case "RechProj":
                    tblHeader.Text = "Recherche de projet";
                    //mainFrame.Navigate(typeof(Agenda));
                    break;
            }
        }

    }
}