## Description
Move back a single entry in the browser\"s history. The action will be completed when page ready state equals ```complete``` or until page loading timeout reached.

## Scope
**Web**, **Mobile Web** or any other Web Driver implementation which implements _**Back**_.

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

Move back a ```single``` entry in the browser\"s history.

#### _Action Rule (JSON)_
```js
{
    "action": "NavigateBack"
}
```

#### _Rhino Literal_
```
navigate back
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.NavigateBack
};

// option no.2
var actionRule = new
{
    Action = "NavigateBack"
};
```

#### _Python_
```python
action_rule = {
    "action": "NavigateBack"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "NavigateBack"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("NavigateBack");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/

Move back ```2``` entries in the browser\"s history.

#### _Action Rule (JSON)_
```js
{
    "action": "NavigateBack",
    "argument": "2"
}
```

#### _Rhino Literal_
```
navigate back {2}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.NavigateBack,
    Argument = "2"
};

// option no.2
var actionRule = new
{
    Action = "NavigateBack",
    Argument = "2"
};
```

#### _Python_
```python
action_rule = {
    "action": "NavigateBack",
    "argument": "2" 
}
```

#### _Java Script_
```js
var actionRule = {
    action: "NavigateBack",
    argument: "2"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("NavigateBack").setArgument("2");