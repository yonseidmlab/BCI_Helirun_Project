

//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
//using extOSC;
using System.Linq;

public class Window_Graph_Soyeon : MonoBehaviour {

    public Sprite circleSprite;
    private RectTransform graphContainer;
    public GameObject tracking;
    public float betaScore;
    public float alphaScore;
    //public OSCReceiver Receiver;
    public string deviceName = "Person0";
    public float distanceBetweenPoints = 10f;
    public int pointNum = 10;
    private string address_beta;
    private string address_alpha;
    public List<float> valueList = new List<float>();
    public List<float> alphaList = new List<float>();


    public void Start()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        // address_alpha = deviceName + "/elements/alpha_session_score";
        // address_beta = deviceName + "/elements/beta_session_score";
      
    }

    public void Update() {

        //Receiver.Bind(address_beta, ReceiveDoubleBeta);
        //Receiver.Bind(address_alpha, ReceiveDoubleAlpha);
        OSC_Receiver_Soyeon oscreader = tracking.GetComponent<OSC_Receiver_Soyeon>();
        betaScore = oscreader.betaScore;
        alphaScore = oscreader.alphaScore;
        //betaScore = Random.Range(0f, 1f);
        //alphaScore = Random.Range(0f, 1f);
        //Debug.Log(betaScore);
        valueList.Add(betaScore);
        alphaList.Add(alphaScore);
        ShowGraphAlpha(valueList);
        ShowGraphBeta(alphaList);

        if (valueList.Count() > pointNum){
            valueList.RemoveAt(1);
            alphaList.RemoveAt(1);
        
            foreach (Transform child in graphContainer)
            {
                Destroy(child.gameObject);
            }
        
        ShowGraphAlpha(valueList);
        ShowGraphBeta(alphaList); 
        
    }
}

    public GameObject CreateCircle(Vector2 anchoredPosition) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    public void ShowGraphBeta(List<float> valueList) {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 1f;
        float xSize = distanceBetweenPoints;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++) {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject != null) {
                CreateDotConnectionBeta(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
        }
    }

    public void ShowGraphAlpha(List<float> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 1f;
        float xSize = distanceBetweenPoints;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject != null)
            {
                CreateDotConnectionAlpha(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
        }
    }

    public void CreateDotConnectionBeta(Vector2 dotPositionA, Vector2 dotPositionB) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color32(255, 197, 42, 100);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }

    public void CreateDotConnectionAlpha(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color32(32, 168, 232, 100);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }

   /* public void ReceiveDoubleBeta(OSCMessage message)
    {
        // Debug.LogFormat("Received: {0}", message);
        if (address_beta == deviceName + "/elements/beta_session_score")
        {
            string s = message.ToString();
            string[] sArray = s.Split('"');
            var betas = new List<float>() { float.Parse(sArray[3]), float.Parse(sArray[5]), float.Parse(sArray[7]), float.Parse(sArray[9]) };
            if (betas.Contains(0))
            {
                betas.RemoveAll(i => i == 0);
            }
            betaScore = betas.Average();
        }

    }
    public void ReceiveDoubleAlpha(OSCMessage message)
    {
        // Debug.LogFormat("Received: {0}", message);
        if (address_alpha == deviceName + "/elements/alpha_session_score")
        {
            string s = message.ToString();
            string[] sArray = s.Split('"');
            var betas = new List<float>() { float.Parse(sArray[3]), float.Parse(sArray[5]), float.Parse(sArray[7]), float.Parse(sArray[9]) };
            if (betas.Contains(0))
            {
                betas.RemoveAll(i => i == 0);
            }
            alphaScore = betas.Average();
        }

    }*/
}
