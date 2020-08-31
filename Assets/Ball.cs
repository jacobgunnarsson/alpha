using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
  float speed;
  float radius;
  Vector2 direction;
  // Start is called before the first frame update
  void Start() {
    speed = 1f;
    radius = 10f;
    direction = Vector2.one.normalized;
  }

  // Update is called once per frame
  void Update() {
    transform.Translate(direction * speed * Time.deltaTime);

    if (transform.position.y + transform.localScale.y / 2 >= GameManager.topRight.y || transform.position.y + transform.localScale.y <= GameManager.bottomLeft.y) {
      direction.y = direction.y * -1f;
    }

  }
}
