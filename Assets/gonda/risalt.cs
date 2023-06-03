using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class risalt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text ScoreText;
    void Start()
    {
        ScoreText.text = "ÉXÉRÉA" + ScoreManager.Score.ToString();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
