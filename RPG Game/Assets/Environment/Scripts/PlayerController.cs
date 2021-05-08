using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMottor))]
public class PlayerController : MonoBehaviour
{
    //need to focus on object
    public Intractable focus;

    public LayerMask movementMask;
    Camera _camera;
    PlayerMottor playerMottor;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        playerMottor = GetComponent<PlayerMottor>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {

                playerMottor.moveToPoint(hit.point);
                SetDefocus();

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                Intractable intractable = hit.collider.GetComponent<Intractable>();

                if (intractable != null)
                {
                    SetFocus(intractable);
                }

            }
        }
        void SetFocus(Intractable newFocus)
        {
            if (newFocus != focus)
            {
                if (focus != null)
                    newFocus.OnFocused(transform);
                focus = newFocus;
                playerMottor.FollowTarget(newFocus);
            }
            newFocus.OnFocused(transform);
        }

        void SetDefocus()
        {

            if (focus != null)
                focus.OnDefocused();
            focus = null;
        }
        playerMottor.StopfollowingTarget();

    }
}
