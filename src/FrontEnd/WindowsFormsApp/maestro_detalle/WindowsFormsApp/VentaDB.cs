using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class VentaDB
    {
        private string connectionString = @"Data Source= (localdb)\MSSQLLocalDB; Initial Catalog= maestro_detalle; Integrated Security = true;";

        public void Add(string cliente, List<Concepto> conceptos)
        {
            //string query = "INSERT INTO VENTAS (Cliente, Fecha) VALUES (@cliente, @fecha)";
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio");

            int i = 1;
            foreach (Concepto concepto in conceptos)
            {
                dt.Rows.Add(i, concepto.nombre, concepto.cantidad, concepto.precio);
                i++;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_GUARDAR_VENTA", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter listaConceptos = new SqlParameter("@conceptos", SqlDbType.Structured);
                listaConceptos.TypeName = "dbo.DATOS_CONCEPTO";
                listaConceptos.Value = dt;

                command.Parameters.Add(listaConceptos);
                command.Parameters.AddWithValue("@cliente", cliente);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
