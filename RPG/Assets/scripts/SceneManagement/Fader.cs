﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();                     
        }


        public IEnumerator FadeOut(float time)
        {


            while (canvasGroup.alpha < 1) 
            { //alfa no sea 1
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
            
        }

        public IEnumerator FadeIn(float time)
        {


            while (canvasGroup.alpha > 0)
            { //alfa no sea 1
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null ;
            }

        }
    }

}
