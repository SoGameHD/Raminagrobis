using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Net.Http;
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
    /// Logique d'interaction pour Fournisseur.xaml
    /// </summary>
    public partial class Fournisseur : Page
    {
        #region Fournisseur
        public Fournisseur()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadPage
        private async void LoadPage(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:/44345", new HttpClient());
            var fournisseur = await apiclient.AdherentAllAsync();

            lvFournisseurs.ItemsSource = fournisseur;
        }
        #endregion

        /*
        

        #region BtnGetAll
        private void BtnGetAll(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User() { Societe = "John Doe", Civilite = true, Nom = "Nizae", Prenom = "Jean", Email = "Jean@gmail.com", Adresse = "Ici", ID = 3, Actif = true });

            lvFournisseurs.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvFournisseurs.ItemsSource);
        }
        #endregion
        */
    }
}