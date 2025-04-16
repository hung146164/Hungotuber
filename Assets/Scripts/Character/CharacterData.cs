using UnityEngine;
[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Character/Create New Character")]
public class CharacterData : ScriptableObject
{
    [Header("Base Stats")]
    public string characterName;
    public int health;
    public float speed;
    public int damage;
    public int armor;
    [Header("Color")]
    public Color color;
}
