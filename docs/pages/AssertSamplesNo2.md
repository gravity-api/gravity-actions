## Content
* [Examples: _**driver**_](#examples-driver)
* [Examples: _**enabled**_](#examples-enabled)
* [Examples: _**hidden**_](#examples-hidden)
* [Examples: _**not_exists**_](#examples-not_exists)
* [Examples: _**not_selected**_](#examples-not_selected)
* [Examples: _**parameter**_](#examples-parameter)

## Examples: _driver_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/

Assert that ```IWebDriver.FullName``` _**equals**_ ```OpenQA.Selenium.Remote.RemoteWebDriver```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}"
}
```

#### _Rhino Literal_
```
assert {{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "argument": "{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}");
```

***

### _Example no. 2_
Assert that ```IWebDriver.FullName``` _**not equals**_ ```OpenQA.Selenium.Chrome.ChromeDriver```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --driver --ne:OpenQA.Selenium.Chrome.ChromeDriver}}"
}
```

#### _Rhino Literal_
```
assert {{$ --driver --ne:OpenQA.Selenium.Chrome.ChromeDriver}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "argument": "{{$ --driver --ne:OpenQA.Selenium.Chrome.ChromeDriver}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --driver --ne:OpenQA.Selenium.Chrome.ChromeDriver}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --driver --ne:OpenQA.Selenium.Chrome.ChromeDriver}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --driver --ne:OpenQA.Selenium.Chrome.ChromeDriver}}");
```

***

### _Example no. 3_
Assert that ```IWebDriver.FullName``` _**match**_ ```RemoteWebDriver```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --driver --match:RemoteWebDriver}}"
}
```

#### _Rhino Literal_
```
assert {{$ --driver --match:RemoteWebDriver}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "argument": "{{$ --driver --match:RemoteWebDriver}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --driver --match:RemoteWebDriver}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --driver --match:RemoteWebDriver}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --driver --RemoteWebDriver}}")
```

***

### _Example no. 4_
Assert that ```IWebDriver.FullName``` _**not match**_ ```ChromeDriver```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --driver --not_match:ChromeDriver}}"
}
```

#### _Rhino Literal_
```
assert {{$ --driver --not_match:ChromeDriver}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "argument": "{{$ --driver --not_match:ChromeDriver}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --driver --not_match:ChromeDriver}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --driver --not_match:ChromeDriver}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --driver --not_match:ChromeDriver}}");
```

## Examples: _enabled_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```<input id="input_enabled">``` element is ```enabled```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --enabled}}",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
assert {{$ --enabled}} on {input_enabled} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "argument": "{{$ --enabled}}",
    OnElement = "input_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --enabled}}",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --enabled}}",
    onElement: "input_enabled",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --enabled}}")
        .setOnElement("input_enabled")
        .setLocator("Id");
```

## Examples: _exists_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```<input id="input_enabled">``` element is ```exists```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --exists}}",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
assert {{$ --exists}} on {input_enabled} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "argument": "{{$ --exists}}",
    OnElement = "input_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --exists}}",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --exists}}",
    onElement: "input_enabled",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --exists}}")
        .setOnElement("input_enabled")
        .setLocator("Id");
```

## Examples: _hidden_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```<input id="input_hidden">``` element is ```hidden```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --hidden}}",
    "onElement": "input_hidden",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
assert {{$ --hidden}} on {input_hidden} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "argument": "{{$ --hidden}}",
    OnElement = "input_hidden",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --hidden}}",
    "onElement": "input_hidden",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --hidden}}",
    onElement: "input_hidden",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --hidden}}")
        .setOnElement("input_hidden")
        .setLocator("Id");
```

## Examples: _not_exists_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```<input id="no_element">``` element is ```not exists```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --not_exists}}",
    "onElement": "no_element",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
assert {{$ --hidden}} on {{input_hidden}} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "argument": "{{$ --not_exists}}",
    OnElement = "no_element",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --not_exists}}",
    "onElement": "no_element",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --not_exists}}",
    onElement: "no_element",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --not_exists}}")
        .setOnElement("no_element")
        .setLocator("Id");
```

***

## Examples: _not_selected_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```<input id="input_not_selected">``` element is ```not selected```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --not_selected}}",
    "onElement": "input_not_selected",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
assert {{$ --hidden}} on {{input_hidden}} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "argument": "{{$ --not_selected}}",
    OnElement = "input_not_selected",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --not_selected}}",
    "onElement": "input_not_selected",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --not_selected}}",
    onElement: "input_not_selected",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --not_selected}}")
        .setOnElement("input_not_selected")
        .setLocator("Id");
