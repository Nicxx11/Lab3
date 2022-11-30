using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace lab3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        internal static ObservableCollection<Projet> ListeProjet = new ObservableCollection<Projet>();
        internal static ObservableCollection<Employe> ListeEmploye = new ObservableCollection<Employe>();


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
                    mainFrame.Navigate(typeof(RechercheEmp));
                    break;
                case "RechProj":
                    tblHeader.Text = "Recherche de projet";
                    mainFrame.Navigate(typeof(RechercheProj));
                    break;
            }
        }

    }
}
