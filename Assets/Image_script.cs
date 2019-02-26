using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_script : MonoBehaviour {

    public static Image img;
    public static Image NewImg;
    public Color OldColor;
    public Color NewColor = new Color(0, 0, 0);




    //Transformer l'image en noir
    public void AllBlack()
    {

        Texture2D tab = img.sprite.texture;


        //tab.SetPixel(0, 0, NewColor);

        for (int x = 0; x < tab.width; x++)
        {
            tab.SetPixel(x, 0, NewColor);


            for (int y = 0; y < tab.height; y++)
            {
                tab.SetPixel(x, y, NewColor);
            }

        }
        img.sprite.texture.Apply();


    }



    //calcul des intensités min et max
    public void Contrast()
    {
        Texture2D tab = img.sprite.texture;
        float Intensity = 0;
        float Imax = 0;
        float Imin = 1;


        for (int x = 0; x < tab.width; x++)
        {
            for (int y = 0; y < tab.height; y++)
            {

                Intensity = tab.GetPixel(x, y).r;
                float II = 1 / (Imax - Imin) * (Intensity - Imin);

                if (Intensity >= Imax)
                {
                    Imax = Intensity;
                }
                else if (Intensity <= Imin)
                {
                    Imin = Intensity;
                }

                tab.SetPixel(x, y, new Color(II, II, II));

            }
        }
        Debug.Log("Imax = " + Imax);
        Debug.Log("Imin = " + Imin);



    }


    //Flou
    public static void Blur()
    {
        Texture2D tab = img.sprite.texture;
        Texture2D NewTab = NewImg.sprite.texture;



        for (int x = 1; x < tab.width - 1; x++)
        {
            for (int y = 1; y < tab.height - 1; y++)
            {
                float Pixel = tab.GetPixel(x, y).r;
                float GroupPixels = tab.GetPixel(x - 1, y - 1).r + tab.GetPixel(x - 1, y).r + tab.GetPixel(x, y - 1).r + tab.GetPixel(x + 1, y + 1).r + tab.GetPixel(x + 1, y).r + tab.GetPixel(x, y + 1).r + tab.GetPixel(x - 1, y + 1).r + tab.GetPixel(x + 1, y - 1).r + tab.GetPixel(x, y).r;
                float AverageBlur = GroupPixels / 9;
                Color AverageColor = new Color(AverageBlur, AverageBlur, AverageBlur);

                NewTab.SetPixel(x - 1, y - 1, AverageColor);
                NewTab.SetPixel(x, y - 1, AverageColor);
                NewTab.SetPixel(x + 1, y - 1, AverageColor);
                NewTab.SetPixel(x - 1, y, AverageColor);
                NewTab.SetPixel(x, y, AverageColor);
                NewTab.SetPixel(x + 1, y, AverageColor);
                NewTab.SetPixel(x - 1, y + 1, AverageColor);
                NewTab.SetPixel(x, y + 1, AverageColor);
                NewTab.SetPixel(x + 1, y + 1, AverageColor);
            }

        }
        NewImg.sprite.texture.Apply();



    }


    //Désaturation
    public void GreyLevel()
    {
        Texture2D tab = img.sprite.texture;


        Color GreyColor;

        float CurrentColorRed = 0;
        float CurrentColorGreen = 0;
        float CurrentColorBlue = 0;

        float CoefR = 0.299f;
        float CoefG = 0.587f;
        float CoefB = 0.114f;

        float ColorAverage;

        for (int x = 0; x < tab.width; x++)
        {

            for (int y = 0; y < tab.height; y++)
            {
                OldColor = tab.GetPixel(x, y);

                CurrentColorRed = OldColor.r;
                CurrentColorGreen = OldColor.g;
                CurrentColorBlue = OldColor.b;

                ColorAverage = (CurrentColorBlue * CoefR + CurrentColorGreen * CoefG + CurrentColorRed * CoefB) / 3;
                GreyColor = new Color(ColorAverage, ColorAverage, ColorAverage);

                tab.SetPixel(x, y, GreyColor);
            }

        }
        img.sprite.texture.Apply();

    }

    // Use this for initialization
    void Start () {
        Blur();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
