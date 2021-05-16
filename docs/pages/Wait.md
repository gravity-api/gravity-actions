## Description
Suspends the current thread for the specified amount of time.  

## Scope
```Wait``` is a generic plugin (application independent) and as such will run on all scopes and all application.

## Properties
| Property        | Description                                           |
|-----------------|-------------------------------------------------------|
| _**argument**_  | The amount of time for which the thread is suspended. |

## Command Line Arguments (CLI)
_*None*_

## Aliases
_*None*_

## W3C Web Driver Protocol
_*None*_

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls  

Suspends the current thread for ```3000ms``` (3s).

#### _Action Rule (JSON)_
```js
{
    "action": "Wait",
    "argument": "3000"
}
```

#### _Rhino Literal_
```
wait {3000}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Wait,
    Argument = "3000"
};
```

#### _Python_
```python
action_rule = {
    "action": "Wait",
    "argument": "3000"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Wait",
    argument: "3000"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Wait")
        .setArgument("3000");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls  

Suspends the current thread for ```0h 5m 30s```.

#### _Action Rule (JSON)_
```js
{
    "action": "Wait",
    "argument": "00:05:30"
}
```

#### _Rhino Literal_
```
wait {00:05:30}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Wait,
    Argument = "00:05:30"
};
```

#### _Python_
```python
action_rule = {
    "action": "Wait",
    "argument": "00:05:30"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Wait",
    argument: "00:05:30"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Wait")
        .setArgument("00:05:30");
```