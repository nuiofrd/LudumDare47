﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public SphereCollider topCollider, bottomCollider, frontCollider, backCollider, leftCollider, rightCollider;
    public CharacterController controller;
    Collider[] frontCollision, backCollision, leftCollision, rightCollision, sideCollision, topCollision, bottomCollision;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(topCollider, frontCollider);
        Physics.IgnoreCollision(topCollider, backCollider);
        Physics.IgnoreCollision(topCollider, leftCollider);
        Physics.IgnoreCollision(topCollider, rightCollider);
        Physics.IgnoreCollision(frontCollider, backCollider);
        Physics.IgnoreCollision(frontCollider, leftCollider);
        Physics.IgnoreCollision(frontCollider, rightCollider);
        Physics.IgnoreCollision(backCollider, leftCollider);
        Physics.IgnoreCollision(backCollider, rightCollider);
        Physics.IgnoreCollision(leftCollider, rightCollider);
    }

    // Update is called once per frame
    void Update()
    {
        frontCollision = Physics.OverlapSphere(frontCollider.transform.position, frontCollider.radius, 1 << 8);
        backCollision = Physics.OverlapSphere(backCollider.transform.position, backCollider.radius, 1 << 8);
        leftCollision = Physics.OverlapSphere(leftCollider.transform.position, leftCollider.radius, 1 << 8);
        rightCollision = Physics.OverlapSphere(rightCollider.transform.position, rightCollider.radius, 1 << 8);
        topCollision = Physics.OverlapSphere(topCollider.transform.position, topCollider.radius, 1 << 8);
        bottomCollision = Physics.OverlapSphere(bottomCollider.transform.position, bottomCollider.radius, 1 << 8);
        sideCollision = frontCollision.Concat(backCollision).Concat(leftCollision).Concat(rightCollision).Distinct().ToArray();
    }

    public Collider[] getFrontCollisions()
    {
        return frontCollision;
    }
    public Collider[] getBackCollisions()
    {
        return backCollision;
    }
    public Collider[] getLeftCollisions()
    {
        return leftCollision;
    }
    public Collider[] getRightCollisions()
    {
        return rightCollision;
    }
    public Collider[] getSideCollisions()
    {
        return sideCollision;
    }
    public Collider[] getTopCollisions()
    {
        return topCollision;
    }
    public Collider[] getBottomCollisions()
    {
        return bottomCollision;
    }
}
