using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class HeliParticleSystemControl_Soeun : MonoBehaviour
{
    HelirunMove_Jaewan helirunMove;

    [Header("Device Settings")]

    #region Variable
    public OSCReceiver Receiver;
    public string deviceName = "Person1";

    public ParticleSystem[] AlphaPSs;
    public ParticleSystem[] BetaPSs;
    

    string alphaAddress;
    string betaAddress;

    #endregion

    void Start()
    {
        helirunMove = GetComponent<HelirunMove_Jaewan>();
        string alphaAddress = deviceName + "/elements/alpha_relative";
        string betaAddress = deviceName + "/elements/beta_relative";

        AlphaPSs = GameObject.Find("alphaParticlePrefab").GetComponentsInChildren<ParticleSystem>();
        BetaPSs = GameObject.Find("betaParticlePrefab").GetComponentsInChildren<ParticleSystem>();
    }


    void Update()
    {
        for(int i=0; i<AlphaPSs.Length; i++)
        {
        }

        foreach(var main in AlphaPSs)
        {
            main.startSize = helirunMove.betaScore;
            main.playbackSpeed = helirunMove.betaScore;

            // 밑에 줄 출력이 넘 많아서 잠시 코멘트아웃했습니다 - 다인
            //Debug.Log("startLifeTime : "+ main.startSize + "                    betaScroe : "+ helirunMove.betaScore);

        }
        foreach (var main in BetaPSs)
        {
            main.startSize = helirunMove.betaScore;
            main.playbackSpeed = helirunMove.betaScore;

            // 밑에 줄 출력이 넘 많아서 잠시 코멘트아웃했습니다 - 다인
            //Debug.Log("startLifeTime : " + main.startSize + "                    betaScroe : " + helirunMove.betaScore);

        }
    }
}