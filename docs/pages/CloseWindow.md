## Description
Close the given window, quitting the browser if it is the last window currently open.

## Scope
**Web**, **Mobile Web** or any other Web Driver implementation which implements _**Close Window**_.

## Properties
| Property             | Description                                                      |
|----------------------|------------------------------------------------------------------|
| _**argument**_       | The window (zero based) index while 0 is the first (main) window.|

## Command Line Arguments (CLI)
_None_

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#close-window](https://www.w3.org/TR/webdriver/#close-window)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Close the given window by it\"s position index, quitting the browser if it is the last window currently open.

#### _Action Rule (JSON)_
```js
{
    "action": "CloseWindow",
    "argument": "2"
}
```

#### _Rhino Literal_
```
close window {2}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.CloseWindow,
    Argument = "2"
};

// option no.2
var actionRule = new
{
    Action = "CloseBrowser",
    Argument = "2"
};
```

#### _Python_
```python
action_rule = {
    "action": "CloseWindow",
    "argument": "2"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "CloseWindow",
    argument: "2"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("CloseWindow")
        .setArgument("2");
```