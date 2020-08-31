using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
  [SerializeField]
  private float speed;
  private float posY;
  private string input;
  private bool isPlayerPaddle;
  // Start is called before the first frame update
  void Start() {
    posY = transform.localScale.y;
    speed = 5f;
  }

  public void Init(bool thisIsPlayerPaddle) {
    Vector2 pos;

    isPlayerPaddle = thisIsPlayerPaddle;

    if (isPlayerPaddle) {
      pos = new Vector2(GameManager.bottomLeft.x + transform.localScale.x, 0);
      input = "PlayerPaddle";
      transform.name = "Player Paddle";
    } else {
      pos = new Vector2(GameManager.topRight.x - transform.localScale.x, 0);
      transform.name = "AI Paddle";
    }

    transform.position = pos;
  }

  private bool isAllowedToMove(float move) {
    return transform.position.y + move < GameManager.topRight.y - transform.localScale.y / 2 - transform.localScale.x / 2
          && transform.position.y + move > GameManager.bottomLeft.y + transform.localScale.y / 2 + transform.localScale.x / 2;
  }

  // Update is called once per frame
  void Update() {
    if (isPlayerPaddle) {
      float move = Input.GetAxis(input) * Time.deltaTime * speed;

      if (isAllowedToMove(move)) {
        transform.Translate(move * Vector2.up);
      }
    }
  }
}
