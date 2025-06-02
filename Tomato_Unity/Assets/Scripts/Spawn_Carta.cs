using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Spawn_Carta : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject cartaInstanciada;
    [SerializeField] private Transform pontoDeSpawn;
    [SerializeField] private Transform pontoFinal;
    [SerializeField] private int i = 0;

    public Deck carta;
    public Controle_Mesa controleDaMesa;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Tem que colocar uma condicao para nao ficar clicando no baralho, se nao ele buga, talvez colocar um true or false e no onComplete ele alterar isto
        if (carta.baralhoTomato[i] != null && pontoDeSpawn != null)
        {
            cartaInstanciada = Instantiate(carta.baralhoTomato[i], pontoDeSpawn.position, Quaternion.identity, pontoFinal.parent);
            cartaInstanciada.transform.DOMove(pontoFinal.position, 1f).SetEase(Ease.InOutSine).OnComplete(() =>
            {
                controleDaMesa.MoverCartaParaMesa(cartaInstanciada);
            });
            i++;

        }
    }
}
