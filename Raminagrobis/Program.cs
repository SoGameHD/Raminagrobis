using System;
using System.Collections.Generic;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis_Console
{
    class Program
    {
        static void Main(string[] args)
        {


            var depotFournisseurs = new FournisseursDepot_DAL();
            List<Fournisseurs_DAL> listeFournisseurs = depotFournisseurs.GetAll();

            var depotFournisseursAll = new FournisseursDepot_DAL();
            Fournisseurs_DAL FournisseursAvecID = depotFournisseursAll.GetByID(1);

            var depotFournisseurs2 = new FournisseursDepot_DAL();
            var Fournisseur = new Fournisseurs_DAL("ok", true, "Nom", "Prenom", "Email", "Adresse", false);

            depotFournisseurs2.Insert(Fournisseur);
            depotFournisseurs2.Delete(Fournisseur);
            
        }
    }
}