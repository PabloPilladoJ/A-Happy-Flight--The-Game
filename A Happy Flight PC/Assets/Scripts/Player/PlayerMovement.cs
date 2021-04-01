using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    #region Variables

    public InputMaster controls;
    public PlayerController playerC;
    public Gun machinegun;
    public Gun rockets;
    public GunChanging gunChng;
    public FillBar speedBar;
    public FillBar energyBar;
    public FillBar dashBar;

    float rotate;
    float quarterOfEnergy;
    float currentEnergy;
    float oldMoveSpeed;
    float dashCountDown;

    public float moveSpeed;
    public float maxEnergy;
    public float maxDashCountdown;

    bool outOfEnergy = false;
    bool isDashing = false;

    bool readyToDash = false;
   


    #endregion


    #region Unity Methods

    private void Awake()
    {
        controls = new InputMaster();
        controls.Player.Turn.performed += ctx => rotate = ctx.ReadValue<float>();
        controls.Player.Turn.canceled += ctx => rotate = 0;

        controls.Player.ChangeSpeed.performed += ctx => playerC.ChangeSpeed(ctx.ReadValue<float>());

        controls.Player.Dash.performed += ctx => ActivateDash();

        controls.Player.ChangeWeapon.performed += ctx => gunChng.ChangeW();
        
            controls.Player.Shoot.performed += ctx => machinegun.ActiveShoot();
            controls.Player.Shoot.canceled += ctx => machinegun.DisableShoot();

            controls.Player.Shoot.performed += ctx => rockets.ActiveRocketShot();
            controls.Player.Shoot.canceled += ctx => rockets.DectiveRocketShot();
        
       


    }

    void Start()
    {
        currentEnergy = maxEnergy;
        quarterOfEnergy = maxEnergy / 4;
        energyBar.maxValue = maxEnergy;
        dashCountDown = 0;
        
    }

    
    void Update()
    {
       if(currentEnergy > 0 && moveSpeed >= 4 && !isDashing)
        {
            DischargeEnergy();
        }

        if (currentEnergy < maxEnergy && moveSpeed <= 2 && !outOfEnergy)
        {
            RechargeEnergy();
        }

        if(currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        if(currentEnergy <= 0)
        {
            outOfEnergy = true;
        }

        if(currentEnergy <= quarterOfEnergy && outOfEnergy == true)
        {
            RechargingTo25();
        }
        else
        {
            outOfEnergy = false;
        }


        speedBar.SetFill(moveSpeed);
        energyBar.SetFill(currentEnergy);
        dashBar.SetFill(dashCountDown);

        CheckForDash();

    }

    private void FixedUpdate()
    {
        if(!outOfEnergy)
        {
            playerC.ForwardMovement(moveSpeed);
        }
        else
        {
            moveSpeed = 0;
            playerC.ForwardMovement(moveSpeed);
        }
        
       

        if(rotate != 0)
        {
            playerC.HorizontalMovement(rotate);
        }
       
        
    }

    private void OnEnable()
    {
        controls.Enable();
    }

   private void OnDisable()
    {
        controls.Disable();
    }

    #endregion


    #region Custom Methods

    public void IncreaseSpeed()
    {
        moveSpeed += 2;
        
    }

    public void DecreaseSpeed()
    {
        moveSpeed -= 2;
        
    }

    public void RechargeEnergy()
    {
        currentEnergy += moveSpeed * Time.deltaTime;
        if(moveSpeed <= 0)
        {
            currentEnergy += 3 * Time.deltaTime;
        }
    }

    public void DischargeEnergy()
    {
        currentEnergy -= moveSpeed * Time.deltaTime;
    }

    public void RechargingTo25()
    {
        
        currentEnergy += 2 * Time.deltaTime;

    }

    public void CheckForDash()
    {
        if(dashCountDown < maxDashCountdown)
        {
            dashCountDown += Time.deltaTime;
            
        }
        else
        {
            readyToDash = true;
        }
    }

    public void ActivateDash()
    {
       
        
        StartCoroutine(Dash());
       
        
    }

    public IEnumerator Dash()
    {
      
        if (readyToDash == true)
        {
            readyToDash = false;
            isDashing = true;
            oldMoveSpeed = 2;
            moveSpeed = 20;
            yield return new WaitForSeconds(0.3f);
            dashCountDown = 0;
            moveSpeed = oldMoveSpeed;
            isDashing = false;
            
        }


    }

    public void AddEnergy(int energy)
    {
        currentEnergy += energy;
        energyBar.SetFill(currentEnergy);
        if(currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

    }


    #endregion


}
