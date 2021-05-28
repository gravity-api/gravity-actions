## Content
* [Examples: _**attribute**_](#examples-attribute)
* [Examples: _**count**_](#examples-count)
* [Examples: _**disabled**_](#examples-disabled)

## Examples: _attribute_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```class``` attribute of an element _**equals**_ ```btn btn-default```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --attribute --eq:btn btn-default}}",
    "onElement": "SearchButton",
    "onAttribute": "class",
    "locator": "Id"
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
condition {{$ --attribute --eq:btn btn-default}} on {SearchButton} from {class} using {id}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --attribute --eq:btn btn-default}}",
    OnElement = "SearchButton",
    OnAttribute = "class",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --attribute --eq:btn btn-default}}",
    "onElement": "SearchButton",
    "onAttribute": "class",
    "locator": "Id"
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
    argument: "{{$ --attribute --eq:btn btn-default}}",
    onElement: "SearchButton",
    onAttribute: "class",
    locator: "Id"
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
        .setArgument("{{$ --attribute --eq:btn btn-default}}")
        .setOnElement("SearchButton")
        .setOnAttribute("class")
        .setLocator("Id")
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

Executes nested actions if ```class``` attribute of an element _**not equals**_ ```btn-default btn```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --attribute --ne:btn-default btn}}",
    "onElement": "SearchButton",
    "onAttribute": "class",
    "locator": "Id"
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
condition {{$ --attribute --ne:btn-default btn}} on {SearchButton} from {class} using {id}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --attribute --ne:btn-default btn}}",
    OnElement = "SearchButton",
    OnAttribute = "class",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --attribute --ne:btn-default btn}}",
    "onElement": "SearchButton",
    "onAttribute": "class",
    "locator": "Id"
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
    argument: "{{$ --attribute --ne:btn-default btn}}",
    onElement: "SearchButton",
    onAttribute: "class",
    locator: "Id"
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
        .setArgument("{{$ --attribute --ne:btn-default btn}}")
        .setOnElement("SearchButton")
        .setOnAttribute("class")
        .setLocator("Id")
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

