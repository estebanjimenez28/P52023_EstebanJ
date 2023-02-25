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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //Cierra la APP
            Application.Exit();
        }

        private void BtnVer_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContrasennia.UseSystemPasswordChar = false;
        }

        private void BtnVer_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContrasennia.UseSystemPasswordChar=true; 
        }

        private void BtnVer_MouseDown_1(object sender, MouseEventArgs e)
        {

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            //TODO:Se debe validar el usuario
            Globales.MiFormPrincipal.show();

            this.Hide();
        }
    }
}
