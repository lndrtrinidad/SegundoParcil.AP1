using SegundoParcial.AP1.BLL;
using SegundoParcial.AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SegundoParcial.AP1.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRegistro.xaml
    /// </summary>
    public partial class rRegistro : Window
    {
        private Proyecto proyecto = new Proyecto();
        public rRegistro()
        {
            InitializeComponent();
            this.DataContext = proyecto;

            
            TipoTareaComboBox.SelectedValuePath = "TareasId";
            TipoTareaComboBox.DisplayMemberPath = "TipoTarea";
            TipoTareaComboBox.ItemsSource = TareasBLL.GetList();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyecto;
        }

        private void Limpiar()
        {
            this.proyecto = new Proyecto();
            this.DataContext = proyecto;
        }

        private bool Validar()
        {
            bool Validado = true;
            if (ProyectoIdTextbox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return Validado;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyecto encontrado = ProyectosBLL.Buscar(proyecto.TareaId);

            if (encontrado != null)
            {
                proyecto = encontrado;
                Cargar();
                MessageBox.Show("Proyecto Encontrado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Este Proyecto no fue encontrado.\n\nAsegurese que existe o cree uno nuevo.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                ProyectoIdTextbox.Text = "";
                ProyectoIdTextbox.Focus();
            }
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var filaDetalle = new DetalleTarea
            {
                TareaId = Convert.ToInt32(TipoTareaComboBox.SelectedValue.ToString()),
                Requerimiento = (RequerimientoTextBox.Text.ToString()),
                Tiempo = Convert.ToDouble(TiempoTextBox.Text.ToString()),
            };

            this.proyecto.Detalle.Add(filaDetalle);
            Cargar();

            TipoTareaComboBox.SelectedIndex = -1;
            RequerimientoTextBox.Clear();
            TiempoTextBox.Clear();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                proyecto.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = ProyectosBLL.Guardar(this.proyecto);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (ProyectosBLL.Eliminar(Utilidades.ToInt(ProyectoIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TiempoTotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

