using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private string[] nomesDasCartas = { "To", "Ma", "Toma", "Tomato", "Potato", "To Reverso", "Ma Reverso", "Toma Reverso", "Tomato Reverso" };

    public Sprite[] imagensDasCartas;
    public List<Estrutura_da_Carta.Carta> cartas = new List<Estrutura_da_Carta.Carta>();
    

    private void Awake()
    {
        CriarBaralho();
    }

    private void CriarBaralho()
    {
        CartasBase();
        CartasEspeciais();
        Embaralhar();
    }

    private void CartasBase()
    {
        int contador = 0;
        int tiposDeCarta = 4;
        int quantidadePorTipoDeCarta = 10;

        for (int i = 0; i < tiposDeCarta; i++)
        {
            while (contador < quantidadePorTipoDeCarta)
            {
                cartas.Add(new Estrutura_da_Carta.Carta(i, nomesDasCartas[i], imagensDasCartas[i], false));
                contador++;
            }

            contador = 0;
        }
    }

    private void CartasEspeciais()
    {
        int tiposDeCartaDeEfeito = 4;
        int posicaoDeContinuacao = 5;

        // Adicionando o Potato
        cartas.Add(new Estrutura_da_Carta.Carta(4, nomesDasCartas[4], imagensDasCartas[4], false));

        // Adicioniando as cartas de reverso
        for (int i = 0; i < tiposDeCartaDeEfeito; i++)
        {
            cartas.Add(new Estrutura_da_Carta.Carta(i + posicaoDeContinuacao, nomesDasCartas[i + posicaoDeContinuacao], imagensDasCartas[i + posicaoDeContinuacao], true));
        }

    }

    private void Embaralhar()
    {
        for (int i = 0; i < cartas.Count; i++)
        {
            
            int randomIndex = Random.Range(i, cartas.Count);

            Estrutura_da_Carta.Carta cartaTemp = cartas[i];
            cartas[i] = cartas[randomIndex];
            cartas[randomIndex] = cartaTemp;
        }
    }
}
