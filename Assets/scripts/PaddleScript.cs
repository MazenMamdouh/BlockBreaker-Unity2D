using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] int screenWidth = 16;
    [SerializeField] float min = 2f;
    [SerializeField] float max = 14f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePos =(Input.mousePosition.x / Screen.width * screenWidth);
        Vector3 PaddlePosition = new Vector3(transform.position.x, 0.25f,0.5f);
        PaddlePosition.x = Mathf.Clamp(mousePos,min,max);
        transform.position = PaddlePosition;
    }
}
