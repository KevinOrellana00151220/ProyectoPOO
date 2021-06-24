using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new Proyecto_POO_BDDContext();
            List<Cabin> cabinas = db.Cabins.ToList();


            List<ManagementAccount> usuarios = db.ManagementAccounts.ToList();

            string usuario = textUsuario.Text;
            string contra = textContraseña.Text;
           

            bool existe = usuarios
                .Where(u => u.UserManagement == usuario &&
                            u.PasswordManagement == contra)
                .ToList().Count() > 0;

            if (existe)
            {
                var filtro = cabinas
                   .Where(a => a.Direction.Equals(comboBox1.Text))
                   .ToList();

                ManagementLogin m = new ManagementLogin();
                Record r = new Record();                

                m.IdCabin = filtro[0].Id;
                m.DateHour = DateTime.Now;

                db.Add(m);
                db.SaveChanges();

                MessageBox.Show("Bienvenido!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Home ventanaprincipal = new Home();
                ventanaprincipal.ShowDialog();

            }
            else
                MessageBox.Show("Usuario no encontrado!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
