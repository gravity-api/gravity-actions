## Description
Refreshes the current page. The action will be completed when page ready state ```complete``` or until page loading timeout reached.

## Scope
**Web**, **Mobile Web** or any other Web Driver implementation which implements _**Refresh**_.

## Properties
| Property             | Description                                           |
|----------------------|-------------------------------------------------------|
| _**argument**_       | Plugin conditions and additional information.         |

## Command Line Arguments (CLI)
_**None**_

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Refreshes the current page.

#### _Action Rule (JSON)_
```js
{
    "action": "Refresh"
}
```

#### _Rhino Literal_
```
refresh
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = PluginsList.Refresh
};

// option no.2
var actionRule = new
{
    Action = "Refresh"
};
```

#### _Python_
```python
action_rule = {
    "action": "Refresh"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Refresh"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("Refresh");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Refreshes the current page ```2``` times.

#### _Action Rule (JSON)_
```js
{
    "action": "Refresh",
    "argument": "2"
}
```

#### _Rhino Literal_
```
refresh {2}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = PluginsList.Refresh,
    Argument = "2"
};

// option no.2
var actionRule = new
{
    Action = "Refresh",
    Argument = "2"
};
```

#### _Python_
```python
action_rule = {
    "action": "Refresh",
    "argument": "2" 
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Refresh",
    argument: "2"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("Refresh").setArgument("2");