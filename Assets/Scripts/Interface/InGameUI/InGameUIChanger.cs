using UnityEngine;
using DG.Tweening;

public class InGameUIChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] inGameUIArray;

    [SerializeField] private InGameUIChanger UIChanger;

    private bool left;
    private int lastUI;
    private int otherUI;
    private int currentUI = 1;

    private float timer;
    private bool awakeActivated = false;

    public void AwakeChangeUI()
    {
        if (awakeActivated == false)
        {
            awakeActivated = true;

            for (int i = 0; i < inGameUIArray.Length; i++)
            {
                inGameUIArray[i].transform.localPosition = new Vector3(inGameUIArray[i].transform.localPosition.x, 0);
            }
        }
    }

    public void ChangeUI(bool left)
    {
        if (timer == 0)
        {
            this.left = left;
            lastUI = currentUI;

            UIChanger.enabled = true;

            if (left == false)
            {
                currentUI++;

                if (currentUI == inGameUIArray.Length)
                {
                    currentUI = 0;
                }

                otherUI = currentUI + 1;

                if (otherUI == inGameUIArray.Length)
                {
                    otherUI = 0;
                }
            }
            else
            {
                currentUI--;

                if (currentUI == -1)
                {
                    currentUI = inGameUIArray.Length - 1;
                }

                otherUI = currentUI - 1;

                if (otherUI == -1)
                {
                    otherUI = inGameUIArray.Length - 1;
                }
            }

            inGameUIArray[lastUI].transform.DOLocalMoveY(-Screen.height * 2, 1f);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            inGameUIArray[currentUI].transform.DOLocalMoveX(0, 0.4f);
            EndChangeUI();
        }
    }

    private void EndChangeUI()
    {
        UIChanger.enabled = false;
        awakeActivated = false;

        timer = 0;

        if (left)
        {
            inGameUIArray[lastUI].transform.localPosition = new Vector3(Screen.width * 2, 0);
            inGameUIArray[otherUI].transform.localPosition = new Vector3(-Screen.width * 2, 0);
        }
        else
        {
            inGameUIArray[lastUI].transform.localPosition = new Vector3(-Screen.width * 2, 0);
            inGameUIArray[otherUI].transform.localPosition = new Vector3(Screen.width * 2, 0);
        }
    }
}
