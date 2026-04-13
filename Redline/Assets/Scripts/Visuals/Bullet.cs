using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletFrom
    {
        Player,
        Enemy
    }
    [SerializeField]
    private BulletFrom bulletFrom;
    [SerializeField]
    private float bulletForce = 5f;

    private Rigidbody2D rigidbody;
    private PlayerController player;
    private GameManager gameManager;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnEnable()
    {
        bulletForce = Random.Range(2, 5);
        if(player == null)
        {
            player = PlayerController.Instance;

        }
        if (bulletFrom == BulletFrom.Player)
        {
            rigidbody.linearVelocity = Vector2.left * bulletForce;

        }
        else
        {
            Vector3 dir =  player.transform.position - transform.position;
            rigidbody.linearVelocity = dir * bulletForce;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && bulletFrom == BulletFrom.Player)
        {
            Debug.Log("Destroying");
            gameManager.RemoveEnemy(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
