## Content
* [Examples: _**attribute**_](#examples-attribute)
* [Examples: _**count**_](#examples-count)
* [Examples: _**disabled**_](#examples-disabled)

## Examples: _attribute_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/
* https://gravitymvctestapplication.azurewebsites.net/UiControls

### _Example no. 1_
Assert that ```class``` attribute of an element _**equals**_ ```nav-link text-dark```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --attribute --eq:nav-link text-dark}}",
    "onElement": "ul > li:nth-child(1) > a",
    "locator": "CssSelector",
    "onAttribute": "class"
}
```

#### _Rhino Literal_
```
assert {{$ --attribute --eq:btn btn-default}} from {class} on {ul > li:nth-child(1) > a} using {css selector}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --attribute --eq:nav-link text-dark}}",
    OnElement = "ul > li:nth-child(1) > a",
    Locator: LocatorsList.CssSelector,
    OnAttribute = "class"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --attribute --eq:nav-link text-dark}}",
    "onElement": "ul > li:nth-child(1) > a",
    "locator": "CssSelector",
    "onAttribute": "class"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --attribute --eq:nav-link text-dark}}",
    onElement: "ul > li:nth-child(1) > a",
    locator: "CssSelector",
    onAttribute: "class"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --attribute --eq:nav-link text-dark}}")
        .setOnElement("ul > li:nth-child(1) > a")
        .setLocator("CssSelector")
        .setOnAttribute("class");
```

***

### _Example no. 2_
Assert that ```class``` attribute of an element _**not equals**_ ```btn-default btn```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --attribute --ne:btn-default btn}}",
    "onElement": "p:nth-child(3) > a",
    "locator": "CssSelector",
    "onAttribute": "class"
}
```

#### _Rhino Literal_
```
assert {{$ --attribute --ne:btn btn-default}} from {class} on {ul > li:nth-child(1) > a} using {css selector}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --attribute --ne:btn-default btn}}",
    OnElement = "p:nth-child(3) > a",
    Locator = LocatorsList.CssSelector,
    OnAttribute = "class"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument" = "{{$ --attribute --ne:btn-default btn}}",
    "onElement": "p:nth-child(3) > a",
    "locator": "CssSelector",
    "onAttribute": "class"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --attribute --ne:btn-default btn}}",
    onElement: "p:nth-child(3) > a",
    locator: "CssSelector",
    onAttribute: "class"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --attribute --ne:btn-default btn}}")
        .setOnElement("p:nth-child(3) > a")
        .setLocator("CssSelector")
        .setOnAttribute("class");
```

***

### _Example no. 3_
Assert that ```class``` attribute of an element _**match**_ ```^btn btn-default$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --attribute --match:^btn btn-default$}}",
    "onElement": "See the tutorial »",
    "locator": "LinkText",
    "onAttribute": "class"
}
```

#### _Rhino Literal_
```
assert {{$ --attribute --match:^btn btn-default$}} from {class} on {See the tutorial »} using {link text}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --attribute --match:^btn btn-default$}}",
    OnElement = "See the tutorial »",
    Locator = LocatorsList.LinkText,
    OnAttribute = "class"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --attribute --match:^btn btn-default$}}",
    "onElement": "See the tutorial »",
    "locator": "LinkText",
    "onAttribute": "class"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --attribute --match:^btn btn-default$}}",
    onElement: "See the tutorial »",
    locator: "LinkText",
    onAttribute: "class"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --attribute --match:^btn btn-default$}}")
        .setOnElement("See the tutorial »")
        .setLocator("LinkText")
        .setOnAttribute("class");
```

***

### _Example no. 4_
Assert that ```class``` attribute of an element _**not match**_ ```^btn-default btn$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --attribute --not_match:^btn-default btn$}}",
    "onElement": "See the tutorial »",
    "locator": "LinkText",
    "onAttribute": "class"
}
```

#### _Rhino Literal_
```
assert {{$ --attribute --not_match:^btn-default btn$}} from {class} on {See the tutorial »} using {link text}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --attribute --not_match:^btn-default btn$}}",
    OnElement = "See the tutorial »",
    Locator = LocatorsList.LinkText,
    OnAttribute = "class"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --attribute --not_match:^btn-default btn$}}",
    "onElement": "See the tutorial »",
    "locator": "LinkText",
    "onAttribute": "class"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --attribute --not_match:^btn-default btn$}}",
    onElement: "See the tutorial »",
    locator: "LinkText",
    onAttribute: "class"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --attribute --not_match:^btn-default btn$}}")
        .setOnElement("See the tutorial »")
        .setLocator("LinkText")
        .setOnAttribute("class");
```

