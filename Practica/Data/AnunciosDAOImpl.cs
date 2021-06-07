using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Practica.DTOs;
using Npgsql;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;

namespace Practica.Data
{
    public class AnunciosDAOImpl
    {
      
        public async Task<OperationResult<List<Anuncio>>> GetAnunciosAsync()
        {
            OperationResult<List<Anuncio>> result = new OperationResult<List<Anuncio>> { Success = false };
            List<Anuncio> items = null;

            string query = @"select a.id,a.titulo,ct.descripcion tipo,a.precio,a.imagen 
                                from anuncios a, cat_tipo ct
                                where a.tipo = ct.id ";
          

               
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["ca_16"].ConnectionString })
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand { CommandText = query, Connection = conn })
                    {

                        // cmd.Parameters.Add(new NpgsqlParameter { ParameterName = "", NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer, Value =  });

                        using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            items = new List<Anuncio>();

                            while (reader.Read())
                            {

                                items.Add(new Anuncio
                                {
                                    Id = Convert.ToInt32(reader["id"]?.ToString()),
                                    Titulo = reader["titulo"]?.ToString()?.Trim() ?? string.Empty,
                                    Tipo = reader["tipo"]?.ToString() ?? string.Empty,
                                    Precio = Convert.ToInt32(reader["precio"]?.ToString()),
                                    Imagen = reader["imagen"]?.ToString() ?? string.Empty,
                                });
                            }
                            result.Data = items;
                            result.Success = true;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                result.Message = "Hubo un error al leer los anuncios.";

            }


            return result;
       }



        public async Task<OperationResult<List<Categoria>>> GetCategoriasAsync()
        {
            OperationResult<List<Categoria>> result = new OperationResult<List<Categoria>> { Success = false };
            List<Categoria> items = null;

            string query = "select id, descripcion from cat_tipo";



            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["ca_16"].ConnectionString })
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand { CommandText = query, Connection = conn })
                    {

                        // cmd.Parameters.Add(new NpgsqlParameter { ParameterName = "", NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer, Value =  });

                        using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            items = new List<Categoria>();

                            while (reader.Read())
                            {

                                items.Add(new Categoria
                                {
                                    Id = Convert.ToInt32(reader["id"]?.ToString()),
                                    Descripcion = reader["descripcion"]?.ToString() ?? string.Empty
                                    
                                });
                            }
                            result.Data = items;
                            result.Success = true;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                result.Message = "Hubo un error al leer las categorias.";

            }


            return result;
        }





    }
}