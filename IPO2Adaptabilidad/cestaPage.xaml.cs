using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IPO2_Amazon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Cesta : Page
    {
        BBDD bbdd;
        double suma = 0;
        SolidColorBrush colorRojo = new SolidColorBrush(Windows.UI.Colors.Red);
        private const int L = 48; private const int M = 36; private const int S = 20; private const int XS = 15;
        public Cesta()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MyUserControl1_VisibleBoundsChanged;
        }

        private void MyUserControl1_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            if (Width < 1100 && Width >= 500)
            {
                lbTotal.FontSize = M;
                tbCantidad.FontSize = S;
            }
            else if (Width < 500)
            {
                lbTotal.FontSize = S;
                tbCantidad.FontSize = XS;
            }
            else
            {
                lbTotal.FontSize = L;
                tbCantidad.FontSize = M;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.bbdd = e.Parameter as BBDD;
            ArrayList cesta = new ArrayList();
            cesta = bbdd.getCesta();
            foreach (Producto pr in cesta)
            {
                productoCesta use1 = new productoCesta(bbdd);
                use1.nProdCesta = pr;
                use1.textoProducto = pr.getNombre();
                use1.textoPrecio = pr.getPrecio().ToString() + "$";
                use1.imgCesta = pr.getImagen();
                this.suma = pr.getPrecio() + this.suma;
                if (pr.getPulsado())
                {
                    use1.corazonColor = this.colorRojo;
                }
                gridProdCesta.Items.Add(use1);
            }
            this.tbCantidad.Text = this.suma.ToString() + "$";
        }


    }
}
