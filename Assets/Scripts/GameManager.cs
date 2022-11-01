﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager Instance { get; private set; }
    #endregion
    //[SerializeField] private GameObject inventoryPanel;
    public Dictionary<GameObject, Health> healthContainer;
    public Dictionary<GameObject, Player> playerContainer;
    public Dictionary<GameObject, Coin> coinContainer;
    public Dictionary<GameObject, Animator> animatorContainer;
    public Dictionary<GameObject, Flag> flagContainer;
    //public Dictionary<GameObject, BuffReciever> buffRecieverContainer;
    //public Dictionary<GameObject, ItemComponent> itemsContainer;
    //public ItemBase itemBase;
    //[HideInInspector] public PlayerInventory inventory;

    private void Awake()
    {
        Instance = this;
        playerContainer= new Dictionary<GameObject, Player>();
        healthContainer = new Dictionary<GameObject, Health>();
        coinContainer = new Dictionary<GameObject, Coin>();
        flagContainer = new Dictionary<GameObject, Flag>();
        //buffRecieverContainer = new Dictionary<GameObject, BuffReciever>();
        //itemsContainer = new Dictionary<GameObject, ItemComponent>();
    }

    public void OnClickPause()
    {
        if (Time.timeScale > 0)
        {
            //inventoryPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            //inventoryPanel.gameObject.SetActive(false);
        }
    }

    public void Win()
    {
        SceneManager.LoadScene(0);
    }

    /*
    private void Start()
    {
        var healthObjects = FindObjectsOfType<Health>();
        foreach (var health in healthObjects)
        {
            healthContainer.Add(health.gameObject, health);
        }
    }
    */
}
