using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{

    #region Variables

    public GameObject proyectile;
    public GameObject[] markers;
    public GameObject relText;
    public Transform[] firePoints;
    public FillBar ammoBar1;
    public FillBar ammoBar2;
    

    public int maxAmmo;
    public int currentAmmo;
    public int maxChargedProyectiles;
    public float fireRate;

    int startAmmo;
    int chargedProyectiles;
    int index = 0;
    int waitTime;
    float nextTimeToFire;

    public bool singleShot;
    public bool hasShot = false;
    bool inputReceived = false;
    bool inputReceived2 = false;
    bool outOfChargedP;
    

    #endregion


    #region Unity Methods


    void Start()
    {
        startAmmo = maxAmmo / 2;
        currentAmmo = startAmmo;
        
        ammoBar1.maxValue = startAmmo;
        ammoBar2.maxValue = startAmmo;
        ammoBar1.SetFill(currentAmmo);
        ammoBar2.SetFill(0);
        if(singleShot == false)
        {
            outOfChargedP = true;
        }
        else
        {
            outOfChargedP = false;
            chargedProyectiles = maxChargedProyectiles;
        }
        
        waitTime = (maxChargedProyectiles / 2) + 2;
    }

   

    void Update()
    {
        if (inputReceived == true && !singleShot)
        {
            Shoot();
        }

        if (inputReceived2 == true && singleShot)
        {
            ShootRockets();
        }


        ammoBar1.SetFill(currentAmmo);
        if (currentAmmo > startAmmo)
        {
            ammoBar2.SetFill(currentAmmo - startAmmo);
        }
        else
        {
            ammoBar2.SetFill(0);
        }

       

    }

    private void OnEnable()
    {
        if (outOfChargedP && singleShot == true && this.isActiveAndEnabled)
        {
            StartCoroutine(ReloadRockets());
        }
    }

    #endregion


    #region Custom Methods

    public void ActiveShoot()
    {
        if (this.isActiveAndEnabled)
        {
            inputReceived = true;
        }

        
    }

    public void ActiveRocketShot()
    {
        if (this.isActiveAndEnabled)
        {
            inputReceived2 = true;
        }
    }

    public void DectiveRocketShot()
    {
        inputReceived2 = false;
    }

    public void Shoot()
    {
        if (currentAmmo > 0 && !singleShot)
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                if (!singleShot)
                {
                    Instantiate(proyectile, firePoints[0].position, firePoints[0].rotation);
                    Instantiate(proyectile, firePoints[1].position, firePoints[1].rotation);
                    currentAmmo -= 2;
                    

                }
                else
                {
                    
                    //ShootRockets();
                    
                }
            }
        }
    }

   public void ShootRockets()
    {
       if(singleShot == true && inputReceived2 == true)
        {
            hasShot = false;

            if (!outOfChargedP && currentAmmo > 0 && singleShot && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                if (index < maxChargedProyectiles && hasShot == false)
                {
                    Instantiate(proyectile, firePoints[index].position, firePoints[index].rotation);
                    markers[index].SetActive(false);
                    hasShot = true;
                    chargedProyectiles -= 1;
                    currentAmmo -= 1;
                    index++;


                }

                if (chargedProyectiles <= 0 && singleShot)
                {
                    outOfChargedP = true;
                    
                }

                if (outOfChargedP)
                {
                    StartCoroutine(ReloadRockets());
                }



            }
        }
     
    }


    IEnumerator ReloadRockets()
    {
       if( currentAmmo > 0 && outOfChargedP == true)
        {
            relText.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            relText.SetActive(false);
            markers[0].SetActive(true);
            markers[1].SetActive(true);
            markers[2].SetActive(true);
            markers[3].SetActive(true);
            markers[4].SetActive(true);
            markers[5].SetActive(true);
            markers[6].SetActive(true);
            markers[7].SetActive(true);

            index = 0;
            chargedProyectiles = maxChargedProyectiles;
            outOfChargedP = false;
            hasShot = false;
            
            

        }
        
    }


    public void DisableShoot()
    {
        inputReceived = false;
    }

   public void AddAmmo(int ammo)
    {
        currentAmmo += ammo;
        ammoBar1.SetFill(currentAmmo);
        if (currentAmmo > startAmmo)
        {
            ammoBar2.SetFill(currentAmmo - startAmmo);
        }
        else
        {
            ammoBar2.SetFill(0);
        }

        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }

        if (outOfChargedP && singleShot == true && this.isActiveAndEnabled)
        {
            StartCoroutine(ReloadRockets());
        }
    }


    #endregion


}
