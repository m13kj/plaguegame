using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRender : MonoBehaviour
{

    public static readonly string[] staticDirections = { "Idle3", "Idle6", "Idle9", "Idle12" };
    public static readonly string[] runDirections = {"Run3", "Run6", "Run9", "Run12" };

    Animator animator;
    int lastDirection;
    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;

        if (direction.magnitude < .01f)
        {
            directionArray = staticDirections;
        }
        else{
            directionArray = runDirections;
            lastDirection = DirectionToIndex(direction, 4);
        }
        animator.Play(directionArray[lastDirection]);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static int DirectionToIndex(Vector2 dir, int sliceCount)
    {
        Vector2 normDir = dir.normalized;
        float step = 360f / sliceCount;
        float halfstep = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        angle += halfstep;
        if (angle < 0)
        {
            angle += 360;
        }
        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }

    public static int[] AnimatorStringArrayToHashArray(string[] animationArray)
    {
        //allocate the same array length for our hash array
        int[] hashArray = new int[animationArray.Length];
        //loop through the string array
        for (int i = 0; i < animationArray.Length; i++)
        {
            //do the hash and save it to our hash array
            hashArray[i] = Animator.StringToHash(animationArray[i]);
        }
        //we're done!
        return hashArray;
    }

}
