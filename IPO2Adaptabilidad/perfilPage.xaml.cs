using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class perfilPage : Page
    {
        private const int L = 25; private const int M = 20; private const int S = 15; private const int XS = 10; private const int lon = 550;

        public perfilPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MyUserControl1_VisibleBoundsChanged;
        }

        private void MyUserControl1_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            var Height = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Height;
            Thickness marginThickness = imPerfil.Margin;
            Thickness marginThickness2 = gridUser.Margin;

            if (Width < 1350 && Width>900)
            {
                if (Height <= lon)
                {
                    imPerfil.Height = 96;
                    imPerfil.Width = 86;
                    imPerfil.Margin = new Thickness(10);
                    gridUser.Margin = new Thickness(0, 0, 186, 360);
                }
                else
                {
                    imPerfil.Height = 196;
                    imPerfil.Width = 186;
                    imPerfil.Margin = new Thickness(30,60,60,0);
                    gridUser.Margin = new Thickness(0, 200, 356, 236);
                }

                gridUser.Width = 645;

                gridUser.HorizontalAlignment = (HorizontalAlignment)0;

                imPerfil.HorizontalAlignment = (HorizontalAlignment)0;

                lbDNI.FontSize = M;
                lbNombre.FontSize = M;
                lbDirecion.FontSize = M;
                lbApellidos.FontSize = M;
                lbLocalidad.FontSize = M;
                lbPais.FontSize = M;
                lbTarjeta.FontSize = M;
                lbTelefono.FontSize = M;

                tbDNI.FontSize = S;
                tbNombre.FontSize = S;
                tbDireccion.FontSize = S;
                tbApellidos.FontSize = S;
                tbLocalidad.FontSize = S;
                tbPais.FontSize = S;
                tbTarjeta.FontSize = S;
                tbTelefono.FontSize = S;
            }
            else if(Width <= 900)
            {
                gridUser.Width = 325;
                if (Height <= lon)
                {
                    imPerfil.Height = 96;
                    imPerfil.Width = 86;
                    imPerfil.Margin = new Thickness(10);
                    gridUser.Margin = new Thickness(0, 0, 186, 360);
                }
                else
                {
                    imPerfil.Height = 196;
                    imPerfil.Width = 186;
                    imPerfil.Margin = new Thickness(30, 60, 60, 0);
                    gridUser.Margin = new Thickness(0, 200, 356, 236);
                }
            }
            else
            {
                if (Height <= lon)
                {
                    imPerfil.Height = 96;
                    imPerfil.Width = 86;
                    imPerfil.Margin = new Thickness(10);
                    gridUser.Margin = new Thickness(0, 0, 186, 360);
                }
                else
                {
                    imPerfil.Height = 196;
                    imPerfil.Width = 186;
                    imPerfil.Margin = new Thickness(30, 60, 60, 0);
                    gridUser.Margin = new Thickness(0, 200, 356, 236);
                }

                gridUser.Width = 968;
                gridUser.HorizontalAlignment = (HorizontalAlignment)1;

                imPerfil.HorizontalAlignment = (HorizontalAlignment)1;
                lbDNI.FontSize = L;
                lbNombre.FontSize = L;
                lbDirecion.FontSize = L;
                lbApellidos.FontSize = L;
                lbLocalidad.FontSize = L;
                lbPais.FontSize = L;
                lbTarjeta.FontSize = L;
                lbTelefono.FontSize = L;
                lbVIP.FontSize = L;

                tbDNI.FontSize = M;
                tbNombre.FontSize = M;
                tbDireccion.FontSize = M;
                tbApellidos.FontSize = M;
                tbLocalidad.FontSize = M;
                tbPais.FontSize = M;
                tbTarjeta.FontSize = M;
                tbTelefono.FontSize = M;
                lbVIP.FontSize = M;
            }
        }

    }
}
