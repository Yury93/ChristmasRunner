using UnityEngine;
using UnityEngine.Events;


    public class Destructible : Entity
    {
        [SerializeField] private int health;
        public int Health => health;

        [SerializeField] private int currentLives;
        public int CurrentLives => currentLives;

        [SerializeField] private UnityEvent eventOnDeath;
        public UnityEvent EventOnDeath => eventOnDeath;

        private void Start()
        {
            currentLives = health;
        }

        public void ApplyDamage(int damage)
        {
            currentLives -= damage;

            if (currentLives <= 0)
            {
                Destroy(gameObject);
                eventOnDeath?.Invoke();
            }
        }
    }
