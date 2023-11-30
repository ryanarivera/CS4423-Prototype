using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] Color fadeColor = Color.black;
    [SerializeField] float fadeTime = 1f;
    bool fadingOut = false;
    // Start is called before the first frame update
    void Start()
    {
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn(){

        StartCoroutine(FadeInRoutine());
        IEnumerator FadeInRoutine(){
            float timer = 0f;
            while(timer < fadeTime){
                fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f - (timer/fadeTime));
                timer += Time.deltaTime;
                yield return null;
            }
            fadeImage.color = Color.clear;
            yield return null;
        }

    }

    public void FadeOut(string sceneName){

        if(fadingOut){
            return;
        }
        fadingOut = true;
        StartCoroutine(FadeOutRoutine());
        IEnumerator FadeOutRoutine(){
            float timer = 0f;
            while(timer < fadeTime){
                fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, (timer/fadeTime));
                timer += Time.deltaTime;
                yield return null;
            }
            fadeImage.color = fadeColor;
            yield return null;
            SceneManager.LoadScene(sceneName);
        }

    }

}
