using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> hpEmpty;
        
        [SerializeField] private int hitPoints;
        
        public bool IsHitPointsExists() {
            return hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                hpEmpty?.Invoke(gameObject);
            }
        }
    }
}