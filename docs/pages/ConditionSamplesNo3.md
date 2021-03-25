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

Executes nested actions if ```<input id="input_selected">``` element is ```selected```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --selected}}",
    "onElement": "input_selected",
    "locator": "Id"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --selected}} on {input_selected} using {id}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --selected}}",
    OnElement = "input_selected",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --selected}}",
    "onElement": "input_selected",
    "locator": "Id"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --selected}}",
    onElement: "input_selected",
    locator: "Id"
    actions: [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --selected}}")
        .setOnElement("input_selected")
        .setLocator("Id")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

## Examples: _stale_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```<div id="for_stale_element">``` element is ```stale```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --stale}}",
    "onElement": "for_stale_element",
    "locator": "Id"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --stale}} on {for_stale_element} using {id}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --stale}}",
    OnElement = "for_stale_element",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --stale}}",
    "onElement": "for_stale_element",
    "locator": "Id"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --stale}}",
    onElement: "for_stale_element",
    locator: "Id"
    actions: [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --stale}}")
        .setOnElement("for_stale_element")
        .setLocator("Id")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

## Examples: _text_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```//h2``` inner text _**equals**_ ```Students```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --text --eq:Students}}",
    "onElement": "//h2",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --text --eq:Students}} on {//h2}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --text --eq:Students}}",
    OnElement = "//h2",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --text --eq:Students}}",
    "onElement": "//h2",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --text --eq:Students}}",
    onElement: "//h2",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --text --eq:Students}}")
        .setOnElement("//h2")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```//h2``` inner text _**not equals**_ ```Not Students```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --text --ne:Not Students}}",
    "onElement": "//h2",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --text --ne:Not Students}} on {//h2}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --text --ne:Not Students}}",
    OnElement = "//h2",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --text --ne:Not Students}}",
    "onElement": "//h2",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --text --ne:Not Students}}",
    onElement: "//h2",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --text --ne:Not Students}}")
        .setOnElement("//h2")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```
***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```//h2``` inner text _**matches**_ ```^Students$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --text --match:^Students$}}",
    "onElement": "//h2",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --text --match:^Students$}} on {//h2}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --text --match:^Students$}}",
    OnElement = "//h2",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --text --match:^Students$}}",
    "onElement": "//h2",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --text --match:^Students$}}",
    onElement: "//h2",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --text --match:^Students$}}")
        .setOnElement("//h2")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```//h2``` inner text _**not matches**_ ```^Not Students$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --text --not_match:^Not Students$}}",
    "onElement": "//h2",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --text --not_match:^Not Students$}} on {//h2}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --text --not_match:^Not Students$}}",
    OnElement = "//h2",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --text --not_match:^Not Students$}}",
    "onElement": "//h2",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --text --not_match:^Not Students$}}",
    onElement: "//h2",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --text --not_match:^Not Students$}}")
        .setOnElement("//h2")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```number for testing``` inner text _**greater than**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --text --gt:1}}",
    "onElement": "number for testing",
    "locator": "Name",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --text --gt:1}} on {number for testing} using {name}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --text --gt:1}}",
    OnElement = "number for testing",
    Locator = LocatorsList.Name,
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --text --gt:1}}",
    "onElement": "number for testing",
    "locator": "Name",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --text --gt:1}}",
    onElement: "number for testing",
    locator: "Name",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --text --gt:1}}")
        .setOnElement("number for testing")
        .setLocator("Name")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```number for testing``` inner text _**lower than**_ ```1000```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --text --lt:1000}}",
    "onElement": "number for testing",
    "locator": "Name",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --text --lt:1000}} on {number for testing} using {name}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --text --lt:1000}}",
    OnElement = "number for testing",
    Locator = LocatorsList.Name,
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --text --lt:1000}}",
    "onElement": "number for testing",
    "locator": "Name",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --text --lt:1000}}",
    onElement: "number for testing",
    locator: "Name",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --text --lt:1000}}")
        .setOnElement("number for testing")
        .setLocator("Name")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```number for testing``` inner text _**greater or equal**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --text --ge:10}}",
    "onElement": "number for testing",
    "locator": "Name",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --text --ge:10}} on {number for testing} using {name}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --text --ge:10}}",
    OnElement = "number for testing",
    Locator = LocatorsList.Name,
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --text --ge:10}}",
    "onElement": "number for testing",
    "locator": "Name",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --text --ge:10}}",
    onElement: "number for testing",
    locator: "Name",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --text --ge:10}}")
        .setOnElement("number for testing")
        .setLocator("Name")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```number for testing``` inner text _**lower or equal**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --text --le:10}}",
    "onElement": "number for testing",
    "locator": "Name",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --text --le:10}} on {number for testing} using {name}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --text --le:10}}",
    OnElement = "number for testing",
    Locator = LocatorsList.Name,
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --text --le:10}}",
    "onElement": "number for testing",
    "locator": "Name",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --text --le:10}}",
    onElement: "number for testing",
    locator: "Name",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --text --le:10}}")
        .setOnElement("number for testing")
        .setLocator("Name")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

## Examples: _title_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Title``` _**equals**_ ```Students - Contoso University```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --title --eq:Students - Contoso University}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --title --eq:Students - Contoso University}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --title --eq:Students - Contoso University}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --title --eq:Students - Contoso University}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --title --eq:Students - Contoso University}}",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --title --eq:Students - Contoso University}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Title``` _**not equals**_ ```Contoso University - Students```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --title --ne:Contoso University - Students}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --title --ne:Contoso University - Students}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --title --ne:Contoso University - Students}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --title --ne:Contoso University - Students}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --title --ne:Contoso University - Students}}",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --title --ne:Contoso University - Students}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Title``` _**matches**_ ```^Students - Contoso University$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --title --match:^Students - Contoso University$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --title --match:^Students - Contoso University$}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --title --match:^Students - Contoso University$}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --title --match:^Students - Contoso University$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --title --match:^Students - Contoso University$}}",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --title --match:^Students - Contoso University$}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Title``` _**not match**_ ```^Contoso University - Students$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --title --not_match:^Contoso University - Students$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --title --not_match:^Contoso University - Students$}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --title --not_match:^Contoso University - Students$}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --title --not_match:^Contoso University - Students$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --title --not_match:^Contoso University - Students$}}",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --title --not_match:^Contoso University - Students$}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.Title``` is _**greater than**_ ```1``` filtered by ```\d+``` regular expression.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --title --gt:1}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --title --gt:1}} filter {\d+}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --title --gt:1}}",
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --title --gt:1}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --title --gt:1}}",
    regularExpression: "\\d+"
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --title --gt:1}}")
        .setRegularExpression("\\d+")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.Title``` is _**lower than**_ ```1000``` filtered by ```\d+``` regular expression.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --title --lt:1000}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --title --lt:1000}} filter {\d+}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --title --lt:1000}}",
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --title --lt:1000}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --title --lt:1000}}",
    regularExpression: "\\d+"
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --title --lt:1000}}")
        .setRegularExpression("\\d+")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.Title``` is _**greater or equal**_ ```10``` filtered by ```\d+``` regular expression.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --title --ge:10}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --title --ge:10}} filter {\d+}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --title --ge:10}}",
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --title --ge:10}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --title --ge:10}}",
    regularExpression: "\\d+"
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --title --ge:10}}")
        .setRegularExpression("\\d+")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.Title``` is _**lower or equal**_ ```10``` filtered by ```\d+``` regular expression.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --title --le:10}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --title --le:10}} filter {\d+}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --title --le:10}}",
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --title --le:10}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --title --le:10}}",
    regularExpression: "\\d+"
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --title --le:10}}")
        .setRegularExpression("\\d+")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

