using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/PlayerClass", order = 0)]
public class CharacterConteiner : ScriptableObject {
    public string charClass;
    public Color charColor;
    public int charAtack;
    public int charMaxHealth;
    public int charCurrentHealth;
    public int charBaseSpeed;
    public int charCurrentSpeed;
    public bool active;
    public bool alreadyAttacked;
}