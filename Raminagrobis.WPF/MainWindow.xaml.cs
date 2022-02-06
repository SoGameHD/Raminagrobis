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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }





        private void BtnAdherent(object sender, RoutedEventArgs e)
        {


            if (GestionnaireDeFenetres.Adherents == null)
            {
                GestionnaireDeFenetres.Adherents = new Adherents();
            }
            Main.Navigate(GestionnaireDeFenetres.Adherents);
        }



        private void BtnFournisseur(object sender, RoutedEventArgs e)
        {


            if (GestionnaireDeFenetres.Fournisseur == null)
            {
                GestionnaireDeFenetres.Fournisseur = new Fournisseur();
            }
            Main.Navigate(GestionnaireDeFenetres.Fournisseur);
        }


        private void BtnLignesAdherents(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.LignesAdherents == null)
            {
                GestionnaireDeFenetres.LignesAdherents = new LignesAdherents();
            }
            Main.Navigate(GestionnaireDeFenetres.LignesAdherents);
        }

        private void BtnLignesGlobal(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.LignesGlobal == null)
            {
                GestionnaireDeFenetres.LignesGlobal = new LignesGlobal();
            }
            Main.Navigate(GestionnaireDeFenetres.LignesGlobal);
        }

        private void BtnProduits(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Produits == null)
            {
                GestionnaireDeFenetres.Produits = new Produits();
            }
            Main.Navigate(GestionnaireDeFenetres.Produits);
        }

        private void BtnProposition(object sender, RoutedEventArgs e)
        {
            if (GestionnaireDeFenetres.Proposition == null)
            {
                GestionnaireDeFenetres.Proposition = new Proposition();
            }
            Main.Navigate(GestionnaireDeFenetres.Proposition);
        }

    }
}