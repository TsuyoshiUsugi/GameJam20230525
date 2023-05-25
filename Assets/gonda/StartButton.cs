using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    [SerializeField] Button _StartButton;
    // Start is called before the first frame update
    void Start()
    {
        _StartButton.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
