using Microsoft.Toolkit.Uwp.Notifications;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPO2_Amazon
{
    public sealed partial class MyUserControl1 : UserControl
    {
        BBDD bbdd;
        Producto productoUser;
        Frame fr = new Frame();

        public MyUserControl1(BBDD bbdd)
        {
            this.InitializeComponent();
            this.bbdd = bbdd;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MyUserControl1_VisibleBoundsChanged;
        }
        private void MyUserControl1_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width <= 420)
            {
                lbNombre.FontSize = 14;
                lbPrecio.FontSize = 14;
            }
            else
            {
                lbNombre.FontSize = 24;
                lbPrecio.FontSize = 24;
            }
        }

        public Frame nuestroCatalogo
        {
            get
            {
                return null;
            }
            set
            {
                this.fr = value;
            }
        }

        private void Marcarfavorito()
        {
            if (productoUser.getPulsado())
            {
                Storyboard sbNoMegusta = (Storyboard)this.Resources["nomegusta"];
                sbNoMegusta.Begin();
                productoUser.setPulsado(false);
                this.bbdd.eliminarFavorito(lbNombre.Text);
            }
            else
            {
                Storyboard sbMegusta = (Storyboard)this.Resources["megusta"];
                sbMegusta.Begin();
                productoUser.setPulsado(true);
                Notificaciones();
                this.bbdd.anadirFav(lbNombre.Text);
            }
        }
        private void pulsaCorazon(object sender, PointerRoutedEventArgs e)
        {
            Marcarfavorito();
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
        public double estrellas
        {
            get
            {
                return this.rating.Value;
            }
            set
            {
                this.rating.Value = value;
            }
        }
        public string imgProducto
        {
            get
            {
                return this.imgProductos.Source.ToString();
            }
            set
            {
                this.imgProductos.Source = new BitmapImage(uriSource: new Uri(value)); ;
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

        public Producto nuestroProducto
        {
            get
            {
                return null;
            }
            set
            {
                this.productoUser = value;
            }
        }

        private void Notificaciones()
        {
            new ToastContentBuilder()
           .AddArgument("action", "Favoritos")
           .AddArgument("conversationId", 1)
           .AddText("Marcado como Favorito")
           .AddInlineImage(new Uri(productoUser.getImagen()))
           .AddText("Su producto se ha añadido a la ventana de Favoritos")
           .Show();
        }

        private void irDetalle(object sender, TappedRoutedEventArgs e)
        {
            this.fr.Navigate(typeof(detalleProducto), this.productoUser);
        }

        private void cestaPulsa(object sender, PointerRoutedEventArgs e)
        {
            PulsaCesta();
        }

        private void PulsaCesta()
        {
            
            Storyboard sbCesta = (Storyboard)this.Resources["carrito"];
            sbCesta.Begin();
            
        }
    }
}
