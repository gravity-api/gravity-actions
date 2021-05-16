## Description
Double clicks the mouse at the last known mouse coordinates or on the specified element. If the click causes a new page to load, the ```OpenQA.Selenium.IWebElement.Click``` method will attempt to block until the page has loaded.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation which implements _**Double Click**_.

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

Double clicks the mouse on the specified element.

#### _Action Rule (JSON)_
```js
{
    "action": "DoubleClick",
    "onElement": "click_button",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
double click on {click_button} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.DoubleClick,
    OnElement = "click_button",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "DoubleClick",
    OnElement = "click_button",
    Locator = "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "DoubleClick",
    "onElement": "click_button",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "DoubleClick",
    onElement: "click_button",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("DoubleClick")
        .setOnElement("click_button")
        .setLocator("Id");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Double clicks the mouse at the last known mouse coordinates.

#### _Action Rule (JSON)_
```js
{
    "action": "DoubleClick"
}
```

#### _Rhino Literal_
```
double click
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.DoubleClick
};

// option no.2
var actionRule = new
{
    Action = "DoubleClick"
};
```

#### _Python_
```python
action_rule = {
    "action": "DoubleClick"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "DoubleClick"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("DoubleClick");
```