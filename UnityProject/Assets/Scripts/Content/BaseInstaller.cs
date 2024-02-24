using EcsEngine.Components;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Assets.Scripts.Content
{
    public class BaseInstaller : EntityInstaller
    {
        [SerializeField] private int _health;
        [SerializeField] private float _radius;
        [SerializeField] private TeamEnum _team;

        protected override void Install(Entity entity)
        {
            entity.AddData(new Health { value = _health });
            entity.AddData(new EntityRadius { value = _radius });
            entity.AddData(new Position { value = transform.position });
            entity.AddData(new Team { value = _team });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}