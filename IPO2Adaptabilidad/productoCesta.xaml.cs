using Microsoft.Toolkit.Uwp.Notifications;
using System;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPO2_Amazon
{
    public sealed partial class productoCesta : UserControl
    {
        private const int L = 24; private const int M = 20; private const int S = 15;
        BBDD bbdd;
        Producto prodCesta;

        public productoCesta(BBDD bbdd)
        {
            this.InitializeComponent();
            this.bbdd = bbdd;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MyUserControl1_VisibleBoundsChanged;
        }

        private void MyUserControl1_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width < 1100 && Width >=500)
            {
                lbNombre.FontSize = 14;
                lbPrecio.FontSize = 14;
                lbT1.FontSize = 14;
                lbT2.FontSize = 14;
                
                RelativePanel.SetBelow(lbNombre, null);
                RelativePanel.SetRightOf(lbNombre, lbT1);
                RelativePanel.SetAlignVerticalCenterWith(lbNombre, lbT1);
                lbNombre.Margin = new Thickness(10, 0, 0, 0);
                lbT1.Margin = new Thickness(0);

            }
            else if (Width < 500)
            {
                RelativePanel.SetRightOf(lbNombre, null);
                RelativePanel.SetBelow(lbNombre, lbT1);
                RelativePanel.SetAlignVerticalCenterWith(lbNombre, null);
                lbNombre.Margin = new Thickness(205, 0, 0, 0);
                lbT1.Margin = new Thickness(0, 0, 50, 0);

            }
            else
            {
                lbNombre.FontSize = 24;
                lbPrecio.FontSize = 24;
                lbT1.FontSize = 24;
                lbT2.FontSize = 24;
            }
        }
        
        private void pulsaCorazon(object sender, PointerRoutedEventArgs e)
        {
            Marcarfavorito();
        }

        private void Marcarfavorito()
        {
            if (prodCesta.getPulsado())
            {
                Storyboard sbNoMegusta = (Storyboard)this.Resources["nomegusta"];
                sbNoMegusta.Begin();
                prodCesta.setPulsado(false);
                this.bbdd.eliminarFavorito(lbNombre.Text);
            }
            else
            {
                Storyboard sbMegusta = (Storyboard)this.Resources["megusta"];
                sbMegusta.Begin();
                prodCesta.setPulsado(true);
                Notificaciones();
                this.bbdd.anadirFav(lbNombre.Text);
            }
        }

        public string textoProducto
        {
            get
            {
                return this.lbNombre.Text;
            }
            set
            {
                this.lbNombre.Text = value;
            }
        }
        public string textoPrecio
        {
            get
            {
                return this.lbPrecio.Text;
            }
            set
            {
                this.lbPrecio.Text = value;
            }
        }
        public string imgCesta
        {
            get
            {
                return this.img.Source.ToString();
            }
            set
            {
                this.img.Source = new BitmapImage(uriSource: new Uri(value)); ;
            }
        }
        public Brush corazonColor
        {
            get
            {
                return null;
            }
            set
            {
                this.path.Fill = value;
            }
        }
        public Producto nProdCesta
        {
            get
            {
                return null;
            }
            set
            {
                this.prodCesta = value;
            }
        }

        private void Notificaciones()
        {
            new ToastContentBuilder()
           .AddArgument("action", "Favoritos")
           .AddArgument("conversationId", 1)
           .AddText("Marcado como Favorito")
           .AddInlineImage(new Uri(prodCesta.getImagen()))
           .AddText("Su producto se ha añadido a la ventana de Favoritos")
           .Show();
        }

        private void NotificacionesCesta()
        {
            new ToastContentBuilder()
           .AddArgument("action", "Eliminado Cesta")
           .AddArgument("conversationId", 1)
           .AddText("Eliminado de la cesta")
           .AddInlineImage(new Uri(prodCesta.getImagen()))
           .AddText("Su producto se ha eliminado de la cesta con exito")
           .Show();
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.bbdd.eliminarCesta(lbNombre.Text);
            NotificacionesCesta();
        }
    }
}
