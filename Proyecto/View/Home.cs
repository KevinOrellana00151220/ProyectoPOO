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

        

        public DateTime Apptime() 
        {
            
            var fechacita = DateTime.Now;            
            int mescita;
            int diacita;       


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
            
            var cita = new DateTime(fechacita.Year, mescita, diacita, 15 , 0, 0);
                        
            return cita;
            
        }

        public DateTime Apptime2(DateTime date1)
        {
            
            var cita = new DateTime();

            cita = date1.AddDays(42);

            return cita;

        }


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
           
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            
          
            
        }

        private void registrarUnCiudadanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            var db = new Proyecto_POO_BDDContext();
            List<Citizen> ciudadanos = db.Citizens.ToList();
            List<Appointment> citas1 = db.Appointments.ToList();
            List<Record> logins = db.Records.ToList();


            string dui = textDUI2.Text;          


            bool existe1 = ciudadanos
                .Where(u => u.Dui == dui)
                .ToList().Count() > 0;

            var filtro1 = ciudadanos
                   .Where(d => d.Dui.Equals(textDUI2.Text))
                    .ToList();
            
            var filtro2 = citas1
                   .Where(e => e.IdCitizen.Equals(filtro1[0].Id))
                    .ToList();

            
            if (existe1)
            {                
                label11.Text = Convert.ToString(filtro1[0].Age);
                label15.Text = Convert.ToString(filtro1[0].Telephone);

                if (filtro1[0].IdChronicDiseases is null)
                {
                    label16.Text = "Ninguna";

                }

                else 
                {
                    switch (filtro1[0].IdChronicDiseases)
                    {
                        case 1:
                            label16.Text = "Alzheimer";
                            break;

                        case 2:
                            label16.Text = "Artritis";
                            break;

                        case 3:
                            label16.Text = "Asma";
                            break;

                        case 4:
                            label16.Text = "Cáncer";
                            break;

                        case 5:
                            label16.Text = "Demencia";
                            break;

                        case 6:
                            label16.Text = "Diabetes";
                            break;

                        case 7:
                            label16.Text = "EPOC (Enfermedad pulmonal obstructiva crónica)";
                            break;

                        case 8:
                            label16.Text = "Enfermedad de Crohn";
                            break;

                        case 9:
                            label16.Text = "Epilipsia";
                            break;

                        case 10:
                            label16.Text = "Enfermedad del corazón";
                            break;

                        case 11:
                            label16.Text = "Fibrosis quística";
                            break;

                        case 12:
                            label16.Text = "Gonorrea";
                            break;

                        case 13:
                            label16.Text = "Herpes genital";
                            break;

                        case 14:
                            label16.Text = "Parkinson";
                            break;

                        case 15:
                            label16.Text = "Sifilis";
                            break;

                        case 16:
                            label16.Text = "Trastornos de humor";
                            break;

                        case 17:
                            label16.Text = "VIH/SIDA";
                            break;

                      
                        default:
                            break;
                    }

                }

                switch (filtro1[0].IdOccupation)
                {
                    case 1:
                        label17.Text = "civil";
                        break;

                    case 2:
                        label17.Text = "educación";
                        break;

                    case 3:
                        label17.Text = "salud";
                        break;

                    case 4:
                        label17.Text = "PNC";
                        break;

                    case 5:
                        label17.Text = "gobierno";
                        break;

                    case 6:
                        label17.Text = "fuerza armada";
                        break;

                    case 7:
                        label17.Text = "periodismo";
                        break;

                    case 8:
                        label17.Text = "cuerpo de socorro";
                        break;

                    case 9:
                        label17.Text = "personal de frontera";
                        break;

                    case 10:
                        label17.Text = "centro penal";
                        break;

                    default:
                        break;
                }


                if (filtro2.Count == 0 || filtro2.Count == 1)
                {
                    if (filtro2.Count == 0) 
                    {
                        var c = new Appointment();
                        DateTime datehour;
                        int hour;
                        int number = logins.Count() - 1 ;
                        int empleado = logins[number].IdEmployee;

                        c.Id = 1;
                        c.ReservationDate = Apptime();
                        c.IdCitizen = filtro1[0].Id;
                        c.IdEmployee = empleado;
                        c.IdVaccination = 1;
                        c.IdVaccine = 1;
                        c.AssistanceDate = null;
                        c.VaccinationDate = null;
                        datehour = (DateTime)c.ReservationDate;
                        hour = datehour.Hour;
                        

                        label21.Text = Convert.ToString(c.ReservationDate);
                        label22.Text = Convert.ToString(hour) + ":00 PM";
                        label23.Text = Convert.ToString(c.IdVaccine);


                        db.Add(c);                        
                        db.SaveChanges();

                        // Notificar al usuario
                        MessageBox.Show("Cita registrada exitosamente!", "Cabina UCA",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else 
                    {
                        if (filtro2[0].VaccinationDate != null)
                        {
                            var c = new Appointment();
                            DateTime datehour;
                            int hour;
                            int number = logins.Count() - 1;
                            int empleado = logins[number].IdEmployee;

                            var newdate = new DateTime();
                            newdate = (DateTime)filtro2[0].ReservationDate;

                            c.Id = 2;
                            c.ReservationDate = Apptime2(newdate);
                            c.IdCitizen = filtro1[0].Id;
                            c.IdEmployee = empleado;
                            c.IdVaccination = 2;
                            c.IdVaccine = 2;
                            c.AssistanceDate = null;
                            c.VaccinationDate = null;
                            datehour = (DateTime)c.ReservationDate;
                            hour = datehour.Hour;

                            label21.Text = Convert.ToString(c.ReservationDate);
                            label22.Text = Convert.ToString(hour) + ":00 PM";
                            label23.Text = Convert.ToString(c.IdVaccine);

                            db.Add(c);
                            db.SaveChanges();



                            // Notificar al usuario
                            MessageBox.Show("Cita registrada exitosamente!", "Cabina UCA",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        else 
                        {
                            MessageBox.Show("Usted ya tiene una cita al cual asistir!", "Cabina UCA",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }


                        

                    }

                }

                else 
                {
                    MessageBox.Show("Usted ya ha recibido las dos vacunas!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                

            }

            else
                MessageBox.Show("Ciudadano no encontrado!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void registrarCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
    }
}