Executes nested actions if ```class``` attribute of an element _**match**_ ```^btn btn-default$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --attribute --match:^btn btn-default$}}",
    "onElement": "SearchButton",
    "onAttribute": "class",
    "locator": "Id"
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
condition {{$ --attribute --match:^btn btn-default$}} on {SearchButton} from {class} using {id}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --attribute --match:^btn btn-default$}}",
    OnElement = "SearchButton",
    OnAttribute = "class",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --attribute --match:^btn btn-default$}}",
    "onElement": "SearchButton",
    "onAttribute": "class",
    "locator": "Id"
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
    argument: "{{$ --attribute --match:^btn btn-default$}}",
    onElement: "SearchButton",
    onAttribute: "class",
    locator: "Id"
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
        .setArgument("{{$ --attribute --match:^btn btn-default$}}")
        .setOnElement("SearchButton")
        .setOnAttribute("class")
        .setLocator("Id")
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

Executes nested actions if ```class``` attribute of an element _**not match**_ ```^btn-default btn$```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --attribute --not_match:^btn-default btn$}}",
    "onElement": "SearchButton",
    "onAttribute": "class",
    "locator": "Id"
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
condition {{$ --attribute --not_match:^btn-default btn$}} on {SearchButton} from {class} using {id}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --attribute --not_match:^btn-default btn$}}",
    OnElement = "SearchButton",
    OnAttribute = "class",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --attribute --not_match:^btn-default btn$}}",
    "onElement": "SearchButton",
    "onAttribute": "class",
    "locator": "Id"
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
    argument: "{{$ --attribute --not_match:^btn-default btn$}}",
    onElement: "SearchButton",
    onAttribute: "class",
    locator: "Id"
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
        .setArgument("{{$ --attribute --not_match:^btn-default btn$}}")
        .setOnElement("SearchButton")
        .setOnAttribute("class")
        .setLocator("Id")
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

Executes nested actions if ```href``` attribute of an element filtered by ```\d+``` regular expression _**greater than**_ ```0```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --attribute --gt:0}}",
    "onElement": "Edit",
    "onAttribute": "href",
    "locator": "LinkText",
    "regularExpression": "\\d+"
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
condition {{$ --attribute --gt:0}} on {Edit} from {href} using {link text} filter {\d+}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --attribute --gt:0}}",
    OnElement = "Edit",
    OnAttribute = "href",
    Locator = LocatorsList.LinkText,
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --attribute --gt:0}}",
    "onElement": "Edit",
    "onAttribute": "href",
    "locator": "LinkText",
    "regularExpression": "\\d+"
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
    argument: "{{$ --attribute --gt:0}}",
    onElement: "Edit",
    onAttribute: "href",
    locator: "LinkText",
    regularExpression: "\\d+"
    actions: [
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
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --attribute --gt:0}}")
        .setOnElement("Edit")
        .setOnAttribute("href")
        .setLocator("LinkText")
        .setRegularExpression("\\d+")
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

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```href``` attribute of an element filtered by ```\d+``` regular expression _**lower than**_ ```1000```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --attribute --lt:1000}}",
    "onElement": "Edit",
    "onAttribute": "href",
    "locator": "LinkText",
    "regularExpression": "\\d+"
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
condition {{$ --attribute --lt:1000}} on {Edit} from {href} using {link text} filter {\d+}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --attribute --lt:1000}}",
    OnElement = "Edit",
    OnAttribute = "href",
    Locator = LocatorsList.LinkText,
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --attribute --lt:1000}}",
    "onElement": "Edit",
    "onAttribute": "href",
    "locator": "LinkText",
    "regularExpression": "\\d+"
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
    argument: "{{$ --attribute --lt:1000}}",
    onElement: "Edit",
    onAttribute: "href",
    locator: "LinkText",
    regularExpression: "\\d+"
    actions: [
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
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --attribute --lt:1000}}")
        .setOnElement("Edit")
        .setOnAttribute("href")
        .setLocator("LinkText")
        .setRegularExpression("\\d+")
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

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```href``` attribute of an element filtered by ```\d+``` regular expression _**greater or equal**_ ```0```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --attribute --ge:0}}",
    "onElement": "Edit",
    "onAttribute": "href",
    "locator": "LinkText",
    "regularExpression": "\\d+"
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
condition {{$ --attribute --ge:0}} on {Edit} from {href} using {link text} filter {\d+}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --attribute --ge:0}}",
    OnElement = "Edit",
    OnAttribute = "href",
    Locator = LocatorsList.LinkText,
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --attribute --ge:0}}",
    "onElement": "Edit",
    "onAttribute": "href",
    "locator": "LinkText",
    "regularExpression": "\\d+"
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
    argument: "{{$ --attribute --ge:0}}",
    onElement: "Edit",
    onAttribute: "href",
    locator: "LinkText",
    regularExpression: "\\d+"
    actions: [
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
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --attribute --ge:0}}")
        .setOnElement("Edit")
        .setOnAttribute("href")
        .setLocator("LinkText")
        .setRegularExpression("\\d+")
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

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```href``` attribute of an element filtered by ```\d+``` regular expression _**lower or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --attribute --le:1}}",
    "onElement": "Edit",
    "onAttribute": "href",
    "locator": "LinkText",
    "regularExpression": "\\d+"
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
condition {{$ --attribute --le:1}} on {Edit} from {href} using {link text} filter {\d+}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --attribute --le:1}}",
    OnElement = "Edit",
    OnAttribute = "href",
    Locator = LocatorsList.LinkText,
    RegularExpression = "\\d+",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --attribute --le:1}}",
    "onElement": "Edit",
    "onAttribute": "href",
    "locator": "LinkText",
    "regularExpression": "\\d+"
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
    argument: "{{$ --attribute --le:1}}",
    onElement: "Edit",
    onAttribute: "href",
    locator: "LinkText",
    regularExpression: "\\d+"
    actions: [
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
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Condition")
        .setArgument("{{$ --attribute --le:1}}")
        .setOnElement("Edit")
        .setOnAttribute("href")
        .setLocator("LinkText")
        .setRegularExpression("\\d+")
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

## Examples: _count_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```//tr[./td[@id]]``` elements count _**equals**_ ```3```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --count --eq:3}}",
    "onElement": "//tr[./td[@id]]",
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
condition {{$ --count --eq:3}} on {//tr[./td[@id]]}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --count --eq:3}}",
    OnElement = "//tr[./td[@id]]",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --count --eq:3}}",
    "onElement": "//tr[./td[@id]]",
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
    argument: "{{$ --count --eq:3}}",
    onElement: "//tr[./td[@id]]",
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
        .setArgument("{{$ --count --eq:3}}")
        .setOnElement("//tr[./td[@id]]")
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

Executes nested actions if ```//tr[./td[@id]]``` elements count _**not equals**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --count --ne:1}}",
    "onElement": "//tr[./td[@id]]",
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
condition {{$ --count --ne:1}} on {//tr[./td[@id]]}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --count --ne:1}}",
    OnElement = "//tr[./td[@id]]",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --count --ne:1}}",
    "onElement": "//tr[./td[@id]]",
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
    argument: "{{$ --count --ne:1}}",
    onElement: "//tr[./td[@id]]",
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
        .setArgument("{{$ --count --ne:1}}")
        .setOnElement("//tr[./td[@id]]")
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

Executes nested actions if ```//tr[./td[@id]]``` elements count _**match**_ ```\d{1}```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --count --match:\\d{1}}}",
    "onElement": "//tr[./td[@id]]",
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
condition {{$ --count --match:\d{1}}} on {//tr[./td[@id]]}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --count --match:\\d{1}}}",
    OnElement = "//tr[./td[@id]]",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --count --match:\\d{1}}}",
    "onElement": "//tr[./td[@id]]",
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
    argument: "{{$ --count --match:\\d{1}}}",
    onElement: "//tr[./td[@id]]",
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
        .setArgument("{{$ --count --match:\\d{1}}}")
        .setOnElement("//tr[./td[@id]]")
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

