using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects/Items", menuName = "NewItemData", order = 0)]

public class ItemData : ScriptableObject
{
    public int value;
    public bool special;
}
