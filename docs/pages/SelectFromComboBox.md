## Description
Provides a convenience method for manipulating selections of options in an HTML select element. This action supports different selection options as well as multiple selection based on a pattern.

## Scope
**Web**, **Mobile Web**.

## Properties
| Property                | Description                                           |
|-------------------------|-------------------------------------------------------|
| _**argument**_          | Plugin conditions and additional information.         |
| _**onElement**_         | The locator value by which the element will be found. |
| _**locator**_           | The locator type by which the element will be found.  |
| _**onAttribute**_       | The element attribute from which to extract information for action execution. If not specified, information will be taken from the element inner text. |
| _**regularExpression**_ | A pattern by which the extracted information will be evaluated. Returns the first match. |

## Command Line Arguments (CLI)
### _all_
Select all values in the combo box (combo must be of type ```multiple```).

## W3C Web Driver Protocol
_**None**_

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Selects a single value from ```select_menu``` combo box, by item ```text```.

#### _Action Rule (JSON)_
```js
{
    "action": "SelectFromComboBox",
    "argument": "Two",
    "onElement": "select_menu",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
select from combo box {Two} on {select_menu} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SelectFromComboBox,
    Argument = "Two",
    OnElement: "select_menu",
    Locator: "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "SelectFromComboBox",
    "argument": "Two",
    "onElement": "select_menu",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SelectFromComboBox",
    argument: "Two",
    onElement: "select_menu",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SelectFromComboBox")
        .setArgument("Two")
        .setOnElement("select_menu")
        .setLocator("Id");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Selects a single value from ```select_menu``` combo box, by item ```value```.

#### _Action Rule (JSON)_
```js
{
    "action": "SelectFromComboBox",
    "argument": "2",
    "onElement": "select_menu",
    "locator": "Id",
    "onAttribute": "value"
}
```

#### _Rhino Literal_
```
select from combo box {2} on {select_menu} using {id} from {value}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SelectFromComboBox,
    Argument = "2",
    OnElement: "select_menu",
    Locator: "Id",
    OnAttribute: "value"
};
```

#### _Python_
```python
action_rule = {
    "action": "SelectFromComboBox",
    "argument": "2",
    "onElement": "select_menu",
    "locator": "Id",
    "onAttribute": "value"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SelectFromComboBox",
    argument: "2",
    onElement: "select_menu",
    locator: "Id",
    onAttribute: "value"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SelectFromComboBox")
        .setArgument("2")
        .setOnElement("select_menu")
        .setLocator("Id")
        .setOnAttribute("value");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Selects a single value from ```select_menu``` combo box, by item ```index```.

#### _Action Rule (JSON)_
```js
{
    "action": "SelectFromComboBox",
    "argument": "2",
    "onElement": "select_menu",
    "locator": "Id",
    "onAttribute": "index"
}
```

#### _Rhino Literal_
```
select from combo box {2} on {select_menu} using {id} from {index}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SelectFromComboBox,
    Argument = "2",
    OnElement: "select_menu",
    Locator: "Id",
    OnAttribute: "index"
};
```

#### _Python_
```python
action_rule = {
    "action": "SelectFromComboBox",
    "argument": "2",
    "onElement": "select_menu",
    "locator": "Id",
    "onAttribute": "index"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "SelectFromComboBox",
    argument: "2",
    onElement: "select_menu",
    locator: "Id",
    onAttribute: "index"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SelectFromComboBox")
        .setArgument("2")
        .setOnElement("select_menu")
        .setLocator("Id")
        .setOnAttribute("index");
```
***
### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Selects multiple values from ```select_menu_multiple``` combo box, by item ```text```.

#### _Action Rule (JSON)_
```js
{
    "action": "SelectFromComboBox",
    "argument": "[\"One\", \"Two\"]",
    "onElement": "select_menu_multiple",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
select from combo box {[\"One\", \"Two\"]} on {select_menu_multiple} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SelectFromComboBox,
    Argument = "[\"One\", \"Two\"]",
    OnElement: "select_menu_multiple",
    Locator: "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "SelectFromComboBox",
    "argument": "[\"One\", \"Two\"]",
    "onElement": "select_menu_multiple",
    "locator": "Id"
}
```

#### _Java Script_
```js
action_rule = {
    action: "SelectFromComboBox",
    argument: "[\"One\", \"Two\"]",
    onElement: "select_menu_multiple",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SelectFromComboBox")
        .setArgument("[\"One\", \"Two\"]")
        .setOnElement("select_menu_multiple")
        .setLocator("Id");
```
***
### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Selects multiple values from ```select_menu_multiple``` combo box, by item ```value```.

#### _Action Rule (JSON)_
```js
{
    "action": "SelectFromComboBox",
    "argument": "[\"1\", \"2\"]",
    "onElement": "select_menu_multiple",
    "locator": "Id",
    "onAttribute": "value"
}
```

#### _Rhino Literal_
```
select from combo box {[\"1\", \"2\"]} on {select_menu_multiple} using {id} from {value}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SelectFromComboBox,
    Argument = "[\"1\", \"2\"]",
    OnElement: "select_menu_multiple",
    Locator: "Id",
    OnAttribute: "value"
};
```

#### _Python_
```python
action_rule = {
    "action": "SelectFromComboBox",
    "argument": "[\"1\", \"2\"]",
    "onElement": "select_menu_multiple",
    "locator": "Id",
    "onAttribute": "value"
}
```

#### _Java Script_
```js
action_rule = {
    action: "SelectFromComboBox",
    argument: "[\"1\", \"2\"]",
    onElement: "select_menu_multiple",
    locator: "Id",
    onAttribute: "value"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SelectFromComboBox")
        .setArgument("[\"1\", \"2\"]")
        .setOnElement("select_menu_multiple")
        .setLocator("Id")
        .setOnAttribute("value");
```
***
### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Selects multiple values from ```select_menu_multiple``` combo box, by item ```index```.

#### _Action Rule (JSON)_
```js
{
    "action": "SelectFromComboBox",
    "argument": "[\"1\", \"2\"]",
    "onElement": "select_menu_multiple",
    "locator": "Id",
    "onAttribute": "index"
}
```

#### _Rhino Literal_
```
select from combo box {[\"1\", \"2\"]} on {select_menu_multiple} using {id} from {index}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SelectFromComboBox,
    Argument = "[\"1\", \"2\"]",
    OnElement: "select_menu_multiple",
    Locator: "Id",
    OnAttribute: "index"
};
```

#### _Python_
```python
action_rule = {
    "action": "SelectFromComboBox",
    "argument": "[\"1\", \"2\"]",
    "onElement": "select_menu_multiple",
    "locator": "Id",
    "onAttribute": "index"
}
```

#### _Java Script_
```js
action_rule = {
    action: "SelectFromComboBox",
    argument: "[\"1\", \"2\"]",
    onElement: "select_menu_multiple",
    locator: "Id",
    onAttribute: "index"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SelectFromComboBox")
        .setArgument("[\"1\", \"2\"]")
        .setOnElement("select_menu_multiple")
        .setLocator("Id")
        .setOnAttribute("index");
```
***
### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Selects all values from ```select_menu_multiple``` combo box.

#### _Action Rule (JSON)_
```js
{
    "action": "SelectFromComboBox",
    "argument": "{{$ --all}}",
    "onElement": "select_menu_multiple",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
select from combo box {{$ --all}} on {select_menu_multiple} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SelectFromComboBox,
    Argument = "{{$ --all}}",
    OnElement: "select_menu_multiple",
    Locator: "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "SelectFromComboBox",
    "argument": "{{$ --all}}",
    "onElement": "select_menu_multiple",
    "locator": "Id"
}
```

#### _Java Script_
```js
action_rule = {
    action: "SelectFromComboBox",
    argument: "{{$ --all}}",
    onElement: "select_menu_multiple",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SelectFromComboBox")
        .setArgument("{{$ --all}}")
        .setOnElement("select_menu_multiple")
        .setLocator("Id");
```
***
### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Selects all values from ```select_menu_multiple``` combo box if the ```option``` inner text match ```T```.

#### _Action Rule (JSON)_
```js
{
    "action": "SelectFromComboBox",
    "argument": "{{$ --all}}",
    "onElement": "select_menu_multiple",
    "locator": "Id",
    "regularExpression": "T"
}
```

#### _Rhino Literal_
```
select from combo box {{$ --all}} on {select_menu_multiple} using {id} filter {T}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.SelectFromComboBox,
    Argument = "{{$ --all}}",
    OnElement: "select_menu_multiple",
    Locator: "Id",
    RegularExpression: "T"
};
```

#### _Python_
```python
action_rule = {
    "action": "SelectFromComboBox",
    "argument": "{{$ --all}}",
    "onElement": "select_menu_multiple",
    "locator": "Id",
    "regularExpression": "T"
}
```

#### _Java Script_
```js
action_rule = {
    action: "SelectFromComboBox",
    argument: "{{$ --all}}",
    onElement: "select_menu_multiple",
    locator: "Id",
    regularExpression: "T"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("SelectFromComboBox")
        .setArgument("{{$ --all}}")
        .setOnElement("select_menu_multiple")
        .setLocator("Id")
        .setRegularExpression("T");
```