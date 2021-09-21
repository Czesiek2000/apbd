using cwiczenia5.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia5.Services
{
    public class WarehouseDbService : IWarehouseDbService
    {
        private readonly string _sqlConn = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True";

        public async Task<int> PostWarehouse (Warehouse warehouse)
        {
            if ( warehouse.IdProduct == 0  || warehouse.IdWarehouse == 0 || warehouse.Amount <= 0 || string.IsNullOrEmpty(warehouse.CreatedAt) ) 
            {
                return 1;
            }
            var warehouseId = 0;
            var order = 0;
            var price = 0;
            using ( var conn = new SqlConnection(_sqlConn) )
            {
                conn.Open();

                using ( SqlTransaction transaction = conn.BeginTransaction() )
                {
                    using ( var comm = new SqlCommand() )
                    {
                        comm.Connection = conn;

                        comm.Transaction = transaction;

                        comm.CommandText = "SELECT * FROM WAREHOUSE WHERE IDWAREHOUSE = " + warehouse.IdProduct;

                        using ( SqlDataReader dr = await comm.ExecuteReaderAsync() )
                        {
                            if ( dr.HasRows )
                            {
                                warehouseId = int.Parse( dr["IdWarehouse"].ToString() );
                            }
                        }
                    }

                    using ( var comm = new SqlCommand() )
                    {

                        comm.CommandText = "SELECT * FROM ORDER WHERE WHERE IDPRODUCT = " + warehouse.IdProduct + " AND AMOUNT = " + warehouse.Amount;

                        using ( SqlDataReader dr = await comm.ExecuteReaderAsync() )
                        {
                            if ( dr.HasRows )
                            {
                                order = int.Parse( dr["IdOrder"].ToString() );
                            }
                        }
                    }

                    using ( var comm = new SqlCommand() )
                    {

                        if ( order != 0 )
                        {

                            comm.CommandText = "SELECT * FROM PRODUCT_WAREHOUSE WHERE IDORDER = " + order;

                            int rows = comm.ExecuteNonQuery();
                            if ( rows != 0 )
                            {

                            }
                        }
                    }

                    using ( var comm = new SqlCommand() )
                    {
                        comm.CommandText = "update order set FulfilledAt = " + DateTime.Now + " where idorder = " + order;
                        comm.ExecuteNonQuery();
                    }

                    using ( var comm = new SqlCommand() )
                    {
                        comm.CommandText = "Select price from product where idproduct = " + warehouse.IdProduct;
                        await comm.ExecuteNonQueryAsync();
                        SqlDataReader dr = await comm.ExecuteReaderAsync();
                        if ( dr.HasRows )
                        {
                            price = int.Parse(dr["price"].ToString());
                        }
                        comm.CommandText = $"INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) VALUES( {warehouse.IdWarehouse}, {warehouse.IdProduct}, {order}, {warehouse.Amount}, {warehouse.Amount * price}, {warehouse.CreatedAt} );";
                        await comm.ExecuteNonQueryAsync();
                    }

                    await transaction.CommitAsync();
                    await conn.CloseAsync();

                }
            }

            return 1;
        }
    }
}
