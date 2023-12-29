using UnityEngine;

public class AnimEventsListener : MonoBehaviour
{
    private ScrollerView _scroller;

    private void Start()
    {
        _scroller = GetComponent<ScrollerView>();
    }

    public void ResetIconsOrder()
    {
        _scroller.ResetIconsOrder();
    }

    public void SetIconsOrderLeftClick()
    {
        _scroller.SetIconsOrderLeftClick();
    }

    public void SetIconsOrderRightClick()
    {
        _scroller.SetIconsOrderRightClick();
    }
}
