using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class ParallaxLayer : MonoBehaviour
    {
        [SerializeField] private float parallaxEffect;
        [SerializeField] private Transform backGround1;
        [SerializeField] private Transform backGround2;
        [SerializeField] private Transform backGround3;

        private Camera mainCamera;
        private float length;
        private Vector3 startpos1, startpos2, startpos3;

        private void Start()
        {
            mainCamera = Camera.main;
            length = backGround1.GetComponent<SpriteRenderer>().bounds.size.x;

            startpos1 = backGround1.position;

            var tempPosition2 = backGround2.position;
            tempPosition2.x -= length;
            startpos2 = tempPosition2;

            var tempPosition3 = backGround3.position;
            tempPosition3.x += length;
            startpos3 = tempPosition3;
        }

        private void Update()
        {
            float paralaxDistX = (mainCamera.transform.position.x * parallaxEffect);
            float paralaxDistY = (mainCamera.transform.position.y * parallaxEffect);

            backGround1.position = new Vector3(startpos1.x + paralaxDistX, startpos1.y + paralaxDistY, backGround1.position.z);
            backGround2.position = new Vector3(startpos2.x + paralaxDistX, startpos2.y + paralaxDistY, backGround2.position.z);
            backGround3.position = new Vector3(startpos3.x + paralaxDistX, startpos3.y + paralaxDistY, backGround3.position.z);

            float farDist1 = mainCamera.transform.position.x - backGround1.position.x;
            float farDist2 = mainCamera.transform.position.x - backGround2.position.x;
            float farDist3 = mainCamera.transform.position.x - backGround3.position.x;

            if (Mathf.Abs(farDist1) > (length * 1.5) && farDist1 > 0)
            {
                startpos1.x += (length * 3);
            }
            if (Mathf.Abs(farDist1) > (length * 1.5) && farDist1 < 0)
            {
                startpos1.x -= (length * 3);
            }
            if (Mathf.Abs(farDist2) > (length * 1.5) && farDist2 > 0)
            {
                startpos2.x += (length * 3);
            }
            if (Mathf.Abs(farDist2) > (length * 1.5) && farDist2 < 0)
            {
                startpos2.x -= (length * 3);
            }
            if (Mathf.Abs(farDist3) > (length * 1.5) && farDist3 > 0)
            {
                startpos3.x += (length * 3);
            }
            if (Mathf.Abs(farDist3) > (length * 1.5) && farDist3 < 0)
            {
                startpos3.x -= (length * 3);
            }
        }
    }
}