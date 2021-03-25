## Description
Moves the mouse to the specified element. This action will trigger ```mouseover``` event.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation which implements _**Actions**_.

## Properties
| Property             | Description                                           |
|----------------------|-------------------------------------------------------|
| _**elementToActOn**_ | The locator value by which the element will be found. |
| _**locator**_        | The locator type by which the element will be found.  |

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)

## Examples
### _Example no. 1_
Can be tested on:
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Moves the mouse to the specified element.

#### _Action Rule (JSON)_
```js
{
    "action": "MoveToElement",
    "onElement": "over_outcome",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
move to element on {over_outcome} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = PluginsList.MoveToElement,
    OnElement = "over_outcome",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "MoveToElement",
    OnElement = "over_outcome",
    Locator = "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "MoveToElement",
    "onElement": "over_outcome",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "MoveToElement",
    onElement: "over_outcome",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("MoveToElement")
        .setOnElement("over_outcome")
        .setLocator("Id");
```