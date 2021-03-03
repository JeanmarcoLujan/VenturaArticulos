using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenturaArticulos.Connection;

namespace VenturaArticulos
{
    public partial class Conexion : Form
    {
        public Conexion()
        {
            InitializeComponent();
        }

        private void Conexion_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateParameters())
                {
                    AccessToB1Async();
                }
                else
                {
                    MessageBox.Show("Falta ingresar datos, todos los campos son obligatorios");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        private bool ValidateParameters()
        {
            bool rpta = true;
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                rpta = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                rpta = false;
            }
            if (string.IsNullOrEmpty(textBox3.Text.Trim()))
            {
                rpta = false;
            }
            if (string.IsNullOrEmpty(textBox4.Text.Trim()))
            {
                rpta = false;
            }
            if (string.IsNullOrEmpty(textBox5.Text.Trim()))
            {
                rpta = false;
            }
            if (string.IsNullOrEmpty(textBox6.Text.Trim()))
            {
                rpta = false;
            }
            if (string.IsNullOrEmpty(textBox7.Text.Trim()))
            {
                rpta = false;
            }
            if (string.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                rpta = false;
            }


            return rpta;
        }


        private void AccessToB1Async()
        {
            

            string strMessage = string.Empty;
            int iServerType = 0;
            string sServer, sLicenseSever, sUserBD, sPassBD, sCompanyName, sUserB1, sPassB1;
            try
            {
                iServerType = comboBox1.SelectedIndex;
                sServer = textBox1.Text;
                sLicenseSever = textBox4.Text;
                sUserBD = textBox2.Text;
                sPassBD = textBox3.Text;
                sCompanyName = textBox5.Text;
                sUserB1 = textBox6.Text;
                sPassB1 = textBox7.Text;

                var SDSD = iServerType;
         
                SBOConnection cn =  new SBOConnection();
                cn.ConnectCompany(iServerType, sServer, sLicenseSever, sUserBD, sPassBD, sUserB1, sPassB1, sCompanyName, out strMessage);


                if (cn != null && cn.IsConnected)
                {
                    
                    Articulos oBaseForm = new Articulos(cn.companyObject, this);
                    oBaseForm.Show();
                }
                else
                {
                    MessageBox.Show("A ocurrido un error en la conexión, ingrese nuevamente la información");
                }

            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
