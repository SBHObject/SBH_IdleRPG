using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPositioner : MonoBehaviour
{
    private void Update()
    {
        transform.position = SetPosition();
    }

    public Vector3 SetPosition()
    {
        int count = PlayerManager.Instance.characters.Count;

        if(count > 0 )
        {
            float x = 0;
            float y = 0;
            float z = 0;

            for (int i = 0; i < count; i++)
            {
                x += PlayerManager.Instance.characters[i].transform.position.x;
                y += PlayerManager.Instance.characters[i].transform.position.y;
                z += PlayerManager.Instance.characters[i].transform.position.z;
            }

            return new Vector3(x/count, y/count, z/count);
        }
        else
        {
            return transform.position;
        }
    }
}
