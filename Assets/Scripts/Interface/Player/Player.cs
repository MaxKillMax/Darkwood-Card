using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite[] lockSpriteArray;
    [SerializeField] private Image lockImage;

    [SerializeField] private Image playerImage;
    [SerializeField] private Button colorChangerButton;
    [SerializeField] private InputField nameInputField;

    [SerializeField] private InputField[] statsTextArray;
    [SerializeField] private int[] statsArray;

    private bool colorChanged = false;
    private bool lockedChanges = false;
    private bool locked = false;

    // 0 - level
    // 1 - health
    // 2 - money

    private void Start()
    {
        for (int i = 0; i < statsTextArray.Length; i++)
        {
            statsTextArray[i].text = statsArray[i].ToString("N0");
        }
    }

    public string GetName()
    {
        return nameInputField.text;
    }

    public void OnColorChanged()
    {
        colorChanged = !colorChanged;

        if (colorChanged)
        {
            playerImage.color = new Color(Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.8f), 1);
        }
        else
        {
            playerImage.color = new Color(0.2f, 0.2f, 0.2f, 1);
        }
    }

    public void ChangeAllowedName()
    {
        locked = !locked;
        nameInputField.interactable = locked;
        colorChangerButton.interactable = locked;

        if (locked == true)
        {
            lockImage.sprite = lockSpriteArray[0];
        }
        else
        {
            lockImage.sprite = lockSpriteArray[1];
        }
    }

    public void ChangeAllowedInputField()
    {
        for (int i = 0; i < statsTextArray.Length; i++)
        {
            statsTextArray[i].interactable = !statsTextArray[i].interactable;
        }
    }

    public void OnValueChanged(int type)
    {
        statsArray[type] = System.Convert.ToInt32(statsTextArray[type].text);
    }

    public void ToggleBlockChanges()
    {
        lockedChanges = !lockedChanges;

        for (int i = 0; i < statsTextArray.Length; i++)
        {
            statsTextArray[i].interactable = lockedChanges;
        }
    }
}
