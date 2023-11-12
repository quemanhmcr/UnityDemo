using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCode : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer spriteRenderer;
    private LogicGame logic;


    public bool isSkin = false;
    public float timeSkin = 1f;
    private float speed = 2f;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        target = GameObject.Find("Player");
        logic = GameObject.Find("Logic").GetComponent<LogicGame>();



        AddSprite("Assets/Project/a3-1646564548.png");
        AddSprite("Assets/Project/tamgiac.jpg");
        AddSprite("Assets/Project/tron.jpg");

        int indexColor = Random.Range(0, logic.Colors.Count);
        List<Vector3> Vector3Logic = logic.Colors;
        Vector3 ColorLogic = Vector3Logic[indexColor].normalized;
        spriteRenderer.color = new Color(ColorLogic.x, ColorLogic.y, ColorLogic.z);

        int indexSprite = Random.Range(0, sprites.Count);
        spriteRenderer.sprite = sprites[indexSprite];
    }

    private void AddSprite(string path)
    {
        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);
        sprites.Add(sprite);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.Normalize(target.transform.position - transform.position);
        dir = dir * speed * Time.deltaTime;
        transform.position += dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyCode>().RemoveOject();
        }
    }

    public void RemoveOject()
    {
        Destroy(this.gameObject);
    }


}
