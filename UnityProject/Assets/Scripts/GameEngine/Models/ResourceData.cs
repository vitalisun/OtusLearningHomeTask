using System;

namespace Assets.Scripts.SaveSystem.Models
{
    [Serializable]
    public struct ResourceData
    {
        public string ID { get; set; }
        public int Amount { get; set; }
    }
}