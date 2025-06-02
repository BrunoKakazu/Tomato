using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Controle_Mesa : MonoBehaviour
{
    [SerializeField] private Transform mesaTransform;

    public List<GameObject> cartasNaMesa = new List<GameObject>();

    private float espacamentoHorizontal = 150f;
    [SerializeField] private float limiteDaTelaEmX = Screen.width;
    private void Start()
    {
        if(cartasNaMesa.Count > 0) cartasNaMesa.Clear();
    }

    public void MoverCartaParaMesa(GameObject carta)
    {
        carta.transform.SetParent(mesaTransform);

        cartasNaMesa.Add(carta);

        AtualizarPosicaoCartaNaMesa(carta);
    }

    private void AtualizarPosicaoCartaNaMesa(GameObject novaCarta)
    {
        // Para arrumar o espacamento das telas -> As telas de smartphones costumam ter proporções de 16:9 ou 18:9.A proporção 18:9, mais alongada, permite que caba mais conteúdo na tela.
        // Ou seja eu preciso verificar como reconhecer que temos uma tela 16:9 e 18:9


        if (cartasNaMesa.Count != 1)
        {
            Sequence sequencia = DOTween.Sequence();

            for (int i = 0; i < cartasNaMesa.Count; i++)
            {
                Vector3 novaPosicao = cartasNaMesa[i].transform.localPosition;
                novaPosicao.x -= espacamentoHorizontal;

                novaPosicao.y = VerificaoEAjusteDaPosicaoDaCarta(novaPosicao.x, novaPosicao.y);

                sequencia.Join(cartasNaMesa[i].transform.DOLocalMove(novaPosicao, 0.3f));
            }

        
            sequencia.Append(novaCarta.transform.DOLocalMoveX((cartasNaMesa.Count - 1) * espacamentoHorizontal, 0.4f));
        }
        else
        {
            // A primeira carta eu pensei em fazer uma apresentacao rapida e depois fazer a animacao dela sendo colocada na mesa
            // Essa animacao serve para depois que revelar uma carta nova(ainda estou pensando se irei implementar isso)
            Vector3 novaPosicao = cartasNaMesa[0].transform.localPosition;
            cartasNaMesa[0].transform.DOLocalMove(novaPosicao, 0.3f);
        }
        
    }

    // Fazer ele entrar aqui toda hora e ruim, depois tem que refatorar isto
    // Tamanho em width tá erradom verificar
    private float VerificaoEAjusteDaPosicaoDaCarta(float posicaoDaCartaX, float posicaoDaCartaY)
    {
        float resultadoDoTamanhoEmY = 0;
        if (posicaoDaCartaX > limiteDaTelaEmX)
        {
            resultadoDoTamanhoEmY =  posicaoDaCartaY + espacamentoHorizontal;
        }

        return resultadoDoTamanhoEmY;
    }
}
