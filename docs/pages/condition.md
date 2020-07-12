## Description
Allows a sub set of actions execution, based on a given condition. The sub set actions will be executed if the condition result is ```true```.


## Scope
**Web**, **Mobile Web**, **Mobile Native** or any other Web Driver implementation.


## Properties

| Property                      | Description                                           |
|-------------------------------|-------------------------------------------------------|
| _**actions**_                 | The sub set actions to execute when condition is met. |
| _**argument**_                | Plugin conditions and additional information.         |
| _**onAttribute**_ | The element attribute from which to extract information for action execution. If not specified, information will be taken from the element inner text.|                       |
| _**onElement**_          | The locator value by which the element will be found. |
| _**locator**_                 | The locator type by which the element will be found.  |
| _**regularExpression**_       |A pattern by which the extracted information will be evaluated. Returns the first match.|


## Command Line Arguments (CLI)
### _attribute_

Return ```true``` if the ```ActionRule.OnAttribute``` value meets a condition. The text based conditions are case sensitive.

| Value           | Description                                                                                         |
|-----------------|-----------------------------------------------------------------------------------------------------|
| _**eq**_        | The attribute value and the provided value (expected) are equal.                                    |
| _**ne**_        | The attribute value and the provided value (expected) are not equal.                                |
| _**match**_     | The attribute value matches to ```ActionRule.RegularExpression``` property.                       |
| _**not_match**_ | The attribute value does not match to ```ActionRule.RegularExpression``` property.                |
| _**gt**_        | Applies for numbers only: The attribute value is greater than provided value (expected).            |
| _**lt**_        | Applies for numbers only: The attribute value is lower than provided value (expected).              |
| _**ge**_        | Applies for numbers only: The attribute value is greater or equal to the provided value (expected). |
| _**le**_        | Applies for numbers only: The attribute value is lower or equal to the provided value (expected).   |

### _count_

Return ```true``` if the ```ActionRule.OnElement``` count (total elements found by the locator) meets a condition. The text based conditions are case sensitive.

| Value           | Description                                                                                      |
|-----------------|--------------------------------------------------------------------------------------------------|
| _**eq**_        | The actual count and the provided value (expected) are equal.                                    |
| _**ne**_        | The actual count and the provided value (expected) are not equal.                                |
| _**match**_     | The actual count matches to ```ActionRule.RegularExpression``` property.                       |
| _**not_match**_ | The actual count does not match to ```ActionRule.RegularExpression``` property.                |
| _**gt**_        | Applies for numbers only: The actual count is greater than provided value (expected).            |
| _**lt**_        | Applies for numbers only: The actual count is lower than provided value (expected).              |
| _**ge**_        | Applies for numbers only: The actual count is greater or equal to the provided value (expected). |
| _**le**_        | Applies for numbers only: The actual count is lower or equal to the provided value (expected).   |

### _disabled_

Return ```true``` if the element exists in the DOM and it is not enabled.

### _driver_

Return ```true``` if the ```IWebDriver.FullName``` value meets a condition. The text based conditions are case sensitive.

| Value           | Description                                                                                                |
|-----------------|------------------------------------------------------------------------------------------------------------|
| _**eq**_        | The driver full name value and the provided value (expected) are equal.                                    |
| _**ne**_        | The driver full name value and the provided value (expected) are not equal.                                |
| _**match**_     | The driver full name value matches to ```ActionRule.RegularExpression``` property.                       |
| _**not_match**_ | The driver full name value does not match to ```ActionRule.RegularExpression``` property.                |
| _**gt**_        | Applies for numbers only: The driver full name value is greater than provided value (expected).            |
| _**lt**_        | Applies for numbers only: The driver full name value is lower than provided value (expected).              |
| _**ge**_        | Applies for numbers only: The driver full name value is greater or equal to the provided value (expected). |
| _**le**_        | Applies for numbers only: The driver full name value is lower or equal to the provided value (expected).   |

### _enabled_

Return ```true``` if the element exists in the DOM and it is enabled.

### _exists_

Return ```true``` if the element exists in the DOM.

### _hidden_

Return ```true``` if the element exists in the DOM and it is not visible.

