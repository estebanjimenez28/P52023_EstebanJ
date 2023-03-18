using Logica.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Logica.Models
{
    public class Usuario
    {
        //propiedades simples
        public int UsuarioID { get; set; }
        public string UsuarioCorreo { get; set; }
        public string UsuarioContrasennia { get; set;}
        public string UsuarioNombre { get; set; }
        public string  UsuarioCedula{ get; set; }

        public string UsuarioTelefono { get; set; }

        public string UsuarioDireccion { get; set; }

        public bool Activo { get; set; }

        //propiedades compuestas
        public Usuario_Rol MiRolTipo { get; set; }

        //normalmente cuando tenemos propiedades compuestas con tipos que
        //hemos programado nosotros mismos, debemos instanciar dichas propiedades
        //ya que son objetos
        //para esto recomiendo hacerlo en el constructor de la clase
        public Usuario()
        {
            //al crear una nueva instancia de la clase Usuario, se ejecuta
            //el codigo de eeste constructor, y tambien se crea una nueva instancia
            //de la clase usuario_rol para el objeto de MiRolTipo
            MiRolTipo= new Usuario_Rol();

        }

        //Funciones y metodos 
        public bool Agregar()
        {
            //cuando la funcion devuelve un bool me gusta inicializar la variable de retorno
            // en false(tiende a negativo el resultado de la fn)
            //y SOLO si la operacion (en este caso Insert) sale correcta
            //se cambia el valor de R a true
            bool R = false;

            //aca va el codigo que funcional que invoca a un procedimiento almacenado
            //que contiene el DML Insert 

            return R;
        }
        public bool Editar () 
        { 
            bool R = false;

            return R;
        }
        public bool Eliminar()
        {
            bool R = false;

            return R;
        }
        public bool ConsultarPorID()
        {
            bool R = false;

            return R;
        }

        public Usuario ConsultarPorIDRetornaUsuario()
        {
            Usuario R =  new Usuario();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            DataTable dt = new DataTable();


            dt = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorID");

            if(dt != null && dt.Rows.Count>0)
            {
                //esta consulta deberia tener solo un registro
                //se crea un objeto de tipo datarow para capturar la info
                //contenida en index 0 del dt (datatable)
                DataRow dr = dt.Rows[0];

                R.UsuarioID = Convert.ToInt32(dr["UsuarioID"]);
                R.UsuarioNombre = Convert.ToString(dr["UsuarioNombre"]);


                R.UsuarioCedula = Convert.ToString(dr["UsuarioCedula"]);
                R.UsuarioCorreo = Convert.ToString(dr["UsuarioCorreo"]);
                R.UsuarioTelefono = Convert.ToString(dr["UsuarioTelefono"]);
                R.UsuarioDireccion = Convert.ToString(dr["UsuarioDireccion"]);

                R.UsuarioContrasennia = string.Empty;

                //composiciones 
                R.MiRolTipo.UsuarioRolID = Convert.ToInt32(dr["UsuarioRolID"]);
                R.MiRolTipo.UsuarioRolDescripcion = Convert.ToString(dr["UsuarioRolDescripcion"]);

            }

            return R;
        }

        public bool ConsultarPorCedula()
        {
            bool R = false;

            return R;
        }
        public bool ConsultarPorEmail()
        {
            bool R = false;

            return R;
        }

        public DataTable ListarActivos()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            //en este caso como el SP tiene un parametro, debemos por lo tanto
            //definir ese parametro en la lista de parametros del objeto de conexion

            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", true));
            R = MiCnn.EjecutarSELECT("SPUsuariosListar");



            return R;
        }

        public DataTable ListarInactivos()
        {
            DataTable R = new DataTable();

            return R;
        }

        public Usuario ValidarUsuario(string pEmail, string pContrasennia) 
        {
            Usuario R = new Usuario();

            return R;

        }








    }
}
