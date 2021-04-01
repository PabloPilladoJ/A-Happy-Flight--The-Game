using UnityEngine;

public class Proyectile : MonoBehaviour
{

    #region Variables

    public Collider2D thisCollider;
    //public Collider2D playerCollider;
    public Rigidbody2D rb;

    public int damage;
    public float speed;

    #endregion


    #region Unity Methods

    void Start()
    {
        //Physics2D.IgnoreCollision(thisCollider, playerCollider, true);
        rb.velocity = transform.up * speed;
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Vector2 _s = new Vector2(0, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage Enemy or Player
    }

    #endregion


    #region Custom Methods

    #endregion


}
