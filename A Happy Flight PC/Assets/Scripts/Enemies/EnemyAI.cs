using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    #region Variables
    public float moveSpeed;
    public float retreatDistance;
    public float attackDistance;
    public float fireRate;
    public float mX;
    public float mY;

    int selectedP;
    float sFireRate;
    public bool isFollowingRandom;


    public GameObject proyectile;
    public Transform[] possiblePoints;
    public Rigidbody2D rb;
    public Transform playerPoint;



    #endregion


    #region Unity Methods

    void Start()
    {
        selectedP = Random.Range(0, possiblePoints.Length);
        isFollowingRandom = false;
    }

    
    void Update()
    {
        if(isFollowingRandom == false)
        {
            playerPoint.position = possiblePoints[selectedP].position;
        }

        if(Vector2.Distance(transform.position, playerPoint.position) < retreatDistance && !isFollowingRandom)
        {
            Retreat();
        }
        else if(Vector2.Distance(transform.position, playerPoint.position) > attackDistance)
        {
            Follow();
        }
        else if(Vector2.Distance(transform.position, playerPoint.position) < attackDistance && Vector2.Distance(transform.position, playerPoint.position) > retreatDistance && !isFollowingRandom)
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        Vector2 targetPos = playerPoint.position;
        Vector2 lookDir = targetPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    #endregion


    #region Custom Methods

    public void Retreat()
    {
        isFollowingRandom = true;

        Vector2 randomPos = new Vector2(Random.Range(playerPoint.position.x - mX, playerPoint.position.x + mX), Random.Range(playerPoint.position.y - mY, playerPoint.position.y + mY));

        playerPoint.position = randomPos;

        if (Vector2.Distance(transform.position, playerPoint.position) <= 0.4f)
        {
            isFollowingRandom = false;
            playerPoint.position = possiblePoints[selectedP].position;
            Debug.Log("Working?");
        }

    }

    public void Attack()
    {
        Debug.Log("Attacking");
    }

    public void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPoint.position, moveSpeed * Time.deltaTime);
    }

    #endregion


}
