using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class tablero : MonoBehaviour
{
    public int NumberOfColumns = 5; // number of columns for the grid
    public int NumberOfRows = 5; // number of rows for the grid
    public float SeperationValueX = 0.001f; // Distance between each column
    public float SeperationValueZ = 0.001f; // Distance between each Row

    public float tempSepX = 0; // used to calculate the separation between each column
    public float tempSepZ = 0;// used to calculate the separation between each row
    double[,] matrix = new double[5, 5];//matriz que se debe de dibujar
    public Texture3D texture;
    public Material paredMat;
    public Material pisoMat;

    public static Material matPiso;
    public static Material matPared;



    // Use this for initialization
    void Start()
    {
        //  Debug.Log(3);
        matPiso = paredMat;
        matPared = pisoMat;
        createGrid();//call the createGrid function on start
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void jsonToMatriz()
    {
        matrix = new double[,] { { 1, 1, 3, -1, 2 }, { 2, -1, 4, -1, 2 }, 
                              { 3, -1, 6, 3, 2 }, { 3, -1, -1, -1, 1 },
                              { 2, -1, 4, 2, 1 } };
    }

    void createGrid()
    {
        jsonToMatriz();

        for (float i = 0; i < NumberOfColumns; i += 1.05f)
        {//loop 1 to loop through columns
            for (float j = 0; j < NumberOfRows; j += 1.05f)
            {//loop 2 to loop through rows
             //   Debug.Log(j);
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube); //create a quad primitive as provided by unity
                plane.transform.position = new Vector3(i, 0, j); //position the newly created quad accordingly
                plane.transform.eulerAngles = new Vector3(90f, 0, 0); //rotate the quads 90 degrees in X to face up
          //      plane.name = i.ToString() + " " + j.ToString();

          /*     texture = (Texture3D)Resources.Load("Assets/textures/piso");
               newMat = Resources.Load("Assets/Materials/piso", typeof(Material)) as Material;
            */    

                //   Debug.Log(newMat);
                if (matrix[(int)i,(int)j] <0)
                {
                    plane.name = i.ToString() + " " + j.ToString()+ " 1";
                    //plane.renderer.material = newMat;

               //     plane.GetComponent<Renderer>().material.mainTexture = texture;
               //     plane.GetComponentInChildren<Renderer>().material = newMat;
                        // plane.GetComponent<Renderer>().material = newMat;
                 /*   MeshRenderer rend = GetComponent<MeshRenderer>();
                    rend.material = newMat;
                    */
            //        Debug.Log(10)

                }
                else{
               //     plane.GetComponent<Renderer>().enabled = false;
                }
              //  plane.AddComponent<MaterialChange>();

                plane.AddComponent<Hide>();
                //      rend.material = newMat;
                //      tempSepZ += SeperationValueZ;//change the value of seperation between rows
                //   Debug.Log(tempSepX);
                /*    Texture3D texture = CreateTexture3D(256);
                    Debug.Log(texture);
                    plane.GetComponent<Renderer>().material.mainTexture = texture;
                    */
                /*
                Texture3D texture = (Texture3D)Resources.Load("Assets/textures/piso");
                Debug.Log(texture);

                plane.GetComponent<Renderer>().material.mainTexture = texture;
                Instantiate(plane);
                */


                /*                Debug.Log(tempSepZ);
                                Debug.Log(i);
                                Debug.Log(j);
                  */
            }
            //    tempSepX += SeperationValueX;//change the value of seperation between columns
            tempSepZ = 0;//Reset the value of the seperation between the rows so it won‘t cumulate
        }
    }


    Texture3D CreateTexture3D(int size)
    {
        Color[] colorArray = new Color[size * size * size];
        Texture3D texture = new Texture3D(size, size, size, TextureFormat.RGBA32, true);
        float r = 1.0f / (size - 1.0f);
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    Color c = new Color(x * r, y * r, z * r, 1.0f);
                    colorArray[x + (y * size) + (z * size * size)] = c;
                }
            }
        }
        texture.SetPixels(colorArray);
        texture.Apply();
        return texture;
    }

}


    
   

