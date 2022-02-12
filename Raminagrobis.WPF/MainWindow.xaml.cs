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
using Raminagrobis.DTO.DTO;

namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region InitializeComponent
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadPage
        private void LoadPage(object sender, RoutedEventArgs e)
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

        #region BtnPaniers
        private void BtnPaniers(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Paniers == null)
            {
                GestionnaireDeFenetres.Paniers = new Paniers();
            }
            Main.Navigate(GestionnaireDeFenetres.Paniers);
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

        #region BtnInsert
        private void BtnInsert(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(Adherents))
                {
                    Main.Content = new AdherentInsert();
                }
                if (Main.Content.GetType() == typeof(Fournisseur))
                {
                    Main.Content = new FournisseurInsert();
                }
                if (Main.Content.GetType() == typeof(Paniers))
                {
                    //Main.Content = new PaniersInsert();
                }
                if (Main.Content.GetType() == typeof(Produits))
                {
                    Main.Content = new ProduitsInsert();
                }
            }
        }
        #endregion

        #region BtnUpdate
        private void BtnUpdate(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(Adherents))
                {
                    Main.Content = new AdherentUpdate();
                }
                if (Main.Content.GetType() == typeof(Fournisseur))
                {
                    Main.Content = new FournisseurUpdate();
                }
                if (Main.Content.GetType() == typeof(Paniers))
                {
                    //Main.Content = new PaniersUpdate();
                }
                if (Main.Content.GetType() == typeof(Produits))
                {
                    Main.Content = new ProduitsUpdate();
                }
            }
        }
        #endregion

        #region BtnDelete
        private void BtnDelete(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(Adherents))
                {
                    Main.Content = new AdherentDelete();
                }
                if (Main.Content.GetType() == typeof(Fournisseur))
                {
                    Main.Content = new FournisseurDelete();
                }
                if (Main.Content.GetType() == typeof(Paniers))
                {
                    //Main.Content = new PaniersDelete();
                }
                if (Main.Content.GetType() == typeof(Produits))
                {
                    Main.Content = new ProduitsDelete();
                }
            }
        }
        #endregion
    }
}