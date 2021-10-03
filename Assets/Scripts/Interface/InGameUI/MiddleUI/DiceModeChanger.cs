using System.Collections;
using UnityEngine;
using DG.Tweening;

public class DiceModeChanger : MonoBehaviour
{
    // 0 is start
    [SerializeField] private GameObject[] DiceModeArray;

    private int currentMode = 0;
    private int otherMode = 1;

    private float up;
    private float down;

    private bool allowed = true;

    private void Start()
    {
        up = DiceModeArray[0].transform.localPosition.y;
        down = DiceModeArray[1].transform.localPosition.y;
    }

    public void ChangeDice()
    {
        if (allowed == true)
        {
            if (currentMode == 0)
            {
                currentMode = 1;
                otherMode = 0;
            }
            else
            {
                currentMode = 0;
                otherMode = 1;
            }

            DiceModeArray[currentMode].transform.DOLocalMoveY(up, 2.5f);
            DiceModeArray[otherMode].transform.DOLocalMoveY(down, 1.5f);

            allowed = false;
            StartCoroutine("ToAllowed");
        }
    }

    IEnumerator ToAllowed()
    {
        yield return new WaitForSeconds(3);

        allowed = true;

        yield break;
    }
}
