using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCode : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer spriteRenderer;
    private LogicGame logic;
    public BoxCollider2D box;
    public GameObject enemy;
    public Color colorPlayer;
    public Sprite spritePlayer;

    public int point = 0;

    public bool isSkin = false;
    public float timeSkin = 1f;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        logic = GameObject.Find("Logic").GetComponent<LogicGame>();



        AddSprite("Assets/Project/a3-1646564548.png");
        AddSprite("Assets/Project/tamgiac.jpg");
        AddSprite("Assets/Project/tron.jpg");
    }

    private void AddSprite(string path)
    {
        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);
        sprites.Add(sprite);
    }

    // Update is called once per frame
    void Update()
    {
        if(isSkin == false)
        {
            StartCoroutine(ChangeSkin());
        }

        Vector3 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 move = dir * Time.deltaTime * speed;

        transform.position += move;




    }

    IEnumerator ChangeSkin()
    {
        int indexSprite = Random.Range(0, sprites.Count);
        spriteRenderer.sprite = sprites[indexSprite];
        int indexColor = Random.Range(0, logic.Colors.Count);
        List<Vector3> Vector3Logic = logic.Colors;
        Vector3 ColorLogic = Vector3Logic[indexColor].normalized;
        spriteRenderer.color = new Color(ColorLogic.x, ColorLogic.y, ColorLogic.z);
        
        isSkin = true;

        yield return new WaitForSeconds(timeSkin);
        
        isSkin = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            colorPlayer = collision.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            spritePlayer = collision.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;

            Sprite currentSprite = spriteRenderer.sprite;
            Color currentColor = spriteRenderer.color;

            // Kiểm tra điều kiện
            if (currentSprite.Equals(spritePlayer) && currentColor.Equals(colorPlayer))
            {
                print("Cong 3 diem");
            }
            else if (currentSprite.Equals(spritePlayer) || currentColor.Equals(colorPlayer))
            {
                print("Cong 1 diem");
            }
            else
            {
                Destroy(this.gameObject);
            }


            collision.gameObject.GetComponent<EnemyCode>().RemoveOject();

        }
    }

}
