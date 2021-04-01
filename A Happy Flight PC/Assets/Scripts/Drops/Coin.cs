using UnityEngine;

public class Coin : MonoBehaviour
{

    #region Variables

    public int value;
    PlayerStats playerStats;

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
            playerStats.AddCoins(value);
            Destroy(gameObject);
        }

    }

    #endregion


    #region Custom Methods

    #endregion


}
