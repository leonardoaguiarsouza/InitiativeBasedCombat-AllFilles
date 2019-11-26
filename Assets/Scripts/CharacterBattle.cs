using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour {
    
    void Start() {
        
    }

    void Update() {
        
    }
}


/* BKPS

 if( hit.collider.CompareTag( "Player" ) ) {
                    // Heal( hit.collider.GetComponent<CharacterDisplay>().character );
                    player = hit.collider.GetComponent<CharacterDisplay>().character;
                    print( player + " Selected" );
                    if( !player.active ) {
                        player.active = true;
                    }
                }



hit.collider.GetComponent<CharacterDisplay>().character

player = hit.collider.GetComponent<CharacterDisplay>().character;
                    print( player + " Selected" );
                    if( !player.active ) {
                        player.active = true;
                    }


if( Input.GetMouseButtonDown(0) ) {
            RaycastHit2D hit = Physics2D.Raycast( mousePosition, Vector2.zero, Mathf.Infinity );

            if( hit.collider != null ) {
                if( hit.collider.CompareTag( "Player" ) ) {
                    Heal( hit.collider.GetComponent<CharacterDisplay>().character );
                } else if( hit.collider.CompareTag( "Enemy" ) ) {
                    print( player );
                    // Atack( player, hit.collider.GetComponent<CharacterDisplay>().character );
                }
            }
        } 



 */