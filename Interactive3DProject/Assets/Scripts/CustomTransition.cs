using UnityEngine;
using Cinemachine;

public class CustomTransition : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;

    void Start()
    {
        // 设置默认优先级，确保一个摄像机初始处于活动状态
        cam1.Priority = 10;
        cam2.Priority = 0;
    }

    void Update()
    {
        // 按下1键切换到cam1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam1.Priority = 10;
            cam2.Priority = 0;
        }
        // 按下2键切换到cam2
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam1.Priority = 0;
            cam2.Priority = 10;
        }
    }
}
