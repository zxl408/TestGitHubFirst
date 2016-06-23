using UnityEngine;
using System.Collections;

public class SnakeBody : MonoBehaviour
{
    public System.Action OnDead;
    public System.Action OnEatFood;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void RestAllEvent()
    {
        OnDead = null;
        OnEatFood = null;
    }
    void OnTriggerEnter(Collider otherCollider)
    {
        if ((otherCollider.tag == "SnakeBody"))
        {
            if (OnDead != null)
            {
                OnDead();
            }
        }
        if (otherCollider.tag == "Food")
        {
            if (OnEatFood != null)
            {
                OnEatFood();
            }
        }
    }
    void OnTriggerExit(Collider otherCollider)
    {
        if ((otherCollider.tag == "Boundary"))
        {
            if (OnDead != null)
            {
                OnDead();
            }
        }
    }
}
