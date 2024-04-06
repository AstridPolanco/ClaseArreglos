using System;

class Program
{
    static char[,] tablero = new char[3, 3];
    static char jugadorActual = 'X'; 

    static void Main(string[] args)
    {
        InicializarTablero();
        bool juegoTerminado = false;

        while (!juegoTerminado)
        {
            MostrarTablero();
            TomarTurno();
            juegoTerminado = VerificarGanador() || VerificarEmpate();
            CambiarJugador();
        }

        Console.ReadLine();
    }

    static void InicializarTablero()
    {
        for (int fila = 0; fila < 3; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                tablero[fila, columna] = '-';
            }
        }
    }

    static void MostrarTablero()
    {
        Console.WriteLine("¡Bienvenido al Juego!");
        Console.WriteLine("0 1 2");
        for (int fila = 0; fila < 3; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                Console.Write(tablero[fila, columna] + " ");
            }
            Console.WriteLine();
        }
    }

    static void TomarTurno()
    {
        bool movimientoValido = false;
        while (!movimientoValido)
        {
            Console.Write($"Turno del jugador {jugadorActual}. Ingrese la fila y la columna separadas por espacio (0 1): ");
            string[] entrada = Console.ReadLine().Split(' ');
            if (entrada.Length == 2 && int.TryParse(entrada[0], out int fila) && int.TryParse(entrada[1], out int columna)
                && fila >= 0 && fila < 3 && columna >= 0 && columna < 3 && tablero[fila, columna] == '-')
            {
                tablero[fila, columna] = jugadorActual;
                movimientoValido = true;
            }
            else
            {
                Console.WriteLine("El movimiento no es válido. Inténtelo de nuevo.");
            }
        }
    }

    static bool VerificarGanador()
    {
        // Verificar filas
        for (int fila = 0; fila < 3; fila++)
        {
            if (tablero[fila, 0] != '-' && tablero[fila, 0] == tablero[fila, 1] && tablero[fila, 1] == tablero[fila, 2])
            {
                Console.WriteLine($"¡El jugador {jugadorActual} ha ganado!");
                return true;
            }
        }

        // Verificar columnas
        for (int columna = 0; columna < 3; columna++)
        {
            if (tablero[0, columna] != '-' && tablero[0, columna] == tablero[1, columna] && tablero[1, columna] == tablero[2, columna])
            {
                Console.WriteLine($"¡El jugador {jugadorActual} ha ganado!");
                return true;
            }
        }

        // Verificar diagonales
        if (tablero[0, 0] != '-' && tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2])
        {
            Console.WriteLine($"¡El jugador {jugadorActual} ha ganado!");
            return true;
        }
        if (tablero[0, 2] != '-' && tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0])
        {
            Console.WriteLine($"¡El jugador {jugadorActual} ha ganado!");
            return true;
        }

        return false;
    }

    static bool VerificarEmpate()
    {
        for (int fila = 0; fila < 3; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                if (tablero[fila, columna] == '-')
                {
                    return false;
                }
            }
        }

        Console.WriteLine("¡Empate!");
        return true;
    }

    static void CambiarJugador()
    {
        jugadorActual = (jugadorActual == 'X') ? 'O' : 'X';
    }
}
