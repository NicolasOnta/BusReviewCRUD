using BusReviewCRUD.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusReviewCRUD.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para BusesView.xaml
    /// </summary>
    public partial class BusesView : UserControl
    {
        HttpClient client = new HttpClient();
        public BusesView()
        {
            client.BaseAddress = new Uri("https://localhost:44329/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void btnCargarBus_Click(object sender, RoutedEventArgs e)
        {
            this.GetBuses();

        }
        private async void GetBuses()
        {
            var response = await client.GetStringAsync("buses");
            var buses = JsonConvert.DeserializeObject<List<Bus>>(response);
            dgBuses.DataContext = buses;
        }

        private void btnGuardarBus_Click(object sender, RoutedEventArgs e)
        {
            bool wifi = false;
            bool tv = false;
            bool disc = false;
            bool bano = false;
            if (cbAsientos.IsChecked == true)
            {
                disc = true;
            }
            if (cbBano.IsChecked == true)
            {
                bano = true;
            }
            if (cbTv.IsChecked == true)
            {
                tv = true;
            }
            if (cbWifi.IsChecked == true)
            {
                wifi = true;
            }
            var bus = new Bus()
            {
                Placa = txtPlaca.Text,
                Nombres_Asistente = txtNombreA.Text,
                Nombres_Chofer = txtNombreC.Text,
                Cedula_Asistente = txtCedulaA.Text,
                Cedula_Chofer = txtCedulaC.Text,
                Cooperativa = txtCooperativa.Text,
                Correo_Asistente = txtCorreoA.Text,
                Correo_Chofer = txtCorreoC.Text,
                Asientos_discapacitados = disc,
                Baño = bano,
                Wifi = wifi,
                TV = tv,
                Marca = txtMarca.Text

            };


        }

        

        void btnEditarBus(object sender, RoutedEventArgs e)
        {

        }

        void btnEliminarBus(object sender, RoutedEventArgs e)
        {
            Bus bus = ((FrameworkElement)sender).DataContext as Bus;
            this.DeleteBuses(bus.Placa);

        }
        public async void DeleteBuses(string placa)
        {
            await client.DeleteAsync("usuarios/" + placa);
        }
    }
}