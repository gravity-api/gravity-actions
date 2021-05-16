## Description
Move forward a single entry in the browser\"s history. The action will be completed when page ready state equals ```complete``` or until page loading timeout reached.

## Scope
**Web**, **Mobile Web** or any other Web Driver implementation which implements _**Forward**_.

## Properties
| Property             | Description                                           |
|----------------------|-------------------------------------------------------|
| _**argument**_       | Plugin conditions and additional information.         |

## Command Line Arguments (CLI)
_**None**_

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/

Move forward a ```single``` entry in the browser\"s history.

#### _Action Rule (JSON)_
```js
{
    "action": "NavigateForward"
}
```

#### _Rhino Literal_
```
navigate forward
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.NavigateForward
};

// option no.2
var actionRule = new
{
    Action = "NavigateForward"
};
```

#### _Python_
```python
action_rule = {
    "action": "NavigateForward"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "NavigateForward"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("NavigateForward");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/

Move forward ```2``` entries in the browser\"s history.

#### _Action Rule (JSON)_
```js
{
    "action": "NavigateForward",
    "argument": "2"
}
```

#### _Rhino Literal_
```
navigate forward {2}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.NavigateForward,
    Argument = "2"
};

// option no.2
var actionRule = new
{
    Action = "NavigateForward",
    Argument = "2"
};
```

#### _Python_
```python
action_rule = {
    "action": "NavigateForward",
    "argument": "2" 
}
```

#### _Java Script_
```js
var actionRule = {
    action: "NavigateForward",
    argument: "2"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("NavigateForward").setArgument("2");