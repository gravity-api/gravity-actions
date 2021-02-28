## Description
Simulates typing text into the element. This actions supports typing interval and various clearing options.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation which implements _**Value**_.

## Properties
| Property        | Description                                           |
|-----------------|-------------------------------------------------------|
| _**argument**_  | Plugin conditions and additional information.         |
| _**onElement**_ | The locator value by which the element will be found. |
| _**locator**_   | The locator type by which the element will be found.  |

## Command Line Arguments (CLI)
### _clear_
Clears the element value, before typing into it.

### _down_
Array of keys to press down while sending keys (use to simulate ```CRTL+A```, ```CTRL+SHIFT+DELETE```, etc.
| Value               | Description                                    |
|---------------------|------------------------------------------------|
| _**control,shift**_ | Holds down ```Control``` and ```Shift``` keys. |

### _forceClear_
Clears the element value using ```BACKSPACE``` key, performing the clearing using real keyboard actions. This action is not supported by ```Mobile Native``` applications.

### _interval_
The interval time between each character typing in _**milliseconds**_.
| Value     | Description                                            |
|-----------|--------------------------------------------------------|
| _**300**_ | Waits ```300 milliseconds``` between each char typing. |

### _keys_
The text to type into the element.
| Value      | Description                                          |
|------------|------------------------------------------------------|
| _**text**_ | Sends the text provided into the element or browser. |

## Aliases
The following keywords can be used instead of ```send keys```
1. type
2. write
3. print

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#element-send-keys](https://www.w3.org/TR/webdriver/#element-send-keys)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Type ```Lorem ipsum``` into ```input_enabled``` text box, using ```ID``` locator.

#### _Action Rule (JSON)_
```js
{
    "action": "SendKeys",
    "argument": "Lorem ipsum",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
send keys {Lorem ipsum} into {input_enabled} using {id}

// aliases (alternatives)
write {Lorem ipsum} into {input_enabled} using {id}
type {Lorem ipsum} into {input_enabled} using {id}
print {Lorem ipsum} into {input_enabled} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SendKeys,
    Argument = "Lorem ipsum",
    OnElement = "input_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "SendKeys",
    "argument": "Lorem ipsum",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SendKeys",
    argument: "Lorem ipsum",
    onElement: "input_enabled",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SendKeys")
        .setArgument("Lorem ipsum")
        .setOnElement("input_enabled")
        .setLocator("Id");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Type ```Lorem ipsum``` into ```input_enabled_with_text``` text box, using ```ID``` locator, after clearing the existing text.

#### _Action Rule (JSON)_
```js
{
    "action": "SendKeys",
    "argument": "{{$ --keys:Lorem ipsum --clear}}",
    "onElement": "input_enabled_with_text",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
send keys {{$ --keys:Lorem ipsum --clear}} into {input_enabled_with_text} using {id}

// aliases (alternatives)
write {{$ --keys:Lorem ipsum --clear}} into {input_enabled_with_text} using {id}
type  {{$ --keys:Lorem ipsum --clear}} into {input_enabled_with_text} using {id}
print {{$ --keys:Lorem ipsum --clear}} into {input_enabled_with_text} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SendKeys,
    Argument = "{{$ --keys:Lorem ipsum --clear}}",
    OnElement = "input_enabled_with_text",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "SendKeys",
    "argument": "{{$ --keys:Lorem ipsum --clear}}",
    "onElement": "input_enabled_with_text",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SendKeys",
    argument: "{{$ --keys:Lorem ipsum --clear}}",
    onElement: "input_enabled_with_text",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SendKeys")
        .setArgument("{{$ --keys:Lorem ipsum --clear}}")
        .setOnElement("input_enabled_with_text")
        .setLocator("Id");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Clear existing text from ```input_enabled_with_text``` text box, using ```ID``` locator.

#### _Action Rule (JSON)_
```js
{
    "action": "SendKeys",
    "argument": "{{$ --clear}}",
    "onElement": "input_enabled_with_text",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
send keys {{$ --clear}} into {input_enabled_with_text} using {id}

// aliases (alternatives)
write {{$ --clear}} into {input_enabled_with_text} using {id}
type  {{$ --clear}} into {input_enabled_with_text} using {id}
print {{$ --clear}} into {input_enabled_with_text} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SendKeys,
    Argument = "{{$ --clear}}",
    OnElement = "input_enabled_with_text",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "SendKeys",
    "argument": "{{$ --clear}}",
    "onElement": "input_enabled_with_text",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SendKeys",
    argument: "{{$ --clear}}",
    onElement: "input_enabled_with_text",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SendKeys")
        .setArgument("{{$ --clear}}")
        .setOnElement("input_enabled_with_text")
        .setLocator("Id");
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Type ```Lorem ipsum``` into ```input_enabled``` text box, using ```ID``` locator, with ```200 milliseconds``` between each character.

#### _Action Rule (JSON)_
```js
{
    "action": "SendKeys",
    "argument": "{{$ --keys:Lorem ipsum --interval:200}}",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
send keys {{$ --keys:Lorem ipsum --interval:200}} into {input_enabled} using {id}

// aliases (alternatives)
write {{$ --keys:Lorem ipsum --interval:200}} into {input_enabled} using {id}
type  {{$ --keys:Lorem ipsum --interval:200}} into {input_enabled} using {id}
print {{$ --keys:Lorem ipsum --interval:200}} into {input_enabled} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SendKeys,
    Argument = "{{$ --keys:Lorem ipsum --interval:200}}",
    OnElement = "input_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "SendKeys",
    "argument": "{{$ --keys:Lorem ipsum --interval:200}}",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SendKeys",
    argument: "{{$ --keys:Lorem ipsum --interval:200}}",
    onElement: "input_enabled",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SendKeys")
        .setArgument("{{$ --keys:Lorem ipsum --interval:200}}")
        .setOnElement("input_enabled")
        .setLocator("Id");
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Type ```Lorem ipsum``` into ```input_enabled_with_text``` text box, using ```ID``` locator, after clearing the existing text using ```Force Clear``` option.

#### _Action Rule (JSON)_
```js
{
    "action": "SendKeys",
    "argument": "{{$ --keys:Lorem ipsum --force_clear}}",
    "onElement": "input_enabled_with_text",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
send keys {{$ --keys:Lorem ipsum --force_clear}} into {input_enabled_with_text} using {id}

// aliases (alternatives)
write {{$ --keys:Lorem ipsum --force_clear}} into {input_enabled_with_text} using {id}
type  {{$ --keys:Lorem ipsum --force_clear}} into {input_enabled_with_text} using {id}
print {{$ --keys:Lorem ipsum --force_clear}} into {input_enabled_with_text} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SendKeys,
    Argument = "{{$ --keys:Lorem ipsum --force_clear}}",
    OnElement = "input_enabled_with_text",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "SendKeys",
    "argument": "{{$ --keys:Lorem ipsum --force_clear}}",
    "onElement": "input_enabled_with_text",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SendKeys",
    argument: "{{$ --keys:Lorem ipsum --force_clear}}",
    onElement: "input_enabled_with_text",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SendKeys")
        .setArgument("{{$ --keys:Lorem ipsum --force_clear}}")
        .setOnElement("input_enabled_with_text")
        .setLocator("Id");
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Sends ```[CTRL]+[A]``` into ```text_area_enabled``` text box, using ```ID``` locator.

#### _Action Rule (JSON)_
```js
{
    "action": "SendKeys",
    "argument": "{{$ --down:control --keys:A}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
send keys {{$ --down:control --keys:A}} into {text_area_enabled} using {id}

// aliases (alternatives)
write {{$ --down:control --keys:A}} into {text_area_enabled} using {id}
type  {{$ --down:control --keys:A}} into {text_area_enabled} using {id}
print {{$ --down:control --keys:A}} into {text_area_enabled} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SendKeys,
    Argument = "{{$ --down:control --keys:A}}",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "SendKeys",
    "argument": "{{$ --down:control --keys:A}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SendKeys",
    argument: "{{$ --down:control --keys:A}}",
    onElement: "text_area_enabled",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SendKeys")
        .setArgument("{{$ --down:control --keys:A}}")
        .setOnElement("text_area_enabled")
        .setLocator("Id");
```