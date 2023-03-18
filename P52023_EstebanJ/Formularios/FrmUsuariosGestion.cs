﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P52023_EstebanJ.Formularios
{
    public partial class FrmUsuariosGestion : Form
    {

        //por orden es mejor crear objetos locales que permitan 
        //la gestion del tema que estamos tratando
        //usando objetos individuales en la funcion puede provocar desorden y 
        //complicar mas la lectura del codigo fuente

        //objeto local para usuario

        private Logica.Models.Usuario MiUsuarioLocal { get; set; }

        //lista local de usuarios que se visualizan en el datagridview

        private DataTable ListaUsuarios { get; set; }


        public FrmUsuariosGestion()
        {
            InitializeComponent();

            MiUsuarioLocal = new Logica.Models.Usuario();
            ListaUsuarios = new DataTable();
        }

        private void FrmUsuariosGestion_Load(object sender, EventArgs e)
        {
            //definimos el padre mdi
            MdiParent = Globales.MiFormPrincipal;

            CargarListaRoles();

            CargarListaDeUsuarios();



        }

        private void CargarListaDeUsuarios()
        {
            //resetear la lista de usuarios haciendo re instancia del objeto

            ListaUsuarios = new DataTable();

            if(CboxVerActivos.Checked)
            {
                ListaUsuarios = MiUsuarioLocal.ListarActivos();
            }
            else
            {
                ListaUsuarios = MiUsuarioLocal.ListarInactivos();

            }

            DgLista.DataSource = ListaUsuarios;
            
        }


        private void CargarListaRoles()
        {
            Logica.Models.Usuario_Rol MiRol = new Logica.Models.Usuario_Rol();

            DataTable dt = new DataTable();
            dt = MiRol.Listar();

            if( dt != null && dt.Rows.Count > 0)
            {
                CbRolesUsuario.ValueMember = "ID";
                CbRolesUsuario.DisplayMember = "Descrip";
                CbRolesUsuario.DataSource = dt;
                CbRolesUsuario.SelectedIndex = -1;
            }


        }

        private void DgLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgLista.ClearSelection();

        }

        private void DgLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cuando seleccionemos
            //una fila del datagrid se debe cargar la info de dicho usuario
            // en el usuario local y luego dibujar esa info en los controles graficos

            if(DgLista.SelectedRows.Count ==1)
            {
                //TODO: Limpiar el formulario

                //de la coleccion de filas seleccionadas(que en este caso es solo una)

                DataGridViewRow MiFila = DgLista.SelectedRows[0];

                //lo que necesito es el valor del ID del usuario para realizar la consulta
                //y traer todos los datos para llenar el objeto de usuario local

                int IdUsuario = Convert.ToInt32(MiFila.Cells["CUsuarioID"].Value);

                //para no asumir riesgos se reinstancia el usuario local
                MiUsuarioLocal = new Logica.Models.Usuario();

                //ahora le agregamos el valor obtenido por la fila aL Id


                MiUsuarioLocal.UsuarioID = IdUsuario;

                //una vez que tengo el objeto local con el valor del id, puedo ir a consultar 
                //el usuario por ese id y llenar el resto de atributos

                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorIDRetornaUsuario();

                //validamos que el usuario local tenga datos

                if(MiUsuarioLocal != null && MiUsuarioLocal.UsuarioID > 0)
                {
                    //si cargamos correctamente el usuario local llenamos los controles

                    TxtUsuarioID.Text =Convert.ToString(MiUsuarioLocal.UsuarioID);

                    TxtUsuarioNombre.Text = MiUsuarioLocal.UsuarioTelefono;

                    TxtUsuarioCedula.Text = MiUsuarioLocal.UsuarioCedula;
                    TxtUsuarioTelefono.Text = MiUsuarioLocal.UsuarioTelefono;
                    TxtUsuarioCorreo.Text = MiUsuarioLocal.UsuarioCorreo;
                    TxtUsuarioDireccion.Text = MiUsuarioLocal.UsuarioDireccion;

                    //combobox
                    CbRolesUsuario.SelectedValue = MiUsuarioLocal.MiRolTipo.UsuarioRolID;


                    //TODO: Desactivar botones que no son necesarios en este caso el de Agregar 



                }



            }
        }
    }
}
