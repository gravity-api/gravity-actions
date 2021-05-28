## Description
Submits the form (same as clicking the Submit button).

## Scope
**Web**, **Mobile Web**.

## Properties
| Property        | Description                                                  |
|-----------------|--------------------------------------------------------------|
| _**argument**_  | The action(s) that will be taken on the alert dialog.        |
| _**onElement**_ | The locator value by which the element will be found.        |
| _**locator**_   | The (zero based) index of the form or its id property value. |

## Command Line Arguments (CLI)
_**None**_

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Submits the form which its id is ```searchForm```.

#### _Action Rule (JSON)_
```js
{
    "action": "SubmitForm",
    "argument": "searchForm"
}
```

#### _Rhino Literal_
```
submit form {searchForm}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.SubmitForm,
    Argument = "searchForm"
};

// option no.2
var actionRule = new
{
    Action = "SubmitForm",
    Argument = "searchForm"
};
```

#### _Python_
```python
action_rule = {
    "action": "SubmitForm",
    "argument": "searchForm"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SubmitForm",
    argument: "searchForm"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SubmitForm")
        .setArgument("searchForm");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Submits the form which its index is 0 (counting from the first form in the DOM).

#### _Action Rule (JSON)_
```js
{
    "action": "SubmitForm",
    "argument": "0"
}
```

#### _Rhino Literal_
```
submit form {0}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.SubmitForm,
    Argument = "0"
};

// option no.2
var actionRule = new
{
    Action = "SubmitForm",
    Argument = "0"
};
```

#### _Python_
```python
action_rule = {
    "action": "SubmitForm",
    "argument": "0"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SubmitForm",
    argument: "0"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SubmitForm")
        .setArgument("0");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Submits the form found by the locator ```//form```

#### _Action Rule (JSON)_
```js
{
    "action": "SubmitForm",
    "onElement": "//form"
}
```

#### _Rhino Literal_
```
submit form on {//form}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.SubmitForm,
    OnElement = "//form"
};

// option no.2
var actionRule = new
{
    Action = "SubmitForm",
    OnElement = "//form"
};
```

#### _Python_
```python
action_rule = {
    "action": "SubmitForm",
    "on_element": "//form"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "SubmitForm",
    "onElement": "//form"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SubmitForm")
        .setOnElement("//form");
```