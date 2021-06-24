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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            /*
          bool validaciones =
             textTelefono.Text.Length == 7;


          if (validaciones) //crea un User con los datos
          {
              //datos del usuario
              var db = new ClinicUcaContex();
              User u = new User();
              List<Question> qs = db.Questions.ToList();

              u.phone = Int32.Parse(textTelefono.Text);
              u.name = textBoxName.Text;
              u.direction = textDireccion.Text;
              u.email = textEmail.Text;
              u.enfermedad = textEnfermedad.Text;
              u.work = textOcupacion.Text;



              // Crear usuario y almacenar en la BDD

              db.Add(u);
              db.SaveChanges();

              // Notificar al usuario
              MessageBox.Show("Ciudadano registrado exitosamente!", "Cabina UCA",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);





          }
          else
          {
              //datos no válidos
              MessageBox.Show("Datos inválidos!", "Cabina UCA",
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
          */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*

         //creamos la cita
         var db = new ClinicUcaContex();
         Appointment a = new Appointment();

         a.id_citizen = u.id;
         a.id_employee = e.id;
         a.id_vacune = null;
         a.reservation = dateTimePicker.Value;

         db.Add(a);
         db.SaveChanges();

         // Notificar al usuario
         MessageBox.Show("Cita registrado exitosamente!", "Cabina UCA",
             MessageBoxButtons.OK, MessageBoxIcon.Information);


         */
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            /*
            var db = new ClinicUcaContex();
            List<User> usuarios = db.Users.ToList();

            string dui = textDUI.Text;
            string name = textName.Text;
           

            bool existe = usuarios
                .Where(u => u.DUI == dui &&
                            u.name == name)
                .ToList().Count() > 0;

            if (existe)
            {
                MessageBox.Show("Ponganse en fila, ya sera atendido para ser vacunado!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

              tabControl1.SelectedIndex = 4;

            }
            else
                MessageBox.Show("Ciudadano no encontrado!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            */
        }
    }
}
