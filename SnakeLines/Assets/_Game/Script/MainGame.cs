using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainGame : MonoBehaviour
{
    public Snake snake;
    public GameObject food;
    public Text pointText;
    int point = 0;
    public GameObject gameOverWindow;
    public Text resultPointText;
    public Vector4 boundary
    {
        get
        {
            Vector2 size = boundaryCollider.size;
            return new Vector4(-size.x / 2f, -size.y / 2f, size.x / 2f, size.y / 2f);
        }
    }
    public BoxCollider boundaryCollider;
    public GameObject controlDrag;
    public GameObject reBeginBtn;

    void Awake()
    {
        snake.OnEatFood += OnSnakeEatFood;
        snake.OnDead += GameOver;
        controlDrag.GetComponent<DragListenr>().DragEvent += OnControlByDrag;
        controlDrag.GetComponent<UClickListener>().PointUpEvent += OnPointUp;
        reBeginBtn.GetComponent<UClickListener>().ClickEvent += OnReBegin;
    }



    private void OnReBegin(PointerEventData obj)
    {
        gameOverWindow.SetActive(false);
        point = 0;
        pointText.text = "分数:0";
        snake.StartInvokeSnake();
    }

    // Use this for initialization
    void Start()
    {
        snake.StartInvokeSnake();
        pointText.text = "分数:0";
        CreatFood();
    }
    void OnSnakeEatFood()
    {
        point++;
        CreatFood();
    }
    void CreatFood()
    {
        pointText.text = "分数:" + point.ToString();
        food.transform.localPosition = new Vector3(Random.Range((int)boundary.x, (int)boundary.z), Random.Range((int)boundary.y, (int)boundary.w), 0);

    }
    void GameOver()
    {
        gameOverWindow.SetActive(true);
        resultPointText.text = "最后得分：" + point.ToString();
    }
    void Update()
    {
        snake.currentDirction = GameInputManager.ListenInput(snake.currentDirction);
    }
 
    Vector2 settingDelta;
    public float dragBoundaryNumber = 1f;
    public void OnControlByDrag(PointerEventData eventData)
    {    
        if (Mathf.Abs(eventData.delta.x) > dragBoundaryNumber) {
            if (eventData.delta.x > 0)
                if (settingDelta.x < eventData.delta.x) {
                    settingDelta = eventData.delta;
                }
            if (eventData.delta.x < 0)
                if (settingDelta.x > eventData.delta.x)
                {
                    settingDelta = eventData.delta;
                }
        }else  if (Mathf.Abs(eventData.delta.y) > dragBoundaryNumber)
        {
            if (eventData.delta.y > 0)
                if (settingDelta.y < eventData.delta.y)
                {
                    settingDelta = eventData.delta;
                }
            if (eventData.delta.y < 0)
                if (settingDelta.y > eventData.delta.y)
                {
                    settingDelta = eventData.delta;
                }
        }    
    }
    private void OnPointUp(PointerEventData obj)
    {
        Direction settingDirection;
        settingDirection = snake.currentDirction;
        if (Mathf.Abs(settingDelta.x) > dragBoundaryNumber)
        {
            if (settingDelta.x > 0)                
            settingDirection = Direction.Right;
            if (settingDelta.x < 0)
                settingDirection = Direction.Left;
        }
        else if (Mathf.Abs(settingDelta.y) > dragBoundaryNumber)
        {
            if (settingDelta.y > 0)
                settingDirection = Direction.Up;
            if (settingDelta.y < 0)
                settingDirection = Direction.Down;
        }

        snake.currentDirction = GameInputManager.TrySetSankeDirction(snake.currentDirction, settingDirection);
    }

}
