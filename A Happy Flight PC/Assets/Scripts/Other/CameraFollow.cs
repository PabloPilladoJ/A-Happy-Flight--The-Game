using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    #region Variables

    public Transform player;

    public Vector3 offset;

    public bool rToo;

    #endregion


    #region Unity Methods

    void Start()
    {
        
    }

    
    void Update()
    {
        
        transform.position = player.position + offset;
        if (rToo)
        {
            transform.rotation = player.rotation;
        }
         
    }

    #endregion


    #region Custom Methods

    #endregion


}
