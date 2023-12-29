using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private ScrollerView _scrollerView;

    public void Show(ScrollerPresenter presenter)
    {
        _scrollerView.Initialize(presenter);
    }
}