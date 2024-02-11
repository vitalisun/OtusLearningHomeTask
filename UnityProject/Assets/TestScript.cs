using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    void Start()
    {
        _restartButton.onClick.AddListener(OnRestart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnRestart()
    {
        Debug.Log("Restart button clicked");
    }
}
