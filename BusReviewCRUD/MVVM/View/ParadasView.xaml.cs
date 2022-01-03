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
    /// Lógica de interacción para ParadasView.xaml
    /// </summary>
    public partial class ParadasView : UserControl
    {
        HttpClient client = new HttpClient();
        public ParadasView()
        {
            client.BaseAddress = new Uri("https://localhost:44329/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }
        private void btnCargarParada_Click(object sender, RoutedEventArgs e)
        {
            this.GetParadas();
        }
        private async void GetParadas()
        {
            var response = await client.GetStringAsync("paradas");
            var paradas = JsonConvert.DeserializeObject<List<Parada>>(response);
            dgParada.DataContext = paradas;
        }
        private void btnGuardarParada_Click(object sender, RoutedEventArgs e)
        {


        }

        void btnEditarParada(object sender, RoutedEventArgs e)
        {

        }

        void btnEliminarParada(object sender, RoutedEventArgs e)
        {
            Parada parada = ((FrameworkElement)sender).DataContext as Parada;
            this.Deleteparadas(parada.ParadaId);
        }
        private async void Deleteparadas(int id)
        {
            await client.DeleteAsync("paradas/" + id);
        }
    }
}
