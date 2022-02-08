using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static GameManager instance;
    public int health = 10;
    private object other;

    // Start is called before the first frame update
    void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //}

        //if (instance != this)
        //    Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemies")
        {
            _ = health - 1;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

   

}
