## Description
Performs an explicit wait until the element conditions are met.

## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation which implements _**FindElement**_.

## Properties
| Property                | Description                                           |
|-------------------------|-------------------------------------------------------|
| _**argument**_          | The assertion condition, operator and expected value. |
| _**locator**_           | The locator type by which the element will be found.  |
| _**onAttribute**_       | The element attribute from which to extract information for action execution. If not specified, information will be taken from the element inner text. |
| _**onElement**_         | The locator value by which the element will be found. |
| _**regularExpression**_ | A pattern by which the extracted information will be evaluated. Returns the first match. |

## Command Line Arguments (CLI)
### _until_
The element state condition to wait for.

| Value           | Description                                                                                    |
|-----------------|------------------------------------------------------------------------------------------------|
| _**exists**_    | An expectation for checking that an element is present on the DOM of a page.                   |
| _**visible**_   | An expectation for checking that an element is present on the DOM of a page and is visible.    |
| _**stale**_     | An expectation for checking the element to be stale.                                           |
| _**enabled**_   | An expectation for checking an element is visible and enabled such that you can click it.      |
| _**attribute**_ | An expectation for checking WebElement with given locator has attribute with a specific value. |
| _**text**_      | An expectation for checking WebElement with given locator has specific text.                   |
| _**hidden**_    | An expectation for checking the element to be invisible.                                       |

### _timeout_
> Note
>
> If not provided, the default will be `ElementSearchTimeout` property.  

Timeout to wait before throwing `TimeoutException`. The value can be a TimeSpan (`hh:mm:ss`) or in millisecond (`3000`).  

## Aliases
_*None*_

## W3C Web Driver Protocol
* https://www.w3.org/TR/webdriver/#find-element



























































## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/uicontrols  

Suspends the current thread for ```3000ms``` (3s).

#### _Action Rule (JSON)_
```js
{
    "action": "Wait",
    "argument": "3000"
}
```

#### _Rhino Literal_
```
wait {3000}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Wait,
    Argument = "3000"
};
```

#### _Python_
```python
action_rule = {
    "action": "Wait",
    "argument": "3000"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Wait",
    argument: "3000"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Wait")
        .setArgument("3000");
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/UiControls  

Suspends the current thread for ```0h 5m 30s```.

#### _Action Rule (JSON)_
```js
{
    "action": "Wait",
    "argument": "00:05:30"
}
```

#### _Rhino Literal_
```
wait {00:05:30}
```

#### _CSharp_
```csharp
var actionRule = new ActionRule
{
    Action = GravityPlugins.Wait,
    Argument = "00:05:30"
};
```

#### _Python_
```python
action_rule = {
    "action": "Wait",
    "argument": "00:05:30"
}
```

#### _Java Script_
```js
var actionRule = {
    action: "Wait",
    argument: "00:05:30"
};
```

#### _Java_
```java
ActionRule actionRule = new ActionRule()
        .setAction("Wait")
        .setArgument("00:05:30");
```