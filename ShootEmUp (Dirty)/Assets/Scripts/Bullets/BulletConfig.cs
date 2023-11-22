using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    [CreateAssetMenu(
        fileName = "BulletConfig",
        menuName = "Bullets/New BulletConfig"
    )]
    public sealed class BulletConfig : ScriptableObject
    {
        public PhysicsLayer PhysicsLayer;

        public Color Color;

        public int Damage;

        public float Speed;
    }
}