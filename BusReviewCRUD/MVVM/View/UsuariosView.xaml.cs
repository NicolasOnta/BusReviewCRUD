using BusReviewCRUD.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Lógica de interacción para UsuariosView.xaml
    /// </summary>
    public partial class UsuariosView : UserControl
    {
        HttpClient client = new HttpClient();
        public UsuariosView()
        {
            client.BaseAddress = new Uri("https://localhost:44329/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void btnCargarUsuario_Click(object sender, RoutedEventArgs e)
        {
            this.GetUsuarios();
        }

        private async void GetUsuarios()
        {
            var response = await client.GetStringAsync("usuarios");
            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);
            dgUsuarios.DataContext = usuarios;
        }

        private async Task<string> SaveUsuarios(Usuario usuario)
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri("https://localhost:44329/api/usuarios"));
            request.ContentType = "application/json";
            request.Method = "Post";
            request.Timeout = 4000; //ms
            var itemToSend = JsonConvert.SerializeObject(usuario);
            using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                streamWriter.Write(itemToSend);
                streamWriter.Flush();
                streamWriter.Dispose();
            }

            // Send the request to the server and wait for the response:  
            using (var response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:  
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream);
                    var message = reader.ReadToEnd();
                    return message;
                }
            }


        }


        public async Task<string> PostTest(Usuario ususario)
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri("https://localhost:44329/api/usuarios"));
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Timeout = 4000; //ms
            var itemToSend = JsonConvert.SerializeObject(ususario);
            using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                streamWriter.Write(itemToSend);
                streamWriter.Flush();
                streamWriter.Dispose();
            }

            // Send the request to the server and wait for the response:  
            using (var response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:  
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream);
                    var message = reader.ReadToEnd();
                    return message;
                }
            }
        }
        public void SaveUsuarios1(Usuario usuario)
        {
            System.Data.SqlClient.SqlConnection sqlConnection1 =
      new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Initial Catalog=Db;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "USE [Db] GO INTO [dbo].[Usuario]([Nombre],[Apellido],[Correo,[Contrasenia],[Administrador]) VALUES ("+usuario.Nombre+","+usuario.Apellido+","+usuario.Correo+","+usuario.Contrasenia+","+usuario.Administrador+") GO";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
          
            sqlConnection1.Close();
        }
        private async void UpdateUsuarios(Usuario usuario)
        {
            await client.PutAsJsonAsync("usuarios/"+ usuario.UsuarioId, usuario);
        }
        private async void DeleteUsuarios(int id)
        {
            await client.DeleteAsync("usuarios/"+ id);
        }
        private void SaveUsuarios2(Usuario usuario)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Initial Catalog=Db;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd;
            con.Open();
            string s = "insert into Usuarios values(@p1,@p2,@p3,@p4)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@p1", usuario.Nombre);
            cmd.Parameters.AddWithValue("@p2", usuario.Apellido);
            cmd.Parameters.AddWithValue("@p3", usuario.Correo);
            cmd.Parameters.AddWithValue("@p4", usuario.Contrasenia);
            
            con.Close();
            
        }
    
        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            bool admin=false;
            if (cbAdmin.IsChecked == true)
            {
                admin = true;
            }
            var usuario = new Usuario()
            {
                UsuarioId = 0,
                Nombre = txtName.Text,
                Apellido = txtApellido.Text,
                Correo = txtCorreo.Text,
                Contrasenia = txtContrasenia.Text,
                
                Administrador = admin
                
            };

            if (usuario.UsuarioId == 0)
            {
                this.SaveUsuarios(usuario);
            }
            else
            {
                this.UpdateUsuarios(usuario);
            }
            txtId.Text = 0.ToString();
            txtName.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            dpFecha.SelectedDate = DateTime.Today;
            txtContrasenia.Text = "";
            cbAdmin.IsChecked = default;
        }

        void btnEditarUsuario(object sender, RoutedEventArgs e)
        {
            Usuario usuario = ((FrameworkElement)sender).DataContext as Usuario;
            txtId.Text = usuario.UsuarioId.ToString();
            txtName.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtCorreo.Text = usuario.Correo;
           
            txtContrasenia.Text = usuario.Contrasenia;
            cbAdmin.IsChecked = usuario.Administrador;
        }

        void btnEliminarUsuario(object sender, RoutedEventArgs e)
        {
            Usuario usuario = ((FrameworkElement)sender).DataContext as Usuario;
            this.DeleteUsuarios(usuario.UsuarioId);
        }
    }
}
