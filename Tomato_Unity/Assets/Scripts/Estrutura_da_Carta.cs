using UnityEngine;

public class Estrutura_da_Carta : MonoBehaviour
{
    public class Carta
    {
        public int id;
        public string nome;
        public Sprite imagem;
        public bool efeito;

        public Carta(int id, string nome, Sprite imagem, bool efeito)
        {
            this.id = id;
            this.nome = nome;
            this.imagem = imagem;
            this.efeito = efeito;
        }
    }
}
