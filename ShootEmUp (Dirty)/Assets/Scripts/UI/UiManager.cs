using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GameManager;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private TextMeshProUGUI _countdownText;

    [SerializeField]
    private Button _pauseButton;

    private bool _isPaused;

    private void Awake()
    {
        _startButton.gameObject.SetActive(true);
        _countdownText.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _gameManager.OnFinish += OnGameFinish;

        _startButton.onClick.AddListener(OnStartButtonClick);
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
    }

    private void OnDisable()
    {
        _gameManager.OnFinish -= OnGameFinish;

        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
    }

    public void OnStartButtonClick()
    {
        _startButton.gameObject.SetActive(false);
        _countdownText.gameObject.SetActive(true);

        StartCoroutine(Countdown());
    }

    public void OnPauseButtonClick()
    {
        var pauseTxtComponent = _pauseButton.gameObject.GetComponentInChildren<TextMeshProUGUI>();

        if (pauseTxtComponent == null)
            throw new System.Exception("Pause button does not have TextMeshProUGUI component");

        if (_isPaused)
        {
            pauseTxtComponent.text = "Pause";
            _gameManager.Resume();
            _isPaused = false;
        }
        else
        {
            pauseTxtComponent.text = "Resume";
            _gameManager.Pause();
            _isPaused = true;
        }
    }

    private IEnumerator Countdown()
    {
        int count = 3;

        while (count > 0)
        {
            _countdownText.text = count.ToString();

            yield return new WaitForSeconds(1f);

            count--;
        }

        _countdownText.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
        _gameManager.OnStart();
    }

    private void OnGameFinish()
    {
        _startButton.gameObject.SetActive(true);
        _countdownText.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(false);
    }
}
