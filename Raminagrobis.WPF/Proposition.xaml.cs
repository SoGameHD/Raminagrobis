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

        #region UneProposition
        public class UneProposition
        {
            public int Prix { get; set; }
            public int ID_ligne_global { get; set; }
            public int ID_fournisseur { get; set; }
        }
        #endregion
    }
}