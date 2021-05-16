## Content
* [Examples: _**driver**_](#examples-driver)
* [Examples: _**enabled**_](#examples-enabled)
* [Examples: _**hidden**_](#examples-hidden)
* [Examples: _**not_exists**_](#examples-not_exists)
* [Examples: _**not_selected**_](#examples-not_selected)

## Examples: _driver_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```IWebDriver.FullName``` _**equals**_ ```OpenQA.Selenium.Remote.RemoteWebDriver```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}",
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
condition {{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Condition,
    Argument = "{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugin.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugin.Click,
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
    "argument": "{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}",
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
    argument: "{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}",
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
        .setArgument("{{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}}")
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

Executes nested actions if ```IWebDriver.FullName``` _**not equals**_ ```not_a_driver```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --driver --ne:not_a_driver}}",
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
condition {{$ --driver --ne:not_a_driver}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Condition,
    Argument = "{{$ --driver --ne:not_a_driver}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugin.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugin.Click,
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
    "argument": "{{$ --driver --ne:not_a_driver}}",
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
    argument: "{{$ --driver --ne:not_a_driver}}",
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
        .setArgument("{{$ --driver --ne:not_a_driver}}")
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

Executes nested actions if ```IWebDriver.FullName``` _**match**_ ```RemoteWebDriver```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --driver --match:RemoteWebDriver}}",
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
condition {{$ --driver --match:RemoteWebDriver}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Condition,
    Argument = "{{$ --driver --match:RemoteWebDriver}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugin.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugin.Click,
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
    "argument": "{{$ --driver --match:RemoteWebDriver}}",
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
    argument: "{{$ --driver --match:RemoteWebDriver}}",
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
        .setArgument("{{$ --driver --match:RemoteWebDriver}}")
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

Executes nested actions if ```IWebDriver.FullName``` _**not match**_ ```not_a_driver```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --driver --not_match:not_a_driver}}",
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
condition {{$ --driver --not_match:not_a_driver}}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Condition,
    Argument = "{{$ --driver --not_match:not_a_driver}}",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugin.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugin.Click,
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
    "argument": "{{$ --driver --not_match:not_a_driver}}",
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
    argument: "{{$ --driver --not_match:not_a_driver}}",
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
        .setArgument("{{$ --driver --not_match:not_a_driver}}")
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

## Examples: _enabled_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```<input id="input_enabled">``` element is ```enabled```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --enabled}}",
    "onElement": "input_enabled",
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
condition {{$ --enabled}} on {input_enabled} using {id}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Condition,
    Argument = "argument": "{{$ --enabled}}",
    OnElement = "input_enabled",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugin.SendKeys,
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
    "argument": "{{$ --enabled}}",
    "onElement": "input_enabled",
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
    argument: "{{$ --enabled}}",
    onElement: "input_enabled",
    locator: "Id"
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
        .setArgument("{{$ --enabled}}")
        .setOnElement("input_enabled")
        .setLocator("Id")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

## Examples: _exists_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```<input id="input_hidden">``` element is ```exists```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --exists}}",
    "onElement": "input_hidden",
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
condition {{$ --exists}} on {input_hidden} using {id}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Condition,
    Argument = "argument": "{{$ --exists}}",
    OnElement = "input_hidden",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugin.SendKeys,
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
    "argument": "{{$ --exists}}",
    "onElement": "input_hidden",
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
    argument: "{{$ --exists}}",
    onElement: "input_hidden",
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
        .setArgument("{{$ --exists}}")
        .setOnElement("input_hidden")
        .setLocator("Id")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

## Examples: _hidden_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```<input id="input_hidden">``` element is ```hidden```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --hidden}}",
    "onElement": "input_hidden",
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
condition {{$ --hidden}} on {input_hidden} using {id}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Condition,
    Argument = "argument": "{{$ --hidden}}",
    OnElement = "input_hidden",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugin.SendKeys,
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
    "argument": "{{$ --hidden}}",
    "onElement": "input_hidden",
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
    argument: "{{$ --hidden}}",
    onElement: "input_hidden",
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
        .setArgument("{{$ --hidden}}")
        .setOnElement("input_hidden")
        .setLocator("Id")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

## Examples: _not_exists_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```<input id="no_element">``` element is ```not exists```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --not_exists}}",
    "onElement": "no_element",
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
condition {{$ --not_exists}} on {no_element} using {id}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Condition,
    Argument = "argument": "{{$ --not_exists}}",
    OnElement = "no_element",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugin.SendKeys,
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
    "argument": "{{$ --not_exists}}",
    "onElement": "no_element",
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
    argument: "{{$ --not_exists}}",
    onElement: "no_element",
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
        .setArgument("{{$ --not_exists}}")
        .setOnElement("no_element")
        .setLocator("Id")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```

***

## Examples: _not_selected_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```<input id="input_not_selected">``` element is ```not selected```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --not_selected}}",
    "onElement": "input_not_selected",
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
condition {{$ --not_selected}} on {input_not_selected} using {id}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugin.Condition,
    Argument = "argument": "{{$ --not_selected}}",
    OnElement = "input_not_selected",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugin.SendKeys,
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
    "argument": "{{$ --not_selected}}",
    "onElement": "input_not_selected",
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
    argument: "{{$ --not_selected}}",
    onElement: "input_not_selected",
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
        .setArgument("{{$ --not_selected}}")
        .setOnElement("input_not_selected")
        .setLocator("Id")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```