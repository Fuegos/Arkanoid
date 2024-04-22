using UnityEngine;

public class GridController : MonoBehaviour
{
    public float frequencyBricks = 0.3f;
    public Transform leftBottom;
    public Transform rightTop;
    public Transform brick;
    public Color[] colors;

    private int brickCount = 0;

    void Start()
    {
        brick.gameObject.SetActive(false);
    }

    public int getBrickCount() { return brickCount; }

    public void destroyBrick(GameObject brick)
    {
        brickCount--;
        Destroy(brick);
    }

    public void generateBricks()
    {
        for (var j = leftBottom.position.y; j <= rightTop.position.y; j += brick.localScale.y)
        {
            for (var i = leftBottom.position.x; i <= rightTop.position.x; i += brick.localScale.x)
            {
                if (Random.value > frequencyBricks)
                {
                    GameObject obj = (GameObject) Instantiate(brick.gameObject, new Vector3(i, j, transform.position.z), Quaternion.identity, brick.parent);
                    obj.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                    obj.SetActive(true);

                    brickCount++;
                }
            }
        }
    }
}