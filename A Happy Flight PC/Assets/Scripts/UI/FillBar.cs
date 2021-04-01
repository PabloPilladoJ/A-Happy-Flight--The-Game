using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{

    #region Variables

    
    public float maxValue;
    float lerpSpeed;

    public Image bar;

    #endregion


    #region Unity Methods

    void Start()
    {
        
    }

    
    void Update()
    {
        lerpSpeed = 4f * Time.deltaTime;
        
    }

    #endregion


    #region Custom Methods

    public void SetFill(float value)
    {
        
        bar.fillAmount = Mathf.Lerp(bar.fillAmount, value / maxValue, lerpSpeed);
    }


    #endregion


}
