using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenturaArticulos
{
    public partial class Articulos : Form
    {
        private Conexion objConnectionFrm;
        public SAPbobsCOM.Company oCompany = null;
        public SAPbobsCOM.Items oItem = null;
        public Articulos(SAPbobsCOM.Company _oCompany, Conexion _objConnectionFrm)
        {
            this.oCompany = _oCompany;
            this.objConnectionFrm = _objConnectionFrm;
            InitializeComponent();
        }

        private void Articulos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //  SAPbobsCOM.Items oItems =  null;

            string numero, nombre;

            numero = txtNum.Text.Trim();
            nombre = txtNom.Text.Trim();

            if(numero.Equals(""))


            oItem = null;
            oItem = (SAPbobsCOM.Items)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);

            if (string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Por favor, ingrese el número de articulo");
            }else if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese el nombre del articulo");
            }
            else
            {
                oItem.ItemCode = numero;
                oItem.ItemName = nombre;



                var result = oItem.Add();
                if (result == 0)
                {
                    MessageBox.Show("El articulo ha sido creado correctamente");
                    txtNum.Text = "";
                    txtNom.Text = "";
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }

            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
