using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Transform startT;
    public Transform endT;
    public float runSpeed = 40f;

    [HideInInspector]
    public GameObject playerObject;

    private Vector2 startWorldPos;
    private Vector2 endWorldPos;
    private bool goingToStartPoint;

    // Start is called before the first frame update
    void Start()
    {
        goingToStartPoint = true;
        startWorldPos = LocalToWorld(startT.localPosition);
        endWorldPos = LocalToWorld(endT.localPosition);
    }

    // Fixed Update is called once per frame
    void FixedUpdate()
    {

        if (!GetComponent<Health>().IsAlive())
            return;

        if (playerObject != null) {
            Vector3 enemyToPlayer = (playerObject.transform.position - transform.position);

            if (enemyToPlayer.magnitude <= 1.25)
            {
                controller.Stop();
                GetComponent<EnemyCombat>().isInAttackRange = true;
                return;
            }
            else {
                GetComponent<EnemyCombat>().isInAttackRange = false;
            }

            float dot = Vector3.Dot(transform.right, enemyToPlayer.normalized);
            if (dot < 0)
            {
                controller.Move((-1 * runSpeed) * Time.fixedDeltaTime, false, false);
            }
            else {
                controller.Move((1 * runSpeed) * Time.fixedDeltaTime, false, false);
            }
            return;
        }

        if (goingToStartPoint)
        {
            controller.Move((-1 * runSpeed) * Time.fixedDeltaTime, false, false);
            if (transform.position.x <= startWorldPos.x) {
                goingToStartPoint = false;
            }
        }
        else {
            controller.Move((1 * runSpeed) * Time.fixedDeltaTime, false, false);
            if (transform.position.x >= endWorldPos.x)
            {
                goingToStartPoint = true;
            }
        }
    }

    private Vector3 LocalToWorld(Vector3 _worldPos) {
        return this.transform.TransformPoint(_worldPos);
    }

}
