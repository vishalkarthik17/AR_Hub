using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptMoleAnim : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("MoleDestroy")) {
            Destroy(gameObject);
        }

    }
}
