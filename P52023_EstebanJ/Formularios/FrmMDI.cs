using System;
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
    public partial class FrmMDI : Form
    {
        public FrmMDI()
        {
            InitializeComponent();
        }

        private void FrmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        private void MnuGestiones_Click(object sender, EventArgs e)
        {

        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //contro para que el formulario de gestion de usuarios se muestre 
            //solo una vez

            if (!Globales.MinFormGestionUsuarios.Visible)
            {
                Globales.MinFormGestionUsuarios = new FrmUsuariosGestion();
                Globales.MinFormGestionUsuarios.Show();
            }
        }
        }
    }

