using UnityEngine;

namespace UI
{
    public sealed class UIService : MonoBehaviour
    {
        [SerializeField]
        private HeroListView bluePlayer;

        [SerializeField]
        private HeroListView redPlayer;

        public HeroListView GetBluePlayer()
        {
            return this.bluePlayer;
        }

        public HeroListView GetRedPlayer()
        {
            return this.redPlayer;
        }

        void OnEnable()
        {
            this.bluePlayer.OnHeroClicked += this.OnHeroClicked;
            this.redPlayer.OnHeroClicked += this.OnHeroClicked;
        }

        void OnDisable()
        {
            this.bluePlayer.OnHeroClicked -= this.OnHeroClicked;
            this.redPlayer.OnHeroClicked -= this.OnHeroClicked;
        }

        private void OnHeroClicked(HeroView view)
        {
            Debug.Log(view.name);
        }
    }
}