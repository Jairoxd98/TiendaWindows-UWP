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
    public sealed partial class catalogoPage : Page
    {
        BBDD bbdd;
        SolidColorBrush colorRojo = new SolidColorBrush(Windows.UI.Colors.Red);

        public catalogoPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.bbdd = e.Parameter as BBDD;
            ArrayList catalogo = new ArrayList();
            catalogo = bbdd.getProductos();
            foreach (Producto pr in catalogo)
            {
                MyUserControl1 use1 = new MyUserControl1(bbdd);
                use1.nuestroProducto = pr;
                use1.textoProducto = pr.getNombre();
                use1.textoPrecio = pr.getPrecio().ToString() + "$";
                use1.imgProducto = pr.getImagen();
                use1.estrellas = pr.getPuntuacion();
                use1.nuestroCatalogo = getCatalogo();
                if (pr.getPulsado())
                {
                    use1.corazonColor = this.colorRojo;
                }
                gridProductos.Items.Add(use1);
            }
        }
        public Frame getCatalogo()
        {
            return this.Frame;
        }
    }
}
