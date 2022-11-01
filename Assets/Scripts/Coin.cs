using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        GameManager.Instance.coinContainer.Add(gameObject, this);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}