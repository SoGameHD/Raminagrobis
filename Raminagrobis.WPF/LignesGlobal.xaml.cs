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
    /// Logique d'interaction pour LignesGlobal.xaml
    /// </summary>
    public partial class LignesGlobal : Page
    {
        public LignesGlobal()
        {
            InitializeComponent();
        }

        private void BtnListe(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            List<LigneGlobal> items = new List<LigneGlobal>();
            items.Add(new LigneGlobal() { ID = 1, ID_panier = 2, ID_produit = 3, Quantite = 4 });
            lvLigneGlobal.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvLigneGlobal.ItemsSource);

        }

        public class LigneGlobal
        {
            public int ID_panier { get; set; }
            public int Quantite { get; set; }
            public int ID_produit { get; set; }
            public int ID { get; set; }

        }
    }
}