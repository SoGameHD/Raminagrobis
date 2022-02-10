using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Raminagrobis.API.Client;

namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour Adherents.xaml
    /// </summary>
    public partial class Adherents : Page
    {
        #region Adherent
        public Adherents()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadPage
        private async void LoadPage(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:/44345", new HttpClient());
            var adherent = await apiclient.AdherentAllAsync();
           
            lvAdherents.ItemsSource = adherent;
        }
        #endregion

        /*
        #region BtnInsert
        private void BtnInsert(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:/44345", new HttpClient());
            Adherent_DTO adherent_DTO = new Adherent_DTO();
            adherent_DTO.Societe = InputSociete.Text;
            adherent_DTO.Civilite = InputCivilite.AcceptsReturn;
            adherent_DTO.Nom = InputNom.Text;
            adherent_DTO.Prenom = InputNom.Text;
            adherent_DTO.Email = InputEmail.Text;
            //TODO : Ajouter Date_Adhesion / Actif

            apiclient.AdherentPOSTAsync(adherent_DTO);
        }
        #endregion
        */
    }
}