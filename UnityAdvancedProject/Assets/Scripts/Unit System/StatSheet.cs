using System.Collections.Generic;

namespace UnitSystem
{
    public class StatSheet
    {
        private Dictionary<StatType, Stat> stats;
        public StatSheet(StatSheetConfig config)
        {
            stats = new Dictionary<StatType, Stat>
            {
                { StatType.MaxHp, new Stat(config.MaxHp) },
                { StatType.Damage, new Stat(config.Damage) },
                { StatType.MoveSpeed, new Stat(config.MoveSpeed) },
                { StatType.Armor, new Stat(config.Armor) },
                { StatType.AttackSpeed, new Stat(config.AttackSpeed) },
            };
        }
        public Stat GetStat(StatType statType)
        {
            return stats.GetValueOrDefault(statType);
        }
    }
}