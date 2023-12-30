using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private ScrollerView _scrollerView;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _selectButton;

    public void Show(ScrollerPresenter presenter)
    {
        _scrollerView.Initialize(presenter);

        _backButton.onClick.AddListener(OnBackButtonClick);
        _selectButton.onClick.AddListener(OnSelectButtonClick);
    }

    private void OnBackButtonClick()
    {
        Destroy(gameObject);
    }

    private void OnSelectButtonClick()
    {
        Debug.Log("Selected character: " + _scrollerView.MiddleIcon.Text.text);
    }

    private void OnDestroy()
    {
        _backButton.onClick.RemoveAllListeners();
        _selectButton.onClick.RemoveAllListeners();
    }
}