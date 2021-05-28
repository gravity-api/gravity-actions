## Content
* [Examples: _**selected**_](#examples-selected)
* [Examples: _**stale**_](#examples-stale)
* [Examples: _**text**_](#examples-text)
* [Examples: _**title**_](#examples-title)
* [Examples: _**url**_](#examples-url)
* [Examples: _**visible**_](#examples-visible)
* [Examples: _**windows_count**_](#examples-windows_count)


## Examples: _selected_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```<input id="input_selected">``` element is ```selected```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --selected}}",
    "onElement": "input_selected",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
assert {{$ --selected}} on {input_selected} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --selected}}",
    OnElement = "input_selected",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --selected}}",
    "onElement": "input_selected",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --selected}}",
    onElement: "input_selected",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --selected}}")
        .setOnElement("input_selected")
        .setLocator("Id");
```

## Examples: _stale_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```<div id="for_stale_element">``` element is ```stale```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --stale}}",
    "onElement": "for_stale_element",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
assert {{$ --selected}} on {input_selected} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --stale}}",
    OnElement = "for_stale_element",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --stale}}",
    "onElement": "for_stale_element",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --stale}}",
    onElement: "for_stale_element",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --stale}}")
        .setOnElement("for_stale_element")
        .setLocator("Id");
```

## Examples: _text_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```text for testing``` inner text _**equals**_ ```Foo Bar```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --text --eq:Foo Bar}}",
    "onElement": "text for testing",
    "locator": "Name"
}
```

#### _Rhino Literal_
```
assert {{$ --text --eq:Foo Bar}} on {text for testing} using {name}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --text --eq:Foo Bar}}",
    OnElement = "text for testing",
    Locator = LocatorsList.Name
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --text --eq:Foo Bar}}",
    "onElement": "text for testing",
    "locator": "Name"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --text --eq:Foo Bar}}",
    onElement: "text for testing",
    locator: "Name"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --text --eq:Foo Bar}}")
        .setOnElement("text for testing")
        .setLocator("Name")
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```text for testing``` inner text _**not equals**_ ```Bar Foo```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --text --ne:Bar Foo}}",
    "onElement": "text for testing",
    "locator": "Name"
}
```

#### _Rhino Literal_
```
assert {{$ --text --ne:Bar Foo}} on {text for testing} using {name}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --text --ne:Bar Foo}}",
    OnElement = "text for testing",
    Locator = LocatorsList.Name
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --text --ne:Bar Foo}}",
    "onElement": "text for testing",
    "locator": "Name"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --text --ne:Bar Foo}}",
    onElement: "text for testing",
    locator: "Name"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --text --ne:Bar Foo}}")
        .setOnElement("text for testing")
        .setLocator("Name")
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```text for testing``` inner text _**matches**_ ```^Foo Bar$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --text --match:^Foo Bar$}}",
    "onElement": "text for testing",
    "locator": "Name"
}
```

#### _Rhino Literal_
```
assert {{$ --text --match:^Foo Bar$}} on {text for testing} using {name}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --text --match:^Foo Bar$}}",
    OnElement = "text for testing",
    Locator = LocatorsList.Name
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --text --match:^Foo Bar$}}",
    "onElement": "text for testing",
    "locator": "Name"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --text --match:^Foo Bar$}}",
    onElement: "text for testing",
    locator: "Name"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --text --match:^Foo Bar$}}")
        .setOnElement("text for testing")
        .setLocator("Name")
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```text for testing``` inner text _**not match**_ ```^Bar Foo$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --text --not_match:^Bar Foo$}}",
    "onElement": "text for testing",
    "locator": "Name"
}
```

#### _Rhino Literal_
```
assert {{$ --text --not_match:^Bar Foo$}} on {text for testing} using {name}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --text --not_match:^Bar Foo$}}",
    OnElement = "text for testing",
    Locator = LocatorsList.Name
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --text --not_match:^Bar Foo$}}",
    "onElement": "text for testing",
    "locator": "Name"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --text --not_match:^Bar Foo$}}",
    onElement: "text for testing",
    locator: "Name"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --text --not_match:^Bar Foo$}}")
        .setOnElement("text for testing")
        .setLocator("Name")
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```number for testing``` inner text is _**greater than**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --text --gt:1}}",
    "onElement": "number for testing",
    "locator": "Name"
}
```

#### _Rhino Literal_
```
assert {{$ --text --gt:1}} on {number for testing} using {name}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --text --gt:1}}",
    OnElement = "number for testing",
    Locator = LocatorsList.Name
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --text --gt:1}}",
    "onElement": "number for testing",
    "locator": "Name"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --text --gt:1}}",
    onElement: "number for testing",
    locator: "Name"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --text --gt:1}}")
        .setOnElement("number for testing")
        .setLocator("Name");
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```number for testing``` inner text is _**lower than**_ ```100```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --text --lt:100}}",
    "onElement": "number for testing",
    "locator": "Name"
}
```

#### _Rhino Literal_
```
assert {{$ --text --lt:100}} on {number for testing} using {name}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --text --lt:100}}",
    OnElement = "number for testing",
    Locator = LocatorsList.Name
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --text --lt:100}}",
    "onElement": "number for testing",
    "locator": "Name"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --text --lt:100}}",
    onElement: "number for testing",
    locator: "Name"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --text --lt:100}}")
        .setOnElement("number for testing")
        .setLocator("Name");
