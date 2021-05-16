## Description
Clicks the mouse at the last known mouse coordinates or on the specified element. If the click causes a new page to load, the Click method will attempt to block until the page has loaded.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation which implements _**Click**_.

## Properties
| Property             | Description                                           |
|----------------------|-------------------------------------------------------|
| _**argument**_       | Plugin conditions and additional information.         |
| _**onElement**_      | The locator value by which the element will be found. |
| _**locator**_        | The locator type by which the element will be found.  |

## Command Line Arguments (CLI)
### _until_
Repeats the click action until condition is met.
| Value          | Description                                                                           |
|----------------|---------------------------------------------------------------------------------------|
| _**no_alert**_ | If alert pops when clicking is performed, dismiss alert and repeat the click action.  |

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Clicks the mouse on the specified element.

#### _Action Rule (JSON)_
```js
{
    "action": "Click",
    "onElement": "//a[.=\"Departments\"]"
}
```

#### _Rhino Literal_
```
click on {//a[.=\"Departments\"]}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.Click,
    OnElement = "//a[.=\"Departments\"]"
};

// option no.2
var actionRule = new
{
    Action = "Click",
    OnElement = "//a[.=\"Departments\"]"
};
```

#### _Python_
```python
action_rule = {
    "action": "Click",
    "onElement": "//a[.=\"Departments\"]"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Click",
    onElement: "//a[.=\"Departments\"]"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Click")
        .setOnElement("//a[.=\"Departments\"]");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Clicks the mouse at the last known mouse coordinates.

#### _Action Rule (JSON)_
```js
{
    "action": "Click"
}
```

#### _Rhino Literal_
```
click
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.Click
};

// option no.2
var actionRule = new
{
    Action = "Click"
};
```

#### _Python_
```python
action_rule = {
    "action": "Click"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Click"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("Click");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Clicks the mouse on the specified element. If alert is present after that click, it will be dismissed and the click action repeats. The action repeats until no alert or until page load timeout reached.

> This is a _**Web**_ only action (not for native). This action is currently not supported by the following:
> 1. iOS + Safari
> 2. Internet Explorer 11

#### _Action Rule (JSON)_
```js
{
    "action": "Click",
    "argument": "{{$ --until:no_alert}}",
    "onElement": "pop_alert",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
click {{$ --until:no_alert}} on {pop_alert} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.Click,
    Argument = "{{$ --until:no_alert}}",
    OnElement = "pop_alert",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "Click",
    Argument = "{{$ --until:no_alert}}",
    OnElement = "pop_alert",
    Locator = "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "Click",
    "argument": "{{$ --until:no_alert}}",
    "onElement": "pop_alert",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Click",
    argument: "{{$ --until:no_alert}}",
    onElement: "pop_alert",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Click")
        .setArgument("{{$ --until:no_alert}}")
        .setOnElement("pop_alert")
        .setLocator("Id");
```