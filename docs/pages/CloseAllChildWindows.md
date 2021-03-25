## Description
Close all open tabs/windows and switch to the main (first) window.

## Scope
**Web**, **Mobile Web** or any other Web Driver implementation which implements _**Close Window**_.

## Properties
_None_

## Command Line Arguments (CLI)
_None_

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#close-window](https://www.w3.org/TR/webdriver/#close-window)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Close all open tabs/windows and switch to the main (first) window.

#### _Action Rule (JSON)_
```js
{
    "action": "CloseAllChildWindows"
}
```

#### _Rhino Literal_
```
close all child windows
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = PluginsList.CloseAllChildWindows
};

// option no.2
var actionRule = new
{
    Action = "CloseAllChildWindows"
};
```

#### _Python_
```python
action_rule = {
    "action": "CloseAllChildWindows"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "CloseAllChildWindows"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("CloseAllChildWindows");
```