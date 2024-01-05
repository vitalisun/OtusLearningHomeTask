using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClickerView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _clickButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _levelFinishedPanel;

    [SerializeField] private TextMeshProUGUI _characterName;
    [SerializeField] private TextMeshProUGUI _health;

    private ClickerPresenter _presenter;

    public void Init(ClickerPresenter presenter)
    {
        _presenter = presenter;
        _clickButton.onClick.AddListener(OnButtonClick);
        _exitButton.onClick.AddListener(OnExitGame);
        _presenter.OnCharacterChanged += OnCharacterChangedHandler;
        _presenter.OnDamage += OnDamageHandler;
        _presenter.OnLevelFinished += OnLevelFinishedHandler;

        _slider.maxValue = _presenter.Health;
        _slider.value = _presenter.Health;

        _characterName.text = _presenter.CharacterName;
        _health.text = $"Health: {_presenter.Health}";
    }

    private void OnExitGame()
    {
        _presenter.Dispose();
        Destroy(gameObject);
    }

    private void OnLevelFinishedHandler()
    {
        _levelFinishedPanel.SetActive(true);
    }

    private void OnDamageHandler()
    {
        _slider.value = _presenter.Health;
        _health.text = $"Health: {_presenter.Health}";
    }

    private void OnCharacterChangedHandler()
    {
        _slider.value = _presenter.Health;
        _characterName.text = _presenter.CharacterName;
        _health.text = $"Health: {_presenter.Health}";
    }

    private void OnButtonClick()
    {
        int randomDamage = Random.Range(10, 40);

        _presenter.Damage(randomDamage);
    }

    private void OnDestroy()
    {
        _clickButton.onClick.RemoveListener(OnButtonClick);
        _presenter.OnCharacterChanged -= OnCharacterChangedHandler;
        _presenter.OnDamage -= OnDamageHandler;
    }
}