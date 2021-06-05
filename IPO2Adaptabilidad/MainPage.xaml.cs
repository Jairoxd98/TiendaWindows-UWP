using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace IPO2_Amazon
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BBDD bbdd = new BBDD();

        public MainPage()
        {
            this.InitializeComponent();

            fmMain.Navigate(typeof(catalogoPage), this.bbdd);

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 340));
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    //TileMedium = ...


                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "Jennifer Parker",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Photos from our trip",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Check out these awesome photos I took while in New Zealand!",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    },

                    //TileLarge = ...
                }
            };
            var notification = new TileNotification(content.GetXml());
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            svMenu.IsPaneOpen = !svMenu.IsPaneOpen;
        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width =
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 720)
            {
                svMenu.DisplayMode = SplitViewDisplayMode.CompactInline;
                svMenu.IsPaneOpen = true;
            }
            else if (Width >= 360)
            {
                svMenu.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                svMenu.IsPaneOpen = false;
            }
            else
            {
                svMenu.DisplayMode = SplitViewDisplayMode.Overlay;
                svMenu.IsPaneOpen = false;
            }
        }

        private void irCatalogo(object sender, PointerRoutedEventArgs e)
        {
            fmMain.Navigate(typeof(catalogoPage), this.bbdd);
        }

        private void irCesta(object sender, PointerRoutedEventArgs e)
        {
            fmMain.Navigate(typeof(Cesta),this.bbdd);
            //SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void irFavoritos(object sender, PointerRoutedEventArgs e)
        {
            fmMain.Navigate(typeof(FavoritosPage),this.bbdd);
        }

        private void irPerfil(object sender, PointerRoutedEventArgs e)
        {
            fmMain.Navigate(typeof(perfilPage));
        }
    }
}
