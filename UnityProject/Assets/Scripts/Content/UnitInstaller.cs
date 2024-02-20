using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets.Scripts.Content
{
    public class UnitInstaller : EntityInstaller
    {
        [SerializeField] private int _health;
        [SerializeField] private int _moveSpeed;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _attackRange;
        [SerializeField] private int _damage;

        [SerializeField] private TeamEnum _team;

        protected override void Install(Entity entity)
        {
            entity.AddData(new Health { value = _health });
            entity.AddData(new MoveSpeed { value = _moveSpeed });
            entity.AddData(new AttackCooldown { value = _attackCooldown });
            entity.AddData(new AttackRange { value = _attackRange });
            entity.AddData(new Position { value = transform.position });
            entity.AddData(new Rotation { value = transform.rotation });
            entity.AddData(new TargetEntity { value = 0 });
            entity.AddData(new Team { value = _team });
            entity.AddData(new TransformView { value = transform });
            entity.AddData(new Damage { value = _damage });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}