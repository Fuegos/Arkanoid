using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public static int BrickCount = 0;

    public float Randomize = 0.3f;
    public Transform LeftBottom;
    public Transform RightTop;
    public Transform m_Brick;

    public Color[] colors;

    void Start()
    {
        m_Brick.gameObject.SetActive(false);
        Generate();
    }

    
    void Update()
    {
        if (BrickCount <= 0)
        {
            Generate();
        }
    }


    void Generate()
    {
        var halfX = (RightTop.position.x - LeftBottom.position.x) / 2 + LeftBottom.position.x;

        for (var j = LeftBottom.position.y; j < RightTop.position.y; j += m_Brick.localScale.y)
        {
            for (var i = LeftBottom.position.x; i < halfX; i += m_Brick.localScale.x)
            {
                if (Random.value > Randomize)
                {
                    GameObject obj = (GameObject) Instantiate(m_Brick.gameObject, new Vector3(i, j, transform.position.z), Quaternion.identity, m_Brick.parent);
                    obj.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                    obj.SetActive(true);

                    obj = (GameObject) Instantiate(m_Brick.gameObject, new Vector3(halfX + (halfX - i), j, transform.position.z), Quaternion.identity, m_Brick.parent);
                    obj.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                    obj.SetActive(true);

                    BrickCount += 2;
                }
            }
        }
    }
}