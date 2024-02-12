using System.Linq;
using UnityEngine;

namespace UnitSystem
{
    [CreateAssetMenu(menuName = "StatConfig",fileName = "NewStatConfig",order = 1)]
    public class StatConfig : ScriptableObject
    {
        [SerializeField] private Stat[] Stats;

        public Stats GenerateStats() => new (Stats.ToList());
    }
}