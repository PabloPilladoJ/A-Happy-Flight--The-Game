using UnityEngine;

public class EnergyKit : MonoBehaviour
{

    #region Variables

    public int energyAmmount;
    private PlayerMovement playerMovement;

    #endregion


    #region Unity Methods
    void Start()
    {
       playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.AddEnergy(energyAmmount);
            Destroy(gameObject);
        }

    }

    #endregion


    #region Custom Methods

    #endregion


}
