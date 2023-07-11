using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;



public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
   }

   public List<Point> points;

   public List<Vector2> ways;
   public List<bool> waysState;

   public List<bool> checkStateWay;
   public List<Vector2> checkWay;

   public TextMeshProUGUI chechText;

   public bool canCheck;

  


   private void Start()
   {
      SetWays();
      foreach (var item in checkWay)
      {
         SetStateTrue((int)item.x, (int)item.y,checkStateWay);
      }
   }
   
   private void Update()
   {
      if (canCheck)
      {
         ChechAllWays();
         CheckLast();
         ResetStateWay();
         canCheck = false;
      }
   }

   public void SetWays()
   {
      for (int i = 1; i < points.Count+1; i++)
      {
         for (int j = 1; j < points.Count+1; j++)
         {
            if (i != j)
            {
               Debug.Log("Yol" + "("+i+","+j+")");
               Vector2 vec = new Vector2(i, j);
               ways.Add(vec);
               waysState.Add(false);
               checkStateWay.Add(false);
            }
              
         }
      }
   }

   public void ResetStateWay()
   {
      for (int i = 0; i < waysState.Count; i++)
      {
         waysState[i] = false;
      }
   }

   public void ChechAllWays()
   {
      for (int i = 1; i < points.Count+1; i++)
      {
         for (int j = 1; j < points.Count+1; j++)
         {
            if (i != j)
            {
              Check(i,j);
            }
              
         }
      }
   }


   public void SetStateTrue(int i,int j, List<bool> list)
   {
      var vec = new Vector2(i, j);

      for (int k = 0; k < ways.Count; k++)
      {
         if (ways[k] == vec)
         {
            list[k] = true;
         }
      }
   }

   public void Check(int i,int j)
   {
      var mainAttachment = points[j - 1].mainAttachment;
      foreach (var item in points[i - 1].mainAttachment.GetComponent<Attachment>().neighbourAttachments)
      {
         if (item == mainAttachment)
         {
            Debug.Log("eeee");
            SetStateTrue(i,j,waysState);
         }
      }
      
   }

   public void CheckLast()
   {
      for (int i = 0; i < checkStateWay.Count; i++)
      {
         if (checkStateWay[i] != waysState[i])
         {
            chechText.text = "INCORRECT";
            Invoke("SetActiveFalseText",1);
            return;
         }
      }
      
      chechText.text = "CORRECT";
   }

   private void SetActiveFalseText()
   {
      chechText.text = "";
   }

 

  
}
