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
    /// Logique d'interaction pour LignesAdherents.xaml
    /// </summary>
    public partial class LignesAdherents : Page
    {
        #region LignesAdherents
        public LignesAdherents()
        {
            InitializeComponent();
        }
        #endregion

        #region BtnGetAll
        private void BtnGetAll(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            List<LigneAdherent> items = new List<LigneAdherent>();
            items.Add(new LigneAdherent() { ID_ligne_global = 1, Quantite = 2, ID_produit = 2, ID_commande = 3 });
            lvLigneAdherents.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvLigneAdherents.ItemsSource);
        }
        #endregion

        #region LignesAdherent
        public class LigneAdherent
        {
            public int ID_ligne_global { get; set; }
            public int Quantite { get; set; }
            public int ID_produit { get; set; }
            public int ID_commande { get; set; }
        }
        #endregion
    }
}