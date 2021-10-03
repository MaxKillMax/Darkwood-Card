using System.Collections;
using UnityEngine;
using DG.Tweening;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private GameObject textObject;

    [SerializeField] private PlayerCountFade playerCountFade;

    [SerializeField] private GameObject onObject;
    [SerializeField] private GameObject offObject;

    private float time = 2;
    private bool activated = false;

    public void Play()
    {
        if (activated == false)
        {
            activated = true;

            textObject.transform.DOScale(0, time * 1.5f);
            StartCoroutine("WaitingForPlay");
        }
    }

    IEnumerator WaitingForPlay()
    {
        yield return new WaitForSeconds(time);

        onObject.SetActive(true);
        offObject.SetActive(false);

        playerCountFade.UnFade();

        yield break;
    }
}
