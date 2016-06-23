using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Snake : MonoBehaviour
{
    public List<GameObject> originalBodys;
    public List<GameObject> bodys;
    public float moveLengthEach = 2f;
    public float Speed = 1f;
    public bool isStopMove = true;
    float MoveLengthEach
    {
        get
        {
            return moveLengthEach * GameSetting.PosUnit;
        }
    }

    public Direction currentDirction = Direction.Right;    
  

    public System.Action OnDead;
    public System.Action OnEatFood;

    public void StartInvokeSnake()
    {
        for (int i = 2; i < bodys.Count; i++)
            Destroy(bodys[i]);      
        bodys.Clear();
        bodys.AddRange(originalBodys);
        foreach (GameObject body in bodys)
        {
            body.GetComponent<SnakeBody>().RestAllEvent();
            body.GetComponent<SnakeBody>().OnDead += Dead;
            body.GetComponent<SnakeBody>().OnEatFood += EatFood;
        }
        bodys[0].transform.localPosition = Vector3.zero;
        bodys[1].transform.localPosition = Vector3.left;
        isStopMove = false;
    }
    void Awake() {
       
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(MoveIE());
    }
   
    // Update is called once per frame
  
    IEnumerator MoveIE()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / Speed);
            if (!isStopMove)
                MoveForward();
        }
    }
    public void MoveForward()
    {
        Move(currentDirction);
    }
    public void AddBody() {
        GameObject body = Instantiate(bodys[0]);

        body.transform.localPosition = Vector3.left * 50;
        bodys.Add(body);
        body.GetComponent<SnakeBody>().OnDead += OnDead;
        body.GetComponent<SnakeBody>().OnEatFood += OnEatFood;
    }

    public void Move(Direction direction)
    {
        List<Vector3> tempBodyPoss = bodys.Select((it) =>
        {
            return it.transform.localPosition;
        }).ToList();

        Vector3 offset = Vector3.zero;
        switch (direction)
        {
            case Direction.Down:
                offset = Vector3.down;
                break;
            case Direction.Up:
                offset = Vector3.up;
                break;
            case Direction.Left:
                offset = Vector3.left;
                break;
            case Direction.Right:
                offset = Vector3.right;
                break;
        }
        for (int i = 0; i < bodys.Count - 1; i++)
        {
            bodys[i + 1].transform.localPosition = tempBodyPoss[i];
        }
        bodys[0].transform.localPosition += offset * MoveLengthEach;
       
    }

    void Dead() {
        isStopMove = true;
        if (OnDead != null)
            OnDead();
    }
    void EatFood() {
        AddBody();
        if (OnEatFood!=null) {
            OnEatFood();
        }
    }
}
