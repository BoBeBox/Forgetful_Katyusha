using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupSystem : MonoBehaviour
{
    public Text popUpBox;
    public Animator transition;
    public float transitionTime = 1f;
    private Color neka = new Color(220,90,33);

    int i = 1;
    string[] dijalozi = {"<color=white>Katyusha:</color> God damn it! I forgot my gym towel again!",
    "<color=yellow>Bo(G):</color> How dare you damn me?!",
    "<color=white>Katyusha:</color> Woooah, am I hearing things?",
    "<color=yellow>Bo(G):</color> Punny mortal, I'll help you this once! Live your life as if Time didn't exist and you'll find your towel!"
    };
    public void nextText(){
        if(dijalozi.Length > i){
            popUpBox.text = dijalozi[i];
            i++;
        }
        else{
            popUpBox.text = "";
            LoadNextLevel();
        }
            
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }



}
