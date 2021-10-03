using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // WARNING!
    // It is not so much a player controller as an interface controller
    // Script name is out of date

    [SerializeField] private Text firstText;
    [SerializeField] private Text playerTurnText;
    [SerializeField] private GameObject[] activateArray;
    [SerializeField] private InputField[] warHealthArray;

    private List<Player> playerList;

    private int currentPlayer = -1;

    private void Start()
    {
        for (int i = 0; i < activateArray.Length; i++)
        {
            activateArray[i].SetActive(false);
        }
    }

    public void SetInformation(List<Player> players)
    {
        playerList = players;
    }

    public void NextTurn()
    {
        if (currentPlayer == -1)
        {
            FirstTurn();
        }

        currentPlayer++;

        if (currentPlayer == playerList.Count)
        {
            currentPlayer = 0;
        }

        playerTurnText.text = "Твоя очередь, " + playerList[currentPlayer].GetName();

        for (int i = 0; i < warHealthArray.Length; i++)
        {
            warHealthArray[i].text = "";
        }
    }

    private void FirstTurn()
    {
        firstText.text = "Закончить бой";

        for (int i = 0; i < activateArray.Length; i++)
        {
            activateArray[i].SetActive(true);
        }
    }

    public void ToggleBlockChanges()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            playerList[i].ToggleBlockChanges();
        }
    }
}
