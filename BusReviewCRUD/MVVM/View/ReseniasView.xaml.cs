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
    /// Lógica de interacción para ReseniasView.xaml
    /// </summary>
    public partial class ReseniasView : UserControl
    {
        HttpClient client = new HttpClient();
        public ReseniasView()

        {
            client.BaseAddress = new Uri("https://localhost:44329/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }
        private void btnCargarResena_Click(object sender, RoutedEventArgs e)
        {
            this.GetResena();
        }
        private async void GetResena()
        {
            var response = await client.GetStringAsync("usuarios");
            var resena = JsonConvert.DeserializeObject<List<Resena>>(response);
            dgResena.DataContext = resena;
        }
        private void btnEliminarResena_Click(object sender, RoutedEventArgs e)
        {
            Resena   resena = ((FrameworkElement)sender).DataContext as Resena;
            this.Deleteresena(resena.ResenaId);
        }
        private async void Deleteresena(int id)
        {
            await client.DeleteAsync("resenas/" + id);
        }

        void btnVerResena(object sender, RoutedEventArgs e)
        {
         
        }

   
    }
}
