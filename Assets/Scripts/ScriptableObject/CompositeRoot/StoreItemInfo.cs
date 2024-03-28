using UnityEngine;

[CreateAssetMenu(fileName = "StoreItemInfo", menuName = "CompositeRoot/Create new StoreItemInfo", order = 51)]
public class StoreItemInfo : ScriptableObject
{
    [field: SerializeField, Min(0)] public int PriceClearShelf { get; private set; } = 75;
}
