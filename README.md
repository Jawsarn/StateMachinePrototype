# StateMachinePrototype

![alt text](/Documentation/Graph.png)

# Usage
Create state machine class deriving or containing the `StateMachine` class.

Create states implementing `IState` (and `IFactoryItemWithParams` if you don't want presistant states).

If you want your state to have parameters on Enter use `IState<T>` with T as parameter.
  
Create `StateNodes` for your states (See supplied `PersistentStateNode` and `FactoryStateNode`)
```cs
var myFactory = new BasicFactory<MyStateClass, MyFactoryParameter>(myFactoryParameterValue);
var myStateA = new FactoryStateNode<MyStateClass, MyEnterParameter>(myFactory);

var myStateB = new PersistentStateNode(new StateB());
```
Create a graphConstructor for ease of use.
```cs
var graphConstructor = new StateMachineGraphConstructor(stateMachine);
```
  
Set initial state for state machine
```cs
graphConstructor.InitialState(myStateA);
```
  
Use builder pattern to create transitions between states by events
  ```cs
UnityEvent<MyEnterParameter> MyTriggerEventWithParameter;
graphConstructor.AddTransition<MyEnterParameter>().From(myStateB).To(myStateA).OnEvent(MyTriggerEventWithParameter);
```
Note above that the above event uses extension method to convert into the provided `UnityStateTransitionEvent` type for ease of use.
For other event wrappers implement the `IStateTransitionEvent`.

Finally call `StateMachine.StartStateMachine()` and `StateMachine.StopStateMachine()` att appropriate times.
