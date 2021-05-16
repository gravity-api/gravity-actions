## Content
* [Examples: _**SQL Server**_](#examples-SQL-Server)
* [Examples: _**CSV**_](#examples-CSV)
* [Examples: _**JSON**_](#examples-JSON)
* [Examples: _**XML**_](#examples-XML)
* [Examples: _**Rest API**_](#examples-Rest-API)

## Examples: _SQL Server_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and save it to SQL Server. The saving will be done when the extraction rule execution completed.

> If the database or repository does not exists, Gravity will create them, otherwise will append to them.

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "dataProvider": {
        "type": "SQLServer",
        "source": "Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True",
        "repository": "StudentsTable"
    }    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save {StudentsTable} on {Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True} using {SQLServer}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.SQLServer,
        Source = @"Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True",
        Repository = "StudentsTable"
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "SQLServer",
        "source": "Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True",
        "repository": "StudentsTable"
    },    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    action: "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "SQLServer",
        source: "Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True",
        repository: "StudentsTable"
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction(action: "ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("SQLServer")
            .setSource("Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True")
            .setRepository("StudentsTable"))
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and save it to SQL Server. The saving will be done when the content entry execution completed.

> If the database or repository does not exists, Gravity will create them, otherwise will append to them.

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "dataProvider": {
        "type": "SQLServer",
        "source": "Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True",
        "repository": "StudentsTable",
        "writePerEntry": true
    }    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save {{$ --repository:StudentsTable --write_per_entry}} on {Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True} using {SQLServer}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.SQLServer,
        Source = @"Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True",
        Repository = "StudentsTable",
        WritePerEntry = true
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "SQLServer",
        "source": "Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True",
        "repository": "StudentsTable",
        "writePerEntry": True
    },    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    action: "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "SQLServer",
        source: "Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True",
        repository: "StudentsTable",
        writePerEntry: true
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction(action: "ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("SQLServer")
            .setSource("Data Source=.\\SQLEXPRESS;Initial Catalog=FooDatabase;Integrated Security=True")
            .setRepository("StudentsTable"))
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```

## Examples: _CSV_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and save it a CSV file. The saving will be done when the extraction rule execution completed.

> If the file or folder(s) does not exists, Gravity will create them, otherwise will append to them.

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "dataProvider": {
        "type": "CSV",
        "source": "Data/StudentsTable.csv"
    }    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save on {Data/StudentsTable.csv} using {csv}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.CSV,
        Source = "Data/StudentsTable.csv"
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "CSV",
        "source": "Data/StudentsTable.csv"
    },    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    action: "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "CSV",
        source: "Data/StudentsTable.csv"
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction(action: "ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("CSV")
            .setSource("Data/StudentsTable.csv"))
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and save it to a CSV file. The saving will be done when the content entry execution completed.

> If the file or folder(s) does not exists, Gravity will create them, otherwise will append to them.

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "dataProvider": {
        "type": "CSV",
        "source": "Data/StudentsTable.csv",
        "writePerEntry": true
    }    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save {{$ --write_per_entry}} on {Data/StudentsTable.csv} using {csv}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.CSV,
        Source = "Data/StudentsTable.csv",
        WritePerEntry = true
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "CSV",
        "source": "Data/StudentsTable.csv",
        "writePerEntry": True
    },    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    action: "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "CSV",
        source: "Data/StudentsTable.csv",
        writePerEntry: true
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction(action: "ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("CSV")
            .setSource("Data/StudentsTable.csv"))
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```

## Examples: _JSON_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and save it a JSON file. The saving will be done when the extraction rule execution completed.

> If the file or folder(s) does not exists, Gravity will create them, otherwise will append to them.

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "dataProvider": {
        "type": "JSON",
        "source": "Data/StudentsTable.json"
    }    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save on {Data/StudentsTable.json} using {json}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.JSON,
        Source = "Data/StudentsTable.json"
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "JSON",
        "source": "Data/StudentsTable.json"
    },    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    action: "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "JSON",
        source: "Data/StudentsTable.json"
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction(action: "ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("JSON")
            .setSource("Data/StudentsTable.json"))
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and save it to a JSON file. The saving will be done when the content entry execution completed.

> If the file or folder(s) does not exists, Gravity will create them, otherwise will append to them.

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "dataProvider": {
        "type": "JSON",
        "source": "Data/StudentsTable.json",
        "writePerEntry": true
    }    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save {{$ --write_per_entry}} on {Data/StudentsTable.json} using {json}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.JSON,
        Source = "Data/StudentsTable.json",
        WritePerEntry = true
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "JSON",
        "source": "Data/StudentsTable.json",
        "writePerEntry": True
    },    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    action: "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "JSON",
        source: "Data/StudentsTable.json",
        writePerEntry: true
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction(action: "ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("JSON")
            .setSource("Data/StudentsTable.json"))
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```

## Examples: _XML_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and save it to XML file. The saving will be done when the extraction rule execution completed.

> If the file or folder(s) does not exists, Gravity will create them, otherwise will append to them.

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "dataProvider": {
        "type": "XML",
        "source": "Data/StudentsTable.xml"
    }    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save on {Data/StudentsTable.xml} using {xml}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.XML,
        Source = "Data/StudentsTable.xml"
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "XML",
        "source": "Data/StudentsTable.xml"
    },    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    action: "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "XML",
        source: "Data/StudentsTable.xml"
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction(action: "ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("XML")
            .setSource("Data/StudentsTable.xml"))
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and save it to XML file. The saving will be done when the content entry execution completed.

> If the file or folder(s) does not exists, Gravity will create them, otherwise will append to them.

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "dataProvider": {
        "type": "XML",
        "source": "Data/StudentsTable.xml",
        "writePerEntry": true
    }    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save {{$ --write_per_entry}} on {Data/StudentsTable.xml} using {xml}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.XML,
        Source = "Data/StudentsTable.xml",
        WritePerEntry = true
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "XML",
        "source": "Data/StudentsTable.xml",
        "writePerEntry": True
    },    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    action: "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "XML",
        source: "Data/StudentsTable.xml",
        writePerEntry: true
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction(action: "ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("XML")
            .setSource("Data/StudentsTable.xml"))
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```

## Examples: _Rest API_
### _Example no. 1_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and send it to a Rest API using HTTP post. The saving will be done when the extraction rule execution completed.

> Authentication will be basic using the following formats.
> 1. ```http://[user]:[password]@foo-bar.io/data```
> 2. ```https://[user]:[password]@foo-bar.io/data```
> 3. ```http://www.[user]:[password]@foo-bar.io/data```
> 4. ```https://www.[user]:[password]@foo-bar.io/data```
> 5. ```http://www.foo-bar.io/data``` - no authentication
> 6. ```https://www.foo-bar.io/data``` - no authentication

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromDom"
}

