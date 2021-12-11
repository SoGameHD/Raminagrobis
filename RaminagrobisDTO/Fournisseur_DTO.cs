using System;

namespace Raminagrobis.DTO
{
    public class Fournisseur_DTO
    {
        public string Societe { get; set; }
        public bool Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public bool Actif { get; set; }
        public int? ID { get; set; }
    }
}
