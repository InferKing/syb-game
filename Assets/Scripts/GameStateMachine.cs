using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public enum GlobalGameState {
    Menu,
    Play,
    Pause,
    End
}
public interface IObservable {
    void UpdateState(GlobalGameState state);
}
public class GameStateMachine : MonoBehaviour {
    public GlobalGameState GameState { get; private set; } = GlobalGameState.Play;
    private List<IObservable> _observers;
    private void OnEnable() {
        MainController.GameStateChange += OnGameStateChange;
        _observers = new List<IObservable>();
    }

    private void OnDisable() {
        MainController.GameStateChange -= OnGameStateChange;
    }
    private void OnGameStateChange(GlobalGameState gameState) {
        GameState = gameState;
        NotifyAll();
    }
    public void AddEventStateListener(IObservable obs) {
        _observers.Add(obs);
    }
    public void RemoveEventStateListener(IObservable obs) { 
        _observers.Remove(obs);
    }
    private void NotifyAll() {
        _observers.ForEach((IObservable obs) => {
            obs.UpdateState(GameState);
        });
    }
}