```

## Examples: _parameter_

> The following examples assumes you have registerd a paramter with ```my_parameter``` as name and ```10``` as value. For more information, check [Register Parameter](https://github.com/gravity-api/gravity-actions/wiki/Plugin:-RegisterParameter) action.

### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/

Assert that ```my_parameter``` value _**equals**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --parameter --eq:10}}",
    "onElement": "my_parameter"
}
```

#### _Rhino Literal_
```
assert {{$ --parameter --eq:10}} on {my_parameter}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "{{$ --parameter --eq:10}}",
    OnElement = "my_parameter"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --parameter --eq:10}}",
    "onElement": "my_parameter"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --parameter --eq:10}}",
    onElement: "my_parameter"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --parameter --eq:10}}")
        .setOnElement("my_parameter");
```

***

### _Example no. 2_
Assert that ```my_parameter``` value _**not equals**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --parameter --ne:1}}",
    "onElement": "my_parameter"
}
```

#### _Rhino Literal_
```
assert {{$ --parameter --ne:1}} on {my_parameter}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "{{$ --parameter --ne:1}}",
    OnElement = "my_parameter"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --parameter --ne:1}}",
    "onElement": "my_parameter"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --parameter --ne:1}}",
    onElement: "my_parameter"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --parameter --ne:1}}")
        .setOnElement("my_parameter");
```

***

### _Example no. 3_
Assert that ```my_parameter``` value _**match**_ ```^10$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --parameter --match:^10$}}",
    "onElement": "my_parameter"
}
```

#### _Rhino Literal_
```
assert {{$ --parameter --match:^10$}} on {my_parameter}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "{{$ --parameter --match:^10$}}",
    OnElement = "my_parameter"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --parameter --match:^10$}}",
    "onElement": "my_parameter"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --parameter --match:^10$}}",
    onElement: "my_parameter"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --parameter --match:^10$}}")
        .setOnElement("my_parameter");
```

***

### _Example no. 4_
Assert that ```my_parameter``` value _**not match**_ ```^1$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --parameter --not_match:^1$}}",
    "onElement": "my_parameter"
}
```

#### _Rhino Literal_
```
assert {{$ --parameter --not_match:^1$}} on {my_parameter}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "{{$ --parameter --not_match:^1$}}",
    OnElement = "my_parameter"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --parameter --not_match:^1$}}",
    "onElement": "my_parameter"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --parameter --not_match:^1$}}",
    onElement: "my_parameter"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --parameter --not_match:^1$}}")
        .setOnElement("my_parameter");
```

***

### _Example no. 5_
Assert that ```my_parameter``` value is _**greater than**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --parameter --gt:1}}",
    "onElement": "my_parameter"
}
```

#### _Rhino Literal_
```
assert {{$ --parameter --gt:1}} on {my_parameter}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "{{$ --parameter --gt:1}}",
    OnElement = "my_parameter"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --parameter --gt:1}}",
    "onElement": "my_parameter"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --parameter --gt:1}}",
    onElement: "my_parameter"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --parameter --gt:1}}")
        .setOnElement("my_parameter");
```

***

### _Example no. 6_
Assert that ```my_parameter``` value is _**lower than**_ ```11```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --parameter --lt:11}}",
    "onElement": "my_parameter"
}
```

#### _Rhino Literal_
```
assert {{$ --parameter --lt:11}} on {my_parameter}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "{{$ --parameter --lt:11}}",
    OnElement = "my_parameter"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --parameter --lt:11}}",
    "onElement": "my_parameter"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --parameter --lt:11}}",
    onElement: "my_parameter"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --parameter --lt:11}}")
        .setOnElement("my_parameter");
```

***

### _Example no. 7_
Assert that ```my_parameter``` value is _**greater or equal**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --parameter --ge:10}}",
    "onElement": "my_parameter"
}
```

#### _Rhino Literal_
```
assert {{$ --parameter --ge:10}} on {my_parameter}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "{{$ --parameter --ge:10}}",
    OnElement = "my_parameter"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --parameter --ge:10}}",
    "onElement": "my_parameter"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --parameter --ge:10}}",
    onElement: "my_parameter"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --parameter --ge:10}}")
        .setOnElement("my_parameter");
```

***

### _Example no. 8_
Assert that ```my_parameter``` value is _**lower or equal**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --parameter --le:10}}",
    "onElement": "my_parameter"
}
```

#### _Rhino Literal_
```
assert {{$ --parameter --le:1}} on {my_parameter}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Assert,
    Argument = "{{$ --parameter --le:10}}",
    OnElement = "my_parameter"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --parameter --le:10}}",
    "onElement": "my_parameter"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --parameter --le:10}}",
    onElement: "my_parameter"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --parameter --le:10}}")
        .setOnElement("my_parameter");
```