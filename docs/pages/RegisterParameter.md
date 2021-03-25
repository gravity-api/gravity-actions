## Description
Saves a parameter under application parameters collection (key/value collection), which allows other actions to access and use the saved value. This action supports locators, elements, attributes, regular expressions and macros.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation.

## Properties
| Property               | Description                                           |
|------------------------|-------------------------------------------------------|
| _**argument**_         | Plugin conditions and additional information.         |
| _**onAttribute**_      | The element attribute from which to extract information for action execution. If not specified, information will be taken from the element inner text.|
| _**onElement**_        | The locator value by which the element will be found. |
| _**locator**_          | The locator type by which the element will be found.  |
| _**regularExpression**_|A pattern by which the extracted information will be evaluated. Returns the first match.|

## Command Line Arguments (CLI)
### _key_
Sets the ```[key]``` of the parameter. The ```[key]``` is the parameter name and will be used by other actions when calling this parameter.

### _value_
Sets the ```[value]``` of the parameter. If this argument is provided, this plugin will ignore any element based value, even if element information was provided.

## W3C Web Driver Protocol
_None_

## Examples
### _Example no. 1_
Save ```//tr[1]/td[2]``` inner text into ```[first_name]``` application parameter.

#### _Action Rule (JSON)_
```js
{
    "actionType": "RegisterParameter",
    "argument": "first_name",
    "onElement": "//tr[1]/td[2]"
}
```

#### _Rhino Literal_
```
register parameter {first_name} take {//tr[1]/td[2]}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    ActionType = CommonPlugins.RegisterParameter,
    Argument = "first_name",
    OnElement = "//tr[1]/td[2]"
};

// option no.2
var actionRule = new
{
    ActionType = "RegisterParameter",
    Argument = "first_name",
    OnElement = "//tr[1]/td[2]"
};
```

#### _Python_
```python
action_rule = {
    "actionType": "RegisterParameter",
    "argument": "first_name",
    "onElement": "//tr[1]/td[2]"
}
```

#### _Java Script_
```js
var actionRule = {
    actionType: "RegisterParameter",
    argument: "first_name",
    onElement: "(//table//a)[1]"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setActionType("RegisterParameter")
        .setArgument("first_name")
        .setonElement("(//table//a)[1]");
```

***

### _Example no. 2_
Save ```//tr[1]/td[2]``` inner text into ```[first_name]``` application parameter.

#### _Action Rule (JSON)_
```js
{
    "actionType": "RegisterParameter",
    "argument": "{{$ --key:first_name}}",
    "onElement": "//tr[1]/td[2]"
}
```

#### _Rhino Literal_
```
register parameter {{$ --key:first_name}} take {//tr[1]/td[2]}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    ActionType = CommonPlugins.RegisterParameter,
    Argument = "{{$ --key:first_name}}",
    OnElement = "//tr[1]/td[2]"
};

// option no.2
var actionRule = new
{
    ActionType = "RegisterParameter",
    Argument = "{{$ --key:first_name}}",
    OnElement = "//tr[1]/td[2]"
};
```

#### _Python_
```python
action_rule = {
    "actionType": "RegisterParameter",
    "argument": "{{$ --key:first_name}}",
    "onElement": "//tr[1]/td[2]"
}
```

#### _Java Script_
```js
var actionRule = {
    actionType: "RegisterParameter",
    argument: "{{$ --key:first_name}}",
    onElement: "(//table//a)[1]"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setActionType("RegisterParameter")
        .setArgument("{{$ --key:first_name}}")
        .setonElement("(//table//a)[1]");
```

***

### _Example no. 3_
Save ```[John]``` into ```[first_name]``` application parameter.

#### _Action Rule (JSON)_
```js
{
    "actionType": "RegisterParameter",
    "argument": "{{$ --key:first_name --value:John}}"
}
```

#### _Rhino Literal_
```
register parameter {{$ --key:first_name --value:John}}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    ActionType = CommonPlugins.RegisterParameter,
    Argument = "{{$ --key:first_name --value:John}}"
};

// option no.2
var actionRule = new
{
    ActionType = "RegisterParameter",
    Argument = "{{$ --key:first_name --value:John}}"
};
```

#### _Python_
```python
action_rule = {
    "actionType": "RegisterParameter",
    "argument": "{{$ --key:first_name --value:John}}"
}
```

