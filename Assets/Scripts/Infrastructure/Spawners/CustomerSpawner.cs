using CookingMaster;
using Customers;
using CustomerService;
using Data;
using Infrastructure.Pools;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Infrastructure.Spawners
{
    public class CustomerSpawner : MonoBehaviour
    {
        [SerializeField] private CashRegister _cashRegister;
        [SerializeField] private List<CustomerServiceBase> _customerServices;
        [SerializeField] private ExitZone _exitZone;

        private Coroutine _spawningCorotine;
        private Range _timeBeetwenSpawn;
        private int _maxCustomer;

        private ICustomerPool _objectPool;

        private bool IsSpawning => _cashRegister.CountCustomer < _maxCustomer;

        [Inject]
        private void Construct(GameData gameData, ICustomerPool customerPool)
        {
            _objectPool = customerPool;
            _timeBeetwenSpawn = gameData.TimeBeetwenSpawn;
            _maxCustomer = gameData.MaxCustomer;
        }

        private void Start() =>
            _spawningCorotine = StartCoroutine(Spawnig());

        private void OnEnable()
        {
            _exitZone.CustomerExit += OnCustomerExit;
        }

        private void OnDisable()
        {
            _exitZone.CustomerExit -= OnCustomerExit;
        }

        private void OnCustomerExit()
        {
            if (_spawningCorotine != null)
                StopCoroutine(_spawningCorotine);

            _spawningCorotine = StartCoroutine(Spawnig());
        }

        private IEnumerator Spawnig()
        {
            while (gameObject.activeSelf && enabled)
            {
                if (!IsSpawning)
                    yield break;

                yield return new WaitForSeconds(Random.Range(_timeBeetwenSpawn.Min, _timeBeetwenSpawn.Max));
                SpawnCustomer();
            }
        }

        private void SpawnCustomer()
        {
            var customer = _objectPool.Get();

            customer.Init(_exitZone);
            customer.transform.position = transform.position;
            _cashRegister.GetInLine(customer);
        }
    }
}
