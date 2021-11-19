using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector2Int inputVectorDown;
    public Vector2Int inputVector;
    public void Update()
    {
        
        inputVector.x = ((int)Input.GetAxisRaw("Horizontal"));
        inputVector.y = ((int)Input.GetAxisRaw("Vertical"));
        

        //This part is not beautiful
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                inputVectorDown.x = -1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                inputVectorDown.x = 1;
            }
        }
        else
        {
            inputVectorDown.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                inputVectorDown.y = -1;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                inputVectorDown.y = 1;
            }
        }
        else
        {
            inputVectorDown.y = 0;
        }

        


    }
}
