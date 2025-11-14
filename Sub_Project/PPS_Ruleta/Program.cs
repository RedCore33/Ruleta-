using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        // --- Leer ranking de máximos créditos de records.txt ---
        string recordsPath = "records.txt";
        var ranking = new Dictionary<string, int>();
        if (File.Exists(recordsPath))
        {
            foreach (var line in File.ReadAllLines(recordsPath))
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int max))
                    ranking[parts[0]] = max;
            }
        }

        // --- Mostrar ranking actual ---
        Console.WriteLine("Ranking de máximos créditos:");
        foreach (var r in ranking.OrderByDescending(x => x.Value))
            Console.WriteLine($"{r.Key}: {r.Value}");

        // --- Pedir nombre del jugador ---
        Console.Write("Introduce tu nombre o 3 letras: ");
        string nombre = Console.ReadLine()?.Trim().ToUpper();
        if (string.IsNullOrWhiteSpace(nombre)) nombre = "???";
        int recordPersonal = ranking.ContainsKey(nombre) ? ranking[nombre] : 0;

        // --- Inicializar créditos y máximo alcanzado ---
        int creditos = 25;
        int maxCreditos = creditos;

        // --- Bucle principal del juego ---
        while (creditos > 0)
        {
            // Mostrar créditos actuales
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Bienvenido a la Ruleta Casino! Créditos actuales: {creditos}");
            Console.ResetColor();

            // Lista de apuestas para la tirada
            var apuestas = new List<(int tipo, string valor, int cantidad)>();
            int creditosRestantes = creditos;

            // --- Bucle para añadir apuestas ---
            while (creditosRestantes > 0)
            {
                Console.WriteLine($"\nCréditos disponibles para apostar: {creditosRestantes}");
                Console.WriteLine("Opciones de apuesta:");
                Console.WriteLine("1. Número (0-36)");
                Console.WriteLine("2. Color (Rojo, Gris, Verde)");
                Console.WriteLine("3. Par o Impar");
                Console.Write("Elige el tipo de apuesta (1-3): ");
                string tipoInput = Console.ReadLine();
                if (!int.TryParse(tipoInput, out int tipoApuesta) || tipoApuesta < 1 || tipoApuesta > 3)
                {
                    Console.WriteLine("Opción inválida. Elige 1, 2 o 3.");
                    continue;
                }
                string valor = "";
                string tipoTexto = "";
                // --- Pedir valor de la apuesta según tipo ---
                switch (tipoApuesta)
                {
                    case 1:
                        tipoTexto = "Número";
                        Console.Write("Elige un número entre 0 y 36: ");
                        int elegido;
                        while (!int.TryParse(Console.ReadLine(), out elegido) || elegido < 0 || elegido > 36)
                        {
                            Console.Write("Número inválido. Elige un número entre 0 y 36: ");
                        }
                        valor = elegido.ToString();
                        break;
                    case 2:
                        tipoTexto = "Color";
                        Console.Write("Elige un color (Rojo, Gris, Verde): ");
                        string color;
                        while (true)
                        {
                            color = Console.ReadLine()?.Trim().ToLower();
                            if (color == "rojo" || color == "gris" || color == "verde") break;
                            Console.Write("Color inválido. Elige Rojo, Gris o Verde: ");
                        }
                        valor = color;
                        break;
                    case 3:
                        tipoTexto = "Par/Impar";
                        Console.Write("Elige Par o Impar: ");
                        string paridad;
                        while (true)
                        {
                            paridad = Console.ReadLine()?.Trim().ToLower();
                            if (paridad == "par" || paridad == "impar") break;
                            Console.Write("Opción inválida. Elige Par o Impar: ");
                        }
                        valor = paridad;
                        break;
                }
                // --- Pedir cantidad de créditos a apostar ---
                int cantidad;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"¿Cuántos créditos quieres apostar a esta opción? (1-{creditosRestantes}): ");
                Console.ResetColor();
                while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 1 || cantidad > creditosRestantes)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Cantidad inválida. Elige entre 1 y {creditosRestantes}: ");
                    Console.ResetColor();
                }
                // --- Añadir apuesta a la lista ---
                apuestas.Add((tipoApuesta, valor, cantidad));
                creditosRestantes -= cantidad;
                Console.WriteLine($"Apuesta añadida: {tipoTexto} = {valor}, Créditos = {cantidad}");
                // --- Preguntar si quiere añadir otra apuesta ---
                if (creditosRestantes > 0)
                {
                    Console.Write("¿Quieres añadir otra apuesta? (s/n): ");
                    string otra = Console.ReadLine()?.Trim().ToLower();
                    if (otra != "s" && otra != "si") break;
                }
            }
            // --- Si no hay apuestas, salir ---
            if (apuestas.Count == 0)
            {
                Console.WriteLine("No has realizado ninguna apuesta. ¡Gracias por jugar!");
                break;
            }
            // --- Descontar créditos apostados ---
            creditos -= (creditos - creditosRestantes);
            Console.WriteLine("\nGirando la ruleta...");
            // --- Animación y resultado de la ruleta ---
            (int resultado, string colorRes, string paridadRes) = GirarRuletaAnimacion();
            Console.WriteLine("\n\n------------------------------\n");
            for (int i = 0; i < 6; i++)
            {
                Console.ForegroundColor = colorRes == "Verde" ? ConsoleColor.Green : (colorRes == "Gris" ? ConsoleColor.Gray : ConsoleColor.Red);
                Console.Write($"\r¡La ruleta cayó en: {resultado} [{colorRes}] ({paridadRes})!   ");
                Thread.Sleep(200);
                Console.Write("\r" + new string(' ', 50));
                Thread.Sleep(150);
            }
            Console.ResetColor();
            Console.WriteLine($"\r¡El resultado es: {resultado} [{colorRes}] ({paridadRes})!");
            int totalGanancia = 0;
            // --- Calcular ganancias de cada apuesta ---
            foreach (var ap in apuestas)
            {
                int ganancia = 0;
                bool acierto = false;
                string tipoTexto = ap.tipo switch
                {
                    1 => "Número",
                    2 => "Color",
                    3 => "Par/Impar",
                    _ => ""
                };
                switch (ap.tipo)
                {
                    case 1: // Número
                        acierto = ap.valor == resultado.ToString();
                        if (acierto) ganancia = ap.cantidad * 14;
                        break;
                    case 2: // Color
                        acierto = ap.valor == colorRes.ToLower();
                        if (acierto)
                        {
                            if (colorRes.ToLower() == "verde") ganancia = ap.cantidad * 14;
                            else ganancia = ap.cantidad * 2;
                        }
                        break;
                    case 3: // Par o Impar
                        acierto = ap.valor == paridadRes.ToLower();
                        if (acierto) ganancia = ap.cantidad + 2;
                        break;
                }
                // --- Mostrar resultado de la apuesta ---
                if (acierto)
                {
                    totalGanancia += ganancia;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Apuesta acertada: {tipoTexto} = {ap.valor}, Ganancia: {ganancia}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Apuesta fallida: {tipoTexto} = {ap.valor}, Pierdes {ap.cantidad} crédito(s)");
                }
            }
            // --- Sumar ganancias al saldo y actualizar máximo ---
            creditos += totalGanancia;
            if (creditos > maxCreditos) maxCreditos = creditos;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Créditos actuales: {creditos}");
            Console.ResetColor();
            // --- Fin de partida si no quedan créditos ---
            if (creditos <= 0)
            {
                Console.WriteLine("\nTe has quedado sin créditos. ¡Fin del juego!");
                break;
            }
            // --- Preguntar si quiere volver a tirar ---
            Console.WriteLine("\n¿Quieres volver a tirar? (s/n): ");
            string respuesta = Console.ReadLine()?.Trim().ToLower();
            if (respuesta != "s" && respuesta != "si")
            {
                Console.WriteLine("¡Gracias por jugar!");
                break;
            }
            Console.Clear();
        }
        // --- Guardar récord personal y ranking ---
        if (maxCreditos > recordPersonal)
        {
            ranking[nombre] = maxCreditos;
            Console.WriteLine($"¡Nuevo récord personal! {nombre}: {maxCreditos}");
        }
        File.WriteAllLines(recordsPath, ranking.OrderByDescending(x => x.Value).Select(x => $"{x.Key}:{x.Value}"));
        Console.WriteLine("\nRanking actualizado:");
        foreach (var r in ranking.OrderByDescending(x => x.Value))
            Console.WriteLine($"{r.Key}: {r.Value}");
    }

    // --- Animación y resultado de la ruleta ---
    static (int, string, string) GirarRuletaAnimacion()
    {
        Random rnd = new Random();
        int[] numeros = new int[37];
        for (int i = 0; i <= 36; i++) numeros[i] = i;
        int resultado = rnd.Next(0, 37);
        int vueltas = rnd.Next(20, 30);
        for (int i = 0; i < vueltas; i++)
        {
            int idx = (resultado + i) % 37;
            int num = numeros[idx];
            string color = num == 0 ? "Verde" : (num % 2 == 0 ? "Gris" : "Rojo");
            Console.ForegroundColor = num == 0 ? ConsoleColor.Green : (num % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.Red);
            Console.Write($"{num} [{color}] ");
            Console.ResetColor();
            Thread.Sleep(100 + i * 10);
        }
        string colorFinal = resultado == 0 ? "Verde" : (resultado % 2 == 0 ? "Gris" : "Rojo");
        string paridadFinal = (resultado % 2 == 0) ? "Par" : "Impar"; // 0 ahora es Par
        return (resultado, colorFinal, paridadFinal);
    }
}
