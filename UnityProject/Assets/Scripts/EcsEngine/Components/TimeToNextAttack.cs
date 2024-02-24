using System;

namespace Assets.Scripts.EcsEngine.Components
{
    [Serializable]
    public struct TimeToNextAttack
    {
        public float value;
        private float _value;


        public TimeToNextAttack(float initValue)
        {
            _value = initValue;
            value = _value;
        }

        public void Reset()
        {
            value = _value;
        }
    }
}
