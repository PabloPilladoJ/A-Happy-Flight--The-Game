using UnityEngine;

public class Despawner : MonoBehaviour
{

    #region Variables

    public float timeToDespawn;

    #endregion


    #region Unity Methods

    void Start()
    {
        
    }

    
    void Update()
    {
        Destroy(gameObject, timeToDespawn);
    }

    #endregion


    #region Custom Methods

    #endregion


}
