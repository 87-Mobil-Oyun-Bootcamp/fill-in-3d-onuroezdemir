using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{
    public int cubeNumber;

    public GameObject Confetti;
    public GameObject GameFinishedPanel;
    public Image fillImage;

    public Texture2D texture2D;
    [Space]
    [SerializeField]
    GameObject block;

    [Space]
    [SerializeField]
    GameObject dynamicBlock;

    [Space]
    [SerializeField]
    GameObject backgroundBlock;


    Vector3 cubesPos;
    Vector3 cubePosDynamic;
    Vector3 cubePosBackground;


    public List<GameObject> CreatedCubes = new List<GameObject>();

    public int CubesCountTemp;
    void Start()
    {
        SpawnStaticCubes(texture2D);
        SpawnDynamicCubes(texture2D);
        SpawnBackgroundCubes(texture2D);

        Physics.gravity = new Vector3(0, -30f, 0);
        CubesCountTemp = CreatedCubes.Count;
        print(CubesCountTemp);
        print(CreatedCubes.Count);
    }

    private void Update()
    {
        if (CreatedCubes.Count <= 0)
        {
            Confetti.SetActive(true);
            GameFinishedPanel.SetActive(true);
       
        }
        print(CubesCountTemp);
        print(CreatedCubes.Count);
        float Success = (float)CreatedCubes.Count / (float)CubesCountTemp;
        print(Success);
        fillImage.fillAmount = Success;

    }

    void SpawnStaticCubes(Texture2D texture)
    {
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                Color color = texture.GetPixel(x, y);
                if (color.a == 0)
                {
                    continue;
                }

                cubesPos = new Vector3((x - (texture.width * 0.5f)), 0, (y - (texture.height * 0.5f)));
                GameObject cubeObject = Instantiate(block);
                cubeObject.transform.localPosition = cubesPos;
                cubeObject.transform.parent = transform;
                cubeObject.GetComponent<Renderer>().material.color = color;
                CreatedCubes.Add(cubeObject);
                cubeNumber++;
            }
        }
    }

    void SpawnDynamicCubes(Texture2D texture)
    {

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                Color color = texture.GetPixel(x, y);
                if (color.a == 0)
                {
                    continue;
                }

                cubePosDynamic = new Vector3((x - (texture.width * 0.5f)), (y - (texture.height * 0.5f))+15f, -30f);

                GameObject cubeObject = Instantiate(dynamicBlock);
                cubeObject.transform.localPosition = cubePosDynamic;
                

                cubeObject.GetComponent<Renderer>().material.color = Color.blue;

            }
        }
    }

    void SpawnBackgroundCubes(Texture2D texture)
    {
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                Color color = texture.GetPixel(x, y);
                if (color.a == 0)
                {
                    continue;
                }

                cubePosBackground = new Vector3((x - (texture.width * 0.5f)), -0.8f, (y - (texture.height * 0.5f)));
                GameObject cubeObject = Instantiate(backgroundBlock);
                cubeObject.transform.localPosition = cubePosBackground;
                cubeObject.transform.parent = transform;
                cubeObject.GetComponent<Renderer>().material.color = Color.gray;



            }
        }
    }

  


}
