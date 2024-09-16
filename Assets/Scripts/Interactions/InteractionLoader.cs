using Infrastructure.Services.Coroutines;
using Player;
using System;
using System.Collections;
using UI;
using UnityEngine;
using Zenject;

namespace Interactions
{
    public class InteractionLoader : IInteractionLoader
    {
        private IProgressLine _progressLine;
        private ICoroutineService _coroutineService;

        private Coroutine _processInteraction;

        public event Action<PlayerInteractor> PlayerInteractСompleted;

        [Inject]
        public InteractionLoader(ICoroutineService coroutineService, IProgressLine progressLine)
        {
            _coroutineService = coroutineService;
            _progressLine = progressLine;
        }

        public void StartInteraction(PlayerInteractor playerInteractor, float timeInterection)
        {
            _progressLine.Show();
            _processInteraction = _coroutineService.StartCoroutine(ProssesInterection(playerInteractor, timeInterection));
        }

        public void StopInteraction()
        {
            if (_processInteraction != null)
                _coroutineService.StopCoroutine(_processInteraction);

            _progressLine.Close();
        }

        private IEnumerator ProssesInterection(PlayerInteractor playerInteractor, float timeInterection)
        {
            float currentTime = 0f;

            while (currentTime < timeInterection)
            {
                currentTime += Time.deltaTime;

                float progress = currentTime / timeInterection;
                _progressLine.SetProgress(progress);

                yield return null;
            }

            PlayerInteractСompleted?.Invoke(playerInteractor);
            _progressLine.Close();
        }
    }
}