## Description
Listens to element or elements ```exists``` state and perform action or actions when available. Use this method to dispose of unexpected banners which might block the user interface. The listener stops when ```OpenQA.Selenium.IWebDriver``` is disposed or after a given timeout. If no ```Actions``` provided, the listener will click the element once available.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation which implements the relevant actions.

## Properties
| Property             | Description                                                                      |
|----------------------|----------------------------------------------------------------------------------|
| _**argument**_       | Plugin conditions and additional information.                                    |
| _**onElement**_ | The locator value by which the element will be found.                            |
| _**locator**_        | The locator type by which the element will be found.                             |
| _**actions**_        | An array of actions which will be executed when the listener finds the elements. |

## Command Line Arguments (CLI)
### _interval_
The time to wait between each listener cycle.

> :warning: Short interval time, might slow down your automation.

| Value          | Description                                                                                               |
|----------------|-----------------------------------------------------------------------------------------------------------|
| _**number**_   | Integer value which represent the timeout in milliseconds.                                                |
| _**time**_     | A valid ```TimeSpan``` string which represent the interval time as a time component like, ```00:00:03```. |

### _timeout_
The time to wait before terminating the listener. This will not terminate the automation.

> :warning: If this time is shorter than your automation run time, the listener might stop before intended.

| Value          | Description                                                                                         |
|----------------|-----------------------------------------------------------------------------------------------------|
| _**number**_   | Integer value which represent the interval time in milliseconds.                                    |
| _**time**_     | A valid ```TimeSpan``` string which represent the timeout as a time component like, ```00:00:45```. |

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Every ```500 milliseconds```, the ```ElementsListener``` will search for ```//div[./strong[contains(.,\"Random Element.\")]]```. If exists, it will be clicked. This will apply for all the elements found by the given locator.

#### _Action Rule (JSON)_
```js
{
    "action": "ElementsListener",
    "argument": "500",
    "onElement": "//div[./strong[contains(.,\"Random Element.\")]]"
}
```

#### _Rhino Literal_
```
elements listener {500} on {//div[./strong[contains(.,\"Random Element.\")]]}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.ElementsListener,
    Argument = "500",
    OnElement = "//div[./strong[contains(.,\"Random Element.\")]]"
};
```

#### _Python_
```python
action_rule = {
    "action": "ElementsListener",
    "argument": "500",
    "onElement": "//div[./strong[contains(.,\"Random Element.\")]]"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "ElementsListener",
    argument: "500",
    onElement: "//div[./strong[contains(.,\"Random Element.\")]]"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("ElementsListener")
        .setArgument("500")
        .setOnElement("//div[./strong[contains(.,\"Random Element.\")]]");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Every ```500 milliseconds``` and for total time of ```30000 milliseconds```, the ```ElementsListener``` will search for ```//div[./strong[contains(.,\"Random Element.\")]]```. If exists, it will be clicked. This will apply for all the elements found by the given locator.

#### _Action Rule (JSON)_
```js
{
    "action": "ElementsListener",
    "argument": "{{$ --interval:500 --timeout:30000}}",
    "onElement": "//div[./strong[contains(.,\"Random Element.\")]]"
}
```

#### _Rhino Literal_
```
elements listener {{$ --interval:500 --timeout:30000}} on {//div[./strong[contains(.,\"Random Element.\")]]}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.ElementsListener,
    Argument = "{{$ --interval:500 --timeout:30000}}",
    OnElement = "//div[./strong[contains(.,\"Random Element.\")]]"
};
```

#### _Python_
```python
action_rule = {
    "action": "ElementsListener",
    "argument": "{{$ --interval:500 --timeout:30000}}",
    "onElement": "//div[./strong[contains(.,\"Random Element.\")]]"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "ElementsListener",
    argument: "{{$ --interval:500 --timeout:30000}}",
    onElement: "//div[./strong[contains(.,\"Random Element.\")]]"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("ElementsListener")
        .setArgument("{{$ --interval:500 --timeout:30000}}")
        .setOnElement("//div[./strong[contains(.,\"Random Element.\")]]");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Every ```1 second(s)``` and for total time of ```30 second(s)```, the ```ElementsListener``` will search for ```//div[./strong[contains(.,\"Random Element.\")]]```. If exists, ```Actions``` will be executed. This will apply for all the elements found by the given locator.

#### _Action Rule (JSON)_
```js
{
    "action": "ElementsListener",
    "argument": "{{$ --interval:00:00:01 --timeout:00:00:30}}",
    "onElement": "//div[./strong[contains(.,\"Random Element.\")]]",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "dismissed",
            "onElement": "input_enabled",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "//div[./strong[contains(.,\"Random Element.\")]]"
        }
    ]        
}
```

#### _Rhino Literal_
```
elements listener {{$ --interval:00:00:01 --timeout:00:00:30}} on {//div[./strong[contains(.,\"Random Element.\")]]}
    > type {dismissed} into {input_enabled} using {id}
    > click on {//div[./strong[contains(.,\"Random Element.\")]]}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.ElementsListener,
    Argument = "{{$ --interval:00:00:01 --timeout:00:00:30}}",
    OnElement = "//div[./strong[contains(.,\"Random Element.\")]]"
    actions: [
        {
            action: PluginsList.SendKeys,
            argument: "dismissed",
            onElement: "input_enabled",
            locator: LocatorsList.Id
        },
        {
            action: PluginsList.Click,
            onElement: "//div[./strong[contains(.,\"Random Element.\")]]"
        }
    ]      
};
```

#### _Python_
```python
action_rule = {
    "action": "ElementsListener",
    "argument": "{{$ --interval:00:00:01 --timeout:00:00:30}}",
    "onElement": "//div[./strong[contains(.,\"Random Element.\")]]",
    "actions": [
        {
            "action": "SendKeys",
            "argument": "dismissed",
            "onElement": "input_enabled",
            "locator": "Id"
        },
        {
            "action": "Click",
            "onElement": "//div[./strong[contains(.,\"Random Element.\")]]"
        }
    ]    
}
```

#### _Java Script_
```js
var actionRule = {
    action: "ElementsListener",
    argument: "{{$ --interval:00:00:01 --timeout:00:00:30}}",
    onElement: "//div[./strong[contains(.,\"Random Element.\")]]",
    actions: [
        {
            action: "SendKeys",
            argument: "dismissed",
            onElement: "input_enabled",
            locator: "Id"
        },
        {
            action: "Click",
            onElement: "//div[./strong[contains(.,\"Random Element.\")]]"
        }
    ]     
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("ElementsListener")
        .setArgument("{{$ --interval:00:00:01 --timeout:00:00:30}}")
        .setOnElement("//div[./strong[contains(.,\"Random Element.\")]]")
        .setActions(
            new ActionRule()
                    .setAction("SendKeys")
                    .setArgument("Carson")
                    .setOnElement("SearchString")
                    .setLocator("Id"),
            new ActionRule()
                    .setAction("Click")
                    .setOnElement("SearchButton"))
                    .setLocator("Id"));        
```