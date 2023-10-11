using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curbadebezier
{
    public partial class Form1 : Form
    {
        private List<PointF> puntos = new List<PointF>(); // Lista que almacena los puntos de control de la curva de Bezier
        private Point puntoArrastrado = Point.Empty; // Punto que se está arrastrando
        private int radioPunto = 5; // Radio de los puntos de control
        private int puntoSeleccionado = -1; // Variable para llevar un registro del punto seleccionado


        public Form1()
        {
            InitializeComponent();
            puntos.Add(new PointF(50, 150));
            puntos.Add(new PointF(150, 50));
            puntos.Add(new PointF(250, 150));
            puntos.Add(new PointF(350, 250));

            // Crear etiquetas para representar los puntos de control
            for (int i = 0; i < puntos.Count; i++)
            {
                var label = new Label
                {
                    Location = new Point((int)puntos[i].X - radioPunto, (int)puntos[i].Y - radioPunto),
                    Size = new Size(2 * radioPunto, 2 * radioPunto),
                    BackColor = Color.Red,
                    Cursor = Cursors.Hand,
                    Tag = i, // Utiliza el atributo 'Tag' para identificar el punto de control
                };
                label.MouseDown += Punto_MouseDown; // Asigna el evento MouseDown para permitir arrastrar el punto
                label.MouseMove += Punto_MouseMove; // Asigna el evento MouseMove para actualizar la posición del punto
                label.MouseUp += Punto_MouseUp; // Asigna el evento MouseUp para finalizar el arrastre
                Controls.Add(label);
            }
        }

        private void Punto_MouseDown(object sender, MouseEventArgs e)
        {
            // Registra el punto seleccionado para el arrastre
            puntoSeleccionado = (int)((Label)sender).Tag;
        }

        private void Punto_MouseMove(object sender, MouseEventArgs e)
        {
            if (puntoSeleccionado != -1)
            {
                int puntoIndex = puntoSeleccionado;
                int x = e.X + ((Label)sender).Left + radioPunto;
                int y = e.Y + ((Label)sender).Top + radioPunto;

                // Actualiza la posición del punto de control
                puntos[puntoIndex] = new PointF(x, y);

                ((Label)sender).Left = x - radioPunto;
                ((Label)sender).Top = y - radioPunto;

                // Actualiza los valores de los TextBox con las nuevas coordenadas
                ActualizarTextBoxConPunto(puntoIndex);

                // Vuelve a dibujar la gráfica
                grafica.Refresh();
            }
        }

        private void Punto_MouseUp(object sender, MouseEventArgs e)
        {
            puntoSeleccionado = -1; // Restablece el punto seleccionado;
        }

        private void ActualizarTextBoxConPunto(int puntoIndex) {
            // Actualiza los valores de los TextBox con las coordenadas del punto de control
            TextBox textBoxX = (TextBox)Controls.Find("P" + (puntoIndex + 1) + "X", true)[0];
            TextBox textBoxY = (TextBox)Controls.Find("P" + (puntoIndex + 1) + "Y", true)[0];

            textBoxX.Text = puntos[puntoIndex].X.ToString();
            textBoxY.Text = puntos[puntoIndex].Y.ToString();
        }

        //COORDADA DEL PUNTO 1 EJE X
        private void P1X_TextChanged(object sender, EventArgs e)
        {
            ActualizarPuntoDesdeTextBox(0, P1X, P1Y);
        }

        //COORDADA DEL PUNTO 1 EJE Y
        private void P1Y_TextChanged(object sender, EventArgs e)
        {
            ActualizarPuntoDesdeTextBox(0, P1X, P1Y);
        }

        //COORDADA DEL PUNTO 2 EJE X
        private void P2X_TextChanged(object sender, EventArgs e)
        {
            ActualizarPuntoDesdeTextBox(1, P2X, P2Y);
        }

        //COORDADA DEL PUNTO 2 EJE Y
        private void P2Y_TextChanged(object sender, EventArgs e)
        {
            ActualizarPuntoDesdeTextBox(1, P2X, P2Y);
        }

        //COORDADA DEL PUNTO 3 EJE X
        private void P3X_TextChanged(object sender, EventArgs e)
        {
            ActualizarPuntoDesdeTextBox(2, P3X, P3Y);
        }

        //COORDADA DEL PUNTO 3 EJE Y
        private void P3Y_TextChanged(object sender, EventArgs e)
        {
            ActualizarPuntoDesdeTextBox(2, P3X, P3Y);
        }

        //COORDADA DEL PUNTO 4 EJE X
        private void P4X_TextChanged(object sender, EventArgs e)
        {
            ActualizarPuntoDesdeTextBox(3, P4X, P4Y);
        }

        //COORDADA DEL PUNTO 4 EJE Y
        private void P4Y_TextChanged(object sender, EventArgs e)
        {
            ActualizarPuntoDesdeTextBox(3, P4X, P4Y);
        }


        private void ActualizarPuntoDesdeTextBox(int puntoIndex, TextBox textBoxX, TextBox textBoxY)
        {
            float x, y;
            if (float.TryParse(textBoxX.Text, out x) && float.TryParse(textBoxY.Text, out y))
            {
                puntos[puntoIndex] = new PointF(x, y);
                ActualizarPosicionPuntoControl(puntoIndex);

                // Vuelve a dibujar la gráfica
                grafica.Refresh();
            }
        }

        //BOTON QUE ACTUALIZA LA GRAFICA CON LOS COORDENADAS LLENADAS EN LOS TEXTS BOXS
        private void actualizar_Click(object sender, EventArgs e)
        {
            // Actualiza los puntos de control con los valores de los TextBox
            for (int i = 0; i < puntos.Count; i++)
            {
                float x, y;
                if (float.TryParse(((TextBox)Controls.Find("P" + (i + 1) + "X", true)[0]).Text, out x) &&
                    float.TryParse(((TextBox)Controls.Find("P" + (i + 1) + "Y", true)[0]).Text, out y))
                {
                    puntos[i] = new PointF(x, y);
                    ActualizarPosicionPuntoControl(i);
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese valores válidos para las coordenadas de los puntos de control.", "Error de entrada");
                    return; // Detenemos la actualización si hay un error en la entrada
                }
            }

            // Vuelve a dibujar la gráfica
            grafica.Refresh();
        }

        private void ActualizarPosicionPuntoControl(int puntoIndex)
        {
            // Actualizar la posición de la etiqueta que representa el punto de control
            Controls[puntoIndex].Location = new Point((int)puntos[puntoIndex].X - radioPunto, (int)puntos[puntoIndex].Y - radioPunto);
        }

        //EN ESTE OBJETO VA LA GRAFICA
        private void grafica_Paint(object sender, PaintEventArgs e)
        {
            if (puntos.Count < 4) return;

            var bezierPoints = CalcularCurvaDeBezier(puntos[0], puntos[1], puntos[2], puntos[3]);
            var graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Dibuja la curva de Bezier
            using (var pen = new Pen(Color.Blue, 2))
            {
                graphics.DrawLines(pen, bezierPoints.ToArray());
            }

            // Dibuja los puntos de control
            foreach (var punto in puntos)
            {
                graphics.FillEllipse(Brushes.Red, punto.X - radioPunto, punto.Y - radioPunto, 2 * radioPunto, 2 * radioPunto);
            }
        }

        private List<PointF> CalcularCurvaDeBezier(PointF p0, PointF p1, PointF p2, PointF p3)
        {
            // Crea una lista para almacenar los puntos que formarán la curva de Bezier
            List<PointF> curvePoints = new List<PointF>();
            // El bucle itera desde t = 0 hasta t = 1 con incrementos de 0.01. Esto permite calcular varios puntos en la curva.
            for (float t = 0; t <= 1; t += 0.01f)
            {
                // Para cada valor de t, se calcula una nueva posición (x, y) en la curva de Bezier.

                // La fórmula para calcular x utiliza la ecuación de Bezier para coordenadas x:
                float x = (float)((1 - t) * (1 - t) * (1 - t) * p0.X +
                                3 * (1 - t) * (1 - t) * t * p1.X +
                                3 * (1 - t) * t * t * p2.X +
                                t * t * t * p3.X);

                // La fórmula para calcular y utiliza la ecuación de Bezier para coordenadas y:
                float y = (float)((1 - t) * (1 - t) * (1 - t) * p0.Y +
                                3 * (1 - t) * (1 - t) * t * p1.Y +
                                3 * (1 - t) * t * t * p2.Y +
                                t * t * t * p3.Y);

                // Se agrega el nuevo punto (x, y) a la lista de puntos en la curva
                curvePoints.Add(new PointF(x, y));
            }

            // Devuelve la lista de puntos que forman la curva de Bezier
            return curvePoints;
        }
    }
}
