using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUIManager : MonoBehaviour
{
    public Text text;
    public RawImage darkScreen;

    void Start()
    {
        
    }

    void Update()
    {
        
    }   

    public void FadeScreenIn(float fadeTime)
    {
        StartCoroutine(FadeScreen(true, fadeTime));
    }
    public void FadeScreenOut(float fadeTime)
    {
        StartCoroutine(FadeScreen(false, fadeTime));
    }
    public void FadeTextIn(float fadeTime)
    {
        StartCoroutine(FadeText(true, fadeTime));
    }
    public void FadeTextOut(float fadeTime)
    {
        StartCoroutine(FadeText(false, fadeTime));
    }

    private IEnumerator FadeText(bool FadeIn, float fadeTime) //coroutine pra o texto aparecer ou desaparecer gradualmente
    {
        Color transparentTxtColor = text.color;
        transparentTxtColor.a = 0;
        Color opaqueTxtColor = text.color;
        opaqueTxtColor.a = 1;
        if(FadeIn)
            text.color = transparentTxtColor;
        else
            text.color = opaqueTxtColor;
        text.gameObject.SetActive(true);

        for(float elapsedTime = 0f; elapsedTime <= fadeTime; elapsedTime += Time.deltaTime){
            if(FadeIn)
                text.color = Color.Lerp(transparentTxtColor, opaqueTxtColor, elapsedTime / fadeTime);
            else
                text.color = Color.Lerp(opaqueTxtColor, transparentTxtColor, elapsedTime / fadeTime);
            yield return null;
        }

        if(!FadeIn)
            text.gameObject.SetActive(false);

    }

    private IEnumerator FadeScreen(bool FadeIn, float fadeTime) //coroutine pra a camera ser bloqueada ou liberada por uma imagem gradualmente
    {
        Color transparentScrnColor = darkScreen.color;
        transparentScrnColor.a = 0;
        Color opaqueScrnColor = darkScreen.color;
        opaqueScrnColor.a = 1;
        if(FadeIn)
            darkScreen.color = transparentScrnColor;
        else
            darkScreen.color = opaqueScrnColor;
        darkScreen.gameObject.SetActive(true);
        
        for(float elapsedTime = 0f; elapsedTime <= fadeTime; elapsedTime += Time.deltaTime){
            if(FadeIn)
                darkScreen.color = Color.Lerp(transparentScrnColor, opaqueScrnColor, elapsedTime / fadeTime);
            else
                darkScreen.color = Color.Lerp(opaqueScrnColor, transparentScrnColor, elapsedTime / fadeTime);
            yield return null;
        }
        
        if(!FadeIn)
            darkScreen.gameObject.SetActive(false);
        
    }

    
}