using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Academy.Animations
{
    public class Jumping : MonoBehaviour
    {
        private Animation _animation;

        [SerializeField] private ParticleSystem _particleSystem;
        // Start is called before the first frame update
        void Awake()
        {
            _animation = GetComponent<Animation>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animation[_animation.clip.name].speed *= -1;
            }
        }

        public void PlayPuff()
        {
            _particleSystem.Play();
        }
    }

}
