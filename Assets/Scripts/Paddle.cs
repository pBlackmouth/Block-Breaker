using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float screenWidthInUnits = 16f;
    [SerializeField]
    private float minPosXInUnits = 0;
    [SerializeField]
    private float maxPosXInUnits = 16;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minPosXInUnits, maxPosXInUnits), transform.position.y);
    }
}
