using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    private Image tablet;
    public Text popUpBox;

    public Animator anim;
    public float transitionTime = 1f;
    int i = 0;
    private string[] dijalozi = {"<color=yellow>Bo(G):</color> You are now a timeless being!",
    "<color=white>Katyusha:</color> What does that even mean?",
    "<color=yellow>Bo(G):</color> Your mortal mind can't comprehend this! But let me explain",
    "<color=yellow>Bo(G):</color> You can shift into your <color=white>young</color> and <color=red>old</color> self",
    "<color=yellow>Bo(G):</color> <color=white>Young</color> being agail and <color=red>old</color> that can collect things",
    "<color=white>Katyusha:</color> I see I see..... and..... WHAT NOW?",
    "<color=yellow>Bo(G):</color> Find and take your towel! Good luck!"
    };

    public void nextText(){
        if(dijalozi.Length > i){
            popUpBox.text = dijalozi[i];
            i++;
        }
        else{
            popUpBox.text = "";
            GetAway();
        }
            
    }


    public void GetAway(){
        anim.SetBool("Go",true);
    }

}
