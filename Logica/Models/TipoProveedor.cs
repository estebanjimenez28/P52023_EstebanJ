using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class TipoProveedor
    {
        public int ProveedorTipo { get; set; }
        public int ProveedorTipoDescripcion { get; set; }
    
        public DataTable Listar()
        { 
            DataTable R = new DataTable();
            //aca va el codigo funcional que carga la lista de categorias

            return R;
    }
}
}
