using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [HideInInspector]
    public bool active = false;

    private PlayerController pc;
    private HomeUIManager homeUIManager;
    private HomeIntro homeIntro;

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        homeUIManager = FindObjectOfType<HomeUIManager>();
        homeIntro = FindObjectOfType<HomeIntro>();
    }

    void Update()
    {
    }

    void OnMouseDown()
    {
        if(active && Mathf.Abs((pc.transform.position - transform.position).magnitude) < pc.range){
            StartCoroutine("LayDown");
            active = false;
        }
    }

    private IEnumerator LayDown(){
            homeUIManager.FadeScreenIn(homeIntro.fadeTime);
            yield return new WaitForSeconds(homeIntro.fadeTime);
            pc.gameObject.SetActive(false);

            homeUIManager.FadeTextIn(homeIntro.fadeTime);
            yield return new WaitForSeconds(homeIntro.fadeTime);
            yield return new WaitForSeconds(homeIntro.textStayTime);

            pc.gameObject.SetActive(true);
            pc.transform.forward = Vector3.forward;
            homeUIManager.FadeTextOut(homeIntro.fadeTime);
            homeUIManager.FadeScreenOut(homeIntro.fadeTime);
            yield return new WaitForSeconds(homeIntro.fadeTime);
            yield return new WaitForSeconds(homeIntro.shotStayTime);
    }
}
