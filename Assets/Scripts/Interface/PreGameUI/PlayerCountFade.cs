using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerCountFade : MonoBehaviour
{
    [SerializeField] private Text[] textArray;
    [SerializeField] private Image[] backgroundImageArray;

    private void Start()
    {
        Fade();
    }

    private void Fade()
    {
        for (int i = 0; i < textArray.Length; i++)
        {
            textArray[i].color =
                new Color(textArray[i].color.r, textArray[i].color.g, textArray[i].color.b, 0);
        }

        for (int i = 0; i < backgroundImageArray.Length; i++)
        {
            backgroundImageArray[i].color =
                new Color(backgroundImageArray[i].color.r, backgroundImageArray[i].color.g, backgroundImageArray[i].color.b, 0);
        }
    }

    public void UnFade()
    {
        for (int i = 0; i < textArray.Length; i++)
        {
            textArray[i].DOFade(1, 5f);
        }

        for (int i = 0; i < backgroundImageArray.Length; i++)
        {
            backgroundImageArray[i].DOFade(1, 4);
        }
    }
}
