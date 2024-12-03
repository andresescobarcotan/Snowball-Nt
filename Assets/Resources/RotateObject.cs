using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RotateObject : MonoBehaviour
{
  public Vector3 RotateAmount;

  void Update() {
    transform.Rotate(RotateAmount * Time.deltaTime);
  }
}
