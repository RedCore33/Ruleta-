using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido a la Ruleta Casino!");
        Console.WriteLine("Opciones de apuesta:");
        Console.WriteLine("1. Número (0-36)");
        Console.WriteLine("2. Color (Rojo, Gris, Verde)");
        Console.WriteLine("3. Par o Impar");
        Console.Write("Elige el tipo de apuesta (1-3): ");
        int tipoApuesta;
        while (!int.TryParse(Console.ReadLine(), out tipoApuesta) || tipoApuesta < 1 || tipoApuesta > 3)
        {
            Console.Write("Opción inválida. Elige 1, 2 o 3: ");
        }

        string apuesta = "";
        switch (tipoApuesta)
        {
            case 1:
                Console.Write("Elige un número entre 0 y 36: ");
                int elegido;
                while (!int.TryParse(Console.ReadLine(), out elegido) || elegido < 0 || elegido > 36)
                {
                    Console.Write("Número inválido. Elige un número entre 0 y 36: ");
                }
                apuesta = elegido.ToString();
                break;
            case 2:
                Console.Write("Elige un color (Rojo, Gris, Verde): ");
                string color;
                while (true)
                {
                    color = Console.ReadLine()?.Trim().ToLower();
                    if (color == "rojo" || color == "gris" || color == "verde") break;
                    Console.Write("Color inválido. Elige Rojo, Gris o Verde: ");
                }
                apuesta = color;
                break;
            case 3:
                Console.Write("Elige Par o Impar: ");
                string paridad;
                while (true)
                {
                    paridad = Console.ReadLine()?.Trim().ToLower();
                    if (paridad == "par" || paridad == "impar") break;
                    Console.Write("Opción inválida. Elige Par o Impar: ");
                }
                apuesta = paridad;
                break;
        }

        Console.WriteLine("Girando la ruleta...");
        (int resultado, string colorRes, string paridadRes) = GirarRuletaAnimacion();

        // Animación de parpadeo del resultado
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

        bool gana = false;
        switch (tipoApuesta)
        {
            case 1:
                gana = apuesta == resultado.ToString();
                break;
            case 2:
                gana = apuesta == colorRes.ToLower();
                break;
            case 3:
                gana = apuesta == paridadRes.ToLower();
                break;
        }
        if (gana)
            Console.WriteLine("¡Felicidades, has ganado!");
        else
            Console.WriteLine("Lo siento, has perdido. ¡Suerte la próxima vez!");
    }

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
        string paridadFinal = resultado == 0 ? "Ninguno" : (resultado % 2 == 0 ? "Par" : "Impar");
        return (resultado, colorFinal, paridadFinal);
    }
}
