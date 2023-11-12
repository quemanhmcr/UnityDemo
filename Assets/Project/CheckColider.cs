using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CheckColider : MonoBehaviour
{
    public BoxCollider2D box;
    public Color colorPlayer;
    public Sprite spritePlayer;

    public int point = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        colorPlayer = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        spritePlayer = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Va chạm với Player!");
    }
}
