using System;

class Program
{
    static void Main()
    {
        string[] bairros = {"Centro", "Moema", "Pinheiros", "Itaquera", "Tatuapé",
                            "Santo Amaro", "Vila Mariana", "Lapa",
                             "Capão Redondo", "Santana"};

        int[] roubos =
        {
            350, 120, 210, 480, 190,
            310, 150, 280, 520, 240  
        };

        calcularMedia(roubos);
        exibirTop3BairrosViolentos(bairros, roubos);

        static double calcularMedia(int[] roubos)
        {
            double soma = 0;

            for (int i = 0; i < roubos.Length; i++)
            {
                soma += roubos[i];
            }

            double media = soma / 10;

            Console.WriteLine("Media dos roubos: " + media);


            return media;
        }

        static void exibirTop3BairrosViolentos(string[] bairros, int[] roubos)
        {
            int primeiro = 0;
            int segundo = 0;
            int terceiro = 0;

            int indiceP = 0;
            int indiceS = 0;
            int indiceT = 0;

            for (int i = 0; i < roubos.Length; i++)
            {
                if (roubos[i] > primeiro)
                {
                    terceiro = segundo;
                    indiceT = indiceS;

                    segundo = primeiro;
                    indiceS = indiceP;

                    primeiro = roubos[i];
                    indiceP = i;
                }
                else if ( roubos[i] > segundo)
                {
                    terceiro = segundo;
                    indiceT = indiceS;

                    segundo = roubos[i];
                    indiceS = i;
                }
                else if ( roubos[i] > terceiro)
                {
                    terceiro = roubos[i];
                    indiceT = i;
                }    

            }

                Console.WriteLine("--- TOP 3 BAIRROS MAIS VIOLENTOS ---");
                Console.WriteLine($"1º Lugar: {bairros[indiceP]} (Indice {indiceP}) - {primeiro} roubos");
                Console.WriteLine($"2º Lugar: {bairros[indiceS]} (Indice {indiceS}) - {segundo} roubos");
                Console.WriteLine($"3º Lugar: {bairros[indiceT]} (Indice {indiceT}) - {terceiro} roubos");
        }
    }
}