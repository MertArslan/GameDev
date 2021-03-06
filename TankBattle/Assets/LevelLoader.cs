﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

	public void LoadLevel(int index)
    {
        StartCoroutine(Load(index));
    }

    public IEnumerator Load(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
