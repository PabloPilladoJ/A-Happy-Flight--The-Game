using UnityEngine;

public class ShieldKit : MonoBehaviour
{

    #region Variables

    GameObject shield;
    PlayerStats playerStats;
    Animator anim;

    public int healAmmount;

    #endregion


    #region Unity Methods
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        shield = GameObject.FindGameObjectWithTag("Shield");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && shield.activeInHierarchy == false)
        {
            playerStats.shieldActive = true;
            anim.SetBool("shieldActive", true);
            Destroy(gameObject);

        }
        else if(other.CompareTag("Player") && shield.activeInHierarchy == true)
        {
            playerStats.ShieldHeal(healAmmount);
            Destroy(gameObject);

        }
        
    }

    #endregion


    #region Custom Methods

    #endregion


}
