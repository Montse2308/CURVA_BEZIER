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
        private List<Point> puntos = new List<Point>(); // Lista que almacena los puntos de control de la curva de Bezier
        private int puntoArrastrado;  // Punto que se está arrastrando
        private int radioPunto = 5; // Radio de los puntos de control
        private int centroX, centroY;
            
        public Form1()
        {
            InitializeComponent();
            puntoArrastrado = -1;
            centroX = panel1.Width / 2;
            centroY = panel1.Height / 2;
            puntos.Add(new Point(50, 150));
            puntos.Add(new Point(150, 50));
            puntos.Add(new Point(250, 150));
            puntos.Add(new Point(350, 250));

            for (int i = 0; i < 4; i++)
            {
                ActualizarTextBoxConPunto(i);
            }
        }

        private void ActualizarTextBoxConPunto(int index) {
            // Actualiza los valores de los TextBox con las coordenadas del punto de control
            TextBox textBoxX = (TextBox)Controls.Find("P" + (index + 1) + "X", true)[0];
            TextBox textBoxY = (TextBox)Controls.Find("P" + (index + 1) + "Y", true)[0];

            textBoxX.Text = puntos[index].X.ToString();
            textBoxY.Text = puntos[index].Y.ToString();
        }

        //BOTON QUE ACTUALIZA LA GRAFICA CON LOS COORDENADAS LLENADAS EN LOS TEXTS BOXS
        private void actualizar_Click(object sender, EventArgs e)
        {
            // Actualiza los puntos de control con los valores de los TextBox
            for (int i = 0; i < puntos.Count; i++)
            {
                int x, y;
                if (int.TryParse(((TextBox)Controls.Find("P" + (i + 1) + "X", true)[0]).Text, out x) &&
                    int.TryParse(((TextBox)Controls.Find("P" + (i + 1) + "Y", true)[0]).Text, out y))
                {
                    puntos[i] = new Point(x, y);
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
            foreach (Point punto in puntos)
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

        private void grafica_MouseDown(object sender, MouseEventArgs e)
        {

            puntoArrastrado = getPointClick(e.Location);
        }

        private void grafica_MouseMove(object sender, MouseEventArgs e)
        {
            if (puntoArrastrado != -1)
            {
                ActualizarTextBoxConPunto(puntoArrastrado);
                puntos[puntoArrastrado] = e.Location;
                grafica.Refresh();
            }

        }

        private void grafica_MouseUp(object sender, MouseEventArgs e)
        {
            puntoArrastrado = -1;

        }

        int getPointClick(Point mouse)
        {
            int i = 0;
            foreach (Point p in puntos)
            {
                int dx = mouse.X - p.X;
                int dy = mouse.Y - p.Y;
                if (dx * dx + dy * dy <= radioPunto * radioPunto)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
    }
}