```

***

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```number for testing``` inner text is _**greater or equal**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --text --ge:10}}",
    "onElement": "number for testing",
    "locator": "Name"
}
```

#### _Rhino Literal_
```
assert {{$ --text --ge:10}} on {number for testing} using {name}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --text --ge:10}}",
    OnElement = "number for testing",
    Locator = LocatorsList.Name
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --text --ge:10}}",
    "onElement": "number for testing",
    "locator": "Name"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --text --ge:10}}",
    onElement: "number for testing",
    locator: "Name"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --text --ge:10}}")
        .setOnElement("number for testing")
        .setLocator("Name");
```

***

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Assert that ```number for testing``` inner text is _**lower or equal**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --text --le:10}}",
    "onElement": "number for testing",
    "locator": "Name"
}
```

#### _Rhino Literal_
```
assert {{$ --text --ge:10}} on {number for testing} using {name}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --text --le:10}}",
    OnElement = "number for testing",
    Locator = LocatorsList.Name
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --text --le:10}}",
    "onElement": "number for testing",
    "locator": "Name"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --text --le:10}}",
    onElement: "number for testing",
    locator: "Name"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --text --le:10}}")
        .setOnElement("number for testing")
        .setLocator("Name");
```

## Examples: _title_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.Title``` _**equals**_ ```UI Controls v10 - Contoso University```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --title --eq:UI Controls v10 - Contoso University}}"
}
```

#### _Rhino Literal_
```
assert {{$ --title --eq:UI Controls v10 - Contoso University}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --title --eq:UI Controls v10 - Contoso University}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --title --eq:UI Controls v10 - Contoso University}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --title --eq:UI Controls v10 - Contoso University}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --title --eq:UI Controls v10 - Contoso University}}");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.Title``` _**not equals**_ ```Contoso University - UI Controls v10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --title --ne:Contoso University - UI Controls v10}}"
}
```

#### _Rhino Literal_
```
assert {{$ --title --ne:Contoso University - UI Controls v10}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --title --ne:Contoso University - UI Controls v10}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --title --ne:Contoso University - UI Controls v10}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --title --ne:Contoso University - UI Controls v10}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --title --ne:Contoso University - UI Controls v10}}");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.Title``` _**matches**_ ```^UI Controls```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --title --match:^UI Controls}}"
}
```

#### _Rhino Literal_
```
assert {{$ --title --match:^UI Controls}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --title --match:^UI Controls}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --title --match:^UI Controls}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --title --match:^UI Controls}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --title --match:^UI Controls}}");
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.Title``` _**not match**_ ```UI Controls v10$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --title --not_match:UI Controls v10$}}"
}
```

#### _Rhino Literal_
```
assert {{$ --title --not_match:UI Controls v10$}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --title --not_match:UI Controls v10$}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --title --not_match:UI Controls v10$}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --title --not_match:UI Controls v10$}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --title --not_match:UI Controls v10$}}");
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.Title``` filtered by ```\d+``` regular expression, is _**greater than**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --title --gt:1}}",
    "regularExpression": "\\d+"
}
```

