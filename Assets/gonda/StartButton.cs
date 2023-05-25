using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    [SerializeField] Button _StartButton;
    [SerializeField] string _sceneName;

    // Start is called before the first frame update
    void Start()
    {
        _StartButton.onClick.AddListener(() => SceneManager.LoadScene(_sceneName));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
