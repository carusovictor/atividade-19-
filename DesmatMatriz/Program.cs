using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Matriz 6 meses antes:");
        int[,] matrizAntes = carregarmatriz("antes.csv");

        Console.WriteLine("\nMatriz atual:");
        int[,] matrizAtual = carregarmatriz("atual.csv");

        analisarAumento(matrizAntes, matrizAtual);
        
    }

    static int[,] carregarmatriz(string caminhoArquivo)
    {
        string[] linhas = File.ReadAllLines(caminhoArquivo);
        int numLinhas = linhas.Length;
        int numcols = linhas[0].Split(",").Length;

        int[,] matriz = new int[numLinhas, numcols];

        for (int i = 0; i < numLinhas; i++)
        {
            string[] valores = linhas[i].Split(",");

            for (int j = 0; j < numcols; j++)
            {
                matriz[i, j] = int.Parse(valores[j]);
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }

        return matriz;
    }

    static double calcularPercentuaDesmatamento(int[,] matriz)
    {
        double desmatamento = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if ( matriz[i, j] == 0)
                {
                    desmatamento++;
                }
            }
        }

        double percentual = (desmatamento / 36) * 100;

        return percentual;
    }

    static void analisarAumento(int[,] matrizAntes, int[,] matrizAtual)
    {
        double percentualAntes = calcularPercentuaDesmatamento(matrizAntes);
        double percentualAtual = calcularPercentuaDesmatamento(matrizAtual);

        Console.WriteLine("\nPercentual de ocorrências na matriz 6 meses atrás:");
        Console.WriteLine($"Área Desmatada (Código 0): {percentualAntes:F2}%");

        Console.WriteLine("\nPercentual de ocorrências na matriz atual:");
        Console.WriteLine($"Área Desmatada (Código 0): {percentualAtual:F2}%");

        if (percentualAntes < percentualAtual)
        {
            Console.WriteLine($"Houve Aumento no desmatamento -- Anterior {percentualAntes:F2}% -> Atual {percentualAtual:F2}%");
        }
        else if (percentualAntes > percentualAtual)
        {
            Console.WriteLine($"Houve diminuida no desmatamento -- Anterior {percentualAntes:F2}% -> Atual {percentualAtual:F2}%");
        }
        else
        {
            Console.WriteLine($"Desmatanento permanece igual -- Anterior {percentualAntes:F2}% -> Atual {percentualAtual:F2}%");
        }
    }
}