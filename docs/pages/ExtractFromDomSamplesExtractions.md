## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column.

#### _Action Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        {
            "key": "FirstName"
        }
    ]
}
```

#### _Rhino Literal_
```
extract from dom on {//td[contains(@id,'student_first_name')]}
    < column {FirstName}
```

#### _CSharp_
```csharp
// action rule
var actionRule = new ActionRule
{
    Action = PluginsList.ExtractFromDom
};

// extraction rule
var contentEntries = new[]
{
    new ContentEntry { Key = "FirstName" }
};
var extraction = new ExtractionRule
{
    OnRootElements = "//td[contains(@id,'student_first_name')]",
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromDom"
}

# extraction rule
content_entries = [
    {
        "key": "FirstName"
    }
]
extraction = {
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromDom"
}

// extraction rule
var contentEntries = [
    {
        key: "FirstName"
    }
]
var extraction = {
    onRootElements: "//td[contains(@id,'student_first_name')]",
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromDom");

// extraction rule
ContentEntry[] contentEntries = new EntriesBuilder()
        .addEntries(new ContentEntry().setKey("FirstName"))
        .build();

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//td[contains(@id,'student_first_name')]")
        .setOnElements(contentEntries);
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract only the first character from all students ```First Name``` into a table with ```FirstName``` column.

#### _Action Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        {
            "key": "FirstName",
            "regularExpression": "^\\w{1}"
        }
    ]
}
```

#### _Rhino Literal_
```
extract from dom on {//td[contains(@id,'student_first_name')]}
    < column {FirstName} filter {^\w{1}}
```

#### _CSharp_
```csharp
// action rule
var actionRule = new ActionRule
{
    Action = PluginsList.ExtractFromDom
};

// extraction rule
var contentEntries = new[]
{
    new ContentEntry { Key = "FirstName", RegularExpression: "^\\w{1}" }
};
var extraction = new ExtractionRule
{
    OnRootElements = "//td[contains(@id,'student_first_name')]",
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromDom"
}

# extraction rule
content_entries = [
    {
        "key": "FirstName",
        "regularExpression": "^\\w{1}"
    }
]
extraction = {
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromDom"
}

// extraction rule
var contentEntries = [
    {
        key: "FirstName",
        regularExpression: "^\\w{1}"
    }
]
var extraction = {
    onRootElements: "//td[contains(@id,'student_first_name')]",
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromDom");

// extraction rule
ContentEntry[] contentEntries = new EntriesBuilder()
        .addEntries(
            new ContentEntry()
                    .setKey("FirstName")
                    .setRegularExpression("^\\w{1}"))
        .build();

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//td[contains(@id,'student_first_name')]")
        .setOnElements(contentEntries);
```

***

### _Example no. 3_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract the HTML ``id`` property, from all students ```First Name``` HTML element, into a table with ```FirstName``` column.

#### _Action Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        {
            "key": "FirstName",
            "onAttribute": "id"
        }
    ]
}
```

#### _Rhino Literal_
```
extract from dom on {//td[contains(@id,'student_first_name')]}
    < column {FirstName} from {id}
```

#### _CSharp_
```csharp
// action rule
var actionRule = new ActionRule
{
    Action = PluginsList.ExtractFromDom
};

// extraction rule
var contentEntries = new[]
{
    new ContentEntry { Key = "FirstName", OnAttribute: "id" }
}
var extraction = new ExtractionRule
{
    OnRootElements = "//td[contains(@id,'student_first_name')]",
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromDom"
}

# extraction rule
content_entries = [
    {
        "key": "FirstName",
        "onAttribute": "id"
    }
]
extraction = {
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromDom"
}

// extraction rule
var contentEntries = [
    {
        key: "FirstName",
        onAttribute: "id"
    }
]
var extraction = {
    onRootElements: "//td[contains(@id,'student_first_name')]",
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromDom");

// extraction rule
ContentEntry[] contentEntries = new EntriesBuilder()
        .addEntries(
            new ContentEntry()
                    .setKey("FirstName")
                    .setOnAttribute("id"))
        .build();

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//td[contains(@id,'student_first_name')]")
        .setOnElements(contentEntries);
```

***

### _Example no. 4_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` and ```Last Name``` into a table with ```FirstName``` and ```Last Name``` columns.

> :information_source: This approach caching the root element and performes a search in it, using relative ```XPath```. If you will use an absolute ```XPath```, the search will be performed on the page level and not within the cached element.

#### _Action Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "onRootElements": "//tbody/tr",
    "onElements": [
        {
            "key": "FirstName",
            "onElement": ".//td[contains(@id,'student_first_name')]"
        },
        {
            "key": "LastName",
            "onElement": ".//td[contains(@id,\"student_last_name\")]"
        }        
    ]
}
```

#### _Rhino Literal_
```
extract from dom on {//td[contains(@id,'student_first_name')]}
    < column {FirstName} take {.//td[contains(@id,'student_first_name')]}
    < column {LastName} take {.//td[contains(@id,\"student_last_name\")]}
```

#### _CSharp_
```csharp
// action rule
var actionRule = new ActionRule
{
    Action = PluginsList.ExtractFromDom
};

// extraction rule
var contentEntries = new[]
{
    new ContentEntry
    { 
        Key = "FirstName",
        OnElement: ".//td[contains(@id,'student_first_name')]"
    },
    new ContentEntry
    { 
        Key = "LastName",
        OnElement: ".//td[contains(@id,\"student_last_name\")]"
    }    
};
var extraction = new ExtractionRule
{
    OnRootElements = "//tbody/tr",
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromDom"
}

# extraction rule
content_entries = [
    {
        "key": "FirstName",
        "onElement": ".//td[contains(@id,'student_first_name')]"
    },
    {
        "key": "LastName",
        "onElement": ".//td[contains(@id,\"student_last_name\")]"
    } 
]
extraction = {
    "onRootElements": "//tbody/tr",
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromDom"
}

// extraction rule
var contentEntries = [
    {
        key: "FirstName",
        onElement: ".//td[contains(@id,'student_first_name')]"
    },
    {
        key: "LastName",
        onElement: ".//td[contains(@id,\"student_last_name\")]"
    } 
]
var extraction = {
    onRootElements: "//tbody/tr",
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromDom");

// extraction rule
ContentEntry[] contentEntries = new EntriesBuilder()
        .addEntries(
            new ContentEntry()
                    .setKey("FirstName")
                    .setOnElement(".//td[contains(@id,'student_first_name')]"),
            new ContentEntry()
                    .setKey("LastName")
                    .setOnElement(".//td[contains(@id,\"student_last_name\")]"))
        .build();

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//tbody/tr")
        .setOnElements(contentEntries);
```

### _Example no. 5_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract the ```HTML Markup``` of all students ```First Name``` HTML element, into a table with ```FirstName``` column.

#### _Action Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        {
            "key": "FirstName",
            "onAttribute": "html"
        }
    ]
}
```

#### _Rhino Literal_
```
extract from dom on {//td[contains(@id,'student_first_name')]}
    < column {FirstName} from {html}
```

#### _CSharp_
```csharp
// action rule
var actionRule = new ActionRule
{
    Action = PluginsList.ExtractFromDom
};

// extraction rule
var contentEntries = new[]
{
    new ContentEntry { Key = "FirstName", OnAttribute: "html" }
};
var extraction = new ExtractionRule
{
    OnRootElements = "//td[contains(@id,'student_first_name')]",
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromDom"
}

# extraction rule
content_entries = [
    {
        "key": "FirstName",
        "onAttribute": "html"
    }
]
extraction = {
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromDom"
}

// extraction rule
var contentEntries = [
    {
        key: "FirstName",
        onAttribute: "html"
    }
]
var extraction = {
    onRootElements: "//td[contains(@id,'student_first_name')]",
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromDom");

// extraction rule
ContentEntry[] contentEntries = new EntriesBuilder()
        .addEntries(
            new ContentEntry()
                    .setKey("FirstName")
                    .setOnAttribute("html"))
        .build();

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//td[contains(@id,'student_first_name')]")
        .setOnElements(contentEntries);
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` and ```First Course``` from ```Details``` page, into a table with ```FirstName``` column.

> This sample includes sub actions under ```ContentEntry``` and de-stale the elements once navigating back.

#### _Action Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "onRootElements": "//tbody/tr",
    "onElements": [
        {
            "key": "FirstName",
            "onElement": ".//td[contains(@id,'student_first_name')]",
            "actions": [
                {
                    "action": "Click",
                    "onElement": "Details",
                    "locator": "LinkText"
                }
            ]
        },
        {
            "key": "Course",
            "onElement": "//tbody/tr/td[1]",
            "actions": [
                {
                    "action": "NavigateBack"
                }
            ]            
        }
    ]
}
```

#### _Rhino Literal_
```
extract from dom on {//tbody/tr}
    < column {FirstName} take {ht.//td[contains(@id,'student_first_name')]ml}
          > click on {Details} using {link text}
    < column {Course} take {"//tbody/tr/td[1]"}
          > navigate back
```

#### _CSharp_
```csharp
// action rule
var actionRule = new ActionRule
{
    Action = PluginsList.ExtractFromDom
};

// extraction rule
var firstNameEntryActions = new[]
{
    new ActionRule
    {
        Action = PluginsList.Click,
        OnElement = "Details",
        Locator = LocatorsList.LinkText
    }
};
var firstNameEntry = new ContentEntry
{
    Key = "FirstName",
    OnElement = ".//td[contains(@id,'student_first_name')]",
    Actions = firstNameEntryActions
};

var courseEntryActions = new[]
{
    new ActionRule { Action = PluginsList.NavigateBack }
};
var courseEntry = new ContentEntry
{
    Key = "Course",
    OnElement = "//tbody/tr/td[1]",
    Actions = courseEntryActions
};

var extraction = new ExtractionRule
{
    OnRootElements = "//tbody/tr",
    OnElements = new[] { firstNameEntry, courseEntry }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromDom"
}

# extraction rule
first_name_entry_actions = [
    {
        "action": "Click",
        "onElement": "Details",
        "locator": "LinkText"
    }
]
first_name_entry = {
    "key": "FirstName",
    "onElement": ".//td[contains(@id,'student_first_name')]",
    "actions": first_name_entry_actions
}

course_entry_actions = [
    {
        "action": "NavigateBack"
    }
]
course_entry = {
    "key": "Course",
    "onElement": "//tbody/tr/td[1]",
    "actions": course_entry_actions
}

extraction = {
    "onRootElements": "//tbody/tr",
    "onElements": [
        first_name_entry,
        course_entry
    ]
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromDom"
}

// extraction rule
var firstNameEntryActions = [
    {
        action: "Click",
        onElement: "Details",
        locator: "LinkText"
    }
]
var firstNameEntry = {
    key: "FirstName",
    onElement: ".//td[contains(@id,'student_first_name')]",
    actions: firstNameEntryActions
}

var courseEntryActions = [
    {
        action: "NavigateBack"
    }
]
var courseEntry = {
    key: "Course",
    onElement: "//tbody/tr/td[1]",
    actions: courseEntryActions
}

var extraction = {
    onRootElements: "//tbody/tr",
    onElements: [
        firstNameEntry,
        courseEntry
    ]
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromDom");

// extraction rule
ActionRule firstNameEntryActions = new ActionRule()
        .setAction("Click").setOnElement("Details").setLocator("LinkText"));

ContentEntry firstNameEntry = new ContentEntry()
        .setKey("FirstName")
        .setOnElement(".//td[contains(@id,'student_first_name')]")
        .setActions(firstNameEntryActions);

ActionRule courseEntryActions = new ActionRule().setAction("NavigateBack");

ContentEntry courseEntry = new ContentEntry()
        .setKey("Course")
        .setOnElement("//tbody/tr/td[1]")
        .setActions(courseEntryActions);

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//tbody/tr")
        .setOnElements(firstNameEntry, courseEntry);
```

***

### _Example no. 6_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` and ```First Course``` from ```Details``` page, into a table with ```FirstName``` column.

> This sample includes sub actions under ```ContentEntry``` without de-stale the elements once switching back.

#### _Action Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "onRootElements": "//tbody/tr",
    "onElements": [
        {
            "key": "FirstName",
            "onElement": ".//td[contains(@id,'student_first_name')]"
            "actions": [
                {
                    "action": "GoToUrl",
                    "argument": "{{$ --blank}}",
                    "onAttribute": "href",
                    "onElement": "Details",
                    "locator": "LinkText"
                },
                {
                    "action": "SwitchToWindow",
                    "argument": "1"
                }
            ]
        },
        {
            "key": "Course",
            "onElement": "//tbody/tr/td[1]",
            "actions": [
                {
                    "action": "CloseAllChildWindows"
                }
            ]            
        }
    ]
}
```

#### _Rhino Literal_
```
extract from dom on {//tbody/tr}
    < column {FirstName} take {ht.//td[contains(@id,'student_first_name')]ml}
          > go to url {{$ --blank}} take {Details} using {link text} from {href}
          > switch to window {1}
    < column {Course} take {"//tbody/tr/td[1]"}
          > close all child windows
```

#### _CSharp_
```csharp
// action rule
var actionRule = new ActionRule
{
    Action = PluginsList.ExtractFromDom
};

// extraction rule
var firstNameEntryActions = new[]
{
    new ActionRule
    {
        Action = PluginsList.GoToUrl,
        Argument = "{{$ --blank}}",
        OnElement = "Details",
        OnAttribute = "href",
        Locator = LocatorsList.LinkText
    },
    new ActionRule
    {
        Action = PluginsList.SwitchToWindow,
        Argument = "1"
    }
};
var firstNameEntry = new ContentEntry
{
    Key = "FirstName",
    OnElement = ".//td[contains(@id,'student_first_name')]",
    Actions = firstNameEntryActions
};

var courseEntryActions = new[]
{
    new ActionRule { Action = PluginsList.CloseAllChildWindows }
};
var courseEntry = new ContentEntry
{
    Key = "Course",
    OnElement = "//tbody/tr/td[1]",
    Actions = courseEntryActions
};

var extraction = new ExtractionRule
{
    OnRootElements = "//tbody/tr",
    OnElements = new[] { firstNameEntry, courseEntry }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromDom"
}

# extraction rule
first_name_entry_actions = [
    {
        "action": "GoToUrl",
        "argument": "{{$ --blank}}",
        "onAttribute": "href",
        "onElement": "Details",
        "locator": "LinkText"
    },
    {
        "action": "SwitchToWindow",
        "argument": "1"
    }
]
first_name_entry = {
    "key": "FirstName",
    "onElement": ".//td[contains(@id,'student_first_name')]",
    "actions": first_name_entry_actions
}

course_entry_actions = [
    {
        "action": "CloseAllChildWindows"
    }
]
course_entry = {
    "key": "Course",
    "onElement": "//tbody/tr/td[1]",
    "actions": course_entry_actions
}

extraction = {
    "onRootElements": "//tbody/tr",
    "onElements": [
        first_name_entry,
        course_entry
    ]
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromDom"
}

// extraction rule
var firstNameEntryActions = [
    {
        action: "GoToUrl",
        argument: "{{$ --blank}}",
        onAttribute: "href",
        onElement: "Details",
        locator: "LinkText"
    },
    {
        action: "SwitchToWindow",
        argument: "1"
    }
]
var firstNameEntry = {
    key: "FirstName",
    onElement: ".//td[contains(@id,'student_first_name')]",
    actions: firstNameEntryActions
}

var courseEntryActions = [
    {
        action: "CloseAllChildWindows"
    }
]
var courseEntry = {
    key: "Course",
    onElement: "//tbody/tr/td[1]",
    actions: courseEntryActions
}

var extraction = {
    onRootElements: "//tbody/tr",
    onElements: [
        firstNameEntry,
        courseEntry
    ]
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromDom");

// extraction rule
ActionRule firstNameEntryActions1 = new ActionRule()
        .setAction("GoToUrl")
        .setArgument("{{$ --blank}}")
        .setOnElement("Details")
        .setOnAttribute("href")
        .setLocator("LinkText"));

ActionRule firstNameEntryActions2 = new ActionRule()
        .setAction("SwitchToWindow").setArgument("1"));   

ContentEntry firstNameEntry = new ContentEntry()
        .setKey("FirstName")
        .setOnElement(".//td[contains(@id,'student_first_name')]")
        .setActions(firstNameEntryActions1, firstNameEntryActions2);

ActionRule courseEntryActions = new ActionRule().setAction("CloseAllChildWindows");

ContentEntry courseEntry = new ContentEntry()
        .setKey("Course")
        .setOnElement("//tbody/tr/td[1]")
        .setActions(courseEntryActions);

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//tbody/tr")
        .setOnElements(firstNameEntry, courseEntry);
```