### _not_exists_

Return ```true``` if the element does not exists in the DOM.

### _selected_

Return ```true``` if the element exists in the DOM and it is selected.

### _stale_

Return ```true``` if the element is stale (element reference out dated or broken).

### _text_

Return ```true``` if the ```ActionRule.OnElement``` inner text meets a condition. The text based conditions are case sensitive.

| Value           | Description                                                                                    |
|-----------------|------------------------------------------------------------------------------------------------|
| _**eq**_        | The text value and the provided value (expected) are equal.                                    |
| _**ne**_        | The text value and the provided value (expected) are not equal.                                |
| _**match**_     | The text value matches to ```ActionRule.RegularExpression``` property.                       |
| _**not_match**_ | The text value does not match to ```ActionRule.RegularExpression``` property.                |
| _**gt**_        | Applies for numbers only: The text value is greater than provided value (expected).            |
| _**lt**_        | Applies for numbers only: The text value is lower than provided value (expected).              |
| _**ge**_        | Applies for numbers only: The text value is greater or equal to the provided value (expected). |
| _**le**_        | Applies for numbers only: The text value is lower or equal to the provided value (expected).   |

### _title_

Return ```true``` if the ```IWebDriver.Title``` value meets a condition. The text based conditions are case sensitive.

| Value           | Description                                                                               |
|-----------------|-------------------------------------------------------------------------------------------|
| _**eq**_        | The title and the provided value (expected) are equal.                                    |
| _**ne**_        | The title and the provided value (expected) are not equal.                                |
| _**match**_     | The title matches to ```ActionRule.RegularExpression``` property.                       |
| _**not_match**_ | The title does not match to ```ActionRule.RegularExpression``` property.                |
| _**gt**_        | Applies for numbers only: The title is greater than provided value (expected).            |
| _**lt**_        | Applies for numbers only: The title is lower than provided value (expected).              |
| _**ge**_        | Applies for numbers only: The title is greater or equal to the provided value (expected). |
| _**le**_        | Applies for numbers only: The title is lower or equal to the provided value (expected).   |

### _url_

Return ```true``` if the ```IWebDriver.Url``` value meets a condition. The text based conditions are case sensitive.

| Value           | Description                                                                             |
|-----------------|-----------------------------------------------------------------------------------------|
| _**eq**_        | The URL and the provided value (expected) are equal.                                    |
| _**ne**_        | The URL and the provided value (expected) are not equal.                                |
| _**match**_     | The URL matches to ```ActionRule.RegularExpression``` property.                       |
| _**not_match**_ | The URL does not match to ```ActionRule.RegularExpression``` property.                |
| _**gt**_        | Applies for numbers only: The URL is greater than provided value (expected).            |
| _**lt**_        | Applies for numbers only: The URL is lower than provided value (expected).              |
| _**ge**_        | Applies for numbers only: The URL is greater or equal to the provided value (expected). |
| _**le**_        | Applies for numbers only: The URL is lower or equal to the provided value (expected).   |

### _visible_

Return ```true``` if the element is stale (element reference out dated or broken).

### _windows_count_

Return ```true``` if the ```IWebDriver.WindowHandles``` count (total open tabs/windows) meets a condition. The text based conditions are case sensitive.

| Value           | Description                                                                                      |
|-----------------|--------------------------------------------------------------------------------------------------|
| _**eq**_        | The actual count and the provided value (expected) are equal.                                    |
| _**ne**_        | The actual count and the provided value (expected) are not equal.                                |
| _**match**_     | The actual count matches to ```ActionRule.RegularExpression``` property.                       |
| _**not_match**_ | The actual count does not match to ```ActionRule.RegularExpression``` property.                |
| _**gt**_        | Applies for numbers only: The actual count is greater than provided value (expected).            |
| _**lt**_        | Applies for numbers only: The actual count is lower than provided value (expected).              |
| _**ge**_        | Applies for numbers only: The actual count is greater or equal to the provided value (expected). |
| _**le**_        | Applies for numbers only: The actual count is lower or equal to the provided value (expected).   |


## W3C Web Driver Protocol
_**None**_