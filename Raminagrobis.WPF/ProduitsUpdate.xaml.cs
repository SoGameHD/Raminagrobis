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
    public partial class ProduitsUpdate : Page
    {
        #region ProduitsUpdate
        public ProduitsUpdate(Produits_DTO produits)
        {
            InitializeComponent();
            this.UpdateReference.Text = produits.Reference;
            this.UpdateLibelle.Text = produits.Libelle;
            this.UpdateMarque.Text = produits.Marque;
            this.UpdateActif.Text = produits.Actif.ToString();
            this.ID.Text = produits.ID.ToString();
        }
        #endregion

        #region BtnUpdate
        public void BtnUpdate(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:44355/", new HttpClient());
            Produits_DTO produits = new Produits_DTO()
            {
                Reference = this.UpdateReference.Text,
                Libelle = this.UpdateLibelle.Text,
                Marque = this.UpdateMarque.Text,
                Actif = Boolean.Parse(this.UpdateActif.Text),
            };

            apiclient.ProduitsPUTAsync(Int32.Parse(this.ID.Text), produits);
        }
        #endregion
    }
}
