using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndDialog : MonoBehaviour
{
    private Image tablet;
    public Text popUpBox;

    public Animator anim;
    int i = 0;
    private string[] dijalozi = {"<color=white>Katyusha:</color> Whas I dreaming?",
    "<color=yellow>Bo(G):</color> .....",
    "<color=white>Katyusha:</color> God? Are you there?",
    "<color=yellow>Bo(G):</color> .....",
    "<color=white>Katyusha:</color> Well I guess I have my gym towel now.",
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
        anim.SetBool("EndText",true);
    }
}
