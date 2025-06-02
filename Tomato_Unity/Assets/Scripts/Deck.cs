using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private GameObject prefabTomato;
    [SerializeField] private GameObject prefabMato;
    [SerializeField] private GameObject prefabMa;
    [SerializeField] private GameObject prefabTo;

    public List<GameObject> cartasEspeciais;
    public List<GameObject> baralhoTomato = new List<GameObject>();

    private void Awake()
    {
        CriarBaralho();
    }

    private void CriarBaralho()
    {
        baralhoTomato.Clear();

        AddCartas(prefabTomato, 10);
        AddCartas(prefabMato, 10);
        AddCartas(prefabMa, 10);
        AddCartas(prefabTo, 10);

        Embaralhar();
    }

    private void AddCartas(GameObject prefab, int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            baralhoTomato.Add(prefab);
        }
    }

    private void Embaralhar()
    {
        for (int i = 0; i < baralhoTomato.Count; i++)
        {
            int randomIndex = Random.Range(i, baralhoTomato.Count);
            GameObject temp = baralhoTomato[i];
            baralhoTomato[i] = baralhoTomato[randomIndex];
            baralhoTomato[randomIndex] = temp;
        }
    }
}
