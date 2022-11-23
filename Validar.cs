using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoRentaDeBarcos
{
    class Validar
    {
        public static void SoloLetras(KeyPressEventArgs v)
        {
            try
            {
                if (Char.IsLetter(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (Char.IsSeparator(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (Char.IsControl(v.KeyChar))
                {
                    v.Handled = false;
                }
                else
                {
                    v.Handled = true;
                    MessageBox.Show("¡SOLO LETRAS!");
                }
            }
            catch (Exception e)
            { }
        }

        public static void SoloNumeros(KeyPressEventArgs v)
        {
            try
            {
                if (Char.IsNumber(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (Char.IsSeparator(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (Char.IsControl(v.KeyChar))
                {
                    v.Handled = false;
                }
                else
                {
                    v.Handled = true;
                    MessageBox.Show("¡SOLO NÚMEROS!");
                }
            }
            catch (Exception e)
            { }
        }
    }
}
