## Examples
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column.

#### _Action Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromSource"
}

// extraction rule
{
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "pageSource": true,
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
    Action = GravityPlugins.ExtractFromSource
};

// extraction rule
var contentEntries = new[]
{
    new ContentEntry { Key = "FirstName" }
};
var extraction = new ExtractionRule
{
    OnRootElements = "//td[contains(@id,'student_first_name')]",
    PageSource = true,
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
content_entries = [
    {
        "key": "FirstName"
    }
]
extraction = {
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "pageSource": True,
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromSource"
}

// extraction rule
var contentEntries = [
    {
        key: "FirstName"
    }
]
var extraction = {
    onRootElements: "//td[contains(@id,'student_first_name')]",
    pageSource: true,
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromSource");

// extraction rule
ContentEntry[] contentEntries = new EntriesBuilder()
        .addEntries(new ContentEntry().setKey("FirstName"))
        .build();

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//td[contains(@id,'student_first_name')]")
        .setPageSource(true)
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
    "action": "ExtractFromSource"
}

// extraction rule
{
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "pageSource": true,
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
    Action = GravityPlugins.ExtractFromSource
};

// extraction rule
var contentEntries = new[]
{
    new ContentEntry { Key = "FirstName", RegularExpression: "^\\w{1}" }
};
var extraction = new ExtractionRule
{
    OnRootElements = "//td[contains(@id,'student_first_name')]",
    PageSource = true,
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
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
    "pageSource": True,
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromSource"
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
    pageSource: true,
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromSource");

// extraction rule
ContentEntry[] contentEntries = new EntriesBuilder()
        .addEntries(
            new ContentEntry()
                    .setKey("FirstName")
                    .setRegularExpression("^\\w{1}"))
        .build();

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//td[contains(@id,'student_first_name')]")
        .setPageSource(true)
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
    "action": "ExtractFromSource"
}

// extraction rule
{
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "pageSource": true,
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
    Action = GravityPlugins.ExtractFromSource
};

// extraction rule
var contentEntries = new[]
{
    new ContentEntry { Key = "FirstName", OnAttribute: "id" }
}
var extraction = new ExtractionRule
{
    OnRootElements = "//td[contains(@id,'student_first_name')]",
    PageSource = true,
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
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
    "pageSource": True,
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromSource"
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
    pageSource: true,
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromSource");

// extraction rule
ContentEntry[] contentEntries = new EntriesBuilder()
        .addEntries(
            new ContentEntry()
                    .setKey("FirstName")
                    .setOnAttribute("id"))
        .build();

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//td[contains(@id,'student_first_name')]")
        .setPageSource(true)
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
    "action": "ExtractFromSource"
}

// extraction rule
{
    "onRootElements": "//tbody/tr",
    "pageSource": true,
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
    Action = GravityPlugins.ExtractFromSource
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
    PageSource = true,
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
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
    "pageSource": True,
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromSource"
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
    pageSource: true,
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromSource");

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
        .setPageSource(true)
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
    "action": "ExtractFromSource"
}

// extraction rule
{
    "onRootElements": "//td[contains(@id,'student_first_name')]",
    "pageSource": true,
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
    Action = GravityPlugins.ExtractFromSource
};

// extraction rule
var contentEntries = new[]
{
    new ContentEntry { Key = "FirstName", OnAttribute: "html" }
};
var extraction = new ExtractionRule
{
    OnRootElements = "//td[contains(@id,'student_first_name')]",
    PageSource = true,
    OnElements = contentEntries
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
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
    "pageSource": True,
    "onElements": content_entries
}
```

#### _Java Script_
```js
// action rule
var actionRule = {
    action: "ExtractFromSource"
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
    pageSource: true,
    onElements: content_entries
}
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule().setAction("ExtractFromSource");

// extraction rule
ContentEntry[] contentEntries = new EntriesBuilder()
        .addEntries(
            new ContentEntry()
                    .setKey("FirstName")
                    .setOnAttribute("html"))
        .build();

ExtractionRule extraction = new ExtractionRule()
        .setOnRootElements("//td[contains(@id,'student_first_name')]")
        .setPageSource(true)
        .setOnElements(contentEntries);
```