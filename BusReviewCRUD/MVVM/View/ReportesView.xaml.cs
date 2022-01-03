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
    /// Lógica de interacción para ReportesView.xaml
    /// </summary>
    public partial class ReportesView : UserControl
    {
        HttpClient client = new HttpClient();
        public ReportesView()
        {
            client.BaseAddress = new Uri("https://localhost:44329/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }
        private void btnCargarReporte_Click(object sender, RoutedEventArgs e)
        {
            this.GetReportes();
        }
        private async void GetReportes()
        {
            var response = await client.GetStringAsync("reportes");
            var reporte = JsonConvert.DeserializeObject<List<Reporte>>(response);
            dgReporte.DataContext = reporte;
        }
        private void btnEliminarReporte_Click(object sender, RoutedEventArgs e)
        {
            Reporte reporte = ((FrameworkElement)sender).DataContext as Reporte;
            this.Deletereporte(reporte.IdUsuario);
        }
        private async void Deletereporte(int id)
        {
            await client.DeleteAsync("reportes/" + id);
        }
        void btnVerReporte(object sender, RoutedEventArgs e)
        {

        }
    }
}
