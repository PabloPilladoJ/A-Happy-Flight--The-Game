using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    #region Variables

    private float lengthx, lengthy, startpos, ypos;

    public GameObject cam;

    public float parallaxEffect;

    #endregion


    #region Unity Methods
    void Start()

    {

        startpos = transform.position.x;

        ypos = transform.position.y;

        lengthx = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthy = GetComponent<SpriteRenderer>().bounds.size.y;

    }

    void Update()

    {

        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float tempy = (cam.transform.position.y * (1 - parallaxEffect));


        float dist = (cam.transform.position.x * parallaxEffect);

        float ydist = (cam.transform.position.y * parallaxEffect);



        transform.position = new Vector3(startpos + dist, ypos + ydist, transform.position.z);

        if (temp > startpos + lengthx)

        {

            startpos += lengthx;

        }

        else if (temp < startpos - lengthx)

        {

            startpos -= lengthx;

        }



        if (tempy > ypos + lengthy)

        {

            ypos += lengthy;

        }

        else if (tempy < ypos - lengthy)

        {

            ypos -= lengthy;

        }

    }

    #endregion


    #region Custom Methods

    #endregion


}
