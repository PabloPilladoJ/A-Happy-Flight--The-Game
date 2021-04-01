using UnityEngine;

public class Rotator : MonoBehaviour
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
        transform.rotation = player.rotation;
    }

    #endregion


    #region Custom Methods

    #endregion


}
