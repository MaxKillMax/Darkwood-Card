using System.Collections.Generic;
using UnityEngine;

public class PlayerCount : MonoBehaviour
{
    [Header("OFF/ON")]
    [SerializeField] private GameObject onObject;
    [SerializeField] private GameObject offObject;

    [Header("Create players")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Vector3[] playerPositions;
    [SerializeField] private Transform parent;

    [SerializeField] private Player playerPrefab;

    private List<Player> playerList = new List<Player>();

    public void SetPlayerCount(int count)
    {
        for (int i = 0; i < count; i++)
        {
            playerList.Add(Instantiate(playerPrefab));

            playerList[playerList.Count - 1].transform.SetParent(parent);
            playerList[playerList.Count - 1].transform.localPosition = playerPositions[i];
            playerList[playerList.Count - 1].transform.localScale = new Vector3(1, 1, 1);
        }

        onObject.SetActive(true);
        offObject.SetActive(false);

        playerController.SetInformation(playerList);
    }
}
