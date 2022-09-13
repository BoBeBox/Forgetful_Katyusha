using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowelTake : MonoBehaviour
{
    private Collider2D coll;
    public Animator transition;
    public float transitionTime = 1f;
    private bool isActivated = false;
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Towel")){
            isActivated = true;
            coll = collision;
        }
    }

    public void TakeIt(){
        if(isActivated){
            Destroy(coll.gameObject);
            isActivated = false;
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
