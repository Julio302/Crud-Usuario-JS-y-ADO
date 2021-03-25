using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetByIdUsuario(int Id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conection.Connection()))
                {
                    var query = "SELECT [IdUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Telefono], [Direccion] FROM [Usuarios] WHERE IdUsuario = "+Id;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result.Object = new object();
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IDUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.Telefono = row[4].ToString();
                                usuario.Direccion = row[5].ToString();
                                result.Object = usuario;
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en " + e.Message;
            }
            return result;
        }
        public static ML.Result GetAllUsuario()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conection.Connection()))
                {
                    string query = "SELECT [IdUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Telefono], [Direccion] FROM [Usuarios]";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach(DataRow row in ds.Tables[0].Rows){
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IDUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.Telefono = row[4].ToString();
                                usuario.Direccion = row[5].ToString();
                                result.Objects.Add(usuario);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error no hay registros";
                        }
                    }

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en " + e.Message;
            }
            return result;
        }

       
        public static ML.Result DeleteUsuario(int Id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conection.Connection()))
                {
                    var query = "DELETE FROM [Usuarios] WHERE IdUsuario = @IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = Id;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        if (rows >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en " + e.Message;
            }
            return result;
        }

        public static ML.Result UpdateUsuario(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conection.Connection()))
                {
                    var query = "UPDATE [Usuarios] SET [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno, [ApellidoMaterno] = @ApellidoMaterno, [Telefono] = @Telefono, [Direccion] = @Direccion WHERE IdUsuario = @IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[4].Value = usuario.Telefono;

                        collection[5] = new SqlParameter("Direccion", SqlDbType.VarChar);
                        collection[5].Value = usuario.Direccion;

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IDUsuario;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                        cmd.Connection.Close();

                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en " + e.Message;
            }
            return result;
        }
        public static ML.Result AddUsuario(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conection.Connection()))
                {
                    var query = "INSERT INTO [Usuarios]([Nombre], [ApellidoPaterno], [ApellidoMaterno], [Telefono], [Direccion]) VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Telefono, @Direccion)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[3].Value = usuario.Telefono;

                        collection[4] = new SqlParameter("Direccion", SqlDbType.VarChar);
                        collection[4].Value = usuario.Direccion;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en "+e.Message;
            }
            return result;
        }
    }
}
