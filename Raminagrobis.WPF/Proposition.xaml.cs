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
    /// Logique d'interaction pour Proposition.xaml
    /// </summary>
    public partial class Proposition : Page
    {
        #region Proposition
        public Proposition()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadWindow
        private async void LoadWindow(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:/44345", new HttpClient());
            var proposition = await apiclient.AdherentAllAsync();

            lvProposition.ItemsSource = proposition;
        }
        #endregion

        #region BtnGetAll
        private void BtnGetAll(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            List<UneProposition> items = new List<UneProposition>();
            items.Add(new UneProposition() { Prix = 4, ID_ligne_global = 2, ID_fournisseur = 3 });
            lvProposition.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvProposition.ItemsSource);
        }
        #endregion
    }
}