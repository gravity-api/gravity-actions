## Description
Scrolls the window or element to a particular set of coordinates inside a given window or element.

## Scope
**Web**, **Mobile Web**.

## Browser Compatibility
* https://developer.mozilla.org/en-US/docs/Web/API/Element/scroll
* https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll

## Properties
| Property             | Description                                           |
|----------------------|-------------------------------------------------------|
| _**argument**_       | Plugin conditions and additional information.         |
| _**onElement**_      | The locator value by which the element will be found. |
| _**locator**_        | The locator type by which the element will be found.  |

## Command Line Arguments (CLI)
### _top_
| Value        | Description                                                                                           |
|--------------|-------------------------------------------------------------------------------------------------------|
| _**number**_ | The pixel along the vertical axis of the document/element that you want displayed in the upper left.  |

### _left_
| Value        | Description                                                                                             |
|--------------|---------------------------------------------------------------------------------------------------------|
| _**number**_ | The pixel along the horizontal axis of the document/element that you want displayed in the upper left.  |

### _behavior_
| Value              | Description                                                                                          |
|--------------------|------------------------------------------------------------------------------------------------------|
| _**smooth, auto**_ | Specifies whether the scrolling should animate smoothly, or happen instantly in a single jump.       |

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Scrolls the page overflow by ```1000``` pixels from top.

#### _Action Rule (JSON)_
```js
{
    "action": "Scroll",
    "argument": "1000"
}
```

#### _Rhino Literal_
```
scroll {1000}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.Scroll,
    Argument = "1000"
};

// option no.2
var actionRule = new
{
    Action = "Scroll",
    Argument = "1000"
};
```

#### _Python_
```python
action_rule = {
    "action": "Scroll",
    "argument": "1000"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Scroll",
    argument: "1000"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Scroll")
        .setArgument("1000");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Scrolls the page overflow by ```1000``` pixels from top.

#### _Action Rule (JSON)_
```js
{
    "action": "Scroll",
    "argument": "{{$ --top:1000}}"
}
```

#### _Rhino Literal_
```
scroll {{$ --top:1000}}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.Scroll,
    Argument = "{{$ --top:1000}}"
};

// option no.2
var actionRule = new
{
    Action = "Scroll",
    Argument = "{{$ --top:1000}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Scroll",
    "argument": "{{$ --top:1000}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Scroll",
    argument: "{{$ --top:1000}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Scroll")
        .setArgument("{{$ --top:1000}}");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Scroll the element overflow by ```1000``` pixels from top.

#### _Action Rule (JSON)_
```js
{
    "action": "Scroll",
    "argument": "1000",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
scroll {1000} on {text_area_enabled} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.Scroll,
    Argument = "1000",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "Scroll",
    Argument = "1000",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Scroll",
    "argument": "1000",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "Scroll",
    "argument": "1000",
    "onElement": "text_area_enabled",
    "locator": "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Scroll")
        .setArgument("1000")
        .setOnElement("text_area_enabled")
        .setLocator("Id");
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Scroll the element overflow by ```1000``` pixels from top.

#### _Action Rule (JSON)_
```js
{
    "action": "Scroll",
    "argument": "{{$ --top:1000}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
scroll {{$ --top:1000}} on {text_area_enabled} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.Scroll,
    Argument = "{{$ --top:1000}}",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "Scroll",
    Argument = "{{$ --top:1000}}",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Scroll",
    "argument": "{{$ --top:1000}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "Scroll",
    "argument": "{{$ --top:1000}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Scroll")
        .setArgument("{{$ --top:1000}}")
        .setOnElement("text_area_enabled")
        .setLocator("Id");
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Scroll the element overflow by ```1000``` pixels from left.

#### _Action Rule (JSON)_
```js
{
    "action": "Scroll",
    "argument": "{{$ --left:1000}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
scroll {{$ --left:1000}} on {text_area_enabled} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.Scroll,
    Argument = "{{$ --left:1000}}",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "Scroll",
    Argument = "{{$ --left:1000}}",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Scroll",
    "argument": "{{$ --left:1000}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "Scroll",
    "argument": "{{$ --left:1000}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Scroll")
        .setArgument("{{$ --left:1000}}")
        .setOnElement("text_area_enabled")
        .setLocator("Id");
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Scroll the element overflow by ```1000``` pixels from top and ```1000``` from left.

#### _Action Rule (JSON)_
```js
{
    "action": "Scroll",
    "argument": "{{$ --top:1000 --left:1000}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
scroll {{$ --top:1000 --left:1000}} on {text_area_enabled} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.Scroll,
    Argument = "{{$ --top:1000 --left:1000}}",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "Scroll",
    Argument = "{{$ --top:1000 --left:1000}}",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Scroll",
    "argument": "{{$ --top:1000 --left:1000}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "Scroll",
    "argument": "{{$ --top:1000 --left:1000}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Scroll")
        .setArgument("{{$ --top:1000 --left:1000}}")
        .setOnElement("text_area_enabled")
        .setLocator("Id");
```

***

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

```Smoothly``` scroll the element overflow by ```1000``` pixels from top and ```1000``` from left.

#### _Action Rule (JSON)_
```js
{
    "action": "Scroll",
    "argument": "{{$ --top:1000 --left:1000 --behavior:smooth}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
scroll {{$ --top:1000 --left:1000 --behavior:smooth}} on {text_area_enabled} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.Scroll,
    Argument = "{{$ --top:1000 --left:1000 --behavior:smooth}}",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "Scroll",
    Argument = "{{$ --top:1000 --left:1000 --behavior:smooth}}",
    OnElement = "text_area_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Scroll",
    "argument": "{{$ --top:1000 --left:1000 --behavior:smooth}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "Scroll",
    "argument": "{{$ --top:1000 --left:1000 --behavior:smooth}}",
    "onElement": "text_area_enabled",
    "locator": "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Scroll")
        .setArgument("{{$ --top:1000 --left:1000 --behavior:smooth}}")
        .setOnElement("text_area_enabled")
        .setLocator("Id");
```

***

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

```Smoothly``` scroll the page overflow by ```1000``` pixels from top.

#### _Action Rule (JSON)_
```js
{
    "action": "Scroll",
    "argument": "{{$ --top:1000 --behavior:smooth}}"
}
```

#### _Rhino Literal_
```
scroll {{$ --top:1000 --behavior:smooth}}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.Scroll,
    Argument = "{{$ --top:1000 --behavior:smooth}}"
};

// option no.2
var actionRule = new
{
    Action = "Scroll",
    Argument = "{{$ --top:1000 --behavior:smooth}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Scroll",
    "argument": "{{$ --top:1000 --behavior:smooth}}"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "Scroll",
    "argument": "{{$ --top:1000 --behavior:smooth}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Scroll")
        .setArgument("{{$ --top:1000 --behavior:smooth}}");
```