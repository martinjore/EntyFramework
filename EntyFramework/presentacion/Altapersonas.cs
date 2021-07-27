using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntyFramework.model;

namespace EntyFramework.presentacion
{


    public partial class Altapersonas : Form
    {
        private int? Id;
        personas Personas = null;
        public Altapersonas(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
            if (Id != null)
            {
                CargaDatos();
            }
        }


        private void CargaDatos()
        {
            using (primaveraEntities1 db = new primaveraEntities1())
            {
                //Personas = from d in db.personas
                //           where Id = Id;
                Personas = db.personas.Find(Id);
                Txtdoc.Text = Personas.Nordoc.ToString();
                TxtApellido.Text = Personas.Apellido;
                TxtNombre.Text = Personas.Nombre;
                TxtDir.Text = Personas.Direccion;



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (primaveraEntities1 db = new primaveraEntities1())
            {
                if (Id == null)
                    Personas = new personas();

                if (Txtdoc.Text != string.Empty)

                {

                    Personas.Nordoc = Int32.Parse(Txtdoc.Text);


                    if (TxtApellido.Text != string.Empty)
                    {
                        Personas.Apellido = TxtApellido.Text;

                        if (TxtNombre.Text != string.Empty)
                        {
                            Personas.Nombre = TxtNombre.Text;
                            if (TxtDir.Text != string.Empty)

                            {
                                Personas.Direccion = TxtDir.Text;
                                if (Id == null)
                                {
                                    db.personas.Add(Personas);
                                }
                                else
                                {
                                    db.Entry(Personas).State = System.Data.Entity.EntityState.Modified;
                                }

                                db.SaveChanges();
                                MessageBox.Show("datos guardados");
                                this.Close();

                            }
                            else
                            {

                                MessageBox.Show("ingrese direccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }


                        }
                        else
                        {

                            MessageBox.Show("ingrese Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {


                        MessageBox.Show("ingrese Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
                else
                {
                    MessageBox.Show("ingrese numero de doc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



























                //            

                //       

                //    MessageBox.Show("ingrese Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //MessageBox.Show("ingrese numero de doc","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);





                //MessageBox.Show("datos guardados", "exitos", MessageBoxButtons.OK);


            }
        }

        private void Txtdoc_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void Altapersonas_Load(object sender, EventArgs e)
        {

        }

        private void Txtdoc_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Validar.Numerico(e);
        }
    }
}
