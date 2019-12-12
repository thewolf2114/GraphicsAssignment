using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string focalPoint = "Bowl";

    public static GameManager Instance { get; private set; }

    public string FocalPoint
    {
        get { return focalPoint; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            focalPoint = "Bowl";
            SceneManager.LoadScene("SampleScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            focalPoint = "Plate";
            SceneManager.LoadScene("SampleScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            focalPoint = "Mug";
            SceneManager.LoadScene("SampleScene");
        }
    }
}
