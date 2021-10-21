using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CharacterSelect : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start() {

        index = PlayerPrefs.GetInt("SelectedCharacter");

        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            characterList[i] = transform.GetChild(i).gameObject; 
        }

        foreach (GameObject go in characterList) {
            go.SetActive(false);
        }

        if (characterList[index]) {
            characterList[index].SetActive(true);
        }
    }

    public void ToggleLeft() {
        //toggle off
        characterList[index].SetActive(false);

        index--;
        if (index < 0) {
            index = characterList.Length - 1;
            //toggle on
            characterList[index].SetActive(true);
        } else
            characterList[index].SetActive(true);
    }

    public void confirmChar() {
        PlayerPrefs.SetInt("SelectedCharacter", index);
        SceneManager.LoadScene("firstScene");
    }

}
