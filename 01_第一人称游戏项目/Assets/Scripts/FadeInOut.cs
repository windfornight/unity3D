﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour {


    public float fadeSpeed = 1.5f;

    private bool sceneStarting = true;
    private GUITexture tex;

    void Start()
    {
        tex = this.GetComponent<GUITexture>();
        tex.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
    }

    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }
    }

    private void FadeToClear()
    {
        tex.color = Color.Lerp(tex.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    private void FadeToBlack()
    {
        tex.color = Color.Lerp(tex.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    private void StartScene()
    {
        FadeToClear();

        if (tex.color.a <= 0.05f)
        {
            tex.color = Color.clear;
            tex.enabled = false;
            sceneStarting = false;
        }
    }

    public void EndScene()
    {
        tex.enabled = true;
        FadeToBlack();

        if (tex.color.a >= 0.95f)
        {
            SceneManager.LoadScene("Demo");
        }
        
    }
}
