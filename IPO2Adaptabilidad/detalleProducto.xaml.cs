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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IPO2_Amazon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class detalleProducto : Page
    {
        private const int XLL = 60; private const int XL = 48; private const int L = 36; private const int M = 24; private const int S = 16;
        private const int r1 = 110; private const int r2 = 275; private const int lon = 585;
        Producto detaProd;
        public detalleProducto()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MyUserControl1_VisibleBoundsChanged;
        }

        private void MyUserControl1_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            var Height = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Height;
            if (Width < 1200 && Width > 900)
            {
                
                if (Height < lon)
                {
                    lbNombre.FontSize = L-6;
                    lbPrecio.FontSize = M;
                    lbT1.FontSize = M;
                    lbT2.FontSize = M;
                    lbT3.FontSize = S;
                    lbValoracion.FontSize = S;
                    txDescripcion.FontSize = M;
                    btComprar.FontSize = M-4;

                    img.Width = 150;
                    img.Height = 150;
                    Canvas.SetLeft(img, 40);

                    Canvas.SetLeft(lbNombre, 392 - r1);

                    Canvas.SetLeft(lbT1, 416 - r1);

                    Canvas.SetLeft(lbPrecio, 580 - r1);

                    Canvas.SetLeft(lbT2, 416 - r1);

                    txDescripcion.Width = 275;
                    Canvas.SetLeft(txDescripcion, 416 - r1);

                    Canvas.SetLeft(btComprar, 416 - r1-125);

                    Canvas.SetLeft(lbValoracion, 236 - r1);

                    Canvas.SetLeft(lbT3, 37);

                    Canvas.SetTop(img, 10);
                    Canvas.SetTop(lbNombre, 10);//-53
                    Canvas.SetTop(lbT1, 185 - r1-5);
                    Canvas.SetTop(lbPrecio, 183 - r1-5);
                    Canvas.SetTop(lbT2, 264 - r1-25);
                    txDescripcion.Height = 108;//121
                    Canvas.SetTop(txDescripcion, 333 - r1-48);
                    Canvas.SetTop(btComprar, 487 - r1-150);
                    Canvas.SetTop(lbValoracion, 357 - r1-60);
                    Canvas.SetTop(lbT3, 357 - r1-60);
                }
                else
                {
                    lbNombre.FontSize = L;
                    lbPrecio.FontSize = M;
                    lbT1.FontSize = M;
                    lbT2.FontSize = M;
                    lbT3.FontSize = S;
                    lbValoracion.FontSize = S;
                    txDescripcion.FontSize = M;
                    btComprar.FontSize = M;

                    img.Width = 200;
                    img.Height = 200;
                    Canvas.SetLeft(img, 40);

                    Canvas.SetLeft(lbNombre, 392 - r1);

                    Canvas.SetLeft(lbT1, 416 - r1);

                    Canvas.SetLeft(lbPrecio, 580 - r1);

                    Canvas.SetLeft(lbT2, 416 - r1);

                    txDescripcion.Width = 275;
                    Canvas.SetLeft(txDescripcion, 416 - r1);

                    Canvas.SetLeft(btComprar, 416 - r1);

                    Canvas.SetLeft(lbValoracion, 236 - r1);

                    Canvas.SetLeft(lbT3, 37);

                    Canvas.SetTop(img, 63);
                    Canvas.SetTop(lbNombre, 63);
                    Canvas.SetTop(lbT1, 185);
                    Canvas.SetTop(lbPrecio, 183);
                    Canvas.SetTop(lbT2, 264);
                    txDescripcion.Height = 121;
                    Canvas.SetTop(txDescripcion, 333);
                    Canvas.SetTop(btComprar, 487);
                    Canvas.SetTop(lbValoracion, 357);
                    Canvas.SetTop(lbT3, 357);
                }
            }
            else if (Width <= 900)
            {

                if (Height < lon)
                {
                    lbNombre.FontSize = M-4;
                    lbPrecio.FontSize = S;
                    lbT1.FontSize = S;
                    lbT2.FontSize = S;
                    lbT3.FontSize = S;
                    lbValoracion.FontSize = S;
                    txDescripcion.FontSize = S;
                    txDescripcion.Width = 150;
                    btComprar.FontSize = S;

                    img.Width = 80;
                    img.Height = 80;
                    Canvas.SetLeft(img, 15);

                    Canvas.SetLeft(lbNombre, 392 - r2);

                    Canvas.SetLeft(lbT1, 416 - r2);

                    Canvas.SetLeft(lbPrecio, 580 - r2 - 70);

                    Canvas.SetLeft(lbT2, 416 - r2-20);

                    txDescripcion.Width = 175;

                    Canvas.SetLeft(txDescripcion, 416 - r2);

                    Canvas.SetLeft(btComprar, 416 - r2);

                    Canvas.SetLeft(lbValoracion, 236 - r2 + 145);

                    Canvas.SetLeft(lbT3, 15);

                    Canvas.SetTop(img, 10);
                    Canvas.SetTop(lbNombre, 10);//-53
                    Canvas.SetTop(lbT1, 185 - r1-10);
                    Canvas.SetTop(lbPrecio, 183 - r1-10);
                    Canvas.SetTop(lbT2, 264 - r1-35);
                    txDescripcion.Height = 85;//121
                    Canvas.SetTop(txDescripcion, 333 - r1-65);
                    Canvas.SetTop(btComprar, 487 - r1-120);
                    Canvas.SetTop(lbValoracion, 357 - r1-65);
                    Canvas.SetTop(lbT3, 357 - r1-65);
                }
                else
                {
                    lbNombre.FontSize = M;
                    lbPrecio.FontSize = S;
                    lbT1.FontSize = S;
                    lbT2.FontSize = S;
                    lbT3.FontSize = S;
                    lbValoracion.FontSize = S;
                    txDescripcion.FontSize = S;
                    txDescripcion.Width = 150;
                    btComprar.FontSize = S;

                    img.Width = 80;
                    img.Height = 80;
                    Canvas.SetLeft(img, 15);

                    Canvas.SetLeft(lbNombre, 392 - r2);

                    Canvas.SetLeft(lbT1, 416 - r2);

                    Canvas.SetLeft(lbPrecio, 580 - r2 - 70);

                    Canvas.SetLeft(lbT2, 416 - r2);

                    txDescripcion.Width = 175;

                    Canvas.SetLeft(txDescripcion, 416 - r2);

                    Canvas.SetLeft(btComprar, 416 - r2);

                    Canvas.SetLeft(lbValoracion, 236 - r2 + 145);

                    Canvas.SetLeft(lbT3, 15);

                    Canvas.SetTop(img, 63);
                    Canvas.SetTop(lbNombre, 63);
                    Canvas.SetTop(lbT1, 185);
                    Canvas.SetTop(lbPrecio, 183);
                    Canvas.SetTop(lbT2, 264);
                    txDescripcion.Height = 121;
                    Canvas.SetTop(txDescripcion, 333);
                    Canvas.SetTop(btComprar, 487);
                    Canvas.SetTop(lbValoracion, 357);
                    Canvas.SetTop(lbT3, 357);
                }
            }
            else
            {  

                if (Height < lon)
                {
                    lbNombre.FontSize = XL-6;
                    lbPrecio.FontSize = L;
                    lbT1.FontSize = XL-10;
                    lbT2.FontSize = XL-10;
                    lbT3.FontSize = L-10;
                    lbValoracion.FontSize = L-10;
                    txDescripcion.FontSize = M;
                    btComprar.FontSize = L-8;

                    img.Width = 170;
                    img.Height = 170;
                    Canvas.SetLeft(img, 75);

                    Canvas.SetLeft(lbNombre, 392);

                    Canvas.SetLeft(lbT1, 416);

                    Canvas.SetLeft(lbPrecio, 580);

                    Canvas.SetLeft(lbT2, 416);

                    txDescripcion.Width = 441;
                    Canvas.SetLeft(txDescripcion, 416);

                    Canvas.SetLeft(btComprar, 416-170);

                    Canvas.SetLeft(lbValoracion, 236);

                    Canvas.SetLeft(lbT3, 37);

                    Canvas.SetTop(img, 10);
                    Canvas.SetTop(lbNombre, 10);//-53
                    Canvas.SetTop(lbT1, 185 - r1);
                    Canvas.SetTop(lbPrecio, 183 - r1);
                    Canvas.SetTop(lbT2, 264 - r1);
                    txDescripcion.Height = 75;//121
                    Canvas.SetTop(txDescripcion, 333 - r1-5);
                    Canvas.SetTop(btComprar, 487 - r1-140);
                    Canvas.SetTop(lbValoracion, 357 - r1-60);
                    Canvas.SetTop(lbT3, 357 - r1-60);
                }
                else
                {
                    lbNombre.FontSize = XLL;
                    lbPrecio.FontSize = XL;
                    lbT1.FontSize = XL;
                    lbT2.FontSize = XL;
                    lbT3.FontSize = L;
                    lbValoracion.FontSize = L;
                    txDescripcion.FontSize = L;
                    btComprar.FontSize = XL;

                    img.Width = 269;
                    img.Height = 261;
                    Canvas.SetLeft(img, 75);

                    Canvas.SetLeft(lbNombre, 392);

                    Canvas.SetLeft(lbT1, 416);

                    Canvas.SetLeft(lbPrecio, 580);

                    Canvas.SetLeft(lbT2, 416);

                    txDescripcion.Width = 441;
                    Canvas.SetLeft(txDescripcion, 416);

                    Canvas.SetLeft(btComprar, 416);

                    Canvas.SetLeft(lbValoracion, 236);

                    Canvas.SetLeft(lbT3, 37);

                    Canvas.SetTop(img, 63);
                    Canvas.SetTop(lbNombre, 63);
                    Canvas.SetTop(lbT1, 185);
                    Canvas.SetTop(lbPrecio, 183);
                    Canvas.SetTop(lbT2, 264);
                    txDescripcion.Height = 121;
                    Canvas.SetTop(txDescripcion, 333);
                    Canvas.SetTop(btComprar, 487);
                    Canvas.SetTop(lbValoracion, 357);
                    Canvas.SetTop(lbT3, 357);
                }
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.detaProd = e.Parameter as Producto;
            this.lbNombre.Text = detaProd.getNombre();
            this.lbPrecio.Text = detaProd.getPrecio().ToString();
            this.txDescripcion.Text = detaProd.getDescripcion();
            this.lbValoracion.Text = detaProd.getPuntuacion().ToString();
            this.img.Source = new BitmapImage(new Uri(detaProd.getImagen()));
        }

        private void NotificacionesCompra()
        {
            new ToastContentBuilder()
           .AddArgument("action", "Favoritos")
           .AddArgument("conversationId", 1)
           .AddText("Compra Realizada")
           .AddInlineImage(new Uri(detaProd.getImagen()))
           .AddText("La compra del articulo " + detaProd.getNombre() + " se ha realizado con exito.")
           .Show();
        }

        private void btComprar_Click_1(object sender, RoutedEventArgs e)
        {
            NotificacionesCompra();
            this.Frame.GoBack();
        }
    }
}
