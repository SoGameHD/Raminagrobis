using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour Produits.xaml
    /// </summary>
    public partial class Produits : Page
    {
        #region Produits
        public Produits()
        {
            InitializeComponent();
        }
        #endregion

        #region BtnGetAll
        private void BtnGetAll(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            List<Produit> items = new List<Produit>();
            items.Add(new Produit() { Reference = "Hey", Libelle = "ho", Marque = " Hoy", Actif = true, ID = 1 });
            lvProduits.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvProduits.ItemsSource);
        }
        #endregion

        #region Produit
        public class Produit
        {
            public string Reference { get; set; }
            public string Libelle { get; set; }
            public string Marque { get; set; }
            public bool Actif { get; set; }
            public int ID { get; set; }
        }
        #endregion
    }
}