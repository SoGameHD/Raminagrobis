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
    /// Logique d'interaction pour AdherentUpdate.xaml
    /// </summary>
    public partial class AdherentUpdate : Page
    {
        public AdherentUpdate()
        {
            InitializeComponent();
        }

        public void UpdateAdherent(object sender, RoutedEventArgs e)
        {
            var apiclient = new Client("https://localhost:44355/", new HttpClient());
            Adherent_DTO adherent = new Adherent_DTO()
            {

            };
        }
    }
}
