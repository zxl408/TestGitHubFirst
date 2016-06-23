using UnityEngine;
using System.Collections;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
public class GameInputManager
{
    public static Direction TrySetSankeDirction(Direction currentDirction, Direction settingDirction)
    {      
        switch (currentDirction)
        {
            case Direction.Up:
                if (settingDirction == Direction.Down)
                    return currentDirction;
                break;
            case Direction.Down:
                if (settingDirction == Direction.Up)
                    return currentDirction;
                break;
            case Direction.Left:
                if (settingDirction == Direction.Right)
                    return currentDirction;
                break;
            case Direction.Right:
                if (settingDirction == Direction.Left)
                    return currentDirction;
                break;
        }

        return settingDirction;
    }
    public static Direction ListenInput(Direction currentDirction)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            return TrySetSankeDirction(currentDirction, Direction.Up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            return TrySetSankeDirction(currentDirction, Direction.Down);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            return TrySetSankeDirction(currentDirction, Direction.Left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            return TrySetSankeDirction(currentDirction, Direction.Right);
        }
        return currentDirction;
    }
}
