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

namespace EntyFramework
{
    public partial class Form1 : Form
    {
        public int? Id;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();

        }

        #region HELPER
        private void Refrescar()
        {
            using (primaveraEntities1 Db = new primaveraEntities1())
            {
                var lst = from d in Db.personas
                          select d;
                DGVlistaPers.DataSource = lst.ToList();
            }

        }

        private int? getId()
        {
            try
            {
              return   int.Parse(DGVlistaPers.Rows[DGVlistaPers.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            presentacion.Altapersonas Faltapersonas = new presentacion.Altapersonas();
            Faltapersonas.ShowDialog();
            Refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? Id = getId();
            if (Id != null)
            {
                presentacion.Altapersonas frmsetear= new presentacion.Altapersonas(Id);
                frmsetear.ShowDialog();
                Refrescar();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? Id = getId();
            if (Id != null)
            {
                using (primaveraEntities1 db=new primaveraEntities1())
                {
                    personas TPersonas = db.personas.Find(Id);
                    db.personas.Remove(TPersonas);
                    db.SaveChanges();
               
                }
                Refrescar();

            }
        }
    }
}
