using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform pfCharacterBattle;
    private Vector2 mousePosition;
    private CharacterConteiner player;
    private CharacterConteiner enemy;
    private int turn;
    private int count = 0;

    Transform tmp;


    private void Start() {

        turn = 1;

        SpawnPlayerParty();
        SpawnEnemyParty();

        ManageBattle();
    }

    private void Update() {

        mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
                
        if( Input.GetMouseButtonDown(0) ) {
            RaycastHit2D hit = Physics2D.Raycast( mousePosition, Vector2.zero, Mathf.Infinity );

            if( hit.collider != null ) {
                if( hit.collider.CompareTag( "Enemy" ) ) {
                    enemy = hit.collider.GetComponent<CharacterDisplay>().character;
                    Atack( player, enemy );
                    ManageBattle();
                }
            } 
        }
    }

    private void SpawnPlayerParty() {
        pfCharacterBattle.tag = "Player";
        pfCharacterBattle.GetComponent<CharacterDisplay>().character = UnityEditor.AssetDatabase.LoadAssetAtPath<CharacterConteiner>("Assets/CharacterClasses/Warrior.asset");
        tmp = Instantiate( pfCharacterBattle, new Vector3(-10, 0), Quaternion.identity );
        tmp.name = pfCharacterBattle.GetComponent<CharacterDisplay>().character.name;
        pfCharacterBattle.GetComponent<CharacterDisplay>().character = UnityEditor.AssetDatabase.LoadAssetAtPath<CharacterConteiner>("Assets/CharacterClasses/Rogue.asset");
        tmp = Instantiate( pfCharacterBattle, new Vector3(-25, 0), Quaternion.identity );
        tmp.name = pfCharacterBattle.GetComponent<CharacterDisplay>().character.name;
        pfCharacterBattle.GetComponent<CharacterDisplay>().character = UnityEditor.AssetDatabase.LoadAssetAtPath<CharacterConteiner>("Assets/CharacterClasses/Mage.asset");
        tmp = Instantiate( pfCharacterBattle, new Vector3(-40, 0), Quaternion.identity );
        tmp.name = pfCharacterBattle.GetComponent<CharacterDisplay>().character.name;
        pfCharacterBattle.GetComponent<CharacterDisplay>().character = UnityEditor.AssetDatabase.LoadAssetAtPath<CharacterConteiner>("Assets/CharacterClasses/Healer.asset");
        tmp = Instantiate( pfCharacterBattle, new Vector3(-55, 0), Quaternion.identity );
        tmp.name = pfCharacterBattle.GetComponent<CharacterDisplay>().character.name;
    }

    private void SpawnEnemyParty() {
        pfCharacterBattle.tag = "Enemy";
        pfCharacterBattle.GetComponent<CharacterDisplay>().character = UnityEditor.AssetDatabase.LoadAssetAtPath<CharacterConteiner>("Assets/CharacterClasses/Dummy.asset");
        tmp = Instantiate( pfCharacterBattle, new Vector3(+10, 0), Quaternion.identity );
        tmp.name = pfCharacterBattle.GetComponent<CharacterDisplay>().character.name;
    }

    private void Atack( CharacterConteiner player, CharacterConteiner target ) {
        target.charCurrentHealth -= player.charAtack;
        print ( "Char Health: " + target.charCurrentHealth );
        player.active = false;
        player.alreadyAttacked = true;
        count++;
    }

    private void EnemyAction( CharacterConteiner enemy ) {
        GameObject[] playerTeam = GameObject.FindGameObjectsWithTag( "Player" );
        int index2 = Random.Range( 0, playerTeam.Length );
        GameObject selectedPlayer = playerTeam[index2];
        CharacterConteiner target = selectedPlayer.GetComponent<CharacterDisplay>().character;

        target.charCurrentHealth -= enemy.charAtack;
        enemy.alreadyAttacked = true;
        print ( "Enemy " + enemy.charClass + " Attacked Player " + target.charClass );
        count++;
    }

    private void Heal( CharacterConteiner target ) {
        target.charCurrentHealth += 10;
        print ( "Char Health: " + target.charCurrentHealth );
    }

    private CharacterConteiner ManageBattle() {
        List<GameObject> turnList = new List<GameObject>();
        GameObject[] playerTeam;
        GameObject[] enemyTeam;
        GameObject[] aux;
        int initiativeRoll;
  
        aux = GameObject.FindGameObjectsWithTag( "Character" );
        playerTeam = GameObject.FindGameObjectsWithTag( "Player" );
        enemyTeam = GameObject.FindGameObjectsWithTag( "Enemy" );

        GameObject[] characters = new GameObject[aux.Length];
     
        for( int i = 0; i < aux.Length; i++ ) {
            GameObject objectMain = aux[i].transform.parent.gameObject;
            characters.SetValue(objectMain, i);
        }

        foreach( var character in characters ) {
            initiativeRoll = Random.Range( 0, 3 );
            character.GetComponent<CharacterDisplay>().character.charCurrentSpeed += initiativeRoll;
            turnList.Add(character);
        }

        turnList = turnList.OrderByDescending( x => x.GetComponent<CharacterDisplay>().character.charCurrentSpeed ).ToList();

        foreach( var action in turnList ) {
            if( action.GetComponent<CharacterDisplay>().CompareTag("Player") && !action.GetComponent<CharacterDisplay>().character.alreadyAttacked ) {
                player = action.GetComponent<CharacterDisplay>().character;
                player.active = true;
                
                print( "Seclected: " + player.charClass + " Count: " + count +  " Turn List: "  + turnList.Count );
                
                return player;
            }
            if( action.GetComponent<CharacterDisplay>().CompareTag("Enemy") && !action.GetComponent<CharacterDisplay>().character.alreadyAttacked ) {
                enemy = action.GetComponent<CharacterDisplay>().character;
                EnemyAction( enemy );
            }
        }

        if( count == turnList.Count ) {
            count = 0;
            turn++;
            
            for ( int i = 0; i < playerTeam.Length; i++ ) {
                playerTeam[i].GetComponent<CharacterDisplay>().character.alreadyAttacked = false;
            }
            for ( int i = 0; i < enemyTeam.Length; i++ ) {
                enemyTeam[i].GetComponent<CharacterDisplay>().character.alreadyAttacked = false;
            }
            ManageBattle();            
        }

        return player;
    }


}