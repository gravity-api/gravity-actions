## Description
Switches to the currently active modal dialog for this particular driver instance.

## Scope
**Web**, **Mobile Web**.

## Properties
| Property             | Description                                           |
|----------------------|-------------------------------------------------------|
| _**argument**_       | The action(s) that will be taken on the alert dialog. |

## Command Line Arguments (CLI)
### _keys_
| Value        | Description                 |
|--------------|-----------------------------|
| _**string**_ | Keys to send to the alert.  |

### _password_
| Value        | Description                                     |
|--------------|-------------------------------------------------|
| _**string**_ | Password in an alert prompting for credentials. |

### _user_
| Value        | Description                                      |
|--------------|--------------------------------------------------|
| _**string**_ | User name in an alert prompting for credentials. |

### _argument enum (can be used as an argument)_
| Value         | Description          |
|---------------|----------------------|
| _**dismiss**_ | Dismisses the alert. |
| _**accept**_  | Accepts the alert.   |

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#user-prompts](https://www.w3.org/TR/webdriver/#user-prompts)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Dismisses the alert.

#### _Action Rule (JSON)_
```js
{
    "action": "SwitchToAlert",
    "argument": "dismiss"
}
```

#### _Rhino Literal_
```
switch to alert {dismiss}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.SwitchToAlert,
    Argument = "dismiss"
};

// option no.2
var actionRule = new
{
    Action = "SwitchToAlert",
    Argument = "dismiss"
};
```

#### _Python_
```python
action_rule = {
    "action": "SwitchToAlert",
    "argument": "dismiss"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SwitchToAlert",
    argument: "dismiss"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SwitchToAlert")
        .setArgument("dismiss");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Accepts the alert.

#### _Action Rule (JSON)_
```js
{
    "action": "SwitchToAlert",
    "argument": "accept"
}
```

#### _Rhino Literal_
```
switch to alert {accept}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.SwitchToAlert,
    Argument = "accept"
};

// option no.2
var actionRule = new
{
    Action = "SwitchToAlert",
    Argument = "accept"
};
```

#### _Python_
```python
action_rule = {
    "action": "SwitchToAlert",
    "argument": "accept"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SwitchToAlert",
    argument: "accept"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SwitchToAlert")
        .setArgument("accept");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Sends keys to the alert.

#### _Action Rule (JSON)_
```js
{
    "action": "SwitchToAlert",
    "argument": "{{$ --keys:Foo Bar}}"
}
```

#### _Rhino Literal_
```
switch to alert {{$ --keys:Foo Bar}}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.SwitchToAlert,
    Argument = "{{$ --keys:Foo Bar}}"
};

// option no.2
var actionRule = new
{
    Action = "SwitchToAlert",
    Argument = "{{$ --keys:Foo Bar}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "SwitchToAlert",
    "argument": "{{$ --keys:Foo Bar}}"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "SwitchToAlert",
    "argument": "{{$ --keys:Foo Bar}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SwitchToAlert")
        .setArgument("{{$ --keys:Foo Bar}}");
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Sends keys to the alert and accept it.

#### _Action Rule (JSON)_
```js
{
    "action": "SwitchToAlert",
    "argument": "{{$ --keys:Foo Bar --accept}}"
}
```

#### _Rhino Literal_
```
switch to alert {{$ --keys:Foo Bar --accept}}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.SwitchToAlert,
    Argument = "{{$ --keys:Foo Bar --accept}}"
};

// option no.2
var actionRule = new
{
    Action = "SwitchToAlert",
    Argument = "{{$ --keys:Foo Bar --accept}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "SwitchToAlert",
    "argument": "{{$ --keys:Foo Bar --accept}}"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "SwitchToAlert",
    "argument": "{{$ --keys:Foo Bar --accept}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SwitchToAlert")
        .setArgument("{{$ --keys:Foo Bar --accept}}");
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Sets the user name and password in an alert prompting for credentials.

#### _Action Rule (JSON)_
```js
{
    "action": "SwitchToAlert",
    "argument": "{{$ --user:Foo --pass:Bar}}"
}
```

#### _Rhino Literal_
```
switch to alert {{$ --user:Foo --pass:Bar}}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.SwitchToAlert,
    Argument = "{{$ --user:Foo --pass:Bar}}"
};

// option no.2
var actionRule = new
{
    Action = "SwitchToAlert",
    Argument = "{{$ --user:Foo --pass:Bar}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "SwitchToAlert",
    "argument": "{{$ --user:Foo --pass:Bar}}"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "SwitchToAlert",
    "argument": "{{$ --user:Foo --pass:Bar}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SwitchToAlert")
        .setArgument("{{$ --user:Foo --pass:Bar}}");
```