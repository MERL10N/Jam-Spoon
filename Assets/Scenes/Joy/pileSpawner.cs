using System.Xml.Linq;
using UnityEngine;

public class pileSpawner : MonoBehaviour
{
    public GameObject instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //instance.GetComponent<SpriteRenderer>().enabled = false;
        instance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        instance = Instantiate(instance, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
        instance.transform.localScale = new Vector3(0.2f, 0.2f, 1);
        //instance.GetComponent<SpriteRenderer>().enabled = true;
        instance.SetActive(true);
    }
}
