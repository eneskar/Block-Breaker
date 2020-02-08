using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenSize = 16f;
    [SerializeField] float xMax = 16f, xMin = 0f;
    [SerializeField] bool isAutoPlayEnabled;

    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(),xMin,xMax);
        transform.position = paddlePos;
    }

    private float GetXPos(){
        if(isAutoPlayEnabled){
            return FindObjectOfType<Ball>().transform.position.x;
        } else{
            return Input.mousePosition.x / Screen.width * screenSize;
        }
    }
}
