using System;
using System.Collections.Generic;
using Raminagrobis.DAL;

namespace Raminagrobis
{
    class Program
    {
        static void Main(string[] args)
        {
            var depot_adherent = new AdherentDepot_DAL();
            List<Adherent_DAL> listeAdherent = depot_adherent.GetAll();

            var depot_produits = new ProduitsDepot_DAL();
            List<Produits_DAL> listeProduits = depot_produits.GetAll();

            //var depot_produits_ID = new ProduitsDepot_DAL();
            //Produits_DAL ProduitsByID = depot_produits_ID.GetByID(1);

            var depot_produits_test = new ProduitsDepot_DAL();
            var Produits = new Produits_DAL("Test", "OK", "Valide", false);

            //depot_produits_testt.Insert(Produits);
            depot_produits_test.Delete(Produits)  ;
        }
    }
}