## Examples: _url_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Url``` _**equals**_ ```https://gravitymvctestapplication.azurewebsites.net/student/```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/student/}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/student/}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/student/}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/student/}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/student/}}",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/student/}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Url``` _**not equals**_ ```https://gravitymvctestapplication.azurewebsites.net/```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --url --ne:https://gravitymvctestapplication.azurewebsites.net/}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Url``` _**matches**_ ```student/$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --url --match:student/$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --url --match:student/$}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --url --match:student/$}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --url --match:student/$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --url --match:student/$}}",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --url --match:student/$}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Url``` _**not matche**_ ```^student/```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --url --not_match:^student/}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --url --not_match:^student/}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --url --not_match:^student/}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "SearchButton",
            Locator = LocatorsList.Id,
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --url --not_match:^student/}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "Carson",
            "onElement": "SearchString",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "SearchButton",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --url --not_match:^student/}}",
    actions: [
        {
            action: "SendKeys",
            argument: "Carson",
            onElement: "SearchString",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "SearchButton",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --url --not_match:^student/}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton")
                    .setLocator("Id"));
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Url``` filter by regular expression ```\d+``` is _**greater than**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --url --gt:1}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "Click",
            "onElement": "Back to List",
            "locator": "LinkText"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --url --gt:0}} filter {\d+}
    > click on {Back to List} using {link text}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --url --gt:1}}",
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "Back to List",
            Locator = LocatorsList.LinkText
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --url --gt:1}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "Click",
            "onElement": "Back to List",
            "locator": "LinkText"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --url --gt:1}}",
    regularExpression: "\\d+"
    actions: [
        {
            action: "Click",
            onElement: "Back to List",
            locator: "LinkText"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --url --gt:1}}")
        .setRegularExpression("\\d+")
        .setActions(
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("Back to List")
                    .setLocator("LinkText"));
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Url``` filter by regular expression ```\d+``` is _**lower than**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --url --le:10}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "Click",
            "onElement": "Back to List",
            "locator": "LinkText"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --url --le:10}} filter {\d+}
    > click on {Back to List} using {link text}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --url --le:10}}",
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "Back to List",
            Locator = LocatorsList.LinkText
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --url --le:10}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "Click",
            "onElement": "Back to List",
            "locator": "LinkText"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --url --le:10}}",
    regularExpression: "\\d+"
    actions: [
        {
            action: "Click",
            onElement: "Back to List",
            locator: "LinkText"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --url --le:10}}")
        .setRegularExpression("\\d+")
        .setActions(
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("Back to List")
                    .setLocator("LinkText"));
