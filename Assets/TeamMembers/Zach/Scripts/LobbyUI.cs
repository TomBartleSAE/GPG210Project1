using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class LobbyUI : NetworkBehaviour
{
    [SerializeField]
    public AsteroidNetworkManager asteroidNetworkManager = null;

    [SerializeField] public GameManager gameManager;

    public Transform userUIPanel;
    public GameObject userUIGameObject;

    public override void OnStartServer()
    {
        base.OnStartServer();
        gameManager.StartGameEvent += Disable;
    }

    public void UpdateUserPanel()
    {
        if (asteroidNetworkManager != null)
        {
            for (int i = 0; i < asteroidNetworkManager.lobbySlots.Count; i++)
            {
                GameObject go = Instantiate(userUIGameObject, userUIPanel);
                go.GetComponentInChildren<TextMeshProUGUI>().text = asteroidNetworkManager.lobbySlots[i].name;
            }
        }

    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
