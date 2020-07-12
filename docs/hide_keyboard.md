## Description
Hide soft keyboard.

## Scope
**Mobile Web**, **Mobile Native**

## Properties
_**None**_

## Command Line Arguments (CLI)
_**None**_

## W3C Web Driver Protocol
[http://appium.io/docs/en/commands/device/keys/hide-keyboard/](http://appium.io/docs/en/commands/device/keys/hide-keyboard/)

## Examples
### _Example no. 1_
Hide soft keyboard..

#### _Action Rule (JSON)_
```js
{
    "action": "HideKeyboard"
}
```

#### _Rhino Literal_
```
hide keyboard
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = PluginsList.HideKeyboard
};

// option no.2
var actionRule = new
{
    Action = "HideKeyboard"
};
```

#### _Python_
```python
action_rule = {
    "action": "HideKeyboard"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "HideKeyboard"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule().setAction("HideKeyboard");
```