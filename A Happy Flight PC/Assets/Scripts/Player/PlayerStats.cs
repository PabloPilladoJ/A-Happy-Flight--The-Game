using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    #region Variables

    public int maxHealth;
    public int maxShieldHealth;
    public int currentCoins;

    int currentHealth;
    public int currentShieldHealth;

    public bool shieldActive;

    public GameObject shield;
    public FillBar healthbar;
    public FillBar shieldbar;
    public Animator anim;
    public TextMeshProUGUI coinsText;

    #endregion


    #region Unity Methods

    void Start()
    {
        healthbar.maxValue = maxHealth;
        shieldbar.maxValue = maxShieldHealth;
        currentHealth = maxHealth;
        currentShieldHealth = maxShieldHealth;
        healthbar.SetFill(currentHealth);
        shieldbar.SetFill(0);
    }

    
    void Update()
    {

        if (shieldActive)
        {
            shield.SetActive(true);
            shieldbar.SetFill(currentShieldHealth);
        }
        else
        {
            shield.SetActive(false);
            currentShieldHealth = maxShieldHealth;
            shieldbar.SetFill(0);
        }
    }

    #endregion


    #region Custom Methods

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetFill(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ShieldTakeDamage(int damage)
    {
        currentShieldHealth -= damage;
        shieldbar.SetFill(currentShieldHealth);

        if (currentShieldHealth <= 0)
        {
            StartCoroutine(ShieldDie());
        }
    }

    public void Heal(int ammount)
    {
        currentHealth += ammount;
        healthbar.SetFill(currentHealth);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void ShieldHeal(int ammount)
    {
        currentShieldHealth += ammount;
        shieldbar.SetFill(currentShieldHealth);

        if (currentShieldHealth > maxShieldHealth)
        {
            currentShieldHealth = maxShieldHealth;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator ShieldDie()
    {
        anim.SetBool("shieldActive", false);
        yield return new WaitForSeconds(0.2f);
        shieldActive = false;
    }

    public void AddCoins(int value)
    {
        currentCoins += value;
        coinsText.text = currentCoins.ToString();
    }


    #endregion


}
