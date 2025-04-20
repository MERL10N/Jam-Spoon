using UnityEngine;

public class HotDogLogic : MonoBehaviour
{
    public GameObject collidedObject;
    public GameObject hotdog;
    public new Collider2D collider2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //hotdog = GameObject.Find("hot dog");
        //collidedObject = GameObject.Find("empty");
        collider2D = GetComponent<Collider2D>();
        hotdog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (collider2D.IsTouching(collidedObject.GetComponent<Collider2D>()))
        {
            Debug.Log("touch");
            if (collidedObject.tag == "bun" || collidedObject.tag == "sausage")
            {
                CombineElements(gameObject, collidedObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedObject = collision.gameObject;
    }

    public void CombineElements(GameObject element1, GameObject element2)
    {
        Destroy(element1);
        Destroy(element2);

        Instantiate(hotdog, new Vector3(element1.transform.position.x, element1.transform.position.y, -1.2f), transform.rotation);
        hotdog.SetActive(true);

    }
}
