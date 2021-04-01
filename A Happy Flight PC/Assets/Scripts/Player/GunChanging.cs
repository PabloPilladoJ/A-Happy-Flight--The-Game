using UnityEngine;

public class GunChanging : MonoBehaviour
{

    #region Variables

    public GameObject machinegun;
    public GameObject rockets;
  

   

    #endregion


    #region Unity Methods

    void Start()
    {
        
    }

    
    void Update()
    {
     
    }

    #endregion


    #region Custom Methods

    public void ChangeW()
    {
        if (machinegun.activeInHierarchy)
        {
            machinegun.SetActive(false);
            rockets.SetActive(true);
           
        }
        else if (rockets.activeInHierarchy)
        {
            machinegun.SetActive(true);
            rockets.SetActive(false);
           
        }
       
       

    }

   

    #endregion


}
