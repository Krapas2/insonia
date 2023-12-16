using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeIntro : MonoBehaviour
{

    [System.Serializable]
    public struct Shot
    {
        public string text;
        public Transform cameraPosition;
    }

    public Shot[] shots;

    public Camera playerCam;
    public Camera introCam;

    public float darkScreenTime = 1f;
    public float fadeTime = .5f;
    public float textStayTime = 2f;
    public float shotStayTime = 3f;

    private PlayerController playerController;
    private HomeUIManager homeUIManager;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        homeUIManager = FindObjectOfType<HomeUIManager>();

        playerCam.enabled = false;
        introCam.enabled = true;
        playerController.gameObject.SetActive(false);
        homeUIManager.darkScreen.gameObject.SetActive(true);

        StartCoroutine("PlayIntro");
    }

    private IEnumerator PlayIntro(){
        yield return new WaitForSeconds(darkScreenTime);

        homeUIManager.text.text = shots[0].text;
        introCam.transform.position = shots[0].cameraPosition.position;
        introCam.transform.rotation = shots[0].cameraPosition.rotation;

        homeUIManager.FadeTextIn(fadeTime);
        yield return new WaitForSeconds(fadeTime);
        yield return new WaitForSeconds(textStayTime);

        homeUIManager.FadeTextOut(fadeTime);
        homeUIManager.FadeScreenOut(fadeTime);
        yield return new WaitForSeconds(fadeTime);
        yield return new WaitForSeconds(shotStayTime);

        for(int i = 1; i < shots.Length; i++)
        {
            homeUIManager.FadeScreenIn(fadeTime);
            yield return new WaitForSeconds(fadeTime);
            
            homeUIManager.text.text = shots[i].text;
            introCam.transform.position = shots[i].cameraPosition.position;
            introCam.transform.rotation = shots[i].cameraPosition.rotation;

            homeUIManager.FadeTextIn(fadeTime);
            yield return new WaitForSeconds(fadeTime);
            yield return new WaitForSeconds(textStayTime);

            homeUIManager.FadeTextOut(fadeTime);
            homeUIManager.FadeScreenOut(fadeTime);
            yield return new WaitForSeconds(fadeTime);
            yield return new WaitForSeconds(shotStayTime);
        }
        
        homeUIManager.FadeScreenIn(fadeTime);
        yield return new WaitForSeconds(fadeTime);
        
        playerController.gameObject.SetActive(true);
        playerCam.enabled = true;
        introCam.enabled = false;

        homeUIManager.FadeScreenOut(fadeTime);
    }
}