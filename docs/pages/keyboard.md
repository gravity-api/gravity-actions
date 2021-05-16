## Description
Simulates keys able to be pressed that are not text keys to the browser.

Full list of supported keys can be found here
* https://github.com/SeleniumHQ/selenium/blob/master/dotnet/src/webdriver/Keys.cs (pass the field name as the action argument).

## Scope
**Web**, **Mobile Web** or any other Web Driver implementation which implements _**Value**_.

## Properties
| Property             | Description                                           |
|----------------------|-------------------------------------------------------|
| _**argument**_       | Plugin conditions and additional information.         |
| _**onElement**_      | The locator value by which the element will be found. |
| _**locator**_        | The locator type by which the element will be found.  |

## Command Line Arguments (CLI)
_**None**_

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#element-send-keys](https://www.w3.org/TR/webdriver/#element-send-keys)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Perform keyboard ```Enter``` action (press enter) on the specified element.

#### _Action Rule (JSON)_
```js
{
    "action": "Keyboard",
    "argument": "Enter",
    "onElement": "SearchString",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
keyboard {Enter} into {SearchString} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.Keyboard,
    Argument: "Enter",
    OnElement: "SearchString",
    Locator: "Id"
};

// option no.2
var actionRule = new
{
    Action = "Keyboard",
    Argument: "Enter",
    OnElement: "SearchString",
    Locator: "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "Keyboard",
    "argument": "Enter",
    "onElement": "SearchString",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Keyboard",
    argument: "Enter",
    onElement: "SearchString",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Keyboard")
        .setArgument("Enter")
        .setOnElement("SearchString")
        .setLocator("Id");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Perform keyboard ```Control+A``` action (ctrl+A) on the specified element.

#### _Action Rule (JSON)_
```js
{
    "action": "Keyboard",
    "argument": "Control,a",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
keyboard {Control,a} into {text_area_enabled} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.Keyboard,
    Argument: "Control,a",
    OnElement: "text_area_enabled",
    Locator: "Id"
};

// option no.2
var actionRule = new
{
    Action = "Keyboard",
    Argument: "Control,a",
    OnElement: "text_area_enabled",
    Locator: "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "Keyboard",
    "argument": "Control,a",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Keyboard",
    argument: "Control,a",
    onElement: "text_area_enabled",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Keyboard")
        .setArgument("Control,a")
        .setOnElement("text_area_enabled")
        .setLocator("Id");
```