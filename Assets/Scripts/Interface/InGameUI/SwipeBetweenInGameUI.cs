using UnityEngine;

public class SwipeBetweenInGameUI : MonoBehaviour
{
    [SerializeField] private InGameUIChanger UIChanger;
    [SerializeField] private float distanceToChange;

    private float startTouchX;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                startTouchX = touch.position.x;
                UIChanger.AwakeChangeUI();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                float difference = startTouchX - touch.position.x;

                if (Mathf.Abs(difference) > distanceToChange)
                {
                    if (difference < 0)
                    {
                        // Swipe left
                        UIChanger.ChangeUI(true);
                    }
                    else
                    {
                        // Swipe right
                        UIChanger.ChangeUI(false);
                    }
                }
            }
        }
    }
}
