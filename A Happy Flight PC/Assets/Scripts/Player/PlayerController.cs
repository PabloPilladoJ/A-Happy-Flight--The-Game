using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Variables

    public PlayerMovement playerM;

    public Transform playerTransform;
    public Transform target;

    public Rigidbody2D playerRb;
  

    private float rSpeed;

    #endregion


    #region Unity Methods


  

    #endregion


    #region Custom Methods

    public void HorizontalMovement(float rotate)
    {
        Vector3 r = new Vector3(0, 0, -rotate) * 2000f * Time.deltaTime;
        //transform.Rotate(r, Space.World);
        playerRb.MoveRotation(playerRb.rotation + r.z * Time.fixedDeltaTime);

 
    }

    public void ForwardMovement(float moveSpeed)
    {
        rSpeed = moveSpeed;
        Vector2 _target = target.transform.position;
        Vector2 newPos = Vector2.MoveTowards(playerRb.position, _target, moveSpeed * Time.fixedDeltaTime);
        playerRb.MovePosition(newPos);
       
    }

    public void ChangeSpeed(float index)
    {
        if(index == 1 && rSpeed < 8)
        {
            playerM.IncreaseSpeed();
        }

        if(index == -1 && rSpeed > 0)
        {
            playerM.DecreaseSpeed();
        }
    }

   


    #endregion


}
