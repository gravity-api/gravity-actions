## Description
Executes JavaScript in the context of the currently selected frame or window.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation which implements _**Execute Script**_.

> **Mobile Native** support is limited by Appium capabilities and implemnetaions. 

## Properties
| Property             | Description                                                                      |
|----------------------|----------------------------------------------------------------------------------|
| _**argument**_       | Plugin conditions and additional information.                                    |
| _**onElement**_ | The locator value by which the element will be found.                            |
| _**locator**_        | The locator type by which the element will be found.                             |

## Command Line Arguments (CLI)
### _args_
Object array to pass into this script.

| Value          | Description                             |
|----------------|-----------------------------------------|
| _**array**_    | An array of **JSON Formatted** objects. |

### _src_
The JavaScript code to execute.

| Value          | Description                |
|----------------|----------------------------|
| _**string**_   | A valid JavaScript script. |

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#execute-script](https://www.w3.org/TR/webdriver/#execute-script)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes script to change an element value, from ```document``` level.

#### _Action Rule (JSON)_
```js
{
    "action": "ExecuteScript",
    "argument": "{document.getElementById(\"input_enabled\").setAttribute(\"value\", \"foo bar\")}"
}
```

#### _Rhino Literal_
```
execute script {document.getElementById(\"input_enabled\").setAttribute(\"value\", \"foo bar\")}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.ExecuteScript,
    Argument = "{document.getElementById(\"input_enabled\").setAttribute(\"value\", \"foo bar\")}"
};
```

#### _Python_
```python
action_rule = {
    "action": "ExecuteScript",
    "argument": "{document.getElementById(\"input_enabled\").setAttribute(\"value\", \"foo bar\")}"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "ExecuteScript",
    argument: "{document.getElementById(\"input_enabled\").setAttribute(\"value\", \"foo bar\")}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("ExecuteScript")
        .setArgument("{document.getElementById(\"input_enabled\").setAttribute(\"value\", \"foo bar\")}");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes script to click on an element from ```Action Rule``` level.

#### _Action Rule (JSON)_
```js
{
    "action": "ExecuteScript",
    "argument": "{arguments[0].click();}",
    "onElement": "click_button",
    "locator": "Id"
}
```

#### _Rhino Literal_
```
execute script {arguments[0].click();} on {click_button} using {id}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.ExecuteScript,
    Argument = "{arguments[0].click();}",
    OnElement = "click_button",
    Locator = LocatorsList.Id
};
```

#### _Python_
```python
action_rule = {
    "action": "ExecuteScript",
    "argument": "{arguments[0].click();}",
    "onElement": "click_button",
    "locator": "Id"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "ExecuteScript",
    argument: "{arguments[0].click();}",
    onElement: "click_button",
    locator: "Id"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("ExecuteScript")
        .setArgument("{arguments[0].click();}")
        .setOnElement("click_button")
        .setLocator("Id");
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Executes script to scroll the page document, from ```document``` level with additional arguments.

#### _Action Rule (JSON)_
```js
{
    "action": "ExecuteScript",
    "argument": "{{$ --src:window.scrollTo(arguments[0], arguments[1]); --args:[0, 100]}}"    
}
```

#### _Rhino Literal_
```
execute script {{$ --src:window.scrollTo(arguments[0], arguments[1]); --args:[0, 100]}}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = PluginsList.ExecuteScript,
    Argument = "{{$ --src:window.scrollTo(arguments[0], arguments[1]); --args:[0, 100]}}",  
};
```

#### _Python_
```python
action_rule = {
    "action": "ExecuteScript",
    "argument": "{{$ --src:window.scrollTo(arguments[0], arguments[1]); --args:[0, 100]}}"   
}
```

#### _Java Script_
```js
var actionRule = {
    action: "ExecuteScript",
    argument: "{{$ --src:window.scrollTo(arguments[0], arguments[1]); --args:[0, 100]}}"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("ExecuteScript")
        .setArgument("{{$ --src:window.scrollTo(arguments[0], arguments[1]); --args:[0, 100]}}");
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Check the element under extraction. This action applies on current element when using ```ExtractionRules```. This action assumes the element already found and will inject it into the script. For an instance, instead of ```document.findElementById(\"id\").checked=true;``` you will provide only the part of the script after the ```\".\" - .checked=true;``` because the element which is now under extraction was already found and will be injected into your code.

#### _Action Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"   
}

// extraction rule
{
    "onRootElement": "//input[@id=\"input_selected\"]",
    "onElements": [
        {
            "key": "inner_text",
            "actions": [
                {
                    "action": "ExecuteScript",
                    "argument": ".checked=false;"
                }
            ]
        }
    ]
}
```

#### _Rhino Literal_
```
extract from page on {//input[@id=\"input_selected\"]}
    < column {inner_text}
        > execute script {.checked=false;}
```

#### _CSharp_
```csharp
// action rule
var actionRule = new ActionRule
{
    Action = PluginsList.ExtractFromDom
};

// extraction rule
var extraction = new ExtractionRule
{
    OnRootElement = "//input[@id=\"input_selected\"]",
    OnElements = new[]
    {
        new ContentEntry
        {
            Key = "inner_text",
            Actions = new[]
            {
                new ActionRule
                {
                    Action = PluginsList.ExecuteScript,
                    Argument = ".checked=false;"
                }
            }
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromDom"  
}

# extraction rule
extraction_rule = {
    "onRootElement": "//input[@id=\"input_selected\"]",
    "onElements": [
        {
            "key": "inner_text",
            "actions": [
                {
                    "action": "ExecuteScript",
                    "argument": ".checked=false;"                    
                }
            ]
        }
    ]    
}
```

#### _Java Script_
```js
// action rule
actionRule = {
    action: "ExtractFromDom"  
}

// extraction rule
extractionRule = {
    onRootElement: "//input[@id=\"input_selected\"]",
    onElements: [
        {
            key: "inner_text",
            actions: [
                {
                    action: "ExecuteScript",
                    argument: ".checked=false;"
                }
            ]
        }
    ]    
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromDom");

// extraction rule
ActionRule actionRule = new ActionRule()
        .setAction("ExecuteScript")
        .setArgument(".checked=false;");

ContentEntry contentEntry = new ContentEntry().setKey("inner_text").setActions(actionRule);

ExtractionRule extractionRule = new ExtractionRule()
        .setRooElementToExtractFrom("//input[@id=\"input_selected\"]")
        .setOnElements(contentEntry);
```