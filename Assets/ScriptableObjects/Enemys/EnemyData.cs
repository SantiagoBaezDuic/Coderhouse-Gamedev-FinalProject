using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects/Enemys", menuName = "NewEnemyData", order = 0)]

public class EnemyData : ScriptableObject
{
    public int rangedMaxHealth;
    public int rangedDamage;
}
