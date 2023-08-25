using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownGridController : MonoBehaviour
{
    public List<GameObject> Image;
    private GridLayoutGroup ImageGrid;


    
    // Start is called before the first frame update
    void Start()
    {
        ImageGrid = GetComponent<GridLayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Image.Count; i++)
        {
            if (i<=7)
            {
                ImageGrid.constraintCount = 3;
            }
            else if(i == 8 || i==9)
            {
                ImageGrid.constraintCount = 4;
            }
            else if(i==5)
            {
                ImageGrid.constraintCount = 5;
            }
        }
    }
}
