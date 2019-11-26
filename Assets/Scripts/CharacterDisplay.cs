using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour {

    public CharacterConteiner character;

    private void Start() {
        
        GetComponent<SpriteRenderer>().color = character.charColor;
        foreach( Transform eachChild in transform ) {
            if( eachChild.name == "ClassName" ) {
               eachChild.GetComponent<TextMesh>().text = character.charClass;
            }

            if( eachChild.name == "Atack" ) {
               eachChild.GetComponent<TextMesh>().text = "ATK: " + character.charAtack.ToString();
            }

            if( eachChild.name == "Health" ) {
                eachChild.GetComponent<TextMesh>().text = "HP: " + character.charCurrentHealth.ToString();
            }

            if( eachChild.name == "Arrow" ) {
                if( character.active ) {
                    Color tmp = eachChild.GetComponent<SpriteRenderer>().color;
                    tmp.a = 255;
                    eachChild.GetComponent<SpriteRenderer>().color = tmp;
                } else {
                    Color tmp = eachChild.GetComponent<SpriteRenderer>().color;
                    tmp.a = 0;
                    eachChild.GetComponent<SpriteRenderer>().color = tmp;
                }
            }

            if( eachChild.name == "Action" ) {
                if( !character.alreadyAttacked ) {
                    Color tmp = eachChild.GetComponent<SpriteRenderer>().color;
                    tmp.a = 255;
                    eachChild.GetComponent<SpriteRenderer>().color = tmp;
                } else {
                    Color tmp = eachChild.GetComponent<SpriteRenderer>().color;
                    tmp.a = 0;
                    eachChild.GetComponent<SpriteRenderer>().color = tmp;
                }
            }

        }
    }

    private void Update() {
        foreach( Transform eachChild in transform ) {
            if( eachChild.name == "Health" ) {
                eachChild.GetComponent<TextMesh>().text = "HP: " + character.charCurrentHealth.ToString();
            }

            if( eachChild.name == "Arrow" ) {
                if( character.active ) {
                    Color tmp = eachChild.GetComponent<SpriteRenderer>().color;
                    tmp.a = 255;
                    eachChild.GetComponent<SpriteRenderer>().color = tmp;
                } else {
                    Color tmp = eachChild.GetComponent<SpriteRenderer>().color;
                    tmp.a = 0;
                    eachChild.GetComponent<SpriteRenderer>().color = tmp;
                }
            }

            if( eachChild.name == "Action" ) {
                if( !character.alreadyAttacked ) {
                    Color tmp = eachChild.GetComponent<SpriteRenderer>().color;
                    tmp.a = 255;
                    eachChild.GetComponent<SpriteRenderer>().color = tmp;
                } else {
                    Color tmp = eachChild.GetComponent<SpriteRenderer>().color;
                    tmp.a = 0;
                    eachChild.GetComponent<SpriteRenderer>().color = tmp;
                }
            }
        }
    }

    private void OnDestroy() {
        character.active = false;
        character.charCurrentHealth = character.charMaxHealth;
        character.charCurrentSpeed = character.charBaseSpeed;
        character.alreadyAttacked = false; 
    }

}
