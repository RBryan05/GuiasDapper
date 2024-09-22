using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public  class CustomerRepository
    {
        public List<Customers> ObtenerTodos()
        {
            using(var conexion = DataBase.GetSqlConnection())
            {
                String selectAll = "";
                selectAll = selectAll + "SELECT [CustomerID] " + "\n";
                selectAll = selectAll + "      ,[CompanyName] " + "\n";
                selectAll = selectAll + "      ,[ContactName] " + "\n";
                selectAll = selectAll + "      ,[ContactTitle] " + "\n";
                selectAll = selectAll + "      ,[Address] " + "\n";
                selectAll = selectAll + "      ,[City] " + "\n";
                selectAll = selectAll + "      ,[Region] " + "\n";
                selectAll = selectAll + "      ,[PostalCode] " + "\n";
                selectAll = selectAll + "      ,[Country] " + "\n";
                selectAll = selectAll + "      ,[Phone] " + "\n";
                selectAll = selectAll + "      ,[Fax] " + "\n";
                selectAll = selectAll + "  FROM [dbo].[Customers]";

                IEnumerable<Customers> cliente = conexion.Query<Customers>(selectAll);
                return cliente.ToList();
            }
        }

        public Customers ObtenerPorID(string customerID)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String selectID = "";
                selectID = selectID + "SELECT [CustomerID] " + "\n";
                selectID = selectID + "      ,[CompanyName] " + "\n";
                selectID = selectID + "      ,[ContactName] " + "\n";
                selectID = selectID + "      ,[ContactTitle] " + "\n";
                selectID = selectID + "      ,[Address] " + "\n";
                selectID = selectID + "      ,[City] " + "\n";
                selectID = selectID + "      ,[Region] " + "\n";
                selectID = selectID + "      ,[PostalCode] " + "\n";
                selectID = selectID + "      ,[Country] " + "\n";
                selectID = selectID + "      ,[Phone] " + "\n";
                selectID = selectID + "      ,[Fax] " + "\n";
                selectID = selectID + "  FROM [dbo].[Customers]";
                selectID = selectID + "  WHERE [CustomerID] = @CustomerID";

                var parametro = new { CustomerID = customerID };
                var cliente = conexion.QueryFirstOrDefault<Customers>(selectID, parametro);
                return cliente;
            }
        }

        public int ActualizarCliente(Customers cliente)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String update = "";
                update = update + "UPDATE [dbo].[Customers] " + "\n";
                update = update + "   SET [CustomerID] = @CustomerID " + "\n";
                update = update + "      ,[CompanyName] = @CompanyName " + "\n";
                update = update + "      ,[ContactName] = @ContactName " + "\n";
                update = update + "      ,[ContactTitle] = @ContactTitle " + "\n";
                update = update + "      ,[Address] = @Address " + "\n";
                update = update + " WHERE [CustomerID] = @CustomerID";

                var parametros = new
                {
                    CustomerID = cliente.CustomerID,
                    CompanyName = cliente.CompanyName,
                    ContactName = cliente.ContactName,
                    ContactTitle = cliente.ContactTitle,
                    Address = cliente.Address,

                };

                int ejecutar = conexion.Execute(update, parametros);
                return ejecutar;
            }
        }

        public int IngresarCliente(Customers cliente)
        {
            using(var conexion = DataBase.GetSqlConnection())
            {
                String insert = "";
                insert = insert + "INSERT INTO [dbo].[Customers] " + "\n";
                insert = insert + "           ([CustomerID] " + "\n";
                insert = insert + "           ,[CompanyName] " + "\n";
                insert = insert + "           ,[ContactName] " + "\n";
                insert = insert + "           ,[ContactTitle] " + "\n";
                insert = insert + "           ,[Address]) " + "\n";
                insert = insert + "     VALUES " + "\n";
                insert = insert + "           (@CustomerID" + "\n";
                insert = insert + "           ,@CompanyName " + "\n";
                insert = insert + "           ,@ContactName " + "\n";
                insert = insert + "           ,@ContactTitle " + "\n";
                insert = insert + "           ,@Address) " + "\n";

                var parametros = new
                {
                    CustomerID = cliente.CustomerID,
                    CompanyName = cliente.CompanyName,
                    ContactName = cliente.ContactName,
                    ContactTitle = cliente.ContactTitle,
                    Address = cliente.Address,
                };

                int ejecutarConsulta = conexion.Execute(insert, parametros);
                return ejecutarConsulta;
            }
        }
    }
}
