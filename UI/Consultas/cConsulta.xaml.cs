using SegundoParcial.AP1.BLL;
using SegundoParcial.AP1.Entidades;
using System;
using System.Linq;
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

namespace SegundoParcial.AP1.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cConsultas.xaml
    /// </summary>
    public partial class cConsultas : Window
    {
        public cConsultas()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Proyecto> listado = new List<Proyecto>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProyectosBLL.GetList(p => p.TareaId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = ProyectosBLL.GetList(p => p.TipoTarea.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                listado = ProyectosBLL.GetList(c => true);
            }
            if (DesdeDatePicker.SelectedDate != null)
                listado = (List<Proyecto>)ProyectosBLL.GetList(p => p.fecha.Date >= DesdeDatePicker.SelectedDate);
            if (HastaDatePicker.SelectedDate != null)
                listado = (List<Proyecto>)ProyectosBLL.GetList(p => p.fecha.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
