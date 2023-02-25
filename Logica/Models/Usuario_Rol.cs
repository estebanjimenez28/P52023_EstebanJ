using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Usuario_Rol
    {
        //Primero se digita las propiedades de la clase  
        public int UsuarioRolID { get; set; }

        //private int usarioRolID;

        //public int UsuarioRolID
        //{
        //    get { return usarioRolID; }
        //    set { usarioRolID = value; }
        //}

        public string UsuarioRolDescripcion { get; set; }

        //luego de escribir las porpiedades simples se digitan
        // las propiedades compuestas(en este caso no hay )

        //Por ultimo se escriben las funciones y metodos.

        public DataTable Listar()
        {

            DataTable R = new DataTable();
            //aqui va la programacion indicada en el diagrama
            // de secuencias

            return R;


        }
    }
}
