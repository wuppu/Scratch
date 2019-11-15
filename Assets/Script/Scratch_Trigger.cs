﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scratch_Trigger : MonoBehaviour {
    private GameObject failPanel;
    private GameObject clearPanel;
    private PlayToggle playToggle;

    // Start is called before the first frame update
    void Start() {
        playToggle = GameObject.FindGameObjectWithTag("compiler").transform.GetChild(0).GetComponent<PlayToggle>();
        failPanel = GameObject.FindGameObjectWithTag("canvas").transform.Find("fail").gameObject;
        clearPanel = GameObject.FindGameObjectWithTag("canvas").transform.Find("clear").gameObject;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Fire") || other.gameObject.CompareTag("wall")) {
            if (clearPanel.activeSelf == false)
            {
                Time.timeScale = 0.1f;
                failPanel.SetActive(true);
            }
        }
        else if (other.gameObject.CompareTag("Flag")) {
            if (!SceneManager.GetActiveScene().name.Contains("tutorial"))
                GameObject.Find("Canvas").GetComponent<StageSaveAndLoad>().Save();
            if (failPanel.activeSelf == false)
            {
                Time.timeScale = 0.1f;
                clearPanel.SetActive(true);
            }
        }
    }
}
