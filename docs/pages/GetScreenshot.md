## Description
Gets an ```OpenQA.Selenium.Screenshot``` object representing the image of the page on and saves the screenshot to a file, overwriting the file if it already exists.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation which implements _**Screenshot**_.

## Properties
| Property             | Description                                                                                                     |
|----------------------|-----------------------------------------------------------------------------------------------------------------|
| _**argument**_       | The full path and file name to save the screenshot to. Support formats ```[\"BMP\",\"GIF\",\"JPEG\",\"TIFF\",\"PNG\"]```. |
| _**onElement**_      | The locator value by which the element will be found.                                                           |
| _**locator**_        | The locator type by which the element will be found.                                                            |

## Command Line Arguments (CLI)
_**None**_

## W3C Web Driver Protocol
[https://www.w3.org/TR/webdriver/#actions](https://www.w3.org/TR/webdriver/#actions)

## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Saves a web driver screenshot as ```page.png``` (you can use different format, see below) to the given path (whole page - not including address bar).

#### _Action Rule (JSON)_
```js
{
    "action": "GetScreenshot",
    "argument": "GetScreenshot/image.png"
}
```

#### _Rhino Literal_
```
get screenshot {GetScreenshot/image.png}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.GetScreenshot,
    Argument = "GetScreenshot/image.png"
};

// option no.2
var actionRule = new
{
    Action = "GetScreenshot",
    Argument = "GetScreenshot/image.png"
};
```

#### _Python_
```python
action_rule = {
    "action": "GetScreenshot",
    "argument": "GetScreenshot/image.png"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "GetScreenshot",
    argument: "GetScreenshot/image.png"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("GetScreenshot")
        .setArgument("GetScreenshot/image.png");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls

Saves a web element screenshot as ```element.png``` to the given path (you can use different format, see below).

#### _Action Rule (JSON)_
```js
{
    "action": "GetScreenshot",
    "argument": "GetScreenshot/image.png",
    "onElement": "//div[@class=\"jumbotron\"]"
}
```

#### _Rhino Literal_
```
get screenshot {GetScreenshot/image.png} on {//div[@class=\"jumbotron\"]}
```

#### _CSharp_
```csharp
// option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.GetScreenshot,
    Argument = "GetScreenshot/image.png",
    OnElement = "//div[@class=\"jumbotron\"]"
};

// option no.2
var actionRule = new
{
    Action = "GetScreenshot",
    Argument = "GetScreenshot/image.png",
    OnElement = "//div[@class=\"jumbotron\"]"
};
```

#### _Python_
```python
action_rule = {
    "action": "GetScreenshot",
    "argument": "GetScreenshot/image.png",
    "onElement": "//div[@class=\"jumbotron\"]"
}
```

#### _Java Script_
```js
var actionRule = {
    "action": "GetScreenshot",
    "argument": "GetScreenshot/image.png",
    "onElement": "//div[@class=\"jumbotron\"]"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("GetScreenshot")
        .setArgument("GetScreenshot/image.png")
        .setOnElement("//div[@class=\"jumbotron\"]");
```