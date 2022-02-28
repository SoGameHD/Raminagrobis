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
using Raminagrobis.DTO.DTO;

namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour FournisseurDelete.xaml
    /// </summary>
    public partial class FournisseurInsert : Page
    {
        #region InitializeComponent
        public FournisseurInsert()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadPage
        private async void LoadPage(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:/44345", new HttpClient());
            var adherent = await apiclient.FournisseursGetAsync();
        }
        #endregion

        #region BtnInsert
        private void BtnInsert(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:/44345", new HttpClient());
            Fournisseur_DTO fournisseur_DTO = new Fournisseur_DTO();
            fournisseur_DTO.Societe = InputSociete.Text;
            fournisseur_DTO.Civilite = InputCivilite.AcceptsReturn;
            fournisseur_DTO.Nom = InputNom.Text;
            fournisseur_DTO.Prenom = InputPrenom.Text;
            fournisseur_DTO.Email = InputEmail.Text;
            fournisseur_DTO.Adresse = InputAdresse.Text;
            fournisseur_DTO.Actif = InputActif.AcceptsReturn;

            apiclient.FournisseursPostAsync(fournisseur_DTO);
        }
        #endregion

    }
}
