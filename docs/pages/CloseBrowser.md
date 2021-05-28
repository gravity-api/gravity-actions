## Description
Quits this driver, closing every associated window.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation which implements _**Delete Session**_.

## Properties
_None_

## Command Line Arguments (CLI)
_None_

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#delete-session](https://www.w3.org/TR/webdriver/#delete-session)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Quits this driver, closing every associated window.

#### _Action Rule (JSON)_
```js
{
    "action": "CloseBrowser"
}
```

#### _Rhino Literal_
```
close browser
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.CloseBrowser
};

// option no.2
var actionRule = new
{
    Action = "CloseBrowser"
};
```

#### _Python_
```python
action_rule = {
    "action": "CloseBrowser"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "CloseBrowser"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("CloseBrowser");
```