***

### _Example no. 5_
Assert that ```number``` attribute of an element is _**greater than**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --attribute --gt:1}}",
    "onElement": "#attribute_div",
    "locator": "CssSelector",
    "onAttribute": "number"
}
```

#### _Rhino Literal_
```
assert {{$ --attribute --gt:1}} from {number} on {#attribute_div} using {css selector}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --attribute --gt:1}}",
    OnElement = "#attribute_div",
    Locator = LocatorsList.CssSelector,
    OnAttribute = "number"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --attribute --gt:1}}",
    "onElement": "#attribute_div",
    "locator": "CssSelector",
    "onAttribute": "number"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --attribute --gt:1}}",
    onElement: "#attribute_div",
    locator: "CssSelector",
    onAttribute: "number"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --attribute --gt:1}}")
        .setOnElement("#attribute_div")
        .setLocator("CssSelector")
        .setOnAttribute("number");
```

***

### _Example no. 6_
Assert that ```number``` attribute of an element is _**lower than**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --attribute --lt:1}}",
    "onElement": "#attribute_div",
    "locator": "CssSelector",
    "onAttribute": "number"
}
```

#### _Rhino Literal_
```
assert {{$ --attribute --lt:1}} from {number} on {#attribute_div} using {css selector}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --attribute --lt:1}}",
    OnElement = "#attribute_div",
    Locator = LocatorsList.CssSelector,
    OnAttribute = "number"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --attribute --lt:1}}",
    "onElement": "#attribute_div",
    "locator": "CssSelector",
    "onAttribute": "number"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --attribute --lt:1}}",
    onElement: "#attribute_div",
    locator: "CssSelector",
    onAttribute: "number"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --attribute --lt:1}}")
        .setOnElement("#attribute_div")
        .setLocator("CssSelector")
        .setOnAttribute("number");
```

***

### _Example no. 7_
Assert that ```number``` attribute of an element is _**greater or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --attribute --ge:1}}",
    "onElement": "#attribute_div",
    "locator": "CssSelector",
    "onAttribute": "number"
}
```

#### _Rhino Literal_
```
assert {{$ --attribute --ge:1}} from {number} on {#attribute_div} using {css selector}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --attribute --ge:1}}",
    OnElement = "#attribute_div",
    Locator = LocatorsList.CssSelector,
    OnAttribute = "number"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --attribute --ge:1}}",
    "onElement": "#attribute_div",
    "locator": "CssSelector",
    "onAttribute": "number"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --attribute --ge:1}}",
    onElement: "#attribute_div",
    locator: "CssSelector",
    onAttribute: "number"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --attribute --ge:1}}")
        .setOnElement("#attribute_div")
        .setLocator("CssSelector")
        .setOnAttribute("number");
```

***

### _Example no. 8_
Assert that ```number``` attribute of an element is _**lower or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --attribute --le:1}}",
    "onElement": "#attribute_div",
    "locator": "CssSelector",
    "onAttribute": "number"
}
```

#### _Rhino Literal_
```
assert {{$ --attribute --le:1}} from {number} on {#attribute_div} using {css selector}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --attribute --le:1}}",
    OnElement = "#attribute_div",
    Locator = LocatorsList.CssSelector,
    OnAttribute = "number"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --attribute --le:1}}",
    "onElement": "#attribute_div",
    "locator": "CssSelector",
    "onAttribute": "number"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --attribute --le:1}}",
    onElement: "#attribute_div",
    locator: "CssSelector",
    onAttribute: "number"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --attribute --le:1}}")
        .setOnElement("#attribute_div")
        .setLocator("CssSelector")
        .setOnAttribute("number");
```

## Examples: _count_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/course

Assert that ```//tbody/tr``` elements count _**equals**_ ```7```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --count --eq:7}}",
    "onElement": "//tbody/tr"
}
```

#### _Rhino Literal_
```
assert {{$ --count --eq:7}} on {//tbody/tr}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --count --eq:7}}",
    OnElement = "//tbody/tr"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --count --eq:7}}",
    "onElement": "//tbody/tr"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --count --eq:7}}",
    onElement: "//tbody/tr"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --count --eq:7}}")
        .setOnElement("//tbody/tr");
