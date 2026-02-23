using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculadoraWPF
{
    public partial class MainWindow : Window
    {
        int num1;
        int num2;
        string opcion;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            string valor = boton.Content.ToString();

            if (valor == "+" || valor == "-" || valor == "*" || valor == "/")
            {
                num1 = int.Parse(txtPantalla.Text);
                opcion = valor;
                txtPantalla.Text += valor;
            }
            else
            {
                if (txtPantalla.Text.Contains("="))
                    txtPantalla.Clear();

                txtPantalla.Text += valor;
            }
        }

        private void Igual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] partes = txtPantalla.Text.Split(
                    new char[] { '+', '-', '*', '/' });

                num2 = int.Parse(partes[1]);

                int resultado = 0;

                switch (opcion)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;

                    case "-":
                        resultado = num1 - num2;
                        break;

                    case "*":
                        resultado = num1 * num2;
                        break;

                    case "/":
                        if (num2 == 0)
                        {
                            MessageBox.Show("No se puede dividir entre 0");
                            return;
                        }
                        resultado = num1 / num2;
                        break;

                    default:
                        MessageBox.Show("Operación no válida");
                        return;
                }

                txtPantalla.Text = txtPantalla.Text + " = " + resultado;
            }
            catch
            {
                MessageBox.Show("Error en la operación");
            }
        }

        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            txtPantalla.Clear();
        }
    }
}