#### _Java Script_
```js
var actionRule = {
    actionType: "RegisterParameter",
    argument: "{{$ --key:first_name --value:John}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setActionType("RegisterParameter")
        .setArgument("{{$ --key:first_name --value:John}}")
```

***

### _Example no. 4_
Save the ```[href]``` attribute value of ```//tr[1]/td[6]/a[1]``` into ```[link]``` application parameter.

#### _Action Rule (JSON)_
```js
{
    "actionType": "RegisterParameter",
    "argument": "link",
    "onElement": "//tr[1]/td[6]/a[1]",
    "onAttribute": "href"
}
```

#### _Rhino Literal_
```
register parameter {link} take {//tr[1]/td[6]/a[1]} from {href}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    ActionType = CommonPlugins.RegisterParameter,
    Argument = "link",
    OnElement = "//tr[1]/td[6]/a[1]",
    OnAttribute = "href"
};

// option no.2
var actionRule = new
{
    ActionType = "RegisterParameter",
    Argument = "link",
    OnElement = "//tr[1]/td[6]/a[1]",
    OnAttribute = "href"
};
```

#### _Python_
```python
action_rule = {
    "actionType": "RegisterParameter",
    "argument": "link",
    "onElement": "//tr[1]/td[6]/a[1]",
    "onAttribute": "href"
}
```

#### _Java Script_
```js
var actionRule = {
    actionType: "RegisterParameter",
    argument: "link",
    onElement: "//tr[1]/td[6]/a[1]",
    onAttribute: "href"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setActionType("RegisterParameter")
        .setArgument("link")
        .setonElement("//tr[1]/td[6]/a[1]")
        .setonAttribute("href");
```

***

### _Example no. 5_
Save the first ```[Abe]``` match, from element ```//tr[1]/td[1]``` inner text, into ```[regex]``` application parameter.

#### _Action Rule (JSON)_
```js
{
    "actionType": "RegisterParameter",
    "argument": "regex",
    "onElement": "//tr[1]/td[1]",
    "regularExpression": "Abe"
}
```

#### _Rhino Literal_
```
register parameter {regex} take {//tr[1]/td[2]} filter {Abe}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    ActionType = CommonPlugins.RegisterParameter,
    Argument = "regex",
    OnElement = "//tr[1]/td[2]",
    RegularExpression = "Abe"
};

// option no.2
var actionRule = new
{
    ActionType = "RegisterParameter",
    Argument = "regex",
    OnElement = "//tr[1]/td[2]",
    RegularExpression = "Abe"
};
```

#### _Python_
```python
action_rule = {
    "actionType": "RegisterParameter",
    "argument": "regex",
    "onElement": "//tr[1]/td[2]",
    "regularExpression" : "Abe"
}
```

#### _Java Script_
```js
var actionRule = {
    actionType: "RegisterParameter",
    argument: "regex",
    onElement: "//tr[1]/td[2]",
    regularExpression: "Abe"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setActionType("RegisterParameter")
        .setArgument("regex")
        .setonElement("//tr[1]/td[2]")
        .setRegularExpression("Abe");
```

***

### _Example no. 6_
Save the current date into ```[date]``` application parameter with ```[yyyy-MM-dd]``` format.

#### _Action Rule (JSON)_
```js
{
    "actionType": "RegisterParameter",
    "argument": "{{$ --key:date --value:{{$date --format:yyyy-MM-dd}}}}"
}
```

#### _Rhino Literal_
```
register parameter {{$ --key:date --value:{{$date --format:yyyy-MM-dd}}}}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    ActionType = CommonPlugins.RegisterParameter,
    Argument = "{{$ --key:date --value:{{$date --format:yyyy-MM-dd}}}}"
};

// option no.2
var actionRule = new
{
    ActionType = "RegisterParameter",
    Argument = "{{$ --key:date --value:{{$date --format:yyyy-MM-dd}}}}"
};
```

#### _Python_
```python
action_rule = {
    "actionType": "RegisterParameter",
    "argument": "{{$ --key:date --value:{{$date --format:yyyy-MM-dd}}}}"
}
```

#### _Java Script_
```js
var actionRule = {
    actionType: "RegisterParameter",
    argument: "{{$ --key:date --value:{{$date --format:yyyy-MM-dd}}}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setActionType("RegisterParameter")
        .setArgument("{{$ --key:date --value:{{$date --format:yyyy-MM-dd}}}}");
```