using UnityEngine;

public class HealthKit : MonoBehaviour
{

    #region Variables

    public int healAmmount;
    private PlayerStats playerStats;

    #endregion


    #region Unity Methods

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.Heal(healAmmount);
            Destroy(gameObject);
        }
        
    }

    #endregion


    #region Custom Methods

    #endregion


}
