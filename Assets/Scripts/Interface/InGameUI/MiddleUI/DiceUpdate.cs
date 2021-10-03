using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DiceUpdate : MonoBehaviour
{
    [SerializeField] private Text diceText;

    // From 1 to 100
    // Has a size 5
    [SerializeField] private int[] DiceNumberArray;

    private bool activated = false;
    private int gameDiceNumber;
    private int stages;

    public void Refresh(bool standard)
    {
        if (activated == false)
        {
            if (standard == true)
            {
                diceText.text = Random.Range(1, 7).ToString("N0");
            }
            else
            {
                stages = 0;
                gameDiceNumber = Random.Range(0, 100);
                StartCoroutine("GameDiceSeek");
            }

            StartCoroutine("WaitSecond");
        }
    }

    public void FinalRandom()
    {
        if (gameDiceNumber >= 100)
        {
            gameDiceNumber = 99;
        }
        else if (gameDiceNumber < 0)
        {
            gameDiceNumber = 0;
        }

        bool accepted = false;

        for (int i = 0; i < DiceNumberArray.Length; i++)
        {
            if (gameDiceNumber >= DiceNumberArray[i])
            {
                accepted = true;
                diceText.text = (6 - i).ToString();
                break;
            }
        }

        if (accepted == false)
        {
            diceText.text = "1";
        }
    }

    IEnumerator GameDiceSeek()
    {
        yield return new WaitForSeconds(0.25f);

        gameDiceNumber = Random.Range(gameDiceNumber - 20, gameDiceNumber + 21);
        stages++;

        if (stages < 5)
        {
            StartCoroutine("GameDiceSeek");
        }

        FinalRandom();

        yield break;
    }

    IEnumerator WaitSecond()
    {
        yield return new WaitForSeconds(1.5f);

        activated = false;

        yield break;
    }
}
