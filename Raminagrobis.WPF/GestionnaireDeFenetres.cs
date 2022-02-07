using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.WPF
{
    static class GestionnaireDeFenetres
    {
        static public MainWindow MainWindow { get; set; }

        static public Adherents Adherents { get; set; }
        static public Fournisseur Fournisseur { get; set; }
        static public LignesAdherents LignesAdherents { get; set; }
        static public LignesGlobal LignesGlobal { get; set; }
        static public Produits Produits { get; set; }
        static public Proposition Proposition { get; set; }
    }
}