// extraction rule
{
    "dataProvider": {
        "type": "RestApi",
        "source": "http://www.@foo-bar.io/data"
    }    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save on {http://www.@foo-bar.io/data} using {RestApi}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.RestApi,
        Source = "http://www.@foo-bar.io/data"
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "RestApi",
        "source": "http://www.@foo-bar.io/data"
    },
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    "action": "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "RestApi",
        source: "http://www.@foo-bar.io/data"
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction("ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("RestApi")
            .setSource("http://www.@foo-bar.io/data")
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```

***

### _Example no. 2_
Can be tested on
* https://gravitymvctestapplication.azurewebsites.net/Student

Extract all students ```First Name``` into a table with ```FirstName``` column and send it to a Rest API using HTTP post. The saving will be done when the content entry execution completed.

> Authentication will be basic using the following formats.
> 1. ```http://[user]:[password]@foo-bar.io/data```
> 2. ```https://[user]:[password]@foo-bar.io/data```
> 3. ```http://www.[user]:[password]@foo-bar.io/data```
> 4. ```https://www.[user]:[password]@foo-bar.io/data```
> 5. ```http://www.foo-bar.io/data``` - no authentication
> 6. ```https://www.foo-bar.io/data``` - no authentication

#### _Action Rule, Extraction Rule (JSON)_
```js
// action rule
{
    "action": "ExtractFromSource",
}

// extraction rule
{
    "dataProvider": {
        "type": "RestApi",
        "source": "http://www.@foo-bar.io/data",
        "writePerEntity": true
    },
    "onRootElement": "//td[contains(@id,'student_first_name')]",
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
    < save {{$ --write_per_entry}} on {http://www.@foo-bar.io/data} using {RestApi}
```

#### _CSharp_
```csharp
// action rule - option no.1
var actionRule = new ActionRule
{
    Action = GravityPlugin.ExtractFromSource
};

// extraction rule - option no.1
var extractionRule = new ExtractionRule
{
    DataSource = new DataSource
    {
        Type = DataSourcesList.RestApi,
        Source = "http://www.@foo-bar.io/data",
        WritePerEntity = true
    },
    OnRootElement = "//td[contains(@id,'student_first_name')]",
    OnElements = new ContentEntry[]
    {
        new ContentEntry
        { 
            Key = "FirstName"
        }
    }
};
```

#### _Python_
```python
# action rule
action_rule = {
    "action": "ExtractFromSource"
}

# extraction rule
extraction_rule = {
    "dataProvider": {
        "type": "RestApi",
        "source": "http://www.@foo-bar.io/data",
        "writePerEntity": True
    },    
    "onRootElement": "//td[contains(@id,'student_first_name')]",
    "onElements": [
        { 
            "key": "FirstName" 
        }
    ]
}
```

#### _Java Script_
```js
// action rule
action_rule = {
    "action": "ExtractFromSource"
};

// extraction rule
extraction_rule = {
    dataSource: {
        type: "RestApi",
        source: "http://www.@foo-bar.io/data",
        writePerEntity: true
    },    
    onRootElement: "//td[contains(@id,'student_first_name')]",
    onElements: [
        { 
            key: "FirstName"
        }
    ]
};
```

#### _Java_
```java
// action rule
ActionRule actionRule = new ActionRule()
    .setAction("ExtractFromSource");

// extration rule
ExtractionRule extractionRule = new ExtractionRule()
    .setDataSource(new DataSource()
            .setType("RestApi")
            .setSource("http://www.@foo-bar.io/data")
            .setWritePerEntity(true)
    .setOnRootElements("//td[contains(@id,'student_first_name')]")
    .addElementToExtract(new ContentEntry("FirstName"));
```