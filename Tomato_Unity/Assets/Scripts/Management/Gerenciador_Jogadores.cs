using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Estrutura_Do_Jogador
{
    [Serializable]
    public class Jogador
    {
        public string nome;
        public string caminhoImagem;
    }

    [Serializable]
    public class ListaDeJogadores
    {
        public List<Jogador> jogadores = new List<Jogador>();
    }
}

// Local para salvar em JSON
public class Gerenciador_Jogadores : MonoBehaviour
{
    public static class GerenciadorDeJogadores
    {
        public static string caminhoDoArquivo => Path.Combine(Application.persistentDataPath, "jogadores.json");

        public static Estrutura_Do_Jogador.ListaDeJogadores CarregarJogadores()
        {
            if (File.Exists(caminhoDoArquivo))
            {
                string json = File.ReadAllText(caminhoDoArquivo);
                return JsonUtility.FromJson<Estrutura_Do_Jogador.ListaDeJogadores>(json);
            }

            return new Estrutura_Do_Jogador.ListaDeJogadores();
        }

        public static void SalvarListaDeJogadores(Estrutura_Do_Jogador.ListaDeJogadores lista)
        {
            string json = JsonUtility.ToJson(lista, true);
            File.WriteAllText(caminhoDoArquivo, json);
        }

    }
}
