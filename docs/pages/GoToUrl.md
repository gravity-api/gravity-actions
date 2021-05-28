## Description
Load a new web page in the current browser window. This is done using an ```HTTP GET``` operation and the method will block until the load is complete. This action supports locators, elements, attributes, macros and regular expressions.

## Scope
**Web**, **Mobile Web**

## Properties
| Property                | Description                                           |
|-------------------------|-------------------------------------------------------|
| _**argument**_          | Plugin conditions and additional information.         |
| _**onAttribute**_       | The element attribute from which to extract information for action execution. If not specified, information will be taken from the element inner text.|
| _**onElement**_         | The locator value by which the element will be found. |
| _**locator**_           | The locator type by which the element will be found.  |
| _**regularExpression**_ |A pattern by which the extracted information will be evaluated. Returns the first match.|

## Command Line Arguments (CLI)
### _blank_
Opens the URL address using ```_blank``` property (under new tab or window).

### _url_
The ```URL``` address to navigate to.
> If the action ```argument``` is the ```URL``` to navigate to, this argument is not mandatory (see examples).

## Aliases
The following keywords can be used instead of ```send keys```
1. open
2. navigate to
3. go to

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#navigate-to](https://www.w3.org/TR/webdriver/#navigate-to)

## Examples
### _Example no. 1_
Navigate to ```https://gravitymvctestapplication.azurewebsites.net/uicontrols/```.

#### _Action Rule (JSON)_
```js
{
    "action": "GoToUrl",
    "argument": "https://gravitymvctestapplication.azurewebsites.net/uicontrols/"
}
```

#### _Rhino Literal_
```
go to url {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}

// aliases (alternatives)
open {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
go to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.GoToUrl,
    Argument = "https://gravitymvctestapplication.azurewebsites.net/uicontrols/"
};

// option no.2
var actionRule = new
{
    Action = "GoToUrl",
    Argument = "https://gravitymvctestapplication.azurewebsites.net/uicontrols/"
};
```

#### _Python_
```python
action_rule = {
    "action": "GoToUrl",
    "argument": "https://gravitymvctestapplication.azurewebsites.net/uicontrols/"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "GoToUrl",
    argument: "https://gravitymvctestapplication.azurewebsites.net/uicontrols/"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("GoToUrl")
        .setArgument("https://gravitymvctestapplication.azurewebsites.net/uicontrols/");
```

***

### _Example no. 2_
Navigate to ```https://gravitymvctestapplication.azurewebsites.net/uicontrols/``` using ```_blank``` operation (new tab or window).

#### _Action Rule (JSON)_
```js
{
    "action": "GoToUrl",
    "argument": "{{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}"
}
```

#### _Rhino Literal_
```
go to url {{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}

// aliases (alternatives)
open {{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}
navigate to {{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}
go to {{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.GoToUrl,
    Argument = "{{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}"
};

// option no.2
var actionRule = new
{
    Action = "GoToUrl",
    Argument = "{{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}"
};
```

#### _Python_
```python
action_rule = {
    "action": "GoToUrl",
    "argument": "{{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "GoToUrl",
    argument: "{{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("GoToUrl")
        .setArgument("{{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}");
```

***

### _Example no. 3_
Gets the ```text``` content of the element found by the given locator and pass it as ```URL``` to the current browser.

#### _Action Rule (JSON)_
```js
{
    "action": "GoToUrl",
    "onElement": "url_div",
    "locator": "id"
}
```

#### _Rhino Literal_
```
go to url on {url_div} using {id}

// aliases (alternatives)
open on {url_div} using {id}
navigate to on {url_div} using {id}
go to on {url_div} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.GoToUrl,
    OnElement = "url_div",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "GoToUrl",
    OnElement = "url_div",
    Locator = "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "GoToUrl",
    "onElement": "url_div",
    "locator": "id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "GoToUrl",
    onElement: "url_div",
    locator: "id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("GoToUrl")
        .setOnElement("url_div")
        .setLocator("Id");
```