Executes nested actions if ```//tr[./td[@id]]``` elements count _**not match**_ ```\d{2}```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --count --not_match:\\d{2}}}",
    "onElement": "//tr[./td[@id]]",
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
condition {{$ --count --not_match:\d{2}}} on {//tr[./td[@id]]}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --count --not_match:\\d{2}}}",
    OnElement = "//tr[./td[@id]]",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --count --not_match:\\d{2}}}",
    "onElement": "//tr[./td[@id]]",
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
    argument: "{{$ --count --not_match:\\d{2}}}",
    onElement: "//tr[./td[@id]]",
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
        .setArgument("{{$ --count --not_match:\\d{2}}}")
        .setOnElement("//tr[./td[@id]]")
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

Executes nested actions if ```//tr[./td[@id]]``` elements count _**greater than**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --count --gt:1}}",
    "onElement": "//tr[./td[@id]]",
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
condition {{$ --count --gt:1}} on {//tr[./td[@id]]}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --count --gt:1}}",
    OnElement = "//tr[./td[@id]]",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --count --gt:1}}",
    "onElement": "//tr[./td[@id]]",
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
    argument: "{{$ --count --gt:1}}",
    onElement: "//tr[./td[@id]]",
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
        .setArgument("{{$ --count --gt:1}}")
        .setOnElement("//tr[./td[@id]]")
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

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```//tr[./td[@id]]``` elements count _**lower than**_ ```1000```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --count --lt:1000}}",
    "onElement": "//tr[./td[@id]]",
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
condition {{$ --count --lt:1000}} on {//tr[./td[@id]]}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --count --lt:1000}}",
    OnElement = "//tr[./td[@id]]",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --count --lt:1000}}",
    "onElement": "//tr[./td[@id]]",
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
    argument: "{{$ --count --lt:1000}}",
    onElement: "//tr[./td[@id]]",
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
        .setArgument("{{$ --count --lt:1000}}")
        .setOnElement("//tr[./td[@id]]")
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

### _Example no. 7_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```//tr[./td[@id]]``` elements count _**greater or equal**_ ```1```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --count --ge:1}}",
    "onElement": "//tr[./td[@id]]",
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
condition {{$ --count --ge:1}} on {//tr[./td[@id]]}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --count --ge:1}}",
    OnElement = "//tr[./td[@id]]",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --count --ge:1}}",
    "onElement": "//tr[./td[@id]]",
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
    argument: "{{$ --count --ge:1}}",
    onElement: "//tr[./td[@id]]",
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
        .setArgument("{{$ --count --ge:1}}")
        .setOnElement("//tr[./td[@id]]")
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

### _Example no. 8_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/student

Executes nested actions if ```//tr[./td[@id]]``` elements count _**lower or equal**_ ```1000```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --count --le:1000}}",
    "onElement": "//tr[./td[@id]]",
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
condition {{$ --count --le:1000}} on {//tr[./td[@id]]}
    > type {Carson} into {SearchString} using {id}
    > click on {SearchButton} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "{{$ --count --le:1000}}",
    OnElement = "//tr[./td[@id]]",
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
            Argument = "Carson",
            OnElement = "SearchString",
            Locator = LocatorsList.Id,
        },
        new ActionRule
        {
            Action = GravityPlugins.Click,
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
    "argument": "{{$ --count --le:1000}}",
    "onElement": "//tr[./td[@id]]",
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
    argument: "{{$ --count --le:1000}}",
    onElement: "//tr[./td[@id]]",
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
        .setArgument("{{$ --count --le:1000}}")
        .setOnElement("//tr[./td[@id]]")
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

## Examples: _disabled_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes nested actions if ```<input id="input_disabled">``` element is ```disabled```.

#### _Action Rule (JSON)_
```js
{
    "action": "Condition",
    "argument": "{{$ --disabled}}",
    "onElement": "input_disabled",
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
condition {{$ --disabled}} on {input_disabled} using {id}
    > type {20} into {number_of_alerts} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Condition,
    Argument = "argument": "{{$ --disabled}}",
    OnElement = "input_disabled",
    Locator = LocatorsList.Id,
    Actions = new[]
    {
        new ActionRule
        {
            Action = GravityPlugins.SendKeys,
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
    "argument": "{{$ --disabled}}",
    "onElement": "input_disabled",
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
    argument: "{{$ --disabled}}",
    onElement: "input_disabled",
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
        .setArgument("{{$ --disabled}}")
        .setOnElement("input_disabled")
        .setLocator("Id")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("20")
                    .setOnElement("number_of_alerts")
                    .setLocator("Id"));
```