using UnityEngine;
using System.Collections;
public enum BowStates {IDLE = 0, IN_POS = 1, DRAWING_BOW = 2, TAUGHT_STRING = 3, FOCUS_MODE = 4, RELEASED = 5}

public class test_bow : MonoBehaviour 
{
    private BowStates state;
    public BowStates getState() { return state; }

    public Rigidbody Arrow;
    private float speed = 200f;

    private float distanceBetweenHands;
    private float distanceFromBowToPlayer;

    private Transform rightHand, leftHand, playerOrigin;

    private GameObject topBowString, botBowString;
    private LineRenderer lrTopBS, lrBotBS;

    private Vector3 arrowStartPos;
    private float arrowStartDist, arrowCurrDist;

    private float minTriggerThatCounts = 0.1f;
    private float grabStringRange = 4f;
    private float maxBowDrawDist = 20f;
    private float trailTime = 1f;
    private float minDistToDraw = 3f;
    private float taughtStringDist = 5f;

    private Vector3 normalScale;

    Rigidbody ArrowInstance;
    private Quaternion bowFiringRotation;
    private Transform topBS, botBS;

	void Start () 
    {
        state = BowStates.IDLE;
        rightHand = GameObject.Find("Right Hand").transform;
        leftHand = GameObject.Find("Left Hand").transform;
        playerOrigin = GameObject.Find("OVRPlayerController").transform;

        ArrowInstance = Instantiate(Arrow, transform.position, transform.rotation) as Rigidbody;

        topBowString = GameObject.Find("TopBowString");
        botBowString = GameObject.Find("BotBowString");

        lrTopBS = topBowString.GetComponent<LineRenderer>();
        lrBotBS = botBowString.GetComponent<LineRenderer>();

        normalScale = transform.localScale;
	}
	
	void FixedUpdate () 
    {
        transform.localScale = transform.localScale;

        //check and record distances
        distanceBetweenHands = (rightHand.position - leftHand.position).magnitude;
        distanceFromBowToPlayer = (rightHand.position - playerOrigin.position).magnitude;

        switch (state)
        {
            case BowStates.IDLE:

                transform.localScale = normalScale;

                topBS = topBowString.transform;
                botBS = botBowString.transform;

                ArrowInstance.gameObject.GetComponent<TrailRenderer>().time = 0;

                if (distanceBetweenHands < grabStringRange)
                {
                    GetComponentInChildren<MeshRenderer>().renderer.material.color = Color.yellow;
                }
                else
                {
                    GetComponentInChildren<MeshRenderer>().renderer.material.color = Color.green;
                }

                if (distanceBetweenHands < grabStringRange && SixenseInput.Controllers[0].Trigger >= minTriggerThatCounts)
                {
                    arrowStartPos = ArrowInstance.transform.position;
                    arrowStartDist = distanceBetweenHands;
                    bowFiringRotation = gameObject.transform.rotation;

                    state = BowStates.DRAWING_BOW;
                }
                else if (SixenseInput.Controllers[1].Trigger <= minTriggerThatCounts)
                {
                    state = BowStates.IDLE;
                }
                break;
            case BowStates.DRAWING_BOW:
                rotationLock();
                
                arrowCurrDist = distanceBetweenHands;
                arrowCurrDist = Mathf.Clamp(arrowCurrDist, 0, maxBowDrawDist);
                //transform.localScale = new Vector3(normalScale.x, normalScale.y, -0.5f * (normalScale.y * (arrowCurrDist / maxBowDrawDist)));
                transform.localScale = new Vector3(normalScale.x, normalScale.y,(0.5f * (normalScale.y * (arrowCurrDist / maxBowDrawDist))));
                //ArrowInstance.transform.position = transform.position - new Vector3(0, 0, arrowCurrDist);
                ArrowInstance.transform.position = leftHand.transform.position;
                ArrowInstance.transform.LookAt(rightHand);
                
                GetComponentInChildren<MeshRenderer>().renderer.material.color = Color.blue;
                if (distanceBetweenHands > minDistToDraw && SixenseInput.Controllers[0].Trigger >= minTriggerThatCounts)
                {
                    state = BowStates.TAUGHT_STRING;
                }
                else if (SixenseInput.Controllers[0].Trigger <= minTriggerThatCounts)
                {
                    state = BowStates.IDLE;
                }
                break;
            case BowStates.TAUGHT_STRING:
                rotationLock();

                arrowCurrDist = distanceBetweenHands;
                arrowCurrDist = Mathf.Clamp(arrowCurrDist, 0, maxBowDrawDist);

                transform.localScale = new Vector3(normalScale.x, normalScale.y,( 0.5f * (normalScale.y * (arrowCurrDist / maxBowDrawDist))));

               // ArrowInstance.transform.position = transform.position - new Vector3(0, 0, arrowCurrDist);
                ArrowInstance.transform.position = leftHand.transform.position;
                ArrowInstance.transform.LookAt(rightHand);

                GetComponentInChildren<MeshRenderer>().renderer.material.color = Color.red;
                if (SixenseInput.Controllers[0].Trigger <= minTriggerThatCounts && distanceBetweenHands > minDistToDraw && distanceFromBowToPlayer > taughtStringDist)
                {
                    state = BowStates.RELEASED;
                }

                if (distanceBetweenHands < minDistToDraw)
                {
                    state = BowStates.DRAWING_BOW;
                }
                break;
            case BowStates.FOCUS_MODE:
                break;
            case BowStates.RELEASED:
                rotationFix();

                transform.localScale = normalScale;

                ArrowInstance.gameObject.GetComponent<TrailRenderer>().time = trailTime;
                //ArrowInstance.transform.position = transform.position - new Vector3(0, 0, arrowCurrDist);
                ArrowInstance.transform.position = leftHand.transform.position;
                ArrowInstance.transform.LookAt(rightHand);
                ArrowInstance.velocity = ArrowInstance.transform.forward * speed;
                ArrowInstance.GetComponent<Arrow>().Loosed = true;
                ArrowInstance = Instantiate(Arrow, transform.position, bowFiringRotation) as Rigidbody;
                state = BowStates.IDLE;
                break;
            default:
                state = BowStates.IDLE;
                break;
        }

        //This code sets the arrow and bowstring data every frame for every state except released (when the arrow is given its impulse and replaced)
        if (state != BowStates.RELEASED)
        {
            if (state != BowStates.DRAWING_BOW && state != BowStates.TAUGHT_STRING)
            {
                ArrowInstance.position = transform.position;
                ArrowInstance.rotation = transform.rotation;
            }

            lrTopBS.SetPosition(0, topBS.position);
            lrTopBS.SetPosition(1, ArrowInstance.transform.position);

            lrBotBS.SetPosition(0, botBS.position);
            lrBotBS.SetPosition(1, ArrowInstance.transform.position);
        }
	}

    private void rotationLock()
    {
        gameObject.transform.rotation = bowFiringRotation;
    }

    private void rotationFix()
    {
        gameObject.transform.rotation = gameObject.transform.parent.transform.rotation;
        gameObject.transform.Rotate(0,0,90);
    }
}
