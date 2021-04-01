using UnityEngine;

public class Compass : MonoBehaviour
{

    #region Variables

    public Transform player;


    #endregion


    #region Unity Methods

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = player.position;
    }

    #endregion


    #region Custom Methods

    #endregion


}