```

***

### _Example no. 2_
Assert that ```//tbody/tr``` elements count _**not equals**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --count --ne:10}}",
    "onElement": "//tbody/tr"
}
```

#### _Rhino Literal_
```
assert {{$ --count --ne:10}} on {//tbody/tr}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --count --ne:10}}",
    OnElement = "//tbody/tr"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --count --ne:10}}",
    "onElement": "//tbody/tr"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --count --ne:10}}",
    onElement: "//tbody/tr"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --count --ne:10}}")
        .setOnElement("//tbody/tr");
```

***

### _Example no. 3_
Assert that ```//tbody/tr``` elements count _**match**_ ```^\d{1}$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --count --match:^\\d{1}$}}",
    "onElement": "//tbody/tr"
}
```

#### _Rhino Literal_
```
assert {{$ --count --match:^\d{1}$}} on {//tbody/tr}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --count --match:^\\d{1}$}}",
    OnElement = "//tbody/tr"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --count --match:^\\d{1}$}}",
    "onElement": "//tbody/tr"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --count --match:^\\d{1}$}}",
    onElement: "//tbody/tr"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --count --match:^\\d{1}$}}")
        .setOnElement("//tbody/tr");
```

***

### _Example no. 4_
Assert that ```//tbody/tr``` elements count _**not match**_ ```^1\d+$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --count --not_match:^1\\d+$}}",
    "onElement": "//tbody/tr"
}
```

#### _Rhino Literal_
```
assert {{$ --count --not_match:^1\d+$}} on {//tbody/tr}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --count --not_match:^1\\d+$}}",
    OnElement = "//tbody/tr"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --count --not_match:^1\\d+$}}",
    "onElement": "//tbody/tr"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --count --not_match:^1\\d+$}}",
    onElement: "//tbody/tr"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --count --not_match:^1\\d+$}}")
        .setOnElement("//tbody/tr");
```

***

### _Example no. 5_
Assert that ```//tbody/tr``` elements count is _**greater than**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --count --gt:1}}",
    "onElement": "//tbody/tr"
}
```

#### _Rhino Literal_
```
assert {{$ --count --gt:1}} on {//tbody/tr}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --count --gt:1}}",
    OnElement = "//tbody/tr"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --count --gt:1}}",
    "onElement": "//tbody/tr"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --count --gt:1}}",
    onElement: "//tbody/tr"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --count --gt:1}}")
        .setOnElement("//tbody/tr");
```

***

### _Example no. 6_
Assert that ```//tbody/tr``` elements count is _**lower than**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --count --lt:10}}",
    "onElement": "//tbody/tr"
}
```

#### _Rhino Literal_
```
assert {{$ --count --lt:10}} on {//tbody/tr}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --count --lt:10}}",
    OnElement = "//tbody/tr"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --count --lt:10}}",
    "onElement": "//tbody/tr"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --count --lt:10}}",
    onElement: "//tbody/tr"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --count --lt:10}}")
        .setOnElement("//tbody/tr");
```

***

### _Example no. 7_
Assert that ```//tbody/tr``` elements count is _**greater or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --count --ge:1}}",
    "onElement": "//tbody/tr"
}
```

#### _Rhino Literal_
```
assert {{$ --count --ge:1}} on {//tbody/tr}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --count --ge:1}}",
    OnElement = "//tbody/tr"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --count --ge:1}}",
    "onElement": "//tbody/tr"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --count --ge:1}}",
    onElement: "//tbody/tr"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --count --ge:1}}")
        .setOnElement("//tbody/tr");
```

***

### _Example no. 8_
Assert that ```//tbody/tr``` elements count is _**lower or equal**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --count --le:10}}",
    "onElement": "//tbody/tr"
}
```

#### _Rhino Literal_
```
assert {{$ --count --le:1}} on {//tbody/tr}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --count --le:10}}",
    OnElement = "//tbody/tr"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --count --le:10}}",
    "onElement": "//tbody/tr"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --count --le:10}}",
    onElement: "//tbody/tr"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --count --le:10}}")
        .setOnElement("//tbody/tr");
```

## Examples: _disabled_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```<input id="input_disabled">``` element is ```disabled```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --disabled}}",
    "onElement": "input_disabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
assert {{$ --disabled}} on {input_disabled} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Assert,
    Argument = "{{$ --disabled}}",
    OnElement = "input_disabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --disabled}}",
    "onElement": "input_disabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --disabled}}",
    onElement: "input_disabled",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --disabled}}")
        .setOnElement("input_disabled")
        .setLocator("Id")
```