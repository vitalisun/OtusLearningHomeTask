namespace Assets.Scripts.Core
{
    public class Hero
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Attack { get; set; }

        public int DamageToRandomEnemyAfterTurn { get;  set; }

        public int TakeDamageModifier { get; set; }

        public int PossibilityAttackWrongEnemy { get; set; }

        public int PossibilityGetHealthAfterAttack { get; set; }

        public bool HasNotDamageFirstTurn { get; set; }

        public int SkipTurnAttack { get; set; }

        public bool SkipTurn { get; set; }

        public int AddHealthToRandomAlly { get; set; }

        public int DamageToAllEnemyAfterTurn { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health}/{Attack}";
        }      
    }
}