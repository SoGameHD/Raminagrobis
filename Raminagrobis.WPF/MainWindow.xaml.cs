using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Raminagrobis.API.Client;
using Raminagrobis.DTO;

namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region MainWindow
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadPage
        private async void LoadPage(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:/44345", new HttpClient());
            GestionnaireDeFenetres.MainWindow = this;
        }
        #endregion

        #region BtnAdherent
        private void BtnAdherent(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Adherents == null)
            {
                GestionnaireDeFenetres.Adherents = new Adherents();
            }
            Main.Navigate(GestionnaireDeFenetres.Adherents);
        }
        #endregion

        #region BtnFournisseur
        private void BtnFournisseur(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Fournisseur == null)
            {
                GestionnaireDeFenetres.Fournisseur = new Fournisseur();
            }
            Main.Navigate(GestionnaireDeFenetres.Fournisseur);
        }
        #endregion

        #region BtnProduits
        private void BtnProduits(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Produits == null)
            {
                GestionnaireDeFenetres.Produits = new Produits();
            }
            Main.Navigate(GestionnaireDeFenetres.Produits);
        }
        #endregion

        #region BtnProposition
        private void BtnProposition(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Proposition == null)
            {
                GestionnaireDeFenetres.Proposition = new Proposition();
            }
            Main.Navigate(GestionnaireDeFenetres.Proposition);
        }
        #endregion
    }
}