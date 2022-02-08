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
    /// Logique d'interaction pour Adherents.xaml
    /// </summary>
    public partial class Adherents : Page
    {
        public Adherents()
        {
            InitializeComponent();
        }

        private void BtnAdd(object sender, RoutedEventArgs e)
        {
            Liste.Text = "Il y a bcp d'adhérents";
            OutputSociete.Text = InputAdherentsSociete.Text;
            InputAdherentsCivilite.Text = "Civilite";
            InputAdherentsEmail.Text = "Email";
            InputAdherentsNom.Text = "Nom";
            InputAdherentsPrenom.Text = "Prenom";
            InputAdherentsSociete.Text = "Societe";
        }

        private void BtnSupprimer(object sender, RoutedEventArgs e)
        {

        }

        private void BtnListe(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User() { Societe = "John Doe", Civilite = true, Nom = "Nizae", Prenom = "Jean", Email = "Jean@gmail.com", Date_adhesion = DateTime.Now.Date, ID = 3 });
            items.Add(new User() { Societe = "John Doe", Civilite = false, Nom = "Nizae", Prenom = "Jean", Email = "Jean@gmail.com", Date_adhesion = DateTime.Now.Date });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now.Date });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now.Date });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now.Date });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now.Date });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now.Date });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now });
            items.Add(new User() { Societe = "Hey ho", Civilite = true, Nom = "Nizae", Prenom = "Hiez", Email = "zea@gmail.com", Date_adhesion = DateTime.Now });
            lvAdherents.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvAdherents.ItemsSource);

        }

        public class User
        {
            public int ID { get; set; }
            public string Societe { get; set; }
            public Boolean Civilite { get; set; }
            //TODO
            //Faire une modif pour que civilite change selon true ou false et met une valeur non bool
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Email { get; set; }
            public DateTime Date_adhesion { get; set; }
        }

    }
}