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
    /// Logique d'interaction pour Fournisseur.xaml
    /// </summary>
    public partial class Fournisseur : Page
    {
        public Fournisseur()
        {
            InitializeComponent();
        }

        private void BtnAdd(object sender, RoutedEventArgs e)
        {
            Liste.Text = "Il y a bcp de fournisseurs";
            OutputSociete.Text = InputFournisseursSociete.Text;
            InputFournisseursCivilite.Text = "Civilite";
            InputFournisseursEmail.Text = "Email";
            InputFournisseursNom.Text = "Nom";
            InputFournisseursPrenom.Text = "Prenom";
            InputFournisseursSociete.Text = "Societe";
        }

        private void BtnSupprimer(object sender, RoutedEventArgs e)
        {

        }

        private void BtnListe(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User() { Societe = "John Doe", Civilite = true, Nom = "Nizae", Prenom = "Jean", Email = "Jean@gmail.com", Adresse = "Ici", ID = 3, Actif = true });

            lvFournisseurs.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvFournisseurs.ItemsSource);

        }

        public class User
        {
            public int ID { get; set; }
            public string Societe { get; set; }
            public bool Civilite { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Email { get; set; }
            public string Adresse { get; set; }
            public bool Actif { get; set; }

        }
    }
}