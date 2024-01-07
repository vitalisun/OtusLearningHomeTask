using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplicationRunner : MonoBehaviour
{
    [SerializeField] private List<StepApplicationRunner> _steps;
    [SerializeField] private int _nextSceneBuildIdx = 1;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _progressTitle;
    [SerializeField] private TextMeshProUGUI _progressText;


    private void Start()
    {
        RunSteps().Forget();
    }

    private async UniTaskVoid RunSteps()
    {
        var stepsCount = _steps.Count;
        _slider.maxValue = stepsCount;

        for (var index = 0; index < stepsCount; index++)
        {
            var step = _steps[index];
            _progressTitle.text = step.Title;
           float sliderProgress = index;
            _slider.value = sliderProgress;
            _progressText.text = $"{sliderProgress / stepsCount * 100:0.00}%";
            await step.WaitOnCompleted();
        }

        _slider.value = 100;
        _progressText.text = $"100.00%";

        await UniTask.Delay(1000);

        RunScene().Forget();
    }

    private async UniTaskVoid RunScene()
    {
        await SceneManager.LoadSceneAsync(_nextSceneBuildIdx, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(0);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_nextSceneBuildIdx));
    }
}