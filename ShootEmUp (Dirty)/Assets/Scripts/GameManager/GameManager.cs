using UnityEngine;

namespace Assets.Scripts.GameManager
{
    public sealed class GameManager : MonoBehaviour
    {
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}