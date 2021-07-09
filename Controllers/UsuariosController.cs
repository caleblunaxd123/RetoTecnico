using CrudUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Security.Cryptography;


namespace CrudUsuarios.Controllers
{
    public class UsuariosController : Controller
    {
        string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listaUsuarios()
        {
            return Json(Usuarioslistado(), JsonRequestBehavior.AllowGet);
        }

        public List<Usuarios> Usuarioslistado()
        {
            List<Usuarios> ll = new List<Usuarios>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Usuarios"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Listar_Usuarios_Mant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Usuarios users = new Usuarios();
                        users.id = int.Parse(dr["Id"].ToString());
                        users.nombres = dr["Nombres"].ToString();
                        users.apellidos = dr["Apellidos"].ToString();
                        users.login = dr["Loginn"].ToString();
                        users.password = dr["Passwordd"].ToString();
                        users.creacion = dr["Crea"].ToString();
                        users.modificacion = dr["Modifica"].ToString();
                        users.estado = Convert.ToBoolean(dr["Estado"]);
                        ll.Add(users);
                    }
                }
                con.Close();
            }
            return ll;
        }

        public string registrarUsuarios(Usuarios g)
        {
            string s = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Usuarios"].ConnectionString))
            {
                con.Open();
                try
                {
                    string encripta = EncryptKey(g.password);
                    SqlCommand cmd = new SqlCommand("INS_USUARIOS_MANT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", g.id);
                    cmd.Parameters.AddWithValue("@Nombres", g.nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", g.apellidos);
                    cmd.Parameters.AddWithValue("@Loginn", g.login);
                    cmd.Parameters.AddWithValue("@Passwordd", encripta);
                    cmd.Parameters.AddWithValue("@Estado", g.estado);
                    cmd.Parameters.AddWithValue("@Crea", "");
                    cmd.Parameters.AddWithValue("@usu", g.Usu);
                    cmd.Parameters.AddWithValue("@Modifica", "");
                    cmd.Parameters.AddWithValue("@Elimina", "");
                    cmd.Parameters.AddWithValue("@opc", 1);
                    cmd.ExecuteNonQuery();
                    s = "si";
                }
                catch (Exception ex)
                {
                    s = "no";
                    ViewBag.mensaje = "error" + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            return s;
        }
        public string editarUsuarios(Usuarios g)
        {
            string s = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Usuarios"].ConnectionString))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("INS_USUARIOS_MANT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", g.id);
                    cmd.Parameters.AddWithValue("@Nombres", g.nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", g.apellidos);
                    cmd.Parameters.AddWithValue("@Loginn", g.login);
                    cmd.Parameters.AddWithValue("@Passwordd", g.password);
                    cmd.Parameters.AddWithValue("@Estado", g.estado);
                    cmd.Parameters.AddWithValue("@Crea", "");
                    cmd.Parameters.AddWithValue("@usu", g.Usu);
                    cmd.Parameters.AddWithValue("@Modifica", "");
                    cmd.Parameters.AddWithValue("@Elimina", "");
                    cmd.Parameters.AddWithValue("@opc", 2);
                    cmd.ExecuteNonQuery();
                    s = "si";
                }
                catch (Exception ex)
                {
                    s = "no";
                    ViewBag.mensaje = "error" + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            return s;
        }
        public string activarUsuarios(Usuarios g)
        {
            string s = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Usuarios"].ConnectionString))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("INS_USUARIOS_MANT", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", g.id);
                    cmd.Parameters.AddWithValue("@Nombres", g.nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", g.apellidos);
                    cmd.Parameters.AddWithValue("@Loginn", g.login);
                    cmd.Parameters.AddWithValue("@Passwordd", g.password);
                    cmd.Parameters.AddWithValue("@Estado", g.estado);
                    cmd.Parameters.AddWithValue("@Crea", "");
                    cmd.Parameters.AddWithValue("@usu", g.Usu);
                    cmd.Parameters.AddWithValue("@Modifica", "");
                    cmd.Parameters.AddWithValue("@Elimina", "");
                    cmd.Parameters.AddWithValue("@opc", 3);
                    cmd.ExecuteNonQuery();
                    s = "si";
                }
                catch (Exception ex)
                {
                    s = "no";
                    ViewBag.mensaje = "error" + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            return s;
        }
        public string eliminarUsuarios(Usuarios g)
        {
            string s = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Usuarios"].ConnectionString))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("INS_USUARIOS_MANT", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", g.id);
                    cmd.Parameters.AddWithValue("@Nombres", g.nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", g.apellidos);
                    cmd.Parameters.AddWithValue("@Loginn", g.login);
                    cmd.Parameters.AddWithValue("@Passwordd", g.password);
                    cmd.Parameters.AddWithValue("@Estado", g.estado);
                    cmd.Parameters.AddWithValue("@Crea", "");
                    cmd.Parameters.AddWithValue("@usu", g.Usu);
                    cmd.Parameters.AddWithValue("@Modifica", "");
                    cmd.Parameters.AddWithValue("@Elimina", "");
                    cmd.Parameters.AddWithValue("@opc", 4);
                    cmd.ExecuteNonQuery();
                    s = "si";
                }
                catch (Exception ex)
                {
                    s = "no";
                    ViewBag.mensaje = "error" + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            return s;
        }

        public string EncryptKey(string cadena)
        {

            byte[] keyArray;
            byte[] Arreglo_a_Cifrar =
            Encoding.UTF8.GetBytes(cadena);

            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            return Convert.ToBase64String(ArrayResultado,
                   0, ArrayResultado.Length);

        }
    }
}