using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Robot roboto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
            roboto.Loadout.OnMouseWheel(Input.mouseScrollDelta.y > 0 ? 1 : -1);
                
        if (Input.GetMouseButtonDown(0))
            roboto.Loadout.OnLeftClickDown();
        if (Input.GetMouseButton(0))
            roboto.Loadout.OnLeftClickHold();
        if (Input.GetMouseButtonUp(0))
            roboto.Loadout.OnLeftClickUp();

        if (Input.GetKeyDown(KeyCode.R))
            roboto.Loadout.OnReload();
    }
}
