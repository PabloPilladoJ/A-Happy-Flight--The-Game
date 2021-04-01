using UnityEngine;
using TMPro;

public class DisplayCoordinates : MonoBehaviour
{

    #region Variables

    public Transform playerCoords;
    public TextMeshProUGUI text;


    #endregion


    #region Unity Methods

    void Start()
    {
        
    }

    
    void Update()
    {
        text.text = "X: " + Mathf.Ceil(playerCoords.position.x) + "  Y: " + Mathf.Ceil(playerCoords.position.y);
    }

    #endregion


    #region Custom Methods

    #endregion


}
