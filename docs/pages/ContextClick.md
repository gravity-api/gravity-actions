## Description
Right clicks the mouse at the last known mouse coordinates or on the specified element.

## Scope
**Web**, **Mobile Web** or any other Web Driver implementation which implements _**Context Click**_.

## Properties
| Property             | Description                                           |
|----------------------|-------------------------------------------------------|
| _**argument**_       | Plugin conditions and additional information.         |
| _**onElement**_ | The locator value by which the element will be found. |
| _**locator**_        | The locator type by which the element will be found.  |

## Command Line Arguments (CLI)
_None_

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Right clicks the mouse on the specified element.

#### _Action Rule (JSON)_
```js
{
    "action": "ContextClick",
    "onElement": "click_button",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
context click on {click_button} using {id}

// aliases (alternatives)
right click on {click_button} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.ContextClick,
    OnElement = "click_button",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "ContextClick",
    OnElement = "click_button",
    Locator = "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "ContextClick",
    "onElement": "click_button",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "ContextClick",
    onElement: "click_button",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("ContextClick")
        .setOnElement("click_button")
        .setLocator("Id");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Right clicks the mouse at the last known mouse coordinates.

#### _Action Rule (JSON)_
```js
{
    "action": "ContextClick"
}
```

#### _Rhino Literal_
```
context click

// aliases (alternatives)
right click
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.ContextClick
};

// option no.2
var actionRule = new
{
    Action = "ContextClick"
};
```

#### _Python_
```python
action_rule = {
    "action": "ContextClick"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "ContextClick"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("ContextClick");
```