#### _Rhino Literal_
```
assert {{$ --title --gt:1}} filter {\d+}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --title --gt:1}}",
    RegularExpression = "\\d+"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --title --gt:1}}",
    "regularExpression": "\\d+"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --title --gt:1}}",
    regularExpression: "\\d+"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --title --gt:1}}")
        .setRegularExpression("\\d+");
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.Title``` filtered by ```\d+``` regular expression, is _**lower than**_ ```100```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --title --lt:100}}",
    "regularExpression": "\\d+"
}
```

#### _Rhino Literal_
```
assert {{$ --title --gt:100}} filter {\d+}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --title --lt:100}}",
    RegularExpression = "\\d+"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --title --lt:100}}",
    "regularExpression": "\\d+"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --title --lt:100}}",
    regularExpression: "\\d+"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --title --lt:100}}")
        .setRegularExpression("\\d+");
```

***

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.Title``` filtered by ```\d+``` regular expression, is _**greater or equal**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --title --ge:10}}",
    "regularExpression": "\\d+"
}
```

#### _Rhino Literal_
```
assert {{$ --title --ge:10}} filter {\d+}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --title --ge:10}}",
    RegularExpression = "\\d+"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --title --ge:10}}",
    "regularExpression": "\\d+"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --title --ge:10}}",
    regularExpression: "\\d+"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --title --ge:10}}")
        .setRegularExpression("\\d+");
```

***

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.Title``` filtered by ```\d+``` regular expression, is _**lower or equal**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --title --le:10}}",
    "regularExpression": "\\d+"
}
```

#### _Rhino Literal_
```
assert {{$ --title --ge:10}} filter {\d+}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --title --le:10}}",
    RegularExpression = "\\d+"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --title --le:10}}",
    "regularExpression": "\\d+"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --title --le:10}}",
    regularExpression: "\\d+"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --title --le:10}}")
        .setRegularExpression("\\d+");
```

## Examples: _url_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/course/

Assert that ```IWebDriver.Url``` _**equals**_ ```https://gravitymvctestapplication.azurewebsites.net/course/```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/course/}}"
}
```

#### _Rhino Literal_
```
assert {{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/course/}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/course/}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/course/}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/course/}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/course/}}");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/course/

Assert that ```IWebDriver.Url``` _**not equals**_ ```https://gravitymvctestapplication.azurewebsites.net/```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}"
}
```

#### _Rhino Literal_
```
assert {{$ --title --ne:https://gravitymvctestapplication.azurewebsites.net/}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/course/

Assert that ```IWebDriver.Url``` _**matches**_ ```course/$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --url --match:course/$}}"
}
```

#### _Rhino Literal_
```
assert {{$ --url --match:course/$}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --url --match:course/$}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --url --match:course/$}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --url --match:course/$}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --url --match:course/$}}");
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/course/

Assert that ```IWebDriver.Url``` _**not match**_ ```^course/```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --url --not_match:^course/}}"
}
```

#### _Rhino Literal_
```
assert {{$ --title --not_match:^course/}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --url --not_match:^course/}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --url --not_match:^course/}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --url --not_match:^course/}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --url --not_match:^course/}}");
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/course/edit/1045

Assert that ```IWebDriver.Url``` filtered by ```\d+``` regular expression, is _**greater than**_ ```1000```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --url --gt:1000}}",
    "regularExpression": "\\d+"
}
```

#### _Rhino Literal_
```
assert {{$ --title --gt:1000}} filter {\\d+}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --url --gt:1000}}",
    RegularExpression = "\\d+"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --url --gt:1000}}",
    "regularExpression": "\\d+"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --url --gt:1000}}",
    regularExpression: "\\d+"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --url --gt:1000}}")
        .setRegularExpression("\\d+");
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/course/edit/1045

Assert that ```IWebDriver.Url``` filtered by ```\d+``` regular expression, is _**lower than**_ ```2000```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --url --lt:2000}}",
    "regularExpression": "\\d+"
}
```

#### _Rhino Literal_
```
assert {{$ --url --lt:2000}} filter {\d+}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --url --lt:2000}}",
    RegularExpression = "\\d+"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --url --lt:2000}}",
    "regularExpression": "\\d+"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --url --lt:2000}}",
    regularExpression: "\\d+"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --url --lt:2000}}")
        .setRegularExpression("\\d+");
```

***

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/course/edit/1045

Assert that ```IWebDriver.Url``` filtered by ```\d+``` regular expression, is _**greater or equal**_ ```1045```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --url --ge:1045}}",
    "regularExpression": "\\d+"
}
```

#### _Rhino Literal_
```
assert {{$ --url --ge:1045}} filter {\d+}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --url --ge:1045}}",
    RegularExpression = "\\d+"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --url --ge:1045}}",
    "regularExpression": "\\d+"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --url --ge:1045}}",
    regularExpression: "\\d+"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --url --ge:1045}}")
        .setRegularExpression("\\d+");