```

***

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Url``` filter by regular expression ```\d+``` is _**greater or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --url --ge:1}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "Click",
            "onElement": "Back to List",
            "locator": "LinkText"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --url --ge:1}} filter {\d+}
    > click on {Back to List} using {link text}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --url --ge:1}}",
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "Back to List",
            Locator = LocatorsList.LinkText
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --url --ge:1}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "Click",
            "onElement": "Back to List",
            "locator": "LinkText"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --url --ge:1}}",
    regularExpression: "\\d+"
    actions: [
        {
            action: "Click",
            onElement: "Back to List",
            locator: "LinkText"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --url --ge:1}}")
        .setRegularExpression("\\d+")
        .setActions(
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("Back to List")
                    .setLocator("LinkText"));
```

***

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.Url``` filter by regular expression ```\d+``` is _**lower or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --url --le:1}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "Click",
            "onElement": "Back to List",
            "locator": "LinkText"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --url --le:1}} filter {\d+}
    > click on {Back to List} using {link text}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --url --le:1}}",
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.Click,
            OnElement = "Back to List",
            Locator = LocatorsList.LinkText
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --url --le:1}}",
    "regularExpression": "\\d+"
    "actions": [
        {
            "action": "Click",
            "onElement": "Back to List",
            "locator": "LinkText"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --url --le:1}}",
    regularExpression: "\\d+"
    actions: [
        {
            action: "Click",
            onElement: "Back to List",
            locator: "LinkText"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --url --le:1}}")
        .setRegularExpression("\\d+")
        .setActions(
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("Back to List")
                    .setLocator("LinkText"));
```

## Examples: _visible_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```<input id="input_enabled">``` element is ```visible```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --visible}}",
    "onElement": "input_enabled",
    "locator": "Id",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --visible}} on {input_enabled} using {id}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --visible}}",
    OnElement = "input_enabled",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --visible}}",
    "onElement": "input_enabled",
    "locator": "Id",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --visible}}",
    onElement: "input_enabled",
    locator: "Id",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --visible}}")
        .setOnElement("input_enabled")
        .setLocator("Id")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

## Examples: _windows_count_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.WindowHandles``` count _**equals**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --windows_count --eq:1}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --windows_count --eq:1}}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --windows_count --eq:1}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --windows_count --eq:1}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --windows_count --eq:1}}",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --windows_count --eq:1}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.WindowHandles``` count _**not equals**_ ```0```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --windows_count --ne:0}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --windows_count --eq:1}}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --windows_count --ne:0}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --windows_count --ne:0}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --windows_count --ne:0}}",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --windows_count --ne:0}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.WindowHandles``` count _**matches**_ ```^1$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --windows_count --match:^1$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --windows_count --match:^1$}}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --windows_count --match:^1$}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --windows_count --match:^1$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --windows_count --match:^1$}}",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --windows_count --match:^1$}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.WindowHandles``` count _**not match**_ ```^0$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --windows_count --not_match:^0$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --windows_count --not_match:^0$}}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --windows_count --not_match:^0$}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --windows_count --not_match:^0$}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --windows_count --not_match:^0$}}",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --windows_count --not_match:^0$}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.WindowHandles``` count _**greater than**_ ```0```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --windows_count --gt:0}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --windows_count --gt:0}}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --windows_count --gt:0}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --windows_count --gt:0}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --windows_count --gt:0}}",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --windows_count --gt:0}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.WindowHandles``` count _**lower than**_ ```10```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --windows_count --lt:10}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --windows_count --lt:10}}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --windows_count --lt:10}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --windows_count --lt:10}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --windows_count --lt:10}}",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --windows_count --lt:10}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.WindowHandles``` count _**greater or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --windows_count --ge:1}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --windows_count --ge:1}}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --windows_count --ge:1}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --windows_count --ge:1}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --windows_count --ge:1}}",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --windows_count --ge:1}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```IWebDriver.WindowHandles``` count _**lower or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --windows_count --le:1}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Rhino Literal_
```
condition {{$ --windows_count --le:1}}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.Condition,
    Argument = "{{$ --windows_count --le:1}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = PluginsList.SendKeys,
            Argument = "20",
            OnElement = "number_of_alerts",
            Locator = LocatorsList.Id
        }
    }
};
```

#### _Python_
```python
action_rule = {
    "action": "Condition",
    "argument": "{{$ --windows_count --le:1}}",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "20",
            "onElement": "number_of_alerts",
            "locator": "Id"
        }
    ]
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Condition",
    argument: "{{$ --windows_count --le:1}}",
    actions: [
        {
            action: "SendKeys",
            argument: "20",
            onElement: "number_of_alerts",
            locator: "Id"
        }
    ]
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --windows_count --le:1}}")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```