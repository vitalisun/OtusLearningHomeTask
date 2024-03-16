using Assets.Scripts.EcsEngine.Components;
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
        [SerializeField] private float _attackRange;
        [SerializeField] private int _damage;
        [SerializeField] private float _timeToNextAttack;
        [SerializeField] private float _radius;

        [SerializeField] 
        private TeamEnum _team;

        private Animator animator;

        protected override void Install(Entity entity)
        {
            entity.AddData(new Health { value = _health });
            entity.AddData(new MoveSpeed { value = _moveSpeed });
            entity.AddData(new AttackRange { value = _attackRange });
            entity.AddData(new Position { value = transform.position });
            entity.AddData(new Rotation { value = transform.rotation });
            entity.AddData(new TargetEntity { value = 0 });
            entity.AddData(new Team { value = _team });
            entity.AddData(new TransformView { value = transform });
            entity.AddData(new Damage { value = _damage });
            entity.AddData(new TimeToNextAttack(_timeToNextAttack));
            entity.AddData(new EntityRadius { value = _radius });

            animator = GetComponentInChildren<Animator>();
            entity.AddData(new AnimatorView { value = animator });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}