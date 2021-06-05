using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO2_Amazon
{
    public class BBDD
    {
        ArrayList listaProductos = new ArrayList();
        ArrayList listaFavoritos = new ArrayList();
        ArrayList listaCesta = new ArrayList();
        ArrayList lstces = new ArrayList();
        ArrayList lstfav = new ArrayList();
        Producto elim;
        Producto elimCesta;

        Producto p1 = new Producto(1, "Reloj", 50.00, "ms-appx:///Assets/reloj.jpg", 1, false, "Reloj con correa de cuero");
        Producto p2 = new Producto(2, "Camiseta", 30.99, "ms-appx:///Assets/camiseta.jpg", 2, false, "Camiseta 100% algodon");
        Producto p3 = new Producto(3, "Pantalon", 49.99, "ms-appx:///Assets/pantalon.jpg", 3, false, "Pantalon 100% poliester");
        Producto p4 = new Producto(4, "Telefono", 550.00, "ms-appx:///Assets/telefono.jpg", 4, false, "Telefono fabricado por Apple");
        Producto p5 = new Producto(5, "Colgante", 15.00, "ms-appx:///Assets/colgante.jpg", 5, false, "Colgante de oro macizo");
        Producto p6 = new Producto(6, "Gorra", 30.00, "ms-appx:///Assets/gorra.jpg", 1, false, "Gorra 100% algodon");
        Producto p7 = new Producto(7, "Pendientes", 100.00, "ms-appx:///Assets/pendiente.jpg", 2, false, "Pendiente de oro con gemas");
        Producto p8 = new Producto(8, "Ordenador", 2000.00, "ms-appx:///Assets/ordenador.jpg", 2, false, "Ordenador fabricado por Apple");
        Producto p9 = new Producto(9, "Playstation", 500.00, "ms-appx:///Assets/play.jpg", 3, false, "Play fabricada por Sony");

        public BBDD()
        {
            rellenarDatos();
        }

        public void rellenarDatos()
        {
            listaProductos.Add(p1);
            listaProductos.Add(p2);
            listaProductos.Add(p3);
            listaProductos.Add(p4);
            listaProductos.Add(p5);
            listaProductos.Add(p6);
            listaProductos.Add(p7);
            listaProductos.Add(p8);
            listaProductos.Add(p9);
            listaCesta.Add(p1);
            listaCesta.Add(p2);
            lstces.Add(p1);
            lstces.Add(p2);
        }

        public ArrayList getProductos()
        {
            return listaProductos;
        }

        public ArrayList getFavoritos()
        {
            return listaFavoritos;
        }

        public ArrayList getCesta()
        {
            return listaCesta;
        }

        public void eliminarCesta(string pces)
        {
            
            foreach (Producto pro in lstces)
            {
                if (pro.getNombre().Equals(pces))
                {
                    
                    listaCesta.Remove(pro);
                    elimCesta = pro;
                }
            }
            this.lstces.Remove(this.elimCesta);
        }

        public void anadirFav(string fav)
        {
            Boolean noexiste = true;
            foreach (Producto p in this.listaFavoritos)
            {
                if (p.getNombre().Equals(fav))
                {
                    noexiste = false;
                }
            }

            foreach (Producto pr in listaProductos)
            {
                if (pr.getNombre().Equals(fav) && noexiste)
                {
                    listaFavoritos.Add(pr);
                    lstfav.Add(pr);
                }
            }
        }

        public void eliminarFavorito(string fav)
        {
            foreach (Producto pr in lstfav)
            {
                if (pr.getNombre().Equals(fav))
                {
                    listaFavoritos.Remove(pr);
                    elim = pr;
                }
            }
            this.lstfav.Remove(this.elim);
        }
    }
}