***

### _Example no. 4_
Gets the ```text``` content of the element found by the given locator and pass it as ```URL``` to a new browser tab or window.

#### _Action Rule (JSON)_
```js
{
    "action": "GoToUrl",
    "argument": "{{$ --blank}}",
    "onElement": "url_div",
    "locator": "id"
}
```

#### _Rhino Literal_
```
go to url {{$ --blank}} on {url_div} using {id}

// aliases (alternatives)
open {{$ --blank}} on {url_div} using {id}
navigate to {{$ --blank}} on {url_div} using {id}
go to {{$ --blank}} on {url_div} using {id}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.GoToUrl,
    Argument = "{{$ --blank}}",
    OnElement: "url_div",
    Locator: LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "GoToUrl",
    Argument = "{{$ --blank}}",
    OnElement: "url_div",
    Locator: "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "GoToUrl",
    "argument": "{{$ --blank}}",
    "onElement": "url_div",
    "locator": "id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "GoToUrl",
    argument: "{{$ --blank}}",
    onElement: "url_div",
    locator: "id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("GoToUrl")
        .setArgument("{{$ --blank}}")
        .setOnElement("url_div")
        .setLocator("Id");
```

***

### _Example no. 5_
Gets the ```href``` attribute value of the element found by the given locator and pass it as ```URL``` to the current browser.

#### _Action Rule (JSON)_
```js
{
    "action": "GoToUrl",
    "onElement": "url_div",
    "onAttribute": "href",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
go to url on {url_div} using {id} from {href}

// aliases (alternatives)
open on {url_div} using {id} from {href}
navigate to on {url_div} using {id} from {href}
go to on {url_div} using {id} from {href}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.GoToUrl,
    OnElement = "url_div",
    OnAttribute = "href",
    Locator = LocatorsList.Id
};

// option no.2
var actionRule = new
{
    Action = "GoToUrl",
    OnElement = "url_div",
    OnAttribute = "href",
    Locator = "Id"
};
```

#### _Python_
```python
action_rule = {
    "action": "GoToUrl",
    "onElement": "url_div",
    "onAttribute": "href",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "GoToUrl",
    onElement: "url_div",
    onAttribute: "href",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("GoToUrl")
        .setOnElement("url_div")
        .setOnAttribute("href")
        .setLocator("Id");
```

***

### _Example no. 6_
Gets the first match from the element ```href``` attribute value, found by the given locator, filtered by the given pattern and pass it as ```URL``` to the current browser.

#### _Action Rule (JSON)_
```js
{
    "action": "GoToUrl",
    "onElement": "url_div_text",
    "onAttribute": "href",
    "locator": "Id",
    "regularExpression": "http.*$"
}
```

#### _Rhino Literal_
```
go to url on {url_div_text} using {id} filter {http.*$}

// aliases (alternatives)
open on {url_div_text} using {id} filter {http.*$}
navigate to {url_div_text} using {id} filter {http.*$}
go to on {url_div_text} using {id} filter {http.*$}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugins.GoToUrl,
    OnElement: "url_div_text",
    OnAttribute: "href",
    Locator: "LocatorsList.Id",
    RegularExpression: "http.*$"
};

// option no.2
var actionRule = new
{
    Action = "GoToUrl",
    OnElement: "url_div_text",
    OnAttribute: "href",
    Locator: "Id",
    RegularExpression: "http.*$"
};
```

#### _Python_
```python
action_rule = {
    "action": "GoToUrl",
    "onElement": "url_div_text",
    "onAttribute": "href",
    "locator": "Id",
    "regularExpression": "http.*$"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "GoToUrl",
    onElement: "url_div_text",
    onAttribute: "href",
    locator: "Id",
    regularExpression: "http.*$"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("GoToUrl")
        .setOnElement("url_div_text")
        .setOnAttribute("href")
        .setLocator("Id")
        .setRegularExpression("http.*$");
```