using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Criar_Jogador : MonoBehaviour
{
    [SerializeField] private RawImage imagemDoJogador;
    [SerializeField] private TMP_InputField tmpNomeDoJogador;
    private Texture2D imagemSelecionada;
    private string caminhoImagemDoJogador;

    private Estrutura_Do_Jogador.ListaDeJogadores listaDeJogadores;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        listaDeJogadores = Gerenciador_Jogadores.GerenciadorDeJogadores.CarregarJogadores();
    }

    public void SelecionarImagem()
    {
        // Refatorar colocando um metodo apenas para checagem de permissao
        NativeGallery.PermissionType tipoEscrita = NativeGallery.PermissionType.Read;
        NativeGallery.MediaType tipoImagem = NativeGallery.MediaType.Image;

        NativeGallery.Permission permissao = NativeGallery.CheckPermission(tipoEscrita, tipoImagem);

        if (permissao == NativeGallery.Permission.Granted || NativeGallery.RequestPermission(tipoEscrita, tipoImagem) == NativeGallery.Permission.Granted)
        {
            NativeGallery.GetImageFromGallery((caminhoImagem) =>
            {
                if (string.IsNullOrEmpty(caminhoImagem) || !File.Exists(caminhoImagem))
                {
                    Debug.Log("Caminho inválido ou arquivo não encontrado");
                    return;
                }

                Texture2D texture = NativeGallery.LoadImageAtPath(caminhoImagem, 512);

                if (texture == null)
                {
                    Debug.Log("Falha ao carregar a imagem");
                    return;
                }

                imagemDoJogador.texture = texture;
                imagemSelecionada = texture;
                caminhoImagemDoJogador = caminhoImagem;
            });
        }
        else if (permissao == NativeGallery.Permission.ShouldAsk)
        {
            NativeGallery.RequestPermission(tipoEscrita, tipoImagem);
        }
    }

    public void SalvarJogadores()
    {
        string nomeDoJogador = tmpNomeDoJogador.text;

        if (string.IsNullOrEmpty(nomeDoJogador) || string.IsNullOrEmpty(caminhoImagemDoJogador)) return;

        Estrutura_Do_Jogador.Jogador novoJogador = new Estrutura_Do_Jogador.Jogador
        {
            nome = nomeDoJogador,
            caminhoImagem = caminhoImagemDoJogador
        };

        listaDeJogadores.jogadores.Add(novoJogador);
        Gerenciador_Jogadores.GerenciadorDeJogadores.SalvarListaDeJogadores(listaDeJogadores);

        Debug.Log("Jogador salvo com sucesso!");
    }
}
