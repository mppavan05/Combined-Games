using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Random = UnityEngine.Random;
using TMPro;

public class ColorController : MonoBehaviour
{
   [SerializeField] private Image[] colorImages;
   [SerializeField] private TMP_Text pickTxt;
   [SerializeField] private TMP_Text scoreTxt;
   
   private int _score;
   private Color _colorToPick;
   private int[] _arrOfNumbers = { 0, 1, 2, 3, 4};
   private Dictionary<string, Color> _colors;

   private void Start()
   {
      AddingToDis();
      colorImages = GetComponentsInChildren<Image>();
      SetUpColors();
      SetUpText();
   }

   private void AddingToDis()
   {
      _colors = new Dictionary<string, Color>();
      _colors.Add("Blue", Color.blue);
      _colors.Add("Green", Color.green);
      _colors.Add("Red", Color.red);
      _colors.Add("Magenta", Color.magenta);
      _colors.Add("Yellow", Color.yellow);
   }

   private void SetUpColors()
   {
      colorImages = GetComponentsInChildren<Image>();

      _arrOfNumbers = _arrOfNumbers.OrderBy(i => Random.Range(0, colorImages.Length)).ToArray();

      var newNumber = 0;

      foreach (var images in colorImages)
      {
         images.color = SetColor(_arrOfNumbers[newNumber]);
         newNumber++;

      }
   }

   private void SetUpText()
   {
      int rand = Random.Range(0, _colors.Count);
      pickTxt.text = "Click " + _colors.ElementAt(rand).Key;
      _colorToPick = _colors.ElementAt(rand).Value;
      pickTxt.color = SetColor(Random.Range(0, 5));
      scoreTxt.text = "Score: " + _score;
   }

   private Color SetColor(int numInArray)
   {
      switch (numInArray)
      {
         case 0:
            return Color.blue;
         case 1:
            return Color.green;
         case 2:
            return Color.magenta;
         case 3:
            return Color.red;
         case 4:
            return Color.yellow;
         default:
            return Color.clear;
         
      }
   }

   public void CheckColor(Image image)
   {
      if (image.color == _colorToPick)
      {
         SetUpColors();
         SetUpText();
         _score++;
         scoreTxt.text = "Score: " + _score;
      }

      else
      {
         SetUpColors();
         SetUpText();
         _score--;
         scoreTxt.text = "Score: " + _score;
      }
   }
   
   public void Close()
   {
      UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
   }
}
