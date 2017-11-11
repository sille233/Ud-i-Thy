using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class creativeScript : MonoBehaviour {

    public GameObject galleryImage;
    public GameObject galleryText;
    public Sprite[] gallerySprite;// = new Sprite[3] { "sten", "sten2", "sten3" }; Get sprites from inspector
    public string[] titles;// = new Sprite[2] { "Maria 12 år", "Espen 13 år" };
    float canvasWidth = 370f;


    // Use this for initialization
    void Start()
    {
        //get the canvas width
        RectTransform objectRectTransform = GameObject.FindGameObjectWithTag("Gallery").GetComponent<RectTransform>();
        canvasWidth = objectRectTransform.rect.width;
        //Debug.Log("width: " + objectRectTransform.rect.width + ", height: " + objectRectTransform.rect.height);
        loadGallery();
    }

    private void loadGallery()
    {        
        //titles for the images
         titles = new string[4] { "Maria 12 år", "Espen 13 år", "Anne 10 år", "Upload billede" };

        int imageSize = 175;
        int padding = 15;
        int topMargin = 300;
        int topMarginText = 200;
        int imageInRow = 0;//the image/text place in the row or the x position
        int imageInColumn = 1;//the image/text place in the column or the y position
        int rowWidth = 0;

        //loop through depending on how many images there is in the gallerySprite Array from the inspector
        for (int i = 0; i < gallerySprite.Length; i++)
        {
            //Debug.Log("Image " + i);
            
            rowWidth = imageInRow * imageSize;
            
            //if the rows width is larger than the canvas size minus how much a new image would fill move the new image to a new line
            //or set the x to 0 to get it to the left and y to the image size * rows to get it one image down
            if (rowWidth >= (canvasWidth - imageSize))
            {
                Debug.Log("i am in the loop: " + i);
                Debug.Log("canvasWidth: " + canvasWidth);
                rowWidth = 0;
                imageInRow = 0;
                imageInColumn++;
                rowWidth = imageInRow * imageSize;
            }
            //rowWidth = imageInRow * imageSize;
            imageInRow++;
            //Debug.Log("x: " + (padding + rowWidth) + " y: " + (topMargin - (imageInColumn * (imageSize + 35))));
            
            //instantiate the image
            GameObject newImg = Instantiate(galleryImage, new Vector3(padding + rowWidth, topMargin - (imageInColumn * (imageSize+35)), 0), Quaternion.identity);
            //move the image inside the gallery canvas
            newImg.transform.SetParent(GameObject.FindGameObjectWithTag("Gallery").transform, false);
            //change the sprite depending on the gallerySprite[i]
            newImg.GetComponent<Image>().sprite = gallerySprite[i];

            //instantiate the text
            GameObject newText = Instantiate(galleryText, new Vector3(padding + rowWidth, topMarginText - (imageInColumn * (imageSize+35)), 0), Quaternion.identity);
            newText.transform.SetParent(GameObject.FindGameObjectWithTag("Gallery").transform, false);
            newText.gameObject.GetComponent<Text>().text = titles[i];
        }
    }
}
