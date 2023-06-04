using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;

namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MostrarDatos();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mario\source\repos\Database\Database\Database1.mdf;Integrated Security=True");

         public void MostrarDatos()
         {
            string seleccionar = "SELECT Id, Nombre, Telefono, Direccion, Carnet, Edad FROM Alumno";
            SqlCommand command = new SqlCommand(seleccionar, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            CuadroData.ItemsSource = dataTable.DefaultView;

         }

        public void GuardarDatos()
        {
           
            string valorId = txtId.Text;
            string valorNombre = txtNombre.Text;
            string valorTelefono = txtTelefono.Text;
            string valorDireccion = txtDireccion.Text;
            string valorCarnet = txtCarnet.Text;
            string valorEdad = txtEdad.Text;
            

            SqlCommand command = new SqlCommand("INSERT INTO Alumno(Id, Nombre, Telefono, Direccion, Carnet, Edad) VALUES (@ValorId, @ValorNombre, @ValorTelefono, @ValorDireccion, @ValorCarnet, @ValorEdad)", conn);
            conn.Open();
            command.Parameters.AddWithValue("@ValorId", valorId);
            command.Parameters.AddWithValue("@ValorNombre", valorNombre);
            command.Parameters.AddWithValue("@ValorTelefono", valorTelefono);
            command.Parameters.AddWithValue("@ValorDireccion", valorDireccion);
            command.Parameters.AddWithValue("@ValorCarnet", valorCarnet);
            command.Parameters.AddWithValue("@ValorEdad", valorEdad);
            command.ExecuteNonQuery();
            conn.Close();
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCarnet.Text = "";
            txtEdad.Text = "";
            
            MostrarDatos();
        }

        public void EliminarDatos()
        {
            conn.Open();
            string valorId = txtId.Text;
            SqlCommand command = new SqlCommand("DELETE FROM Alumno WHERE Id = @ValorId", conn);
            command.Parameters.AddWithValue("@ValorId", valorId);
            command.ExecuteNonQuery();
            conn.Close();
            txtId.Text = "";
            MostrarDatos();
        }

        public void ActualizarDatos()
        {
            string valorId = txtId.Text;
            string valorNombre = txtNombre.Text;
            string valorTelefono = txtTelefono.Text;
            string valorDireccion = txtDireccion.Text;
            string valorCarnet = txtCarnet.Text;
            string valorEdad = txtEdad.Text;
            conn.Open();
            SqlCommand command = new SqlCommand("UPDATE Alumno SET Nombre = @ValorNombre, Telefono = @ValorTelefono, Direccion = @ValorDireccion, Carnet = @ValorCarnet, Edad = @ValorEdad WHERE Id = @ValorId", conn);
            command.Parameters.AddWithValue("@ValorId", valorId);
            command.Parameters.AddWithValue("@ValorNombre", valorNombre);
            command.Parameters.AddWithValue("@ValorTelefono", valorTelefono);
            command.Parameters.AddWithValue("@ValorDireccion", valorDireccion);
            command.Parameters.AddWithValue("@ValorCarnet", valorCarnet);
            command.Parameters.AddWithValue("@ValorEdad", valorEdad);
            command.ExecuteNonQuery();
            conn.Close();
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCarnet.Text = "";
            txtEdad.Text = "";

            MostrarDatos();
        }
        
        private void GuardarData_Click(object sender, RoutedEventArgs e)
        {
            GuardarDatos();
        }

        private void EliminarData_Click(object sender, RoutedEventArgs e)
        {
            EliminarDatos();
        }

        private void ActualizarData_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDatos();
        }
    }
}
