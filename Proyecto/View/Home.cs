using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Models;

namespace Proyecto
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        /*

        private DateTime Apptime() 
        {
            
            var fechacita = DateTime.Now;            
            bool continuar = true;
            int horacita;
            int mescita;
            int diacita;


            do

            {
                if (fechacita.Hour >= 8)
                {
                    continuar = false;

                }
                else
                {
                    horacita = fechacita.Hour + 1;

                }
                
            } while (continuar);


            if (fechacita.Day >= 26 )
            {
                mescita = fechacita.Month + 1;
                diacita = 1;

            }
            else 
            {
                mescita = fechacita.Month;
                diacita = fechacita.Day + 5;
            }
            
            var cita = new DateTime(fechacita.Year, mescita, diacita, horacita , 0, 0);



            
           
         
            return cita;
            
        }
        */


        private void button2_Click(object sender, EventArgs e)
        {
            

            //Expresiones regulares que controlan que solo sea una expresion con 8 digitos con numeros del 0 al 9 y otra expresion
            // de 9 digitos de 0 al 9, esto para el telefono y el DUI.
            var expression = "^[0-9]{8}$";
            var expression2 = "^[0-9]{9}$";
         


            if (Regex.IsMatch(textTelefono.Text,expression) && Regex.IsMatch(textDUI.Text,expression2) && comboBox3.Text != "" 
                && comboBox4.Text !="" && textDireccion.Text!="" && textTelefono.Text !="" && textDUI.Text !="" && textName.Text != "" 
                && textEmail.Text != "" ) //crea un User con los datos
            {
                
                //Declaramos las variables que contendran los datos de la base de datos y creamos un objeto de tipo Citizen
                //en el cual almacenaremos los datos del ciudadano para luego agregarlos a la base de datos.
                var db = new Proyecto_POO_BDDContext();
                Citizen c = new Citizen();
                List<ChronicDisease> enfermedades = db.ChronicDiseases.ToList();
                List<Ocupation> ocupaciones = db.Ocupations.ToList();
                List<Citizen> ciudadanos = db.Citizens.ToList();

                //Agregamos los datos
                c.Telephone = Int32.Parse(textTelefono.Text);
                c.Dui = textDUI.Text;
                c.FullName = textName.Text;
                c.Direction = textDireccion.Text;
                c.Age = Int32.Parse(comboBox4.Text);
                c.Email = textEmail.Text;

                bool existe = ciudadanos
                .Where(t => t.Dui == textDUI.Text)
                .ToList().Count() > 0;

             
                //Esta funcion lo que hace es que: el combobox contendra la enfermedad elegida 
                var filtro1 = enfermedades
                   .Where(e => e.CommonName.Equals(comboBox2.Text))
                    .ToList();

                //y exactamente lo mismo con las ocupaciones 
                var filtro2 = ocupaciones
                   .Where(o => o.CommonName.Equals(comboBox3.Text))
                    .ToList();

                if(comboBox2.Text == "") 
                {
                    c.IdChronicDiseases = null;

                }
                else 
                {
                    c.IdChronicDiseases = filtro1[0].Id;
                }

                                
                c.IdOccupation = filtro2[0].Id;

                if (ciudadanos.Count() == 0)
                {
                    c.Id = 1;
                }
                else
                {
                    c.Id = (ciudadanos.Count() + 1);
                }

                if (existe)
                {
                    //datos no válidos
                    MessageBox.Show("Este ciudadano ya esta registrado", "Cabina UCA",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else 
                {
                    db.Add(c);
                    db.SaveChanges();

                    // Notificar al usuario
                    MessageBox.Show("Ciudadano registrado exitosamente!", "Cabina UCA",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

             
            }
            else
            {
                //datos no válidos
                MessageBox.Show("Datos inválidos!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
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

        private void registrarUnCiudadanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
    }
}
