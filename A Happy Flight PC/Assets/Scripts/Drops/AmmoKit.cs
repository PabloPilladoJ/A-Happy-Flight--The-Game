using UnityEngine;

public class AmmoKit : MonoBehaviour
{

    #region Variables

    public int ammoAmmount1;
    public int ammoAmmount2;
    private Gun gun1;

    #endregion


    #region Unity Methods

    void Start()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gun1 = other.GetComponentInChildren<Gun>();

            if (gun1.CompareTag("Gun1(M)"))
            {
                gun1.AddAmmo(ammoAmmount1);
                Destroy(gameObject);
            }
            if (gun1.CompareTag("Gun2(R)"))
            {
                gun1.AddAmmo(ammoAmmount2);
                Destroy(gameObject);
            }

        }
        
    }

    #endregion


    #region Custom Methods

    #endregion


}