```

***

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/course/edit/1045

Assert that ```IWebDriver.Url``` filtered by ```\d+``` regular expression, is _**lower or equal**_ ```1045```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --url --le:1045}}",
    "regularExpression": "\\d+"
}
```

#### _Rhino Literal_
```
assert {{$ --url --le:1045}} filter {\d+}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --url --le:1045}}",
    RegularExpression = "\\d+"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --url --le:1045}}",
    "regularExpression": "\\d+"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --url --le:1045}}",
    regularExpression: "\\d+"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --url --le:1045}}")
        .setRegularExpression("\\d+");
```

## Examples: _visible_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```<input id="input_enabled">``` element is ```visible```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --visible}}",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
assert {{$ --visible}} on {input_enabled} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --visible}}",
    OnElement = "input_enabled",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --visible}}",
    "onElement": "input_enabled",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --visible}}",
    onElement: "input_enabled",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --visible}}")
        .setOnElement("input_enabled")
        .setLocator("Id");
```

## Examples: _windows_count_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.WindowHandles``` count _**equals**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --windows_count --eq:1}}"
}
```

#### _Rhino Literal_
```
assert {{$ --windows_count --eq:1}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --windows_count --eq:1}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --windows_count --eq:1}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --windows_count --eq:1}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --windows_count --eq:1}}");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.WindowHandles``` count _**not equals**_ ```0```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --windows_count --ne:0}}"
}
```

#### _Rhino Literal_
```
assert {{$ --windows_count --ne:0}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --windows_count --ne:0}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --windows_count --ne:0}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --windows_count --ne:0}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --windows_count --ne:0}}");
```

***

### _Example no. 3_
Assert that ```IWebDriver.WindowHandles``` count _**matches**_ ```\d{1}```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --windows_count --match:\\d{1}}}"
}
```

#### _Rhino Literal_
```
assert {{$ --windows_count --match:\d{1}}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --windows_count --match:\\d{1}}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --windows_count --match:\\d{1}}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --windows_count --match:\\d{1}}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --windows_count --match:\\d{1}}}");
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.WindowHandles``` count _**not match**_ ```1\d+```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --windows_count --not_match:1\\d+}}"
}
```

#### _Rhino Literal_
```
assert {{$ --windows_count --not_match:1\d+}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --windows_count --not_match:1\\d+}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --windows_count --not_match:1\\d+}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --windows_count --not_match:1\\d+}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --windows_count --not_match:1\\d+}}");
```

***

### _Example no. 5_
Assert that ```IWebDriver.WindowHandles``` count is _**greater than**_ ```0```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --windows_count --gt:0}}"
}
```

#### _Rhino Literal_
```assert {{$ --windows_count --gt:0}}```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --windows_count --gt:0}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --windows_count --gt:0}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --windows_count --gt:0}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --windows_count --gt:0}}");
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.WindowHandles``` count is _**lower than**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --windows_count --lt:10}}"
}
```

#### _Rhino Literal_
```
assert {{$ --windows_count --lt:10}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --windows_count --lt:10}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --windows_count --lt:10}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --windows_count --lt:10}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --windows_count --lt:10}}");
```

***

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.WindowHandles``` count is _**greater or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --windows_count --ge:1}}"
}
```

#### _Rhino Literal_
```
assert {{$ --windows_count --ge:1}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --windows_count --ge:1}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --windows_count --ge:1}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --windows_count --ge:1}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --windows_count --ge:1}}");
```

***

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols

Assert that ```IWebDriver.WindowHandles``` count is _**lower or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Assert",
    "argument": "{{$ --windows_count --le:1}}"
}
```

#### _Rhino Literal_
```
assert {{$ --windows_count --le:1}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Assert,
    Argument = "{{$ --windows_count --le:1}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "Assert",
    "argument": "{{$ --windows_count --le:1}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Assert",
    argument: "{{$ --windows_count --le:1}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Assert")
        .setArgument("{{$ --windows_count --le:1}}");
```