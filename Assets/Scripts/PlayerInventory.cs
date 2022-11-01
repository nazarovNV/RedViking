using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public int coinsCount;
    [SerializeField] private Text coinsText;
    public GameObject winButton;
    public Player CoinSoundFunc;



    private void Start()
    {
        coinsText.text = coinsCount.ToString();

    }
    public static PlayerInventory Instance { get; set; }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.Instance.coinContainer.ContainsKey(col.gameObject))
        {
            coinsCount=+10;
            coinsText.text = coinsCount.ToString();
            var coin = GameManager.Instance.coinContainer[col.gameObject];
            CoinSoundFunc.StartGainingCoinsound();
            coin.Destroy();

        }
        if (GameManager.Instance.flagContainer.ContainsKey(col.gameObject))
       {
            winButton.SetActive(true);
            Debug.Log("Кнопка активирована");

        }

    }
}
