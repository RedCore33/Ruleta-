using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public partial class Form1 : Form
{
    // --- Variables de juego ---
    int creditos = 25;
    int maxCreditos;
    string nombre = "";
    Dictionary<string, int> ranking = new();
    List<(int tipo, string valor, int cantidad)> apuestas = new();
    int resultado = 0;
    string colorRes = "";
    string paridadRes = "";
    Random rnd = new();
    Timer animTimer = new();
    int animStep = 0;
    int animTarget = 0;
    bool girando = false;

    public Form1()
    {
        InitializeComponent();
        LeerRanking();
        MostrarRanking();
        btnGirar.Enabled = false;
        maxCreditos = creditos;
        animTimer.Interval = 50;
        animTimer.Tick += AnimTimer_Tick;
        ActualizarUI();
    }

    // --- Leer ranking de records.txt ---
    void LeerRanking()
    {
        string path = "records.txt";
        if (File.Exists(path))
        {
            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int max))
                    ranking[parts[0]] = max;
            }
        }
    }

    // --- Mostrar ranking en ListBox ---
    void MostrarRanking()
    {
        lstRanking.Items.Clear();
        foreach (var r in ranking.OrderByDescending(x => x.Value))
            lstRanking.Items.Add($"{r.Key}: {r.Value}");
    }

    // --- Actualizar UI de créditos y nombre ---
    void ActualizarUI()
    {
        lblCreditos.Text = $"Créditos: {creditos}";
        lblNombre.Text = $"Jugador: {nombre}";
        btnGirar.Enabled = apuestas.Count > 0 && !girando;
    }

    // --- Añadir apuesta ---
    private void btnAñadirApuesta_Click(object sender, EventArgs e)
    {
        if (creditos <= 0) return;
        int tipo = cmbTipo.SelectedIndex + 1;
        string valor = "";
        int cantidad;
        if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad < 1 || cantidad > creditos)
        {
            MessageBox.Show($"Cantidad inválida. Elige entre 1 y {creditos}");
            return;
        }
        switch (tipo)
        {
            case 1:
                valor = txtValor.Text;
                if (!int.TryParse(valor, out int num) || num < 0 || num > 36)
                {
                    MessageBox.Show("Número inválido. Elige entre 0 y 36");
                    return;
                }
                break;
            case 2:
                valor = cmbColor.SelectedItem?.ToString()?.ToLower();
                if (valor != "rojo" && valor != "gris" && valor != "verde")
                {
                    MessageBox.Show("Color inválido");
                    return;
                }
                break;
            case 3:
                valor = cmbParidad.SelectedItem?.ToString()?.ToLower();
                if (valor != "par" && valor != "impar")
                {
                    MessageBox.Show("Paridad inválida");
                    return;
                }
                break;
        }
        apuestas.Add((tipo, valor, cantidad));
        creditos -= cantidad;
        lstApuestas.Items.Add($"{TipoTexto(tipo)} = {valor}, Créditos = {cantidad}");
        ActualizarUI();
    }

    // --- Girar la ruleta ---
    private void btnGirar_Click(object sender, EventArgs e)
    {
        if (girando || apuestas.Count == 0) return;
        girando = true;
        animStep = 0;
        animTarget = rnd.Next(0, 37);
        animTimer.Start();
    }

    // --- Animación de la ruleta ---
    private void AnimTimer_Tick(object sender, EventArgs e)
    {
        animStep++;
        resultado = (animTarget + animStep) % 37;
        pnlRuleta.Invalidate();
        if (animStep > rnd.Next(30, 50))
        {
            animTimer.Stop();
            girando = false;
            resultado = animTarget;
            colorRes = resultado == 0 ? "Verde" : (resultado % 2 == 0 ? "Gris" : "Rojo");
            paridadRes = (resultado % 2 == 0) ? "Par" : "Impar";
            CalcularGanancias();
            ActualizarUI();
            lstApuestas.Items.Clear();
            apuestas.Clear();
        }
    }

    // --- Dibujo de la ruleta circular ---
    private void pnlRuleta_Paint(object sender, PaintEventArgs e)
    {
        int cx = pnlRuleta.Width / 2;
        int cy = pnlRuleta.Height / 2;
        int radio = Math.Min(cx, cy) - 10;
        for (int i = 0; i < 37; i++)
        {
            double ang = (2 * Math.PI * i) / 37.0;
            int x = cx + (int)(radio * Math.Cos(ang));
            int y = cy + (int)(radio * Math.Sin(ang));
            Color col = i == 0 ? Color.Green : (i % 2 == 0 ? Color.Gray : Color.Red);
            using (Brush b = new SolidBrush(col))
                e.Graphics.FillEllipse(b, x - 15, y - 15, 30, 30);
            using (Font f = new Font("Arial", 10, FontStyle.Bold))
            using (Brush b = new SolidBrush(Color.White))
                e.Graphics.DrawString(i.ToString(), f, b, x - 10, y - 10);
            if (i == resultado)
            {
                using (Pen p = new Pen(Color.Gold, 4))
                    e.Graphics.DrawEllipse(p, x - 18, y - 18, 36, 36);
            }
        }
    }

    // --- Calcular ganancias y mostrar resultado ---
    void CalcularGanancias()
    {
        int totalGanancia = 0;
        foreach (var ap in apuestas)
        {
            int ganancia = 0;
            bool acierto = false;
            switch (ap.tipo)
            {
                case 1:
                    acierto = ap.valor == resultado.ToString();
                    if (acierto) ganancia = ap.cantidad * 14;
                    break;
                case 2:
                    acierto = ap.valor == colorRes.ToLower();
                    if (acierto)
                    {
                        if (colorRes.ToLower() == "verde") ganancia = ap.cantidad * 14;
                        else ganancia = ap.cantidad * 2;
                    }
                    break;
                case 3:
                    acierto = ap.valor == paridadRes.ToLower();
                    if (acierto) ganancia = ap.cantidad + 2;
                    break;
            }
            if (acierto)
            {
                totalGanancia += ganancia;
                MessageBox.Show($"Apuesta acertada: {TipoTexto(ap.tipo)} = {ap.valor}, Ganancia: {ganancia}");
            }
            else
            {
                MessageBox.Show($"Apuesta fallida: {TipoTexto(ap.tipo)} = {ap.valor}, Pierdes {ap.cantidad} crédito(s)");
            }
        }
        creditos += totalGanancia;
        if (creditos > maxCreditos) maxCreditos = creditos;
        lblResultado.Text = $"Resultado: {resultado} [{colorRes}] ({paridadRes})";
        if (creditos <= 0)
        {
            MessageBox.Show("Te has quedado sin créditos. ¡Fin del juego!");
            GuardarRanking();
            Application.Exit();
        }
    }

    // --- Guardar ranking en records.txt ---
    void GuardarRanking()
    {
        if (maxCreditos > (ranking.ContainsKey(nombre) ? ranking[nombre] : 0))
            ranking[nombre] = maxCreditos;
        File.WriteAllLines("records.txt", ranking.OrderByDescending(x => x.Value).Select(x => $"{x.Key}:{x.Value}"));
    }

    // --- Utilidad para mostrar tipo de apuesta ---
    string TipoTexto(int tipo)
    {
        return tipo switch
        {
            1 => "Número",
            2 => "Color",
            3 => "Par/Impar",
            _ => ""
        };
    }

    // --- Evento para introducir nombre ---
    private void btnNombre_Click(object sender, EventArgs e)
    {
        nombre = txtNombre.Text.Trim().ToUpper();
        if (string.IsNullOrWhiteSpace(nombre)) nombre = "???";
        lblNombre.Text = $"Jugador: {nombre}";
        btnNombre.Enabled = false;
        txtNombre.Enabled = false;
    }
}
