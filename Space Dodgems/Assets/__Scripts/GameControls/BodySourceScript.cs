using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class BodySourceScript : MonoBehaviour
{
    public BodySourceManager mBodySourceManager;
    public GameObject mJointObject;// prefab of spaceman

    // all the bodies the kinect can see

    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();

    // list of joints the prefab is connected to
    private List<JointType> _joints = new List<JointType>
    {
        JointType.HandRight,
    };

    void Update()
    {

        Body[] data = mBodySourceManager.GetData();
        if (data == null)
        {
            return;
        }

        // tracking id values for each body
        List<ulong> trackedIds = new List<ulong>();

        // loop through data recevied from kinect
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                trackedIds.Add(body.TrackingId);
            }
        }

        List<ulong> knownIds = new List<ulong>(mBodies.Keys);

        // First delete untracked bodies
        foreach (ulong trackingId in knownIds)
        {
            if (!trackedIds.Contains(trackingId))
            {
                // Destroy the body object
                Destroy(mBodies[trackingId]);

                // Remove the body from the list
                mBodies.Remove(trackingId);
            }
        }

        foreach (var body in data)
        {
            // if there is no body, skip
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                // if the dictionary deos not contain the key of the tracking id
                // create a new object
                if (!mBodies.ContainsKey(body.TrackingId))
                {
                    mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }

                // once it is created, update positions
                UpdateBodyObject(body, mBodies[body.TrackingId]);
            }
        }
    }

    private GameObject CreateBodyObject(ulong id)
    {
        // empty game object - create body parent
        GameObject body = new GameObject("Body:" + id);

        // Create joints
        foreach (JointType joint in _joints)
        {
            // instantiate the prefab - create object
            GameObject newJoint = Instantiate(mJointObject);
            newJoint.name = joint.ToString();

            // Parent to body
            newJoint.transform.parent = body.transform;
        }

        // return to be assigned to dictionary
        return body;
    }

    private void UpdateBodyObject(Body body, GameObject bodyObject)
    {
        // JointType - > enum
        foreach (JointType _joint in _joints)
        {
            // get new target position
            Joint sourceJoint = body.Joints[_joint];

            // get the vector 3 of joint
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;

            // Get joint, set new position
            Transform jointObject = bodyObject.transform.Find(_joint.ToString());
            jointObject.position = targetPosition;
        }
    }

    private static Vector3 GetVector3FromJoint(Joint joint)
    {
        // * 10 is standard in kinect code
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);     
    }
}
