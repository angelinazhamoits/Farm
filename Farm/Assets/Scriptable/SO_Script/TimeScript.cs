using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeScript : MonoBehaviour
{

 private float _startTime; //1 способ
 private float _elapsedTime = 0f; //2 способ
 public float _timeToSecondStage = 30f;
 private float _timeToThirdStage = 40f;
 private float _timeToRipe = 50f;
 public ItemObject _ItemObject;// 1 и 2 способ

 private Stages _stages;

 /*private void Start() // 1
 {
  _startTime = Time.time;
 }

 private void Update() //1
 {
  if (Time.time - _startTime >= _duration)
  {
  Debug.Log("10 minutes later");
  this.enabled = false;
  }
 }*/

 /*private void Update() //2
 {
  _elapsedTime += Time.deltaTime;
  if (_elapsedTime>=_duration)
  {
   Debug.Log("10 minutes later");
   this.enabled = false;
  }
 }*/

 private void Start() //3 способ
 {
  StartCoroutine(TimeCoroutine());

 }

 IEnumerator TimeCoroutine() //3
 {
  yield return new WaitForSeconds(_timeToSecondStage);
  Debug.Log("1 minute later");
  yield return new WaitForSeconds(_timeToThirdStage);
  Debug.Log("2 minutes");
  yield return new WaitForSeconds(_timeToRipe);
  Debug.Log("3 minutes");
  _ItemObject._isRipe = true;
 
 }
 
}
