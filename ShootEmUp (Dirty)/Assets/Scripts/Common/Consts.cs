namespace Assets.Scripts.Common
{
    public class Consts
    {
        /// <summary>
        /// Скорость движения объектов использующих MoveComponent
        /// </summary>
        public const float MoveComponentSpeed = 5f;

        /// <summary>
        /// Количество пуль в пуле
        /// </summary>
        public const int BulletPoolInitialCount = 50;

        /// <summary>
        /// Количество врагов в пуле
        /// </summary>
        public const int EnemyPoolInitialCount = 7;

        /// <summary>
        /// Минимальная дистация до позиции аттаки
        /// </summary>
        public const float ReachDistanseThreshold = 0.25f;
    }
}
