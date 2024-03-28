using UnityEngine;

[CreateAssetMenu(fileName = "RewardRange", menuName = "CompositeRoot/Create new RewardRange", order = 51)]
public class RewardRange : ScriptableObject
{
    [field: SerializeField, Min(0)] public int MinAddCoins { get; private set; } = 9;
    [field: SerializeField, Min(0)] public int MaxAddCoins { get; private set; } = 20;
}