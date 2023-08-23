using FirebirdSql.Data.FirebirdClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace REPORTE_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string connectionString = "User=SYSDBA;Password=masterkey;Database=" + ConfigurationManager.AppSettings["rutaBdd"] + ";DataSource=localhost;Port=3050;";
        public MainWindow()
        {
            InitializeComponent();
            CargarDatosComboBox();
            

            //CargarDatos DP a fecha "HOY"
            dp_desde.SelectedDate = DateTime.Today;
            dp_hasta.SelectedDate = DateTime.Today;
            //Desactivamos pro default
            dp_desde.IsEnabled = false;
            dp_hasta.IsEnabled = false;
        }

        // Define la clase ColumnWidthConverter aquí
        public class ColumnWidthConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is double listViewWidth)
                {
                    int numColumns = 7; // Número de columnas en el ListView
                    double columnWidth = listViewWidth / numColumns;
                    return columnWidth;
                }

                return DependencyProperty.UnsetValue;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private void CargarDatosComboBox()
        {
            List<SeleccionarProveedor> sp = new List<SeleccionarProveedor>();
            string consulta = "SELECT r.NOMBRE, r.ID FROM PROVEEDORES r"; // Cambia nombre_columna y tuTabla según tu base de datos

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                using (FbCommand command = new FbCommand(consulta, connection))
                {
                    try
                    {
                        using (FbDataReader reader = command.ExecuteReader())
                        {
                            //List<string> items = new List<string>();

                            while (reader.Read())
                            {
                                string nombre = reader.GetString(0); // Cambia el índice según tu consulta
                                string idProveedor = reader.GetString(1);

                                sp.Add(new SeleccionarProveedor { nombre = nombre, idProveedor = idProveedor });


                            }
                            if (sp.Count != 0)
                            {
                                cb_proveedores.ItemsSource = sp;
                                cb_proveedores.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (FbException ex)
                    {
                        MessageBox.Show("Error en la consulta: " + ex.Message);
                    }
                }

                connection.Close();

            }
        }

        private void CDHistorialInventario()
        {
            List<HistorialInventario> historial = new List<HistorialInventario> ();
            if (dg_historial.Items.Count != 0)
            {
                dg_historial.Items.Clear();
            }
            if (lb_prod_proov.SelectedItem != null)
            {
                string idProducto = lb_prod_proov.SelectedValue.ToString();
                string consulta = "SELECT r.PRODUCTO_ID, r.CUANDO_FUE, r.CANTIDAD_ANTERIOR, r.CANTIDAD, r.DESCRIPCION, r.COSTO_UNITARIO, p.DESCRIPCION, p.CODIGO " +
                    "FROM INVENTARIO_HISTORIAL r " +
                    "JOIN PRODUCTOS p ON r.PRODUCTO_ID = p.ID WHERE r.PRODUCTO_ID = " + idProducto;

                Boolean? tempfiltrar = cb_filtrar.IsChecked;
                Boolean filtrar = false;

                if (tempfiltrar.HasValue);
                {
                    filtrar = tempfiltrar.Value;
                }

                if (filtrar)
                {
                    //tomamos el valor de los Datepikers como no nulleable para comparar despues y asignar
                    DateTime? tempDeste = dp_desde.SelectedDate;
                    DateTime? tempHasta = dp_hasta.SelectedDate;
                    DateTime desde = DateTime.Today;
                    DateTime hasta = DateTime.Today;

                    ////tomar el valor de las fechas
                    if (tempDeste.HasValue)
                    {
                        desde = tempDeste.Value.Date;
                    
                    }
                    if (tempHasta.HasValue)
                    {
                        hasta = tempHasta.Value.Date;
                    }

                    //Cambiar QUERY
                    consulta = consulta + " AND r.CUANDO_FUE BETWEEN '" + desde.Date.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + hasta.Date.ToString("yyyy/MM/dd") + " 23:59:59'";
                    //MessageBox.Show(consulta);
                }

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    using (FbCommand command = new FbCommand(consulta, connection))
                    {
                        try
                        {
                            using (FbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string producto = reader.GetString(6);
                                    string codigo = reader.GetString(7);
                                    DateTime fecha = reader.GetDateTime(1);
                                    int cantidadAnterior = reader.GetInt16(2);
                                    string descripcion = reader.GetString(4);

                                    //ver si fue una venta y tipo de movimiento
                                    string tipoMovimiento = "Entrada"; //0 = entrada, 1 salida, 2 ajuste
                                    int tempCant = reader.GetInt16(3);
                                    string corteString = descripcion.Substring(0, 5);
                                    //MessageBox.Show(descripcion.Substring(0, 5));

                                    int cantidad = reader.GetInt16(3);

                                    if (corteString == "Venta")
                                    {
                                        cantidad = tempCant * -1;
                                        tipoMovimiento = "Salida";
                                    }
                                    else if (corteString == "Ajust")
                                    {
                                        tipoMovimiento = "Ajuste";
                                    }

                                    //"Venta, Recep, Alta , Ajust"

                                    float costoUnitario = reader.GetFloat(5);
                                    float total = cantidadAnterior + cantidad;



                                    //lv_movimientos.Items.Add(new HistorialInventario
                                    //{
                                    //    producto = producto,
                                    //    codigo = codigo,
                                    //    fecha = fecha,
                                    //    cantidadAnterior = cantidadAnterior,
                                    //    cantidad = cantidad,
                                    //    descripcion = descripcion,
                                    //    costoUnitario = costoUnitario,
                                    //    total = total
                                    //});

                                    dg_historial.Items.Add(new HistorialInventario
                                    {
                                        fecha = fecha,
                                        producto = producto,
                                        codigo = codigo,
                                        costoUnitario = costoUnitario,
                                        descripcion = descripcion,
                                        cantidad = cantidad,
                                        total = total,
                                        tmovimiento = tipoMovimiento
                                    });

                                    //historial.Add(new HistorialInventario
                                    //{
                                    //    fecha = fecha,
                                    //    producto = producto,
                                    //    codigo = codigo,
                                    //    costoUnitario = costoUnitario,
                                    //    descripcion = descripcion,
                                    //    cantidad = cantidad,
                                    //    total = total
                                    //});

                                }
                                //dg_historial.ItemsSource = historkial;
                            }
                        }
                        catch (FbException ex)
                        {
                            MessageBox.Show("Error en la consulta: " + ex.Message);
                        }
                    }

                    connection.Close();
                }
            }
        }

        private void CDProdPorProovedor(Boolean porCodigo)
        {
            if (lb_prod_proov.Items.Count != 0) 
            {
                lb_prod_proov.Items.Clear();
            }
            string proveedor = cb_proveedores.SelectedValue.ToString();
            string consulta = "SELECT r.DESCRIPCION, r.ID FROM PRODUCTOS r WHERE r.PROVID = " + proveedor;
            if (porCodigo && tb_buscarProd.Text != "")
            {
                //get código
                string codigo = tb_buscarProd.Text;
                //cambiar QUERY 
                consulta = "SELECT r.DESCRIPCION, r.ID FROM PRODUCTOS r WHERE r.PROVID = " + proveedor + " AND ( UPPER(r.CODIGO) LIKE UPPER('%" + codigo + "%') OR UPPER(r.DESCRIPCION) LIKE UPPER('%" + codigo + "%'))";

            }
            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                using (FbCommand command = new FbCommand(consulta, connection))
                {
                    try
                    {
                        using (FbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombre = reader.GetString(0);
                                string id = reader.GetString(1);

                                lb_prod_proov.Items.Add(new ProductoBuscado
                                {
                                    nombre = nombre,
                                    id = id
                                });
                            }
                            if (lb_prod_proov.Items.Count != 0)
                            {
                                lb_prod_proov.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (FbException ex)
                    {
                        MessageBox.Show("Error en la consulta: " + ex.Message);
                    }
                }

                connection.Close();
            }
        }
        private void DPDesde_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? tempDesde = dp_desde.SelectedDate;
            DateTime? tempHasta = dp_hasta.SelectedDate;
            DateTime desde = DateTime.Today;
            DateTime hasta = DateTime.Today;

            if (tempDesde.HasValue)
            {
                desde = tempDesde.Value;
            }
            if (tempHasta.HasValue)
            {
                hasta = tempHasta.Value;
            }

            if (desde > hasta)
            {
                dp_hasta.SelectedDate = desde;
            }
            CDHistorialInventario();
        }

        private void DPHasta_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime desde = dp_desde.SelectedDate.Value;
            DateTime hasta = dp_hasta.SelectedDate.Value;
            if (desde > hasta)
            {
                dp_desde.SelectedDate = hasta;
            }
            CDHistorialInventario();
        }

        private void cb_proveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CDProdPorProovedor(false);
        }

        private void tb_buscarProd_TextChanged(object sender, TextChangedEventArgs e)
        {
            CDProdPorProovedor(true);
        }

        private void lb_prod_proov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CDHistorialInventario();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CDHistorialInventario();
            dp_desde.IsEnabled = true;
            dp_hasta.IsEnabled = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            dp_desde.IsEnabled = false;
            dp_hasta.IsEnabled = false;
            CDHistorialInventario();

        }

    }
}
