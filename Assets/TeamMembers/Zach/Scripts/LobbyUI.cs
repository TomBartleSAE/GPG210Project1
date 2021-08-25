using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class LobbyUI : NetworkBehaviour
{
    [SerializeField]
    public AsteroidNetworkManager asteroidNetworkManager = null;

    public Transform userUIPanel;
    public GameObject userUIGameObject;

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
}
