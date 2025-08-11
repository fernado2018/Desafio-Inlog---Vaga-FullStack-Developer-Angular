using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlog.Desafio.Backend.Domain.Models.Utils
{
    public static class PesquisaCoringa
    {
        /// <summary>
        /// Faz uma pesquisa del termoDigitado em uma posição especifica
        /// </summary> 
        /// <param name="termoDigitado">Especifica termoDigitado no qual se faz a pesquisa.</param>      
        /// <param name="posicao">Especifica a posição em que o termoDigitado vai começar a pesquisa.</param>     
        /// <posicao value="I">Faz uma pequisa ao inicio do termoDigitado.</posicao>
        /// <posicao value="E">Faz uma pequisa ao inicio e ao final do termoDigitado.</posicao>
        /// <posicao value="F">Faz uma pequisa ao final do termoDigitado.</posicao>
        public static string PosicaoTermodaPesquisa(string termoDigitado, string posicao)
        {
            string b = posicao;
            var saidaPosicao = "";

            switch (b)

            {
                case "I":
                    saidaPosicao = termoDigitado + "%";
                    break;
                case "E":
                    saidaPosicao = "%" + termoDigitado + "%";
                    break;

                case "F":
                    saidaPosicao = "%" + termoDigitado;
                    break;
            }

            return saidaPosicao;
        }
        
         public static bool EstaPreenchido(this string texto)
        {
            return !string.IsNullOrWhiteSpace(texto);
        }

    }
}