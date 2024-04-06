using System;

class Program
{
    static void Main(string[] args)
    {
        int[][] compras = new int[][]
        {
            new int[] {25, 50, 75, 100, 125},  // Cliente 1
            new int[] {50, 100, 150, 200, 250},  // Cliente 2
            new int[] {100, 100, 100, 100, 100}, // Cliente 3
            new int[] {200, 300, 400, 300, 400}, // Cliente 4
            new int[] {500, 600, 100, 600, 500}  // Cliente 5
        };

        int[] descuentos = CalcularDescuentos(compras);

        for (int i = 0; i < compras.Length; i++)
        {
            int totalCompra = 0;
            foreach (int compra in compras[i])
            {
                totalCompra += compra;
            }

            Console.WriteLine($"Cliente {i + 1}: Total de compra: {totalCompra} quetzales, con un descuento de: {descuentos[i]} quetzales");
        }
    }

    static int[] CalcularDescuentos(int[][] compras)
    {
        int[] descuentos = new int[compras.Length];

        for (int i = 0; i < compras.Length; i++)
        {
            int totalCompra = 0;

            foreach (int compra in compras[i])
            {
                totalCompra += compra;
            }

            // Aplicar descuentos
            if (totalCompra < 100)
            {
                // No aplica descuento
                descuentos[i] = 0;
            }
            else if (totalCompra >= 100 && totalCompra <= 1000)
            {
                // con 10% de descuento
                descuentos[i] = (int)(totalCompra * 0.1);
            }
            else
            {
                // con 20% de descuento
                descuentos[i] = (int)(totalCompra * 0.2);
            }
        }

        return descuentos;